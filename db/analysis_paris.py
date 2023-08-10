import json
import pickle

import pandas as pd
import psycopg2
from sklearn.linear_model import LinearRegression
from sqlalchemy import create_engine
import matplotlib.pyplot as plt
import numpy as np
import seaborn as sns
from sklearn.model_selection import train_test_split, cross_val_score


def main():
    controller = AnalysisController(test_option=True)
    controller.config_pd_option()
    # controller.거주_거리칼럼_세우기()
    # controller.get_living_info()
    # controller.get_paris_df()
    # controller.매장면적에_따른_수익_점도표()
    # controller.주변_인구에_따른_수익_점도표()
    # controller.주변_직장인_수에_따른_수익_점도표()
    # controller.매달_거래_건수에_따른_수익_점도표()
    # controller.거주_인원에_따른_매달_거래_건수()
    # controller.거주_인원에_따른_버스정류장500_개수()
    # controller.거주_인원에_따른_반경1000_경쟁업체_개수()
    # controller.주변_거주_평균소득에_따른_매출건수()
    # controller.박스플롯_월매출()
    # controller.박스플롯_반경500_거주인원()
    # controller.박스플롯_유동인구()
    # controller.박스플롯_경쟁업체_수()
    # controller.박스플롯_반경500_거주인원_평균소득()
    # controller.박스플롯_매장_크기()
    # controller.유동인구에_따른_매달_거래_건수()
    # controller.짝플롯()
    # controller.테스트()
    for i in range(10):
        controller.predict_paris()
    # controller.predict_paris()

class AnalysisController:
    # ===================== BASIC ============================ #
    _instance = None
    CONFIG_PATH = r"db_configuration.json"

    def __init__(self, test_option=False):
        self.conn = None
        self.engine = None
        self.config = self.read_config()
        self.test_option = test_option

    def read_config(self):
        """db 접속 정보는 config file에서 관리함, json으로 읽어서 dictionary 로 반환함 """
        with open(self.CONFIG_PATH, 'r', encoding='utf-8') as config_file:
            config_dict = json.load(config_file)
            return config_dict

    def __new__(cls, test_option=False):
        if not isinstance(cls._instance, cls):
            cls._instance = object.__new__(cls)
        return cls._instance

    def start_conn(self):
        # 메인 db 연결
        if self.test_option is False:
            self.conn = psycopg2.connect(host=self.config["host"],
                                         database=self.config["main_database_name"],
                                         user=self.config["user"],
                                         port=self.config["port"],
                                         password=self.config["password"])
            # engine_param = f'postgresql://{self.config["user"]}:{self.config["password"]}@{self.config["host"]}' \
            #                f':{self.config["port"]}/{self.config["main_database_name"]}'
            origin_engine_param = f'postgresql://{self.config["user"]}:{self.config["password"]}@{self.config["host"]}' \
                                  f':{self.config["port"]}/{self.config["origin_database_name"]}'
            self.engine = create_engine(origin_engine_param)
        # 테스트 db 연결
        else:
            self.conn = psycopg2.connect(host=self.config["host"],
                                         database=self.config["test_database_name"],
                                         user=self.config["user"],
                                         port=self.config["port"],
                                         password=self.config["password"])
            engine_param = f'postgresql://{self.config["user"]}:{self.config["password"]}@{self.config["host"]}' \
                           f':{self.config["port"]}/{self.config["test_database_name"]}'
            self.engine = create_engine(engine_param)

        return self.conn.cursor()

    def end_conn(self):
        if self.conn is not None:
            self.conn.close()
            self.conn = None

    def commit_db(self):
        self.conn.commit()

    # ===================== DF 가져오기 ============================ #
    def get_paris_df(self):
        self.start_conn()
        pstmt = """select * from "TB_PARIS" """
        read_db = pd.read_sql(pstmt, self.engine)
        df = pd.DataFrame(read_db)
        df.sort_values(by="PARIS_ID", inplace=True)
        df.to_excel("data_as_excels/paris.xlsx", index_label=False, index=False)

    def get_living_info(self):
        self.start_conn()
        pstmt = """select * from "TB_LIVING_INFO" """
        read_db = pd.read_sql(pstmt, self.engine)
        df = pd.DataFrame(read_db)
        df.sort_values(by="LIVING_INFO_ID", inplace=True)
        df.to_excel("data_as_excels/living_info.xlsx", index_label=False, index=False)

    def 매장면적에_따른_수익_점도표(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)
        x_values = df['AREA_SIZE']
        y_values = df['MONTHLY_SHOP_REVENUE']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("매장면적과 수익의 점도표")
        plt.xlabel('매장 면적(㎡)')
        plt.ylabel('매달 수입(원)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 주변_인구에_따른_수익_점도표(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        x_values = df['LIVING_POPULATION']
        y_values = df['MONTHLY_SHOP_REVENUE']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("주변_인구에_따른_수익_점도표")
        plt.xlabel('주변 인구')
        plt.ylabel('매달 수입(원)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 주변_직장인_수에_따른_수익_점도표(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        x_values = df['LIVING_WORKER_POPULATION']
        y_values = df['MONTHLY_SHOP_REVENUE']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("주변_직장인_수에_따른_수익_점도표")
        plt.xlabel('주변_직장인_수(명)')
        plt.ylabel('매달 수입(원)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 주변_직장인_수입에_따른_수익_점도표(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        x_values = df['LIVING_WORKER_AVG_REVENUE']
        y_values = df['MONTHLY_SHOP_REVENUE']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("주변_직장인_수입에_따른_수익_점도표")
        plt.xlabel('주변_직장인_평균수입(원)')
        plt.ylabel('매달 수입(원)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 매달_거래_건수에_따른_수익_점도표(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        x_values = df['MONTHLY_SHOP_SALE_TRANSACTION_COUNT']
        y_values = df['MONTHLY_SHOP_REVENUE']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("매달_거래_건수에_따른_수익_점도표")
        plt.xlabel('매달 평균 거래 건수(건)')
        plt.ylabel('매달 수입(원)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 거주_인원에_따른_매달_거래_건수(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        x_values = df['LIVING_POPULATION']
        y_values = df['MONTHLY_SHOP_SALE_TRANSACTION_COUNT']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("거주_인원에_따른_매달_거래_건수")
        plt.xlabel('주변 거주 인원(명)')
        plt.ylabel('거래 건수(건)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 유동인구에_따른_매달_거래_건수(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        x_values = df['DAILY_FLOATING_POPULATION']
        y_values = df['MONTHLY_SHOP_SALE_TRANSACTION_COUNT']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("유동인구에_따른_매달_거래_건수")
        plt.xlabel('반경 500미터 유동 인원(명)')
        plt.ylabel('거래 건수(건)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 거주_인원에_따른_버스정류장500_개수(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        x_values = df['LIVING_POPULATION']
        y_values = df['STOP_COUNT_NEAR_500']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("거주_인원에_따른_버스정류장500_개수")
        plt.xlabel('주변 거주 인원(명)')
        plt.ylabel('버스정류장(개)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 거주_인원에_따른_반경1000_경쟁업체_개수(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        x_values = df['LIVING_POPULATION']
        y_values = df['RIVAL_COUNT_NEAR_1000']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("거주_인원에_따른_반경1000_경쟁업체_개수")
        plt.xlabel('주변 거주 인원(명)')
        plt.ylabel('경쟁업체(개)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 주변_거주_평균소득에_따른_매출건수(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        x_values = df['LIVING_POPULATION_AVG_REVENUE']
        y_values = df['MONTHLY_SHOP_SALE_TRANSACTION_COUNT']
        s_values = np.empty(len(x_values))
        s_values.fill(0.2)
        plt.title("주변_거주_평균소득에_따른_매출건수".replace('_', " "))
        plt.xlabel('주변 인구 평균 소득(원)')
        plt.ylabel('매출건수(건)')
        plt.grid()

        plt.scatter(x_values, y_values, s=s_values)
        plt.show()

    def 박스플롯_월매출(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        y_values = df['MONTHLY_SHOP_REVENUE']
        marker_value = df.iloc[256]['MONTHLY_SHOP_REVENUE']
        plt.boxplot(y_values)
        plt.plot(1, marker_value, "ro", markersize=3)
        plt.title("박스플롯_월매출")
        plt.xlabel('파리바게트 가게')
        plt.ylabel('매출')
        plt.grid()

        plt.show()

    def 박스플롯_반경500_거주인원(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        y_values = df['LIVING_POPULATION']
        marker_value = df.iloc[256]['MONTHLY_SHOP_REVENUE']
        plt.boxplot(y_values)
        # plt.plot(1, marker_value, "ro", markersize=3)
        plt.title("박스플롯_반경500_거주인원")
        plt.xlabel('파리바게트 가게')
        plt.ylabel('인구(명)')
        plt.grid()

        plt.show()

    def 박스플롯_반경500_거주인원_평균소득(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        y_values = df['LIVING_POPULATION_AVG_REVENUE']
        marker_value = df.iloc[716]['LIVING_POPULATION_AVG_REVENUE']
        plt.boxplot(y_values)
        plt.plot(1, marker_value, "ro", markersize=3)
        plt.title("박스플롯_반경500_거주인원_평균소득 - 영통롯데점")
        plt.xlabel('파리바게트 가게')
        plt.ylabel('가구당 소득(원)')
        plt.grid()

        plt.show()

    def 박스플롯_유동인구(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        y_values = df['DAILY_FLOATING_POPULATION']
        marker_value = df.iloc[256]['MONTHLY_SHOP_REVENUE']
        plt.boxplot(y_values)
        # plt.plot(1, marker_value, "ro", markersize=3)
        plt.title("박스플롯_반경500미터_유동인구")
        plt.xlabel('파리바게트 가게')
        plt.ylabel('유동인구(명)')
        plt.grid()

        plt.show()

    def 박스플롯_경쟁업체_수(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        category_1_values = df['RIVAL_COUNT_NEAR_500']
        category_2_values = df['RIVAL_COUNT_NEAR_1000']

        plt.boxplot([category_1_values, category_2_values])
        marker_value_1 = df.iloc[716]['RIVAL_COUNT_NEAR_500']
        marker_value_2 = df.iloc[716]['RIVAL_COUNT_NEAR_1000']
        plt.plot(1, marker_value_1, "ro", markersize=3)
        plt.plot(2, marker_value_2, "ro", markersize=3)

        plt.title("거리별 박스플롯 경쟁업체 수")
        plt.xticks([1, 2], ["500m 내", "1000m 내"])
        plt.xlabel('경쟁업체')
        plt.ylabel('경쟁업체 수(개)')
        plt.grid()

        plt.show()

    def 박스플롯_매장_크기(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        category_1_values = df['AREA_SIZE']

        plt.boxplot(category_1_values)
        # marker_value_1 = df.iloc[833]['AREA_SIZE']
        # plt.plot(1, marker_value_1, "ro", markersize=3)

        plt.title("박스플롯 매장 크기")
        plt.xlabel('매장별')
        plt.ylabel('매장 크기(㎡)')
        plt.grid()

        plt.show()

    def predict_paris(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)
        # X = df[['AREA_SIZE', 'RIVAL_COUNT_NEAR_500',
        #         'RIVAL_COUNT_NEAR_1000',
        #         'MONTHLY_SHOP_SALE_TRANSACTION_COUNT', 'DAILY_FLOATING_POPULATION',
        #         'LIVING_WORKER_POPULATION', 'LIVING_WORKER_AVG_REVENUE',
        #         'LIVING_POPULATION', 'LIVING_POPULATION_AVG_REVENUE',
        #         'ATTRACTION_COUNT_NEAR_500', 'ATTRACTION_COUNT_NEAR_1000',
        #         'ACADEMY_COUNT_NEAR_500', 'ACADEMY_COUNT_NEAR_1000',
        #         'STOP_COUNT_NEAR_500', 'STOP_COUNT_NEAR_1000',
        #         'CROSSWALK_COUNT_NEAR_500', 'CROSSWALK_COUNT_NEAR_1000',
        #         'HOSPITAL_COUNT_NEAR_500', 'HOSPITAL_COUNT_NEAR_1000',
        #         'PARKING_COUNT_NEAR_500', 'PARKING_COUNT_NEAR_1000',
        #         'SCHOOL_COUNT_NEAR_500', 'SCHOOL_COUNT_NEAR_1000',
        #         'STATION_COUNT_NEAR_500', 'STATION_COUNT_NEAR_1000',
        #         'LIVING_COUNT_NEAR_500', 'LIVING_COUNT_NEAR_1000',
        #         'RIVAL_NEAR_DISTANCE', 'LIVING_NEAR_DISTANCE', 'SCHOOL_NEAR_DISTANCE',
        #         'ACADEMY_NEAR_DISTANCE', 'HOSPITAL_NEAR_DISTANCE',
        #         'STATION_NEAR_DISTANCE', 'STOP_NEAR_DISTANCE', 'PARKING_NEAR_DISTANCE',
        #         'ATTRACTION_NEAR_DISTANCE', 'CROSSWALK_NEAR_DISTANCE']]
        X = df[['LIVING_POPULATION', 'STOP_COUNT_NEAR_500', 'LIVING_WORKER_AVG_REVENUE', 'HOSPITAL_COUNT_NEAR_500',
                'RIVAL_COUNT_NEAR_1000', 'LIVING_POPULATION_AVG_REVENUE', 'MONTHLY_SHOP_SALE_TRANSACTION_COUNT']]
        y = df['MONTHLY_SHOP_REVENUE']
        X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2)

        model = LinearRegression()
        model.fit(X_train, y_train)
        pickle.dump(model)

        y_pred = model.predict(X_test)

        # Evaluate the model's performance
        # accuracy = r2_score(y_test, y_pred)
        # accuracy = mean_squared_error(y_test, y_pred)

        scores = cross_val_score(model, X, y, cv=100)
        print("평균 교차 검증 점수:", np.mean(scores))  # 일반적으로 평균 교차 검증 점수가 높을수록 모델의 성능이 우수


        # print(f"MSE Accuracy: {accuracy:.2f}")

    def 짝플롯(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        col_names = ['PARIS_NAME', 'PARIS_ADDRESS', 'LATITUDE', 'LONGITUDE', 'AREA_SIZE', 'OPEN_DATE', 'CLOSE_DATE',
                     'IS_OPEN_STATE', 'RIVAL_COUNT_NEAR_500', 'RIVAL_COUNT_NEAR_1000', 'MONTHLY_SHOP_REVENUE',
                     'MONTHLY_SHOP_SALE_TRANSACTION_COUNT', 'DAILY_FLOATING_POPULATION', 'LIVING_WORKER_POPULATION',
                     'LIVING_WORKER_AVG_REVENUE', 'LIVING_POPULATION', 'LIVING_POPULATION_AVG_REVENUE',
                     'ATTRACTION_COUNT_NEAR_500', 'ATTRACTION_COUNT_NEAR_1000', 'ACADEMY_COUNT_NEAR_500',
                     'ACADEMY_COUNT_NEAR_1000', 'STOP_COUNT_NEAR_500', 'STOP_COUNT_NEAR_1000',
                     'CROSSWALK_COUNT_NEAR_500', 'CROSSWALK_COUNT_NEAR_1000', 'HOSPITAL_COUNT_NEAR_500',
                     'HOSPITAL_COUNT_NEAR_1000', 'PARKING_COUNT_NEAR_500', 'PARKING_COUNT_NEAR_1000',
                     'SCHOOL_COUNT_NEAR_500', 'SCHOOL_COUNT_NEAR_1000', 'STATION_COUNT_NEAR_500',
                     'STATION_COUNT_NEAR_1000', 'LIVING_COUNT_NEAR_500', 'LIVING_COUNT_NEAR_1000',
                     'RIVAL_NEAR_DISTANCE', 'LIVING_NEAR_DISTANCE', 'SCHOOL_NEAR_DISTANCE', 'ACADEMY_NEAR_DISTANCE',
                     'HOSPITAL_NEAR_DISTANCE', 'STATION_NEAR_DISTANCE',
                     'STOP_NEAR_DISTANCE', 'PARKING_NEAR_DISTANCE', 'ATTRACTION_NEAR_DISTANCE',
                     'CROSSWALK_NEAR_DISTANCE']

        print(df.columns)

        df.insert(0, 'CAT', '')
        # 카테고리화 : 근처 거주 세대 100미터 이내 거리
        # df.loc[df['LIVING_NEAR_DISTANCE'] <= 100, 'CAT'] = 1
        # df.loc[(df['LIVING_NEAR_DISTANCE'] > 100) & (
        #         df['LIVING_NEAR_DISTANCE'] <= 200), 'CAT'] = 2
        # df.loc[df['LIVING_NEAR_DISTANCE'] > 200, 'CAT'] = 3

        # 카테고리화 : 근처 거주 세대 100미터 이내 거리
        df.loc[df['HOSPITAL_NEAR_DISTANCE'] <= 100, 'CAT'] = 1
        df.loc[(df['HOSPITAL_NEAR_DISTANCE'] > 100) & (
                df['HOSPITAL_NEAR_DISTANCE'] <= 500), 'CAT'] = 2
        df.loc[df['HOSPITAL_NEAR_DISTANCE'] > 500, 'CAT'] = 3

        # df = df[
        #     ['CAT',
        #      'MONTHLY_SHOP_REVENUE', 'LIVING_WORKER_POPULATION',
        #      'LIVING_WORKER_AVG_REVENUE', 'LIVING_POPULATION', 'LIVING_POPULATION_AVG_REVENUE',
        #      'RIVAL_NEAR_DISTANCE', 'LIVING_NEAR_DISTANCE', 'SCHOOL_NEAR_DISTANCE', 'ACADEMY_NEAR_DISTANCE',
        #      'HOSPITAL_NEAR_DISTANCE', 'STATION_NEAR_DISTANCE',
        #      'STOP_NEAR_DISTANCE', 'PARKING_NEAR_DISTANCE', 'ATTRACTION_NEAR_DISTANCE',
        #      'CROSSWALK_NEAR_DISTANCE'
        #      ]
        # ]
        df = df[
            ['CAT', 'MONTHLY_SHOP_REVENUE', 'MONTHLY_SHOP_SALE_TRANSACTION_COUNT',
             'AREA_SIZE', 'RIVAL_COUNT_NEAR_500', 'DAILY_FLOATING_POPULATION', 'LIVING_WORKER_POPULATION',
             'LIVING_WORKER_AVG_REVENUE', 'LIVING_POPULATION', 'LIVING_POPULATION_AVG_REVENUE', 'STOP_COUNT_NEAR_500',
             'HOSPITAL_COUNT_NEAR_500',
             ]
        ]

        self.make_seaborn_pair_plot(df)

    @staticmethod
    def haversine_distance(lat1, lon1, lat2, lon2):
        # Convert latitude and longitude from degrees to radians
        lat1, lon1, lat2, lon2 = map(np.radians, [lat1, lon1, lat2, lon2])

        # Haversine formula
        d_lat = lat2 - lat1
        d_lon = lon2 - lon1
        a = np.sin(d_lat / 2) ** 2 + np.cos(lat1) * np.cos(lat2) * np.sin(d_lon / 2) ** 2
        c = 2 * np.arcsin(np.sqrt(a))
        r = 6371  # Radius of the Earth in kilometers
        return c * r

    def get_distance(self, latitude: float, longitude: float) -> int:
        living_df = pd.read_excel("data_as_excels/living_info.xlsx", index_col=0)

    def 테스트(self):
        df = pd.read_excel("data_as_excels/paris.xlsx", index_col=0)

        df.insert(0, 'CAT', '')

        df.loc[df['LIVING_WORKER_AVG_REVENUE'] >= 4000000, 'CAT'] = 1
        df.loc[(df['LIVING_WORKER_AVG_REVENUE'] > 3300000) & (df['LIVING_WORKER_AVG_REVENUE'] < 4000000), 'CAT'] = 2
        df.loc[df['LIVING_WORKER_AVG_REVENUE'] <= 3300000, 'CAT'] = 3

        for row in df.itertuples():
            print(row)

    def make_seaborn_pair_plot(self, df):
        rename_df = self.rename_columns(df)
        sns.set(font="Malgun Gothic", font_scale=0.5)
        custom_palette = ['#023586', '#FEDA24', '#16A085']
        sns.pairplot(rename_df, height=2, hue='CAT', plot_kws={'s': 3}, palette=sns.color_palette(custom_palette, 3))
        plt.show()

    def rename_columns(self, df):
        new_df = df.rename(columns={
            "PARIS_NAME": "지점명",
            "PARIS_ADDRESS": "주소",
            "LATITUDE": "위도",
            "LONGITUDE": "경도",
            "AREA_SIZE": "면적",
            "OPEN_DATE": "허가일자",
            "CLOSE_DATE": "폐업일자",
            "IS_OPEN_STATE": "개점여부",
            "RIVAL_COUNT_NEAR_500": "500m 내 경쟁업체 수(개)",
            "RIVAL_COUNT_NEAR_1000": "1000m 내 경쟁업체 수(개)",
            "MONTHLY_SHOP_REVENUE": "월 추정 수입(원)",
            "MONTHLY_SHOP_SALE_TRANSACTION_COUNT": "월 거래건수(건)",
            "DAILY_FLOATING_POPULATION": "유동 인구(명)",
            "LIVING_WORKER_POPULATION": "500m 거주 근로자 수(명)",
            "LIVING_WORKER_AVG_REVENUE": "거주 근로자 평균 수입(원)",
            "LIVING_POPULATION": "500m 거주 거주인구 수(명)",
            "LIVING_POPULATION_AVG_REVENUE": "거주 인구 평균 수입(원)",
            "ATTRACTION_COUNT_NEAR_500": "500m 내 관광명소(곳)",
            "ATTRACTION_COUNT_NEAR_1000": "1000m 내 관광명소(곳)",
            "ACADEMY_COUNT_NEAR_500": "500m 내 학원 수(개)",
            "ACADEMY_COUNT_NEAR_1000": "1000m 내 학원 수(개)",
            "STOP_COUNT_NEAR_500": "500m 내 버스정류장 수(개)",
            "STOP_COUNT_NEAR_1000": "1000m 내 버스정류장 수(개)",
            "CROSSWALK_COUNT_NEAR_500": "500m 내 횡단보도 수(개)",
            "CROSSWALK_COUNT_NEAR_1000": "1000m 내 횡단보도 수(개)",
            "HOSPITAL_COUNT_NEAR_500": "500m 내 병원 수(개)",
            "HOSPITAL_COUNT_NEAR_1000": "1000m 내 병원 수(개)",
            "PARKING_COUNT_NEAR_500": "500m 내 주차장 수(개)",
            "PARKING_COUNT_NEAR_1000": "1000m 내 주차장 수(개)",
            "SCHOOL_COUNT_NEAR_500": "500m 내 학교 수(개)",
            "SCHOOL_COUNT_NEAR_1000": "1000m 내 학교 수(개)",
            "STATION_COUNT_NEAR_500": "500m 내 지하철역 수(개)",
            "STATION_COUNT_NEAR_1000": "1000m 내 지하철역 수(개)",
            "LIVING_COUNT_NEAR_500": "500m 내 거주세대 수(세대)",
            "LIVING_COUNT_NEAR_1000": "1000m 내 거주세대 수(세대)",
            "RIVAL_NEAR_DISTANCE": "최근 경쟁업체 거리(m)",
            "LIVING_NEAR_DISTANCE": "최근 주택세대 거리(m)",
            "SCHOOL_NEAR_DISTANCE": "최근 학교 거리(m)",
            "ACADEMY_NEAR_DISTANCE": "최근 학원 거리(m)",
            "HOSPITAL_NEAR_DISTANCE": "최근 병원 거리(m)",
            "STATION_NEAR_DISTANCE": "최근 지하철 거리(m)",
            "STOP_NEAR_DISTANCE": "최근 버스정류장 거리(m)",
            "PARKING_NEAR_DISTANCE": "최근 주차장 거리(m)",
            "ATTRACTION_NEAR_DISTANCE": "최근 관광명소 거리(m)",
            "CROSSWALK_NEAR_DISTANCE": "최근 횡단보도 거리(m)",

        })
        return new_df

    @staticmethod
    def config_pd_option():
        # pandas 칼럼 다 보이게 설정
        pd.set_option('display.max_columns', None)
        pd.set_option('display.width', 1000)
        plt.rcParams['axes.unicode_minus'] = False
        # # seaboarn 한글 설정
        # plt.rc("font", family="Malgun Gothic")
        # sns.set(font="Malgun Gothic",
        #         rc={"axes.unicode_minus": False}, style='white')


if __name__ == '__main__':
    main()
