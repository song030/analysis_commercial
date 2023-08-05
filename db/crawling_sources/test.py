test_str = "1011|월세|근린상가|네일샵|경기도 수원시 장안구 송죽동 495.-17|725.62|1층|4000|160|7000|37.5040994|126.756611|https://www.sangga114.co.kr/sales-item/store/14967|0|1|0|4|0|3|0|0|1|25|0|18개|38개|2,758만원|2,061건|103,274명|3,985명|354만원|18,941명|316만원"

col_names = ['SELLING_AREA_ID', 'SELLING_TYPE', 'BUILDING_TYPE', 'CURRENT_STATE', 'ADDRESS', 'AREA_SIZE',
             'FLOOR_INFO', 'DEPOSIT', 'RATE_PER_MONTH', 'PREMIUM','LATITUDE', 'LONGITUDE', 'RELATION_LINK',
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

sample_dict = dict()
data_list = test_str.split("|")

for pair in zip(col_names, data_list):
    print(f"{pair[0]}: {pair[1]}")
    sample_dict.update({pair[0]: pair[1]})

print(sample_dict)
