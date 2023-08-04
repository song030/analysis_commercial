import time
import traceback

import psycopg2
from selenium import webdriver
from selenium.webdriver.common.by import By


# driver = webdriver.Chrome()
# driver.implicitly_wait(10)
# driver.get("https://address.dawul.co.kr/")
#
# new_altitude_and_longitude = list()
# with open("old_address.txt", "r", encoding="utf-8") as file:
#     count = 0
#     whole_lines = file.read().split("\n")[:-1]
#     for row in whole_lines:
#         address_id, address = row.split("|")
#         search_bar = driver.find_element(by=By.ID, value="input_juso")
#         search_bar.clear()
#         search_bar.send_keys(address)
#
#         search_btn = driver.find_element(by=By.CSS_SELECTOR, value="#btnSch")
#         search_btn.click()
#         time.sleep(0.5)
#         try:
#             new_address = driver.find_element(by=By.ID, value="insert_data_2").text
#             # new_address 가 안터지면 x, y좌표도 있음
#             pos = driver.find_element(by=By.CSS_SELECTOR, value="#insert_data_5").text
#             x_str, y_str = pos.split(",")
#             x_pos = x_str.split(":")[1].strip()
#             y_pos = y_str.split(":")[1].strip()
#
#             with open("new_address.txt", 'a', encoding='utf-8') as file:
#                 insert_row_str = f"{address_id}|{new_address}|{x_pos}|{y_pos}\n"
#                 file.write(insert_row_str)
#                 print(insert_row_str, end="")
#             time.sleep(0.5)
#
#         except BaseException:
#             # 검색이 안되는 주소
#             traceback.print_exc()

conn = psycopg2.connect(
    host="10.10.20.117",
    database="db_test",
    user="postgres",
    password="1234")

c = conn.cursor()

with open("new_address.txt", "r", encoding="utf-8") as file:
    count = 0
    whole_rine = file.read().split("\n")[:-1]
    for line in whole_rine:
        print(line)
        if "x좌표없음" in line or len(line.split('|')[2]) == 0:
            with open("new_address_refine.txt", "a", encoding="utf-8") as refine_file:
                refine_file.write(f"{line}\n")
        else:
            # continue
            count += 1
            address_id, address, x_pos, y_pos = line.split("|")
            query = f"""update "TB_SELLING_AREA" set
            "ADDRESS" = '{address}',
            "latitude" = {y_pos},
            "longitude" = {x_pos}
            where "SELLING_AREA_ID" = {address_id}"""
            c.execute(query)
    conn.commit()
    print(f"{count} rows were updated.")
