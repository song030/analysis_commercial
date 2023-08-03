"""
psycopg2 이용해서 위경도가 확인되지 않은 주소와 아이디를 가져옴
"""

#잘못된 주소 가져오기
import psycopg2

conn = psycopg2.connect(
    host="10.10.20.117",
    database="db_test",
    user="postgres",
    password="1234")

c = conn.cursor()
query = """select "ADDRESS", "SELLING_AREA_ID" from "TB_SELLING_AREA" where "longitude" = 0"""
c.execute(query)
all_rows = c.fetchall()
result_list = list()
for row in all_rows:
    unavailable_address = row[0]
    selling_area_id = row[1]
    with open("old_address.txt", 'a', encoding='utf-8') as file:
        file.write(f"{selling_area_id}|{unavailable_address}\n")

