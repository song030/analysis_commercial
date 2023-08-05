"""
psycopg2 이용해서 위경도가 확인되지 않은 발달골목 상권의 주소에 대해 정보(COMM_NAME, COMM_ID)를 가져옴
-> 이를 네이버 지도 크롤링을 통해 주소를 가져와서 새로 부여함
-> 새로운 주소를 바탕으로 위,경도 확인 (다올)
-> POSTGRESQL TB_SALES에 업데이트함
"""
import time
import traceback

import pandas as pd
import psycopg2
from selenium import webdriver
from selenium.webdriver import Keys
from selenium.webdriver.common.by import By


def main():
    config_pd_option()
    # get_excel_from_db()
    # read_new_paris_excel()
    # read_trimmed_paris_and_crawling()
    add_col_to_base()


def add_col_to_base():
    basic_read_file = pd.read_excel("_dummy_src/db_paris.xlsx", engine="openpyxl", index_col=0)
    result_join_file = pd.read_excel("_dummy_src/result_join.xlsx", engine="openpyxl", index_col=0)
    df_basic = pd.DataFrame(basic_read_file)
    df_joined = pd.DataFrame(result_join_file)

    df_basic['AREA_SIZE'] = 0
    df_basic['OPEN_DATE'] = ""
    df_basic['CLOSE_DATE'] = ""
    df_basic['IS_OPEN_STATE'] = ""
    result_list = list()
    for idx, row in df_joined.iterrows():
        if row['BASIC_IDX'] != -1:
            df_basic.loc[df_basic.index == row['BASIC_IDX'], "AREA_SIZE"] = row.AREA_SIZE
            df_basic.loc[df_basic.index == row['BASIC_IDX'], "OPEN_DATE"] = row.OPEN_DATE
            df_basic.loc[df_basic.index == row['BASIC_IDX'], "CLOSE_DATE"] = row.CLOSE_DATE
            df_basic.loc[df_basic.index == row['BASIC_IDX'], "IS_OPEN_STATE"] = row.IS_OPEN_STATE
        else:
            new_row = {
                "PARIS_NAME": row.PARIS_NAME,
                "PARIS_ADDRESS": row["ADDRESS"],
                "LATITUDE": row["LATITUDE"],
                "LONGITUDE": row["LONGITUDE"],
                "RIVAL_CNT": 0,
                "TOUR_CNT": 0,
                "HOSPITAL_CNT": 0,
                "STOP_CNT": 0,
                "LIVING_CNT": 0,
                "PARKING_CNT": 0,
                "STATION_CNT": 0,
                "SCHOOL_CNT": 0,
                "ACADEMY_CNT": 0,
                "CROSSWALK_CNT": 0,
                "AVG_SALES": 0,
                "AVG_MONTH_SALES": 0,
                "AVG_YEAR_SALES": 0,
                "AREA_SIZE": row.AREA_SIZE,
                "OPEN_DATE": row.OPEN_DATE,
                "CLOSE_DATE": row.CLOSE_DATE,
                "IS_OPEN_STATE": row.IS_OPEN_STATE
            }
            new_df = pd.DataFrame([new_row])
            result_list.append(new_df)

    for i in result_list:
        df_basic = pd.concat([df_basic, i], ignore_index=True)
    df_basic.to_excel("_dummy_src/final_paris.xlsx")


def get_excel_from_db():
    conn = psycopg2.connect(
        host="10.10.20.117",
        database="db_test",
        user="postgres",
        password="1234")
    c = conn.cursor()
    query = """select * from "TB_PARIS" """
    read_db = pd.read_sql(query, conn)
    df = pd.DataFrame(read_db)
    df.to_excel("_dummy_src/db_paris.xlsx")


def read_trimmed_paris_and_crawling():
    basic_read_file = pd.read_excel("_dummy_src/db_paris.xlsx", engine="openpyxl", index_col=0)
    other_read_file = pd.read_excel("_dummy_src/trimmed_paris.xlsx", engine="openpyxl", index_col=0)
    result_join_file = pd.read_excel("_dummy_src/result_join.xlsx", engine="openpyxl", index_col=0)
    df_basic = pd.DataFrame(basic_read_file)
    df_other = pd.DataFrame(other_read_file)
    df_joined = pd.DataFrame(result_join_file)
    basic_columns_name = ['PARIS_NAME', 'PARIS_ADDRESS', 'LATITUDE', 'LONGITUDE', 'PARIS_NO', 'RIVAL_CNT', 'TOUR_CNT',
                          'HOSPITAL_CNT', 'STOP_CNT', 'LIVING_CNT', 'PARKING_CNT', 'STATION_CNT', 'SCHOOL_CNT',
                          'ACADEMY_CNT', 'CROSSWALK_CNT', 'AVG_SALES', 'AVG_MONTH_SALES', 'AVG_YEAR_SALES']
    other_columns_name = ['OTHER_TABLE_PARIS_ID', 'PARIS_NAME', 'IS_OPEN_STATE', 'AREA_SIZE', 'OPEN_DATE', 'CLOSE_DATE']

    new_columns_name = ['BASIC_IDX', 'PARIS_NAME', 'IS_OPEN_STATE', 'AREA_SIZE', 'OPEN_DATE', 'CLOSE_DATE', 'ADDRESS',
                        "LATITUDE", "LONGITUDE"]

    # other에 새로운 아이디 부여
    result_df = pd.DataFrame(columns=new_columns_name)
    for other_idx, other_row in df_other.iterrows():
        has_same_paris = False
        for basic_idx, basic_row, in df_basic.iterrows():
            if other_row["PARIS_NAME"] == basic_row["PARIS_NAME"]:
                has_same_paris = True
                new_row = {"BASIC_IDX": basic_idx,
                           'PARIS_NAME': basic_row.PARIS_NAME,
                           "IS_OPEN_STATE": other_row.IS_OPEN_STATE,
                           "AREA_SIZE": other_row.AREA_SIZE,
                           "OPEN_DATE": other_row.OPEN_DATE,
                           "CLOSE_DATE": other_row.CLOSE_DATE,
                           "ADDRESS": other_row.ADDRESS,
                           "LATITUDE": other_row.LATITUDE,
                           "LONGITUDE": other_row.LONGITUDE}
                # print( f"{other_row['PARIS_NAME']}|{basic_row['PARIS_NAME']}", new_row)
                new_df = pd.DataFrame([new_row])
                result_df = pd.concat([result_df, new_df], ignore_index=True)
                break
        if has_same_paris is False:
            new_row = {"BASIC_IDX": -1,
                       'PARIS_NAME': other_row.PARIS_NAME,
                       "IS_OPEN_STATE": other_row.IS_OPEN_STATE,
                       "AREA_SIZE": other_row.AREA_SIZE,
                       "OPEN_DATE": other_row.OPEN_DATE,
                       "CLOSE_DATE": other_row.CLOSE_DATE,
                       "ADDRESS": other_row.ADDRESS,
                       "LATITUDE": other_row.LATITUDE,
                       "LONGITUDE": other_row.LONGITUDE}
            # print( f"{other_row['PARIS_NAME']}|{basic_row['PARIS_NAME']}", new_row)
            new_df = pd.DataFrame([new_row])
            result_df = pd.concat([result_df, new_df], ignore_index=True)
    result_df.to_excel("_dummy_src/result_join.xlsx")
    # # 인허가 날짜 추가
    # result_join_file


def read_new_paris_excel():
    read_file = pd.read_excel("_dummy_src/paris_excel.xlsx", engine="openpyxl")
    df = pd.DataFrame(read_file)
    cols_name = ['번호', '개방서비스명', '개방서비스아이디', '개방자치단체코드', '관리번호', '인허가일자', '인허가취소일자', '영업상태구분코드', '영업상태명', '상세영업상태코드',
                 '상세영업상태명', '폐업일자', '소재지전화', 'Unnamed: 13', '소재지면적', '소재지우편번호', '소재지전체주소', '도로명전체주소', '도로명우편번호', '사업장명',
                 '사업장명.1', 'Unnamed: 21', 'Unnamed: 22', 'Unnamed: 23', '최종수정시점', '데이터갱신구분', '데이터갱신일자', '업태구분명',
                 '좌표정보(X)', '좌표정보(Y)', '위생업태명', '남성종사자수', '여성종사자수', '영업장주변구분명', '급수시설구분명', '다중이용업소여부', '시설총규모']

    new_col_list = ['Unnamed: 22', '상세영업상태명', '시설총규모', '인허가일자', '폐업일자', '도로명전체주소', '좌표정보(X)', '좌표정보(Y)']
    df = df[new_col_list]
    df.reset_index(inplace=True)
    df['index'] = df['index'] + 1
    df.rename(columns={'index': "OTHER_TABLE_PARIS_ID", "Unnamed: 22": "PARIS_NAME", "상세영업상태명": "IS_OPEN_STATE",
                       "시설총규모": "AREA_SIZE", '인허가일자': 'OPEN_DATE', '폐업일자': 'CLOSE_DATE',
                       '도로명전체주소': "ADDRESS", '좌표정보(X)': "LATITUDE", '좌표정보(Y)': "LONGITUDE"},
              inplace=True)
    print(df)
    df.to_excel("_dummy_src/trimmed_paris.xlsx")


def config_pd_option():
    # pandas 칼럼 다 보이게 설정
    pd.set_option('display.max_columns', None)
    pd.set_option('display.width', 1000)


def get_selling_area_gps(rows):
    driver = webdriver.Chrome()
    driver.implicitly_wait(10)
    driver.get("https://address.dawul.co.kr/")
    result_list = list()
    for r in rows:
        address_id = r[0]
        address = r[1]
        latitude = "latitude"
        longitude = "longitude"
        search_bar = driver.find_element(by=By.ID, value="input_juso")
        search_bar.clear()
        search_bar.send_keys(address)
        search_btn = driver.find_element(by=By.CSS_SELECTOR, value="#btnSch")
        search_btn.click()
        time.sleep(0.5)
        try:
            new_address = driver.find_element(by=By.ID, value="insert_data_2").text
            # new_address 가 안터지면 x, y좌표도 있음
            pos = driver.find_element(by=By.CSS_SELECTOR, value="#insert_data_5").text
            x_str, y_str = pos.split(",")
            x_pos = x_str.split(":")[1].strip()
            y_pos = y_str.split(":")[1].strip()
            if "x좌표" in y_pos:  # 검색 안된 경우
                try:
                    address = address + 1
                    search_bar = driver.find_element(by=By.ID, value="input_juso")
                    search_bar.clear()
                    search_bar.send_keys(address)
                    search_btn = driver.find_element(by=By.CSS_SELECTOR, value="#btnSch")
                    search_btn.click()
                    new_address = driver.find_element(by=By.ID, value="insert_data_2").text
                    # new_address 가 안터지면 x, y좌표도 있음
                    pos = driver.find_element(by=By.CSS_SELECTOR, value="#insert_data_5").text
                    x_str, y_str = pos.split(",")
                    x_pos = x_str.split(":")[1].strip()
                    y_pos = y_str.split(":")[1].strip()
                except BaseException:
                    y_pos = 'latitude'
                    x_pos = 'longitude'

            with open("_dummy_src/selling_area_with_GPS.txt", 'a', encoding='utf-8') as file:
                file.write(f"{address_id}|{address}|{y_pos}|{x_pos}\n")
            result_list.append((address_id, address, y_pos, x_pos))
        except BaseException:
            # 검색이 안되는 주소
            traceback.print_exc()
    return result_list


def get_selling_area():
    conn = psycopg2.connect(
        host="10.10.20.117",
        database="db_test",
        user="postgres",
        password="1234")
    c = conn.cursor()
    query = """select "SELLING_AREA_ID", "ADDRESS" from "TB_SELLING_AREA" """
    c.execute(query)
    list_area = c.fetchall()
    print(list_area)
    for area in list_area:
        with open("_dummy_src/selling_area.txt", "a", encoding="utf-8") as file:
            file.write(f"{area[0]}|{area[1]}\n")


def get_crawling_from_daul_second(rows):
    driver = webdriver.Chrome()
    driver.implicitly_wait(10)
    driver.get("https://address.dawul.co.kr/")
    result_list = list()
    for r in rows:
        address_id = r[0]
        market_name = r[1]
        address = r[2]
        latitude = r[3]
        longitude = r[4]
        if latitude.isnumeric():
            with open("_dummy_src/pos2_get_new_market_address.txt", 'a', encoding='utf-8') as file:
                file.write(f"{address_id}|{market_name}|{address}|{latitude}|{longitude}\n")
            continue
        address = address + " 1"
        search_bar = driver.find_element(by=By.ID, value="input_juso")
        search_bar.clear()
        search_bar.send_keys(address)
        search_btn = driver.find_element(by=By.CSS_SELECTOR, value="#btnSch")
        search_btn.click()
        time.sleep(0.5)
        try:
            new_address = driver.find_element(by=By.ID, value="insert_data_2").text
            # new_address 가 안터지면 x, y좌표도 있음
            pos = driver.find_element(by=By.CSS_SELECTOR, value="#insert_data_5").text
            x_str, y_str = pos.split(",")
            x_pos = x_str.split(":")[1].strip()
            y_pos = y_str.split(":")[1].strip()
            if "x좌표" in y_pos:  # 검색 안된 경우
                y_pos = 'latitude'
                x_pos = 'longitude'
            with open("_dummy_src/pos2_get_new_market_address.txt", 'a', encoding='utf-8') as file:
                file.write(f"{address_id}|{market_name}|{address}|{y_pos}|{x_pos}\n")
            result_list.append((address_id, market_name, address, y_pos, x_pos))


        except BaseException:
            # 검색이 안되는 주소
            traceback.print_exc()


def get_crawling_from_daul(rows):
    driver = webdriver.Chrome()
    driver.implicitly_wait(10)
    driver.get("https://address.dawul.co.kr/")
    result_list = list()
    for r in rows:
        address_id = r[0]
        market_name = r[1]
        address = r[2]
        search_bar = driver.find_element(by=By.ID, value="input_juso")
        search_bar.clear()
        search_bar.send_keys(address)
        search_btn = driver.find_element(by=By.CSS_SELECTOR, value="#btnSch")
        search_btn.click()
        time.sleep(0.5)
        try:
            new_address = driver.find_element(by=By.ID, value="insert_data_2").text
            # new_address 가 안터지면 x, y좌표도 있음
            pos = driver.find_element(by=By.CSS_SELECTOR, value="#insert_data_5").text
            x_str, y_str = pos.split(",")
            x_pos = x_str.split(":")[1].strip()
            y_pos = y_str.split(":")[1].strip()
            if "x좌표" in y_pos:  # 검색 안된 경우
                y_pos = 'latitude'
                x_pos = 'longitude'
            with open("_dummy_src/pos_get_new_market_address.txt", 'a', encoding='utf-8') as file:
                file.write(f"{address_id}|{market_name}|{address}|{y_pos}|{x_pos}\n")
            result_list.append((address_id, market_name, address, y_pos, x_pos))


        except BaseException:
            # 검색이 안되는 주소
            traceback.print_exc()
    return result_list


def get_file_as_list(path):
    result_list = list()
    with open(path, "r", encoding="utf-8") as file:
        whole_lines = file.read().split("\n")[:-1]
        for row in whole_lines:
            words = row.split("|")
            selling_id = words[0]
            address = words[1]
            # latitude = words[3]
            # longitude = words[4]
            # result_list.append((address_id,market_name, address, latitude, longitude))
            result_list.append((selling_id, address))
    return result_list


def get_file_as_sale_list(path):
    result_list = list()
    with open(path, "r", encoding="utf-8") as file:
        whole_lines = file.read().split("\n")[:-1]
        for row in whole_lines:
            words = row.split("|")
            address_id = words[0]
            market_name = words[1]
            address = words[2]
            latitude = words[3]
            longitude = words[4]
            result_list.append((address_id, market_name, address, latitude, longitude))
    return result_list


def get_crawling_longitude_latitude(old_path, new_path):
    driver = webdriver.Chrome()
    driver.implicitly_wait(10)
    driver.get("https://address.dawul.co.kr/")

    new_altitude_and_longitude = list()
    with open(old_path, "r", encoding="utf-8") as file:
        count = 0
        whole_lines = file.read().split("\n")[:-1]
        for row in whole_lines:
            words = row.split("|")
            address_id = words[0]
            if len(words[-2]) == 0:
                address = words[1]
            else:
                address = words[-2]
            search_bar = driver.find_element(by=By.ID, value="input_juso")
            search_bar.clear()
            search_bar.send_keys(address)
            search_btn = driver.find_element(by=By.CSS_SELECTOR, value="#btnSch")
            search_btn.click()
            time.sleep(0.5)
            try:
                new_address = driver.find_element(by=By.ID, value="insert_data_2").text
                # new_address 가 안터지면 x, y좌표도 있음
                pos = driver.find_element(by=By.CSS_SELECTOR, value="#insert_data_5").text
                x_str, y_str = pos.split(",")
                x_pos = x_str.split(":")[1].strip()
                y_pos = y_str.split(":")[1].strip()
                if "x좌표" in y_pos:  # 검색 안된 경우
                    y_pos = 'latitude'
                    x_pos = 'longitude'
                with open(new_path, 'a', encoding='utf-8') as file:
                    insert_row_str = f"{address_id}|{address}|{y_pos}|{x_pos}\n"
                    file.write(insert_row_str)
                    print(insert_row_str, end="")
                time.sleep(0.5)

            except BaseException:
                # 검색이 안되는 주소
                traceback.print_exc()


def get_crawling_from_map_naver(old_path, save_path):
    driver = webdriver.Chrome()
    driver.implicitly_wait(3)
    driver.get("https://map.naver.com/v5/?c=15,0,0,0,dh")
    search_box_frame = driver.find_element(by=By.CLASS_NAME, value="search_box")
    search_box = search_box_frame.find_element(by=By.TAG_NAME, value="input")
    current_handle = driver.current_window_handle
    with open(old_path, "r", encoding="utf-8") as file:
        lines = file.read().split("\n")[:-1]
        for l in lines:

            try:
                fast_found = False
                driver.switch_to.window(current_handle)
                words = l.split("|")
                while len(words) != 2:
                    words.pop(len(words) - 1)
                COMM_ID, COMM_NAME = words
                print(f"search_address: {COMM_NAME} |", end="")
                COMM_NAME = COMM_NAME.replace("정류소", " 행정복지센터")
                search_box.clear()
                search_box.send_keys(COMM_NAME)
                search_box.send_keys(Keys.ENTER)
                time.sleep(2)
                try:
                    new_address = driver.find_element(by=By.CLASS_NAME, value="end_box").find_element(by=By.TAG_NAME,
                                                                                                      value="a").text
                    fast_found = True
                    raise "빨리 찾음"
                except Exception:
                    driver.switch_to.frame("searchIframe")
                    driver.find_element(by=By.CSS_SELECTOR, value="#_pcmap_list_scroll_container").find_element(
                        by=By.CSS_SELECTOR, value="ul > li:nth-child(1) > div > div > a:nth-child(1)").click()
                    time.sleep(0.5)
                    driver.switch_to.window(current_handle)
                    driver.switch_to.frame("entryIframe")
                    driver.find_element(by=By.CLASS_NAME, value="place_fixed_maintab").find_element(by=By.TAG_NAME,
                                                                                                    value="a").click()
                    time.sleep(0.5)
                    inner_box = driver.find_element(by=By.CLASS_NAME, value="place_section_content")
                    new_address = inner_box.find_element(by=By.TAG_NAME, value="a").text
                    if "알림" in new_address:
                        new_address = driver.find_elements(by=By.CLASS_NAME, value="place_section_content")[
                            1].find_element(
                            by=By.TAG_NAME, value="a").text
                # new_address_list = driver.find_elements(by=By.CSS_SELECTOR, value="div")
                # for address in new_address_list:
                #     if "경기" in address.text:
                #         new_address = address.text
                #         break
            except BaseException:
                try:
                    if fast_found is True:
                        raise "빨리 찾음 2단"
                    driver.switch_to.window(current_handle)
                    driver.switch_to.frame("entryIframe")
                    try:
                        driver.find_element(by=By.CLASS_NAME, value="place_fixed_maintab").find_element(by=By.TAG_NAME,
                                                                                                        value="a").click()
                        inner_box = driver.find_element(by=By.CLASS_NAME, value="place_section_content")
                        new_address = inner_box.find_element(by=By.TAG_NAME, value="a").text
                        if "알림" in new_address:
                            new_address = driver.find_elements(by=By.CLASS_NAME, value="place_section_content")[
                                1].find_element(by=By.TAG_NAME, value="a").text
                    except Exception:
                        inner_box = driver.find_element(by=By.CLASS_NAME, value="place_section_content")
                        new_address = inner_box.find_element(by=By.TAG_NAME, value="a").text
                        if "알림" in new_address:
                            new_address = driver.find_elements(by=By.CLASS_NAME, value="place_section_content")[
                                1].find_element(by=By.TAG_NAME, value="a").text

                except BaseException:
                    if fast_found is False:
                        new_address = ""
            finally:
                with open(save_path, "a", encoding="utf-8") as new_address_file:
                    new_address_file.write(f"{l}|{new_address}|\n")
                    print("get new address : ", new_address)


def update_new_address_TB_SALES(comm_id, new_address, latitude, longitude):
    """
    주소와 아이디를 넣어주면 변경해줌 (트랜잭션 scope 1건당)
    :param comm_id:
    :param new_address:
    :param latitude:
    :param longitude:
    :return:
    """
    conn = psycopg2.connect(
        host="10.10.20.117",
        database="db_test",
        user="postgres",
        password="1234")
    c = conn.cursor()
    if new_address is not None:
        query = f"""update "TB_SALES" set
                    "ROAD_ADDRESS" = '{new_address}',
                    "latitude" = {latitude},
                    "longitude" = {longitude}
                    where "COMM_ID" = {comm_id}"""
    else:
        query = f"""update "TB_SALES" set
                            "latitude" = {latitude},
                            "longitude" = {longitude}
                            where "COMM_ID" = {comm_id}"""
    c.execute(query)
    conn.commit()


def update_new_address_TB_SELLING_AREA(selling_area_id, new_address, latitude, longitude):
    """
    주소와 아이디를 넣어주면 변경해줌 (트랜잭션 scope 1건당)
    :param comm_id:
    :param new_address:
    :param latitude:
    :param longitude:
    :return:
    """
    conn = psycopg2.connect(
        host="10.10.20.117",
        database="db_test",
        user="postgres",
        password="1234")
    c = conn.cursor()
    if new_address is not None:
        query = f"""update "TB_SELLING_AREA" set
                    "ADDRESS" = '{new_address}',
                    "LATITUDE" = {latitude},
                    "LONGITUDE" = {longitude}
                    where "SELLING_AREA_ID" = {selling_area_id}"""
    else:
        query = f"""update "TB_SELLING_AREA" set
                            "LATITUDE" = {latitude},
                            "LONGITUDE" = {longitude}
                            where "SELLING_AREA_ID" = {selling_area_id}"""
    c.execute(query)
    conn.commit()


def get_wrong_address():
    """
    #postgres에서 잘못된 주소 가져오기
    :return:
    """
    conn = psycopg2.connect(
        host="10.10.20.117",
        database="db_test",
        user="postgres",
        password="1234")

    c = conn.cursor()
    query = """select "COMM_ID", "COMM_NAME" from "TB_SALES" where "ROAD_ADDRESS" = 'None'"""
    c.execute(query)
    all_rows = c.fetchall()
    result_list = list()
    for row in all_rows:
        COMM_ID = row[0]
        COMM_NAME = row[1]
        with open("../backup_dummy/not_found_community.txt", 'a', encoding='utf-8') as file:
            file.write(f"{COMM_ID}|{COMM_NAME}\n")


if __name__ == '__main__':
    main()
