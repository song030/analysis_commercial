from analysis.connect_db import Databases
import pandas as pd

class MakeParisDatasets:
    def __init__(self):
        db = Databases()
        table_name = '"TB_PARIS"'
        read_file = pd.read_sql(f'select * from {table_name}', db.engine)
        self.data_df = pd.DataFrame(read_file)
        self.id_list = self.data_df.PARIS_ID.to_list()


    def get_dataset(self):
        RIVAL_500 = self.data_df.RIVAL_COUNT_NEAR_500.to_list()
        RIVAL_1000 = self.data_df.RIVAL_COUNT_NEAR_1000.to_list()
        LIVING_500 = self.data_df.LIVING_COUNT_NEAR_500.to_list()
        LIVING_1000 = self.data_df.LIVING_COUNT_NEAR_1000.to_list()
        SCHOOL_500 = self.data_df.SCHOOL_COUNT_NEAR_500.to_list()
        SCHOOL_1000 = self.data_df.SCHOOL_COUNT_NEAR_1000.to_list()
        ACADEMY_500 = self.data_df.ACADEMY_COUNT_NEAR_500.to_list()
        ACADEMY_1000 = self.data_df.ACADEMY_COUNT_NEAR_1000.to_list()
        HOSPITAL_500 = self.data_df.HOSPITAL_COUNT_NEAR_500.to_list()
        HOSPITAL_1000 = self.data_df.HOSPITAL_COUNT_NEAR_1000.to_list()
        STATION_500 = self.data_df.STATION_COUNT_NEAR_500.to_list()
        STATION_1000 = self.data_df.STATION_COUNT_NEAR_1000.to_list()
        STOP_500 = self.data_df.STOP_COUNT_NEAR_500.to_list()
        STOP_1000 = self.data_df.STOP_COUNT_NEAR_1000.to_list()
        PARKING_500 = self.data_df.PARKING_COUNT_NEAR_500.to_list()
        PARKING_1000 = self.data_df.PARKING_COUNT_NEAR_1000.to_list()
        TOUR_500 = self.data_df.ATTRACTION_COUNT_NEAR_500.to_list()
        TOUR_1000 = self.data_df.ATTRACTION_COUNT_NEAR_1000.to_list()
        CROSSWALK_500 = self.data_df.CROSSWALK_COUNT_NEAR_500.to_list()
        CROSSWALK_1000 = self.data_df.CROSSWALK_COUNT_NEAR_1000.to_list()
        LEISURE_500 = self.data_df.LEISURE_COUNT_NEAR_500.to_list()
        LEISURE_1000 = self.data_df.LEISURE_COUNT_NEAR_1000.to_list()
        MARKET_500 = self.data_df.MARKET_COUNT_NEAR_500.to_list()
        MARKET_1000 = self.data_df.MARKET_COUNT_NEAR_1000.to_list()
        MART_500 = self.data_df.MART_COUNT_NEAR_500.to_list()
        MART_1000 = self.data_df.MART_COUNT_NEAR_1000.to_list()
        DAILY_FLOATING_POPULATION = self.data_df.DAILY_FLOATING_POPULATION.to_list()
        LIVING_WORKER_POPULATION = self.data_df.LIVING_WORKER_POPULATION.to_list()
        LIVING_WORKER_AVG_REVENUE = self.data_df.LIVING_WORKER_AVG_REVENUE.to_list()
        LIVING_POPULATION = self.data_df.LIVING_POPULATION.to_list()
        LIVING_POPULATION_AVG_REVENUE = self.data_df.LIVING_POPULATION_AVG_REVENUE.to_list()
        MONTHLY_SHOP_SALE_TRANSACTION_COUNT = self.data_df.MONTHLY_SHOP_SALE_TRANSACTION_COUNT.to_list()
        MONTHLY_SHOP_REVENUE = self.data_df.MONTHLY_SHOP_REVENUE.to_list()
        AREA_SIZE = self.data_df.AREA_SIZE.to_list()

        # 데이터셋 생성
        datasets = {
            '경쟁업체_500': RIVAL_500,
            '경쟁업체_1000': RIVAL_1000,
            '주거단지_500': LIVING_500,
            '주거단지_1000': LIVING_1000,
            '학교_500': SCHOOL_500,
            '학교_1000': SCHOOL_1000,
            '학원_500': ACADEMY_500,
            '학원_1000': ACADEMY_1000,
            '병원_500': HOSPITAL_500,
            '병원_1000': HOSPITAL_1000,
            '지하철역_500': STATION_500,
            '지하철역_1000': STATION_1000,
            '버스정거장_500': STOP_500,
            '버스정거장_1000': STOP_1000,
            '주차장_500': PARKING_500,
            '주차장_1000': PARKING_1000,
            '관광지_500': TOUR_500,
            '관광지_1000': TOUR_1000,
            '횡단보도_500': CROSSWALK_500,
            '횡단보도_1000': CROSSWALK_1000,
            '여가시설_500': LEISURE_500,
            '여가시설_1000': LEISURE_1000,
            '발달상권_500': MARKET_500,
            '발달상권_1000': MARKET_1000,
            '대형점포_500': MART_500,
            '대형점포_1000': MART_1000,
            '일일유동인구': DAILY_FLOATING_POPULATION,
            '직장인인구': LIVING_WORKER_POPULATION,
            '거주인구': LIVING_POPULATION,
            '거주직장인평균소득': LIVING_WORKER_AVG_REVENUE,
            '거주인구평균소득': LIVING_POPULATION_AVG_REVENUE,
            '거래건수': MONTHLY_SHOP_SALE_TRANSACTION_COUNT,
            '월매출': MONTHLY_SHOP_REVENUE,
            '면적': AREA_SIZE,
        }

        return datasets


class MakeSellingDatasets:
    def __init__(self):
        db = Databases()
        table_name = '"TB_SELLING_AREA"'
        read_file = pd.read_sql(f'select * from {table_name}', db.engine)
        self.data_df = pd.DataFrame(read_file)
        self.id_list = self.data_df.SELLING_AREA_ID.to_list()

    def get_dataset(self):
        RIVAL_500 = self.data_df.RIVAL_COUNT_NEAR_500.to_list()
        RIVAL_1000 = self.data_df.RIVAL_COUNT_NEAR_1000.to_list()
        LIVING_500 = self.data_df.LIVING_COUNT_NEAR_500.to_list()
        LIVING_1000 = self.data_df.LIVING_COUNT_NEAR_1000.to_list()
        SCHOOL_500 = self.data_df.SCHOOL_COUNT_NEAR_500.to_list()
        SCHOOL_1000 = self.data_df.SCHOOL_COUNT_NEAR_1000.to_list()
        ACADEMY_500 = self.data_df.ACADEMY_COUNT_NEAR_500.to_list()
        ACADEMY_1000 = self.data_df.ACADEMY_COUNT_NEAR_1000.to_list()
        HOSPITAL_500 = self.data_df.HOSPITAL_COUNT_NEAR_500.to_list()
        HOSPITAL_1000 = self.data_df.HOSPITAL_COUNT_NEAR_1000.to_list()
        STATION_500 = self.data_df.STATION_COUNT_NEAR_500.to_list()
        STATION_1000 = self.data_df.STATION_COUNT_NEAR_1000.to_list()
        STOP_500 = self.data_df.STOP_COUNT_NEAR_500.to_list()
        STOP_1000 = self.data_df.STOP_COUNT_NEAR_1000.to_list()
        PARKING_500 = self.data_df.PARKING_COUNT_NEAR_500.to_list()
        PARKING_1000 = self.data_df.PARKING_COUNT_NEAR_1000.to_list()
        TOUR_500 = self.data_df.ATTRACTION_COUNT_NEAR_500.to_list()
        TOUR_1000 = self.data_df.ATTRACTION_COUNT_NEAR_1000.to_list()
        CROSSWALK_500 = self.data_df.CROSSWALK_COUNT_NEAR_500.to_list()
        CROSSWALK_1000 = self.data_df.CROSSWALK_COUNT_NEAR_1000.to_list()
        LEISURE_500 = self.data_df.LEISURE_COUNT_NEAR_500.to_list()
        LEISURE_1000 = self.data_df.LEISURE_COUNT_NEAR_1000.to_list()
        MART_500 = self.data_df.MART_COUNT_NEAR_500.to_list()
        MART_1000 = self.data_df.MART_COUNT_NEAR_1000.to_list()
        DAILY_FLOATING_POPULATION = self.data_df.DAILY_FLOATING_POPULATION.to_list()
        LIVING_WORKER_POPULATION = self.data_df.LIVING_WORKER_POPULATION.to_list()
        LIVING_WORKER_AVG_REVENUE = self.data_df.LIVING_WORKER_AVG_REVENUE.to_list()
        LIVING_POPULATION = self.data_df.LIVING_POPULATION.to_list()
        LIVING_POPULATION_AVG_REVENUE = self.data_df.LIVING_POPULATION_AVG_REVENUE.to_list()
        MONTHLY_SHOP_SALE_TRANSACTION_COUNT = self.data_df.MONTHLY_SHOP_SALE_TRANSACTION_COUNT.to_list()
        EXPECTED_SHOP_REVENUE = self.data_df.EXPECTED_SHOP_REVENUE.to_list()
        AREA_SIZE = self.data_df.AREA_SIZE.to_list()

        # 데이터셋 생성
        datasets = {
            '경쟁업체_500': RIVAL_500,
            '경쟁업체_1000': RIVAL_1000,
            '주거단지_500': LIVING_500,
            '주거단지_1000': LIVING_1000,
            '학교_500': SCHOOL_500,
            '학교_1000': SCHOOL_1000,
            '학원_500': ACADEMY_500,
            '학원_1000': ACADEMY_1000,
            '병원_500': HOSPITAL_500,
            '병원_1000': HOSPITAL_1000,
            '지하철역_500': STATION_500,
            '지하철역_1000': STATION_1000,
            '버스정거장_500': STOP_500,
            '버스정거장_1000': STOP_1000,
            '주차장_500': PARKING_500,
            '주차장_1000': PARKING_1000,
            '관광지_500': TOUR_500,
            '관광지_1000': TOUR_1000,
            '횡단보도_500': CROSSWALK_500,
            '횡단보도_1000': CROSSWALK_1000,
            '여가시설_500': LEISURE_500,
            '여가시설_1000': LEISURE_1000,
            '대형점포_500': MART_500,
            '대형점포_1000': MART_1000,
            '일일유동인구': DAILY_FLOATING_POPULATION,
            '직장인인구': LIVING_WORKER_POPULATION,
            '거주인구': LIVING_POPULATION,
            '거주직장인평균소득': LIVING_WORKER_AVG_REVENUE,
            '거주인구평균소득': LIVING_POPULATION_AVG_REVENUE,
            '거래건수': MONTHLY_SHOP_SALE_TRANSACTION_COUNT,
            '월매출': EXPECTED_SHOP_REVENUE,
            '면적': AREA_SIZE,
        }

        return datasets

