import time
import traceback

from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.remote.webelement import WebElement


def find_last_index(element: WebElement):
    """
    페이지 하단의 마지막 숫자를 리턴함
    :param element:
    :return:
    """
    btns = element.find_elements(by=By.TAG_NAME, value="a")
    last_num = 0
    for btn in btns:
        if btn.text.isdigit():
            last_num = int(btn.text)
    return last_num


driver = webdriver.Chrome()
driver.implicitly_wait(10)
driver.get("https://www.sangga114.co.kr/sales-item/store")
location_selector = driver.find_element(by=By.XPATH, value="//*[@id=\"searchForm\"]/fieldset/div/div[2]/div[1]/a/div")
location_selector.click()
geongido_select = driver.find_element(by=By.XPATH, value="//*[@id=\"area\"]/li[2]/a")
geongido_select.click()

time.sleep(2)
flag_to_continue = True  # 계속 여부
row_index = 0  # 첫페이지인지 여부

start_row = 0
start_page = 0

while flag_to_continue:
    # 선택 페이지가 시작 페이지 될 때까지 이동
    now_page_index = int(driver.find_element(by=By.CSS_SELECTOR, value="#page > div > strong").text)
    print("현재 페이지:", now_page_index)
    if now_page_index < start_page:
        row_index += len(driver.find_elements(by=By.TAG_NAME, value="tr"))
        control_btns = driver.find_elements(by=By.CLASS_NAME, value="paging-arrow")
        control_btns[-2].click()
        time.sleep(1)
        continue

    if row_index == 0:
        with open("crawling_on_market.txt", "a", encoding="utf-8") as file:
            file.write("매매/월세|상가타입|현업종|주소|면적|층수|매물가|링크\n")
    # 목록 리스트 조회
    table = driver.find_element(by=By.ID, value="salesList")
    tr_list = table.find_elements(by=By.TAG_NAME, value="tr")

    for idx, tr in enumerate(tr_list):
        row_index += 1
        if row_index < start_row:
            continue
        td_list = tr.find_elements(by=By.TAG_NAME, value="td")
        try:
            if len(td_list) == 6:  # 썸네일 사진 없는 경우
                try:
                    business_type, location_type = td_list[0].text.split("\n")
                except Exception:
                    business_type = "월세?"
                    location_type = td_list[0].text
                now_state = td_list[1].text
                location_address = td_list[2].text
                location_area, additional_location = td_list[3].text.replace("\n", "").split("㎡")
                location_area = location_area.replace("약", "")
                price = td_list[4].text
                link_element = tr.find_element(by=By.TAG_NAME, value="a")
                link = link_element.get_attribute('href')
                register_date = td_list[5].text
                with open("crawling_on_market.txt", "a", encoding="utf-8") as file:
                    a_row = '|'.join(
                        [business_type, location_type, now_state, location_address, location_area, additional_location,
                         price, link])
                    file.write(a_row + "\n")
                    print(f"{row_index} FILE APPENDED: ", a_row)
            elif len(td_list) == 7:  # 썸네일 사진 있는 경우
                try:
                    business_type, location_type = td_list[0].text.split("\n")
                except Exception:
                    business_type = "월세?"
                    location_type = td_list[0].text
                now_state = td_list[1].text
                location_address = td_list[2].text
                location_area, additional_location, = td_list[4].text.replace("\n", "").split("㎡")
                location_area = location_area.replace("약", "")
                price = td_list[5].text
                link_element = tr.find_element(by=By.TAG_NAME, value="a")
                link = link_element.get_attribute('href')
                register_date = td_list[6].text
                with open("crawling_on_market.txt", "a", encoding="utf-8") as file:
                    a_row = '|'.join(
                        [business_type, location_type, now_state, location_address, location_area, additional_location,
                         price, link])
                    file.write(a_row + "\n")
                    print(f"{row_index} FILE APPENDED: ", a_row)
        except BaseException as e:
            print(f"\n내용을 분해하는데 실패하였음 idx: {idx} len: {len(td_list)}")
            for temp_idx, ele in enumerate(td_list):
                temp_text = ele.text.replace('\n', ' ')
                print(f"{temp_idx}:{temp_text}", end="\t")
            flag_to_continue = False  # 크롤링 중단함
            print(traceback.print_exc())
            break

    if flag_to_continue is False:
        break

    # 페이지 확인
    buttons = driver.find_element(by=By.CLASS_NAME, value="pagination")
    control_btns = buttons.find_elements(by=By.CLASS_NAME, value="paging-arrow")
    if len(control_btns) == 2 and row_index > 30:  # 마지막 페이지
        print("크롤링 종료됨")
        break
    control_btns[-2].click()
    print(f"다음버튼 클릭함")
    time.sleep(2.5)

while True:
    pass
