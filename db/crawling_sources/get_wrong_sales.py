"""
psycopg2 이용해서 위경도가 확인되지 않은 발달골목 상권의 주소에 대해 정보(COMM_NAME, COMM_ID)를 가져옴
-> 이를 네이버 지도 크롤링을 통해 주소를 가져와서 새로 부여함
-> 새로운 주소를 바탕으로 위,경도 확인 (다올)
-> POSTGRESQL TB_SALES에 업데이트함
"""
import time
import traceback

import psycopg2
from selenium import webdriver
from selenium.webdriver import Keys
from selenium.webdriver.common.by import By


def main():
    get_crawling_from_map_naver()


def get_crawling_from_map_naver():
    driver = webdriver.Chrome()
    driver.implicitly_wait(3)
    driver.get("https://map.naver.com/v5/?c=15,0,0,0,dh")
    search_box_frame = driver.find_element(by=By.CLASS_NAME, value="search_box")
    search_box = search_box_frame.find_element(by=By.TAG_NAME, value="input")
    current_handle = driver.current_window_handle
    with open("_dummy_src/not_found_community.txt", "r", encoding="utf-8") as file:
        lines = file.read().split("\n")[:-1]
        for l in lines:
            try:
                fast_found = False
                driver.switch_to.window(current_handle)
                COMM_ID, COMM_NAME = l.split("|")
                print(f"search_address: {COMM_NAME} |", end="")
                COMM_NAME = COMM_NAME.replace("정류소"," 행정복지센터")
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
                        new_address = driver.find_elements(by=By.CLASS_NAME, value="place_section_content")[1].find_element(
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
                with open("_dummy_src/try_get_new_address.txt", "a", encoding="utf-8") as new_address_file:
                    new_address_file.write(f"{l}|{new_address}|\n")
                    print("get new address : ", new_address)


def update_new_address(comm_id, new_address, latitude, longitude):
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
    query = """select "COMM_ID", "COMM_NAME" from "TB_SALES" where "ROAD_ADDRESS" = 'None'"""
    c.execute(query)
    query = f"""update "TB_SALES" set
                "COMM_NAME" = '{new_address}',
                "latitude" = {latitude},
                "longitude" = {longitude}
                where "COMM_ID" = {comm_id}"""
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
        with open("_dummy_src/not_found_community.txt", 'a', encoding='utf-8') as file:
            file.write(f"{COMM_ID}|{COMM_NAME}\n")


if __name__ == '__main__':
    main()
