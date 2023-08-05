import time
import traceback

import psycopg2
from selenium import webdriver
from selenium.webdriver import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver import Chrome, ChromeOptions
import pandas as pd
from sqlalchemy import create_engine


def main():
    pd.set_option('display.max_columns', None)
    pd.set_option('display.width', 1000)
    integrate_infos()

def integrate_infos():
    whole_line = None
    with open('integerated_infos.txt', 'r', encoding='utf-8') as file:
        whole_line = file.read().split("\n")[:-1]
    assert isinstance(whole_line, list)

    col_names = ['SELLING_AREA_ID', 'SELLING_TYPE', 'BUILDING_TYPE', 'CURRENT_STATE', 'ADDRESS', 'AREA_SIZE',
                 'FLOOR_INFO', 'DEPOSIT', 'RATE_PER_MONTH', 'PREMIUM', 'LATITUDE', 'LONGITUDE', 'RELATION_LINK',
                 'SELLING_PRICE', 'RIVAL_CNT_300', 'TOUR_CNT_300', 'HOSPITAL_CNT_300', 'STOP_CNT_300', 'LIVING_CNT_300',
                 'PARKING_CNT_300', 'STATION_CNT_300', 'SCHOOL_CNT_300', 'ACADEMY_CNT_300', 'CROSSWALK_CNT_300',
                 "RIVAL_COUNT_NEAR_500",  # 반경 500미터 내 경쟁 업체 수
                 "RIVAL_COUNT_NEAR_1000",  # 반경 1000미터 내 경쟁 업체 수
                 "MONTHLY_SHOP_REVENUE",  # 매달 가게 매상
                 "MONTHLY_SHOP_SALE_TRANSACTION_COUNT",  # 매달 가게 발생 거래 횟수
                 "DAILY_FLOATING_POPULATION",  # 일일 유동인구 평균
                 "LIVING_WORKER_POPULATION",  # 500미터 내 직장인 근로자 인구
                 "LIVING_WORKER_AVG_REVENUE",  # 500미터 내 직장인 근로지 평균 수입
                 "LIVING_POPULATION",  # 500미터 내 거주민 인구
                 "LIVING_POPULATION_AVG_REVENUE"]

    result_df = pd.DataFrame(columns=col_names)
    for line in whole_line:
        sample_dict = dict()
        data_list = line.split("|")

        for pair in zip(col_names, data_list):
            if pair[0] == 'SELLING_AREA_ID':
                sample_dict.update({pair[0]: int(pair[1])})

            else:
                sample_dict.update({pair[0]: pair[1]})

        row_df = pd.DataFrame([sample_dict])

        # if result_df['SELLING_AREA_ID'].isin(row_df['SELLING_AREA_ID']):
        #     continue
        result_df = pd.concat([result_df, row_df])

    # result_df.drop_duplicates(keep="first")
    result_df.sort_values(by="SELLING_AREA_ID", inplace=True)
    result_df.drop_duplicates("SELLING_AREA_ID", keep="first", inplace=True)
    result_df.to_excel("Integrated_infos.xlsx", index=False, index_label=False)

def test_2(start_idx):
    read_file = pd.read_excel("infos.xlsx", engine="openpyxl", index_col=0)
    df = pd.DataFrame(read_file)
    for row in df.itertuples():
        if int(row[0]) < start_idx:
            continue
        searching_address = row[4]
        print(searching_address)


def test():
    excel_file = pd.read_excel("infos.xlsx")
    df = pd.DataFrame(excel_file)
    for row in df.itertuples(index=False):
        convert_row = list()
        for element in row:
            convert_row.append(str(element))
        print("|".join(convert_row))


def save_sale_area_excel():
    conn = psycopg2.connect(
        host="10.10.20.117",
        database="db_test",
        user="postgres",
        password="1234")
    engine_param = f'postgresql://postgres:1234@10.10.20.117:5432/db_test'
    engine = create_engine(engine_param)
    read_table = pd.read_sql("""select * from "TB_SELLING_AREA" """, engine)
    df = pd.DataFrame(read_table)
    df.drop("SELLING_AREA_ID", axis="columns", inplace=True)
    df.reset_index(inplace=True)
    df.rename(columns={"index": "SELLING_AREA_ID"}, inplace=True)
    df["SELLING_AREA_ID"] = df["SELLING_AREA_ID"] + 1
    df.to_excel("infos.xlsx", index=False, index_label=False)


def get_selling_area_infos(start_idx):
    # 화면 작으면 분석 안보임, 크기 키우기
    opts = ChromeOptions()
    opts.add_argument("--window-size=1300,900")
    # 창 띄우기
    driver = webdriver.Chrome(options=opts)
    driver.implicitly_wait(50)
    driver.get("https://sg.sbiz.or.kr/godo/index.sg")

    # 일주일 안보기
    driver.find_element(By.CSS_SELECTOR, "#help_guide > div > div.foot > div:nth-child(2) > label").click()
    driver.find_element(By.CSS_SELECTOR, "#help_guide > div > div.foot > a").click()

    # 로그인 버튼화면 이동
    page_login_btn = driver.find_element(By.CSS_SELECTOR,
                                         "#menu > div.lay.scrollbarView > div > div.head > div > ul > li > a > span")
    page_login_btn.click()
    time.sleep(1)

    # 로그인 정보 입력

    # song030s / q1w2e3r4!!
    # parisjoo / @password1234
    # mun0392 / qkrrhkdgus123!
    # 3gorgeous / rhkddlsro!!  (광인개!!)

    login_id = "mun0392"
    login_pw = "qkrrhkdgus123!"
    edit_line_id = driver.find_element(By.ID, "id")
    edit_line_pw = driver.find_element(By.ID, "pass")
    login_btn = driver.find_element(By.CSS_SELECTOR, "body > div > div.l_content > form > div > input")

    edit_line_id.send_keys(login_id)
    edit_line_pw.send_keys(login_pw)
    login_btn.click()

    container = driver.find_element(By.ID, "container")
    # 첫번째 팝업 끄기
    try:
        # WebDriverWait(driver, 10).until(EC.element_to_be_clickable((By.XPATH, "//*[@id='container'] and contains(.,'한달')]"))).click()
        x_btn = driver.find_element(By.CLASS_NAME, "option-wrap")
        x_btn.click()
    except:
        traceback.print_exc()
        while True:
            pass
    # 상세분석 버튼 클릭
    detail_btn = container.find_element(By.CSS_SELECTOR, "#toLink > a > h4")
    detail_btn.click()
    time.sleep(3)

    # 좌상단 음식 버튼 클릭
    container = driver.find_element(By.ID, "container")
    food_btn = container.find_element(By.CSS_SELECTOR, "#upjong > ul > li:nth-child(2)")
    food_btn.click()
    time.sleep(0.5)

    # 빵/도넛 클릭
    container = driver.find_element(By.ID, "container")
    bread_btn = container.find_element(By.CSS_SELECTOR,
                                       "#container > div:nth-child(17) > div > div.midd > div.midd > div.searchview.scrollbarView > div > ul > li:nth-child(9) > div > ul > li:nth-child(3) > label > span")
    bread_btn.click()
    time.sleep(0.5)

    # 확인 클릭
    container = driver.find_element(By.ID, "container")
    confirm_btn = container.find_element(By.CSS_SELECTOR, "#checkTypeConfirm > span")
    confirm_btn.click()
    time.sleep(3)

    read_file = pd.read_excel("infos.xlsx", engine="openpyxl", index_col=0)
    df = pd.DataFrame(read_file)
    for row in df.itertuples():
        if row[0] < start_idx:
            continue
        try:

            searching_address = row[4]
            # 검색창 클릭
            container = driver.find_element(By.ID, "container")
            search_box = container.find_element(By.CSS_SELECTOR, "#searchAddress")
            search_box.clear()
            search_box.send_keys(f"{searching_address}")
            search_box.send_keys(Keys.ENTER)
            time.sleep(1.5)

            # 검색 결과 최상단 선택
            searched_label = container.find_element(By.CSS_SELECTOR, "#adrsList > li > label > span")
            searched_label.click()

            # 상권 분석 버튼 클릭
            analysis_sector_btn = container.find_element(By.CSS_SELECTOR,
                                                         "#map > div:nth-child(1) > div > div:nth-child(6) > div:nth-child(2) > div > ul > li.child > label")
            analysis_sector_btn.click()

            radius_sector_btn = container.find_element(By.CSS_SELECTOR,
                                                       "#map > div:nth-child(1) > div > div:nth-child(6) > div:nth-child(2) > div > ul > li.child > div > ul > li:nth-child(2) > label")
            radius_sector_btn.click()

            # 500m 클릭
            distance_btn = container.find_element(By.CSS_SELECTOR,
                                                  "#auto_circle > div > div.midd > ul > li:nth-child(5) > label")
            distance_btn.click()
            time.sleep(0.5)

            confirm_btn = container.find_element(By.CSS_SELECTOR,
                                                 "#auto_circle > div > div.foot > a:nth-child(2) > span")
            confirm_btn.click()
            time.sleep(0.5)

            # 분석 버튼 클릭
            start_analysis = container.find_element(By.CSS_SELECTOR,
                                                    "#map > div:nth-child(1) > div > div:nth-child(6) > div:nth-child(3) > img")
            start_analysis.click()
            time.sleep(10)
            container = driver.find_element(By.ID, "page1")
            rival_count_near_500 = container.find_element(By.CSS_SELECTOR,
                                                          "#page1 > div.report-pop-layer > div.analysis-section.analysis-01 > div.analysis-content > div:nth-child(1) > div > div > span").text
            rival_count_near_1000 = container.find_element(By.CSS_SELECTOR,
                                                           "#page1 > div.report-pop-layer > div.analysis-section.analysis-01 > div.analysis-content > div:nth-child(3) > div > div > span").text
            monthly_shop_revenue = container.find_element(By.CSS_SELECTOR, "#salesSmryInfoCurSaleAmt").text
            monthly_shop_sale_transaction_count = container.find_element(By.CSS_SELECTOR,
                                                                         "#salesSmryInfoCurSaleCnt").text
            daily_floating_population = container.find_element(By.CSS_SELECTOR, "#flowPopSmryInfoFlowPop").text
            living_worker_population = container.find_element(By.CSS_SELECTOR, "#empAbodePopSmryInfoEmpPop").text
            living_worker_avg_revenue = container.find_element(By.CSS_SELECTOR, "#empAbodePopSmryInfoEmpAvgCo").text
            living_population = container.find_element(By.CSS_SELECTOR, "#empAbodePopSmryInfoAbodePop").text
            living_population_avg_revenue = container.find_element(By.CSS_SELECTOR,
                                                                   "#empAbodePopSmryInfoAbodeAvgCo").text

            driver.find_element(By.CSS_SELECTOR, "#bind > div.lay > a").click()
        except:
            rival_count_near_500 = "0"
            rival_count_near_1000 = "0"
            monthly_shop_revenue = "0"
            monthly_shop_sale_transaction_count = "0"
            daily_floating_population = "0"
            living_worker_population = "0"
            living_worker_avg_revenue = "0"
            living_population = "0"
            living_population_avg_revenue = "0"

        temp_list = list()
        for item in row:
            temp_list.append(str(item))
        temp_list.append(rival_count_near_500)
        temp_list.append(rival_count_near_1000)
        temp_list.append(monthly_shop_revenue)
        temp_list.append(monthly_shop_sale_transaction_count)
        temp_list.append(daily_floating_population)
        temp_list.append(living_worker_population)
        temp_list.append(living_worker_avg_revenue)
        temp_list.append(living_population)
        temp_list.append(living_population_avg_revenue)
        line = "|".join(temp_list)
        with open("infos_result.txt", "a", encoding="utf-8") as file:
            file.write(f"{line}\n")
            print(line)

    while True:
        pass


def get_site_and_login(start_idx):
    # 화면 작으면 분석 안보임, 크기 키우기
    opts = ChromeOptions()
    opts.add_argument("--window-size=1300,900")

    # 창 띄우기
    driver = webdriver.Chrome(options=opts)
    driver.implicitly_wait(20)
    driver.get("https://sg.sbiz.or.kr/godo/index.sg")

    # 일주일 안보기
    driver.find_element(By.CSS_SELECTOR, "#help_guide > div > div.foot > div:nth-child(2) > label").click()
    driver.find_element(By.CSS_SELECTOR, "#help_guide > div > div.foot > a").click()

    # 로그인 버튼화면 이동
    page_login_btn = driver.find_element(By.CSS_SELECTOR,
                                         "#menu > div.lay.scrollbarView > div > div.head > div > ul > li > a > span")
    page_login_btn.click()
    time.sleep(1)

    # 로그인 정보 입력

    # song030s / q1w2e3r4!!
    # parisjoo / @password1234
    # mun0392 / qkrrhkdgus123!
    # 3gorgeous / rhkddlsro!!  (광인개!!)

    login_id = "mun0392"
    login_pw = "qkrrhkdgus123!"
    edit_line_id = driver.find_element(By.ID, "id")
    edit_line_pw = driver.find_element(By.ID, "pass")
    login_btn = driver.find_element(By.CSS_SELECTOR, "body > div > div.l_content > form > div > input")

    edit_line_id.send_keys(login_id)
    edit_line_pw.send_keys(login_pw)
    login_btn.click()

    container = driver.find_element(By.ID, "container")
    # 첫번째 팝업 끄기
    try:
        # WebDriverWait(driver, 10).until(EC.element_to_be_clickable((By.XPATH, "//*[@id='container'] and contains(.,'한달')]"))).click()
        x_btn = driver.find_element(By.CLASS_NAME, "option-wrap")
        x_btn.click()
    except:
        traceback.print_exc()
        while True:
            pass
    # 상세분석 버튼 클릭
    detail_btn = container.find_element(By.CSS_SELECTOR, "#toLink > a > h4")
    detail_btn.click()
    time.sleep(3)

    # 좌상단 음식 버튼 클릭
    container = driver.find_element(By.ID, "container")
    food_btn = container.find_element(By.CSS_SELECTOR, "#upjong > ul > li:nth-child(2)")
    food_btn.click()
    time.sleep(0.5)

    # 빵/도넛 클릭
    container = driver.find_element(By.ID, "container")
    bread_btn = container.find_element(By.CSS_SELECTOR,
                                       "#container > div:nth-child(17) > div > div.midd > div.midd > div.searchview.scrollbarView > div > ul > li:nth-child(9) > div > ul > li:nth-child(3) > label > span")
    bread_btn.click()
    time.sleep(0.5)

    # 확인 클릭
    container = driver.find_element(By.ID, "container")
    confirm_btn = container.find_element(By.CSS_SELECTOR, "#checkTypeConfirm > span")
    confirm_btn.click()
    time.sleep(3)

    read_file = pd.read_excel("sale_area_info.xlsx", engine="openpyxl", index_col=0)
    df = pd.DataFrame(read_file)
    for idx, row in df.iterrows():
        if idx < start_idx:
            continue

        searching_address = row["PARIS_ADDRESS"]
        # 검색창 클릭
        container = driver.find_element(By.ID, "container")
        search_box = container.find_element(By.CSS_SELECTOR, "#searchAddress")
        search_box.clear()
        search_box.send_keys(f"{searching_address}")
        search_box.send_keys(Keys.ENTER)
        time.sleep(1.5)

        # 검색 결과 최상단 선택
        searched_label = container.find_element(By.CSS_SELECTOR, "#adrsList > li > label > span")
        searched_label.click()

        # 상권 분석 버튼 클릭
        analysis_sector_btn = container.find_element(By.CSS_SELECTOR,
                                                     "#map > div:nth-child(1) > div > div:nth-child(6) > div:nth-child(2) > div > ul > li.child > label")
        analysis_sector_btn.click()

        radius_sector_btn = container.find_element(By.CSS_SELECTOR,
                                                   "#map > div:nth-child(1) > div > div:nth-child(6) > div:nth-child(2) > div > ul > li.child > div > ul > li:nth-child(2) > label")
        radius_sector_btn.click()

        # 500m 클릭
        distance_btn = container.find_element(By.CSS_SELECTOR,
                                              "#auto_circle > div > div.midd > ul > li:nth-child(5) > label")
        distance_btn.click()
        time.sleep(0.5)

        confirm_btn = container.find_element(By.CSS_SELECTOR, "#auto_circle > div > div.foot > a:nth-child(2) > span")
        confirm_btn.click()
        time.sleep(0.5)

        # 분석 버튼 클릭
        start_analysis = container.find_element(By.CSS_SELECTOR,
                                                "#map > div:nth-child(1) > div > div:nth-child(6) > div:nth-child(3) > img")
        start_analysis.click()
        time.sleep(10)
        container = driver.find_element(By.ID, "page1")
        rival_count_near_500 = container.find_element(By.CSS_SELECTOR,
                                                      "#page1 > div.report-pop-layer > div.analysis-section.analysis-01 > div.analysis-content > div:nth-child(1) > div > div > span").text
        rival_count_near_1000 = container.find_element(By.CSS_SELECTOR,
                                                       "#page1 > div.report-pop-layer > div.analysis-section.analysis-01 > div.analysis-content > div:nth-child(3) > div > div > span").text
        monthly_shop_revenue = container.find_element(By.CSS_SELECTOR, "#salesSmryInfoCurSaleAmt").text
        monthly_shop_sale_transaction_count = container.find_element(By.CSS_SELECTOR, "#salesSmryInfoCurSaleCnt").text
        daily_floating_population = container.find_element(By.CSS_SELECTOR, "#flowPopSmryInfoFlowPop").text
        living_worker_population = container.find_element(By.CSS_SELECTOR, "#empAbodePopSmryInfoEmpPop").text
        living_worker_avg_revenue = container.find_element(By.CSS_SELECTOR, "#empAbodePopSmryInfoEmpAvgCo").text
        living_population = container.find_element(By.CSS_SELECTOR, "#empAbodePopSmryInfoAbodePop").text
        living_population_avg_revenue = container.find_element(By.CSS_SELECTOR, "#empAbodePopSmryInfoAbodeAvgCo").text

        print('rival_count_near_500: ', rival_count_near_500)
        print('rival_count_near_1000: ', rival_count_near_1000)
        print('monthly_shop_revenue: ', monthly_shop_revenue)
        print('monthly_shop_sale_transaction_count: ', monthly_shop_sale_transaction_count)
        print('daily_floating_population: ', daily_floating_population)
        print('living_worker_population: ', living_worker_population)
        print('living_worker_avg_revenue: ', living_worker_avg_revenue)
        print('living_population: ', living_population)
        print('living_population_avg_revenue: ', living_population_avg_revenue)

        driver.find_element(By.CSS_SELECTOR, "#bind > div.lay > a").click()

        temp_list = list()
        for item in row.items():
            temp_list.append(f"{item}")
        temp_list.append(rival_count_near_500)
        temp_list.append(rival_count_near_1000)
        temp_list.append(monthly_shop_revenue)
        temp_list.append(monthly_shop_sale_transaction_count)
        temp_list.append(daily_floating_population)
        temp_list.append(living_worker_population)
        temp_list.append(living_worker_avg_revenue)
        temp_list.append(living_population)
        temp_list.append(living_population_avg_revenue)
        line = "|".join(temp_list)
        with open("search_analysis_report.txt", "a", encoding="utf-8") as file:
            file.write(f"{line}\n")

    while True:
        pass


if __name__ == '__main__':
    main()
