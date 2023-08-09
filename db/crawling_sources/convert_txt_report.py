import pandas as pd


def main():
    # convert_txt_file()
    read_txt_file_to_dataFrame()
    pass




def read_txt_file_to_dataFrame():
    column_names = [
        "INDEX",
        "PARIS_NAME",
        "PARIS_ADDRESS",
        "LATITUDE",
        "LONGITUDE",
        "PARIS_NO",
        "RIVAL_CNT",
        "TOUR_CNT",
        "HOSPITAL_CNT",
        "STOP_CNT",
        "LIVING_CNT",
        "PARKING_CNT",
        "STATION_CNT",
        "SCHOOL_CNT",
        "ACADEMY_CNT",
        "CROSSWALK_CNT",
        "AVG_QUARTER_SALES",
        "AVG_MONTH_SALES",
        "AVG_YEAR_SALES",
        "RIVAL_CNT_500",
        "TOUR_CNT_500",
        "HOSPITAL_CNT_500",
        "STOP_CNT_500",
        "LIVING_CNT_500",
        "PARKING_CNT_500",
        "STATION_CNT_500",
        "SCHOOL_CNT_500",
        "ACADEMY_CNT_500",
        "CROSSWALK_CNT_500",#추가된 Final Paris Table 칼럼 소개
        "AREA_SIZE", #매장 면적
        "OPEN_DATE", # 영업허가일
        "CLOSE_DATE", # 폐업이면 폐업시 닫은 날짜
        "IS_OPEN_STATE", # 운영중인지 여부
        "AVG_SALES", # 삭제 예정
        "RIVAL_COUNT_NEAR_500", # 반경 500미터 내 경쟁 업체 수
        "RIVAL_COUNT_NEAR_1000",# 반경 1000미터 내 경쟁 업체 수
        "MONTHLY_SHOP_REVENUE",  # 매달 가게 매상
        "MONTHLY_SHOP_SALE_TRANSACTION_COUNT", # 매달 가게 발생 거래 횟수
        "DAILY_FLOATING_POPULATION", # 일일 유동인구 평균
        "LIVING_WORKER_POPULATION", # 500미터 내 직장인 근로자 인구
        "LIVING_WORKER_AVG_REVENUE", # 500미터 내 직장인 근로지 평균 수입
        "LIVING_POPULATION", # 500미터 내 거주민 인구
        "LIVING_POPULATION_AVG_REVENUE", # 500미터 내 거주민 평균 수입
    ]

    lines = None
    with open("../backup_dummy/result_report.txt", "r", encoding="utf-8") as file:
        lines = file.read().split("\n")[:-1]
    assert isinstance(lines, list)

    new_df = pd.DataFrame(columns=column_names)

    for line in lines:
        words = line.split("|")
        temp_dict = dict()
        for i in range(len(words)):
            temp_dict.update({column_names[i]:words[i]})
        row_df = pd.DataFrame([temp_dict])
        new_df = pd.concat([new_df, row_df])

    new_df.to_excel("_dummy_src/RESULT_PARIS.xlsx", index_label=False, index=False)

def convert_txt_file():
    lines = None
    with open("../backup_dummy/search_analysis_report.txt", "r", encoding="utf-8") as file:
        lines = file.read().split("\n")[:-1]
    assert isinstance(lines, list)
    for idx, line in enumerate(lines):
        temp_list = list()
        temp_list.append(f"{idx + 1}")
        elements = line.split('|')
        for e in elements:
            if "'" in e:
                data = e.replace("'", "").split(",")[1][:-1].strip()
                temp_list.append(data)
            else:
                if "만원" in e:
                    e = e.replace("만원", "").replace(",","")
                    temp_word = int(e) * 10000
                    temp_word = str(temp_word)
                else:
                    temp_word = e.replace("개", "").replace(",", "").replace("명", "").replace("건", "").replace("만원",
                                                                                                              "")
                temp_list.append(temp_word)
        with open("../backup_dummy/result_report.txt", "a", encoding="utf-8") as file:
            new_line = "|".join(temp_list)
            file.write(f"{new_line}\n")


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

    return str(number)


if __name__ == '__main__':
    main()
