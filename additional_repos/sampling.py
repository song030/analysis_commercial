"""
selenium 이용해서 매물 정보 파싱 + 정제 로직
"""

import traceback

from selenium import webdriver
from selenium.webdriver.common.by import By

result_list = list()

driver = webdriver.Chrome()
driver.implicitly_wait(10)
accumulated_index = -1
with open("additional_crawling_price.txt", 'r', encoding='utf-8') as file:
    total_row_count = len(file.read().split('\n'))
    accumulated_index = total_row_count

if accumulated_index == -1:
    raise "파일 실행 불가"

with open("crawling_on_market.txt", 'r', encoding='utf-8') as file:
    row_index = -1
    while True:
        row_index+= 1
        if row_index < accumulated_index:
            file.readline()
            continue
        try:
            a_row = file.readline().replace("\n","")
        except BaseException as e:
            print("변환 종료됨")
            print(traceback.print_exc())
            break
        words = a_row.split('|')
        temp_list = list()
        link = words[-1]
        driver.get(link)
        insurance_money = driver.find_element(by=By.CSS_SELECTOR,
                                              value="body > main > section > div.container.clearfix > div > form > fieldset > div > div.sales-detail-info.clearfix > div.sales-detail-info-right.dealing-detail-info-right > table > tbody > tr:nth-child(7) > td:nth-child(2)").text
        rate_by_month = driver.find_element(by=By.CSS_SELECTOR,
                                            value="body > main > section > div.container.clearfix > div > form > fieldset > div > div.sales-detail-info.clearfix > div.sales-detail-info-right.dealing-detail-info-right > table > tbody > tr:nth-child(7) > td:nth-child(4)").text
        premium = driver.find_element(by=By.CSS_SELECTOR,
                                      value="body > main > section > div.container.clearfix > div > form > fieldset > div > div.sales-detail-info.clearfix > div.sales-detail-info-right.dealing-detail-info-right > table > tbody > tr:nth-child(8) > td:nth-child(2)").text
        temp_list.extend(words)
        if not insurance_money.isdigit():
            temp_list.append(f"협의후결정")
        else:
            temp_list.append(f"{insurance_money}") # 보증금

        if not rate_by_month.isdigit():
            temp_list.append(f"협의후결정")
        else:
            temp_list.append(f"{rate_by_month}")  # 월세
        if not premium.isdigit():
            temp_list.append(f"협의후결정")
        else:
            temp_list.append(f"{premium}")  # 권리금
        result_row = "|".join(temp_list)
        result_list.append(result_row)
        print(f"{row_index} FILE APPENDED: {result_row}")

with open("additional_crawling_price.txt", 'a', encoding='utf-8') as file:
    result_str = "\n".join(result_list)
    file.write(f"\n{result_str}")