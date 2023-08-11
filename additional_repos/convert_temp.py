# #temp -> additional_crawling_price.txt
# with open("temp.txt", 'r', encoding='utf-8') as file:
#     whole_lines = file.read().split("\n")
#     for line in whole_lines:
#         head, data = line.split(" FILE APPENDED: ")
#         row_index = int(head)
#         with open("additional_crawling_price.txt", 'a', encoding='utf-8') as inner_file:
#             inner_file.write(f"{row_index}|{data}\n")
import psycopg2


def korean_to_number(korean_str):
    num_map = {
        '일': 1, '이': 2, '삼': 3, '사': 4, '오': 5,
        '육': 6, '칠': 7, '팔': 8, '구': 9, '십': 10,
        '백': 100, '천': 1000, '만': 10000, '억': 100000000
    }

    number = 0
    partial_sum = 0

    for word in korean_str.split():
        if word in num_map:
            if num_map[word] >= 10000:
                number += partial_sum * num_map[word]
                partial_sum = 0
            else:
                partial_sum += num_map[word]

    number += partial_sum

    return number


def price_preprocessing(price_str: str) -> str:
    result_str = price_str.replace(",", "").replace("협의후결정", "-1")
    if not result_str.isdigit():
        result_str = korean_to_number(result_str)
    return result_str


conn = psycopg2.connect(
    host="10.10.20.117",
    database="db_test",
    user="postgres",
    password="1234")

c = conn.cursor()

with open("additional_crawling_price.txt", 'r', encoding='utf-8') as file:
    whole_lines = file.read().split("\n")
    for line in whole_lines[:-1]:
        words = line.split("|")
        temp_dict = dict()
        SELLING_AREA_ID = words[0]
        SELLING_TYPE = words[1]
        BUILDING_TYPE = words[2]
        CURRENT_STATE = words[3]
        ADDRESS = words[4]
        AREA_SIZE = words[5]
        FLOOR_INFO = words[6]
        SELLING_PRICE = words[7]
        RELATION_LINK = words[8]
        DEPOSIT = words[9]
        RATE_PER_MONTH = words[10]
        PREMIUM = words[11]

        # 전처리
        SELLING_PRICE = price_preprocessing(SELLING_PRICE)
        DEPOSIT = DEPOSIT.replace(",", "").replace("협의후결정", "-1")
        RATE_PER_MONTH = RATE_PER_MONTH.replace(",", "").replace("협의후결정", "-1")
        PREMIUM = PREMIUM.replace(",", "").replace("협의후결정", "-1")

        if "경기" in ADDRESS and "경기도" not in ADDRESS:
            ADDRESS = ADDRESS.replace("경기", "경기도")

        # temp_dict.update({"SELLING_AREA_ID": int(SELLING_AREA_ID)})
        temp_dict.update({"SELLING_TYPE": SELLING_TYPE})
        temp_dict.update({"BUILDING_TYPE": BUILDING_TYPE})
        temp_dict.update({"CURRENT_STATE": CURRENT_STATE})
        temp_dict.update({"ADDRESS": ADDRESS})
        temp_dict.update({"AREA_SIZE": float(AREA_SIZE)})
        temp_dict.update({"FLOOR_INFO": FLOOR_INFO})
        temp_dict.update({"RELATION_LINK": RELATION_LINK})
        temp_dict.update({"SELLING_PRICE": int(SELLING_PRICE)})
        temp_dict.update({"DEPOSIT": int(DEPOSIT)})
        temp_dict.update({"RATE_PER_MONTH": int(RATE_PER_MONTH)})
        temp_dict.update({"PREMIUM": int(PREMIUM)})

        # INSERT용
        # column_names = '","'.join(temp_dict.keys())
        # temp_list = list()
        # for i in temp_dict.values():
        #     if isinstance(i, int) or isinstance(i, float):
        #         temp_list.append(f"{i}")
        #     else:
        #         temp_list.append(f"'{i}'")
        # values = ",".join(temp_list)

        # UPDATE용
        # query_for_update = list()
        # for k,v in zip(temp_dict.keys(), temp_dict.values()):
        #     query_for_update.append(f"{k}={v}")

        c.execute(f"""update "TB_SELLING_AREA"
        set "ADDRESS"='{ADDRESS}' where "SELLING_AREA_ID"={SELLING_AREA_ID}""")

    conn.commit()
