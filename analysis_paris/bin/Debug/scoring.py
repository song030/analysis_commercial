import pickle

import pandas as pd
from sqlalchemy import create_engine


class Databases():
    def __init__(self):
        self.engine = create_engine('postgresql://postgres:1234@10.10.20.117:5432/db_analysis_test')

    def __del__(self):
        self.engine.dispose()


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


class Scoring:
    def __init__(self, df: pd.DataFrame):
        self.db_conn = Databases()
        self.paris_datasets = MakeParisDatasets().get_dataset()
        self.df_paris = pd.DataFrame(self.paris_datasets)
        self.df = pd.concat([self.df_paris, df])

    def get_score_percent_df(self):
        # 점수 부여
        plus_score_list = [20, 40, 60, 80, 100]

        #  plus 가중치
        plus_independents = [
            self.df.월매출,
            self.df.거주인구평균소득,
            self.df.거주직장인평균소득,
            self.df.거주인구,
            self.df.일일유동인구,
            self.df.학원_500,
            self.df.학원_1000,
            self.df.학교_500,
            self.df.학교_1000,
            self.df.여가시설_500,
            self.df.여가시설_1000,
            self.df.지하철역_500,
            self.df.지하철역_1000,
            self.df.버스정거장_500,
            self.df.버스정거장_1000,
        ]

        df_list = []
        for independent in plus_independents:
            score_cut = pd.cut(independent, 5, labels=plus_score_list)
            df_list.append(score_cut.to_frame())

        df_score = pd.concat(df_list, axis=1)
        df = pd.DataFrame(df_score.iloc[len(df_score) - 1]).transpose()
        return df

    def get_score(self):
        # 점수 부여
        plus_score_list = [20, 40, 60, 80, 100]
        minus_score_list = [-20, -40, -60, -80, -100]

        #  plus 가중치
        plus_independents = [
            self.df.월매출,
            self.df.거주인구평균소득,
            self.df.거주직장인평균소득,
            self.df.거주인구,
            self.df.일일유동인구,
            self.df.학원_500,
            self.df.학원_1000,
            self.df.학교_500,
            self.df.학교_1000,
            self.df.여가시설_500,
            self.df.여가시설_1000,
            self.df.지하철역_500,
            self.df.지하철역_1000,
            self.df.버스정거장_500,
            self.df.버스정거장_1000,
        ]

        # 가중치 총합 1.2
        plus_weights = [
            0.3,  # 월매출
            0.1,  # 거주인구평균소득
            0.1,  # 거주직장인평군소득
            0.05,  # 일일유동인구
            0.05,  # 거주인구
            0.05,  # 학원_500
            0.05,  # 학원_1000
            0.05,  # 학교_500
            0.05,  # 학교_1000
            0.05,  # 여가시설_500
            0.05,  # 여가시설_1000
            0.05,  # 지하철역_500
            0.05,  # 지하철역_1000
            0.05,  # 버스정거장_500
            0.05,  # 버스정거장_1000
        ]

        df_list = []
        for independent, weight in zip(plus_independents, plus_weights):
            score_cut = pd.cut(independent, 5, labels=plus_score_list)
            result = score_cut.astype(float) * weight
            result = result.astype(int)
            df_list.append(result.to_frame())

        # minus
        minus_independents = [
            self.df.경쟁업체_500,
            self.df.경쟁업체_1000
        ]

        # 가중치 총합 - 0.2
        minus_weights = [
            -0.1  # 경쟁업체_500
            - 0.1  # 경쟁업체_1000
        ]

        for independent, weight in zip(minus_independents, minus_weights):
            score_cut = pd.cut(independent, 5, labels=minus_score_list)
            result = score_cut.astype(float) * weight
            result = result.astype(int)
            df_list.append(result.to_frame())

        # 데이터프레임 합치기
        # df_list.append(self.df.SELLING_AREA_ID.to_frame())
        # concat_df = pd.concat(df_list, axis=1)
        # df_score = concat_df.set_index(keys=['SELLING_AREA_ID'], drop=True)
        df_score = pd.concat(df_list, axis=1)
        df_score.reset_index(inplace=True)
        # 점수 계산
        df_score['SCORE'] = df_score.sum(axis=1)
        # print("SCORE@@@@@@@@@@@@@@@@@@@@@@@")
        # print(df_score)
        # print(type(df_score))
        # print(type(df_score['SCORE']))
        result_score = int(df_score.at[len(df_score) - 1, 'SCORE'])

        return result_score
