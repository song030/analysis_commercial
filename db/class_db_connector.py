import json

import pandas as pd
import psycopg2
from sqlalchemy import create_engine


def main():
    connector = DBConnector(test_option=True)
    connector.config_pd_option()


    # connector.save_paris_excel_on_db()
    # connector.migration_TB_PARIS()
    # connector.migration_TB_ATTRACTION_PLACE()
    # connector.migration_TB_BUS_STOP()
    # connector.migration_TB_STATION()
    # connector.migration_TB_SELLING_AREA()
    # connector.migration_TB_SCHOOL()
    # connector.migration_TB_SALES()
    # connector.migration_TB_PARKING()
    # connector.migration_TB_LIVING_INFO()
    # connector.migration_TB_CROSSWALK()
    # connector.migration_TB_HOSPITAL()
    # connector.migration_TB_ACADEMY()

    # connector.create_table()


class DBConnector:
    # ===================== BASIC ============================ #
    _instance = None
    CONFIG_PATH = r"db_configuration.json"

    def read_config(self):
        """db 접속 정보는 config file에서 관리함, json으로 읽어서 dictionary 로 반환함 """
        with open(self.CONFIG_PATH, 'r', encoding='utf-8') as config_file:
            config_dict = json.load(config_file)
            return config_dict

    def __new__(cls, test_option=False):
        if not isinstance(cls._instance, cls):
            cls._instance = object.__new__(cls)
        return cls._instance

    def __init__(self, test_option=False):
        self.conn = None
        self.engine = None
        self.origin_conn = None
        self.origin_engine = None
        self.config = self.read_config()
        self.test_option = test_option

    def start_conn(self):
        # 메인 db 연결
        if self.test_option is False:
            self.conn = psycopg2.connect(host=self.config["host"],
                                         database=self.config["main_database_name"],
                                         user=self.config["user"],
                                         port=self.config["port"],
                                         password=self.config["password"])
            engine_param = f'postgresql://{self.config["user"]}:{self.config["password"]}@{self.config["host"]}' \
                           f':{self.config["port"]}/{self.config["main_database_name"]}'
            self.engine = create_engine(engine_param)
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

        # origin 연결
        self.origin_conn = psycopg2.connect(host=self.config["host"],
                                            database=self.config["origin_database_name"],
                                            user=self.config["user"],
                                            port=self.config["port"],
                                            password=self.config["password"])
        engine_param = f'postgresql://{self.config["user"]}:{self.config["password"]}@{self.config["host"]}' \
                       f':{self.config["port"]}/{self.config["origin_database_name"]}'
        self.origin_engine = create_engine(engine_param)
        return self.conn.cursor()

    def end_conn(self):
        if self.conn is not None:
            self.conn.close()
            self.conn = None

    def commit_db(self):
        self.conn.commit()

    def create_table(self):
        query = None
        with open('table_queries_for_creation.sql', 'r', encoding='utf-8') as query_file:
            query = query_file.read()
        assert isinstance(query, str)
        try:
            c = self.start_conn()
            c.execute(query)
            self.commit_db()
            self.end_conn()
            print(f"Table created successfully.")
        except Exception as e:
            print(f"Error creating table: {e}")
            self.conn.rollback()

    def back_up_tables(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        engine_param = f'postgresql://{self.config["user"]}:{self.config["password"]}@{self.config["host"]}' \
                       f':{self.config["port"]}/backup_db'
        backup_engine = create_engine(engine_param)
        self.start_conn()

        drop_table_query = """  DROP TABLE IF EXISTS public."TB_HOSPITAL";
                                DROP TABLE IF EXISTS public."TB_CROSSWALK";
                                DROP TABLE IF EXISTS public."TB_ADMIT";
                                DROP TABLE IF EXISTS public."TB_ACADEMY";
                                DROP TABLE IF EXISTS public."TB_LIVING_INFO";
                                DROP TABLE IF EXISTS public."TB_PARIS";
                                DROP TABLE IF EXISTS public."TB_PARKING";
                                DROP TABLE IF EXISTS public."TB_SALES";
                                DROP TABLE IF EXISTS public."TB_SCHOOL";
                                DROP TABLE IF EXISTS public."TB_SELLING_AREA";
                                DROP TABLE IF EXISTS public."TB_STATION";
                                DROP TABLE IF EXISTS public."TB_STOP";
                                DROP TABLE IF EXISTS public."TB_TOUR";"""

        pstmt = """SELECT * FROM "TB_ACADEMY" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_ACADEMY", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_ADMIT" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_ADMIT", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_CROSSWALK" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_CROSSWALK", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_HOSPITAL" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_HOSPITAL", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_LIVING_INFO" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_LIVING_INFO", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_PARIS" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_PARIS", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_PARKING" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_PARKING", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_SALES" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_SALES", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_SCHOOL" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_SCHOOL", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_SELLING_AREA" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_SELLING_AREA", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_STATION" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_STATION", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_STOP" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_STOP", backup_engine, if_exists='replace', index=False)

        pstmt = """SELECT * FROM "TB_TOUR" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        df.to_sql("TB_TOUR", backup_engine, if_exists='replace', index=False)

        self.commit_db()

    def migration_TB_ACADEMY(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        self.start_conn()
        pstmt = """SELECT * FROM "TB_ACADEMY" """
        read_table = pd.read_sql(pstmt, self.origin_engine)  # 예전 db에서 가져옴
        df = pd.DataFrame(read_table)
        # print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['SHOP_NUM', 'SHOP_NAME', 'SHOP_TYPE', 'STANDARD_CODE', 'STANDARD_NAME',
                                    'CITY_CODE', 'CITY_NAME', 'ROAD_NAME', 'BUILDING_NAME', 'ROAD_ADDRESS',
                                    'LATITUDE', 'LONGITUDE']

        new_col_list = ['SHOP_NAME', 'ROAD_ADDRESS', 'STANDARD_NAME', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list].reset_index()
        df['ACADEMY_ID'] = df['index'] + 1
        final_col_list = ['ACADEMY_ID', 'SHOP_NAME', 'ROAD_ADDRESS', 'STANDARD_NAME', 'LATITUDE', 'LONGITUDE']
        df = df[final_col_list]

        # 추가 칼럼(후에 사용할) 만들어 놓기
        df.to_sql("TB_ACADEMY", self.engine, if_exists='fail', index=False)
        self.commit_db()
        self.create_PK_query('TB_ACADEMY_ID_seq', 'TB_ACADEMY', 'ACADEMY_ID')

    def migration_TB_ACADEMY(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        self.start_conn()
        pstmt = """SELECT * FROM "TB_ACADEMY" """
        read_table = pd.read_sql(pstmt, self.origin_engine)  # 예전 db에서 가져옴
        df = pd.DataFrame(read_table)
        # print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['SHOP_NUM', 'SHOP_NAME', 'SHOP_TYPE', 'STANDARD_CODE', 'STANDARD_NAME',
                                    'CITY_CODE', 'CITY_NAME', 'ROAD_NAME', 'BUILDING_NAME', 'ROAD_ADDRESS',
                                    'LATITUDE', 'LONGITUDE']

        new_col_list = ['SHOP_NAME', 'ROAD_ADDRESS', 'STANDARD_NAME', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list].reset_index()
        df['ACADEMY_ID'] = df['index'] + 1
        final_col_list = ['ACADEMY_ID', 'SHOP_NAME', 'ROAD_ADDRESS', 'STANDARD_NAME', 'LATITUDE', 'LONGITUDE']
        df = df[final_col_list]

        # 추가 칼럼(후에 사용할) 만들어 놓기
        df.to_sql("TB_ACADEMY", self.engine, if_exists='fail', index=False)
        self.commit_db()

    def migration_TB_CROSSWALK(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        self.start_conn()
        pstmt = """SELECT * FROM "TB_CROSSWALK" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        # print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['DO_NAME', 'CITY_NAME', 'ROAD_NAME', 'BRANCH_ADDRESS', 'MANAGE_NUM', 'LATITUDE',
                                    'LONGITUDE']

        new_col_list = ['BRANCH_ADDRESS', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list]
        df.reset_index(inplace=True)
        df['index'] = df['index'] + 1
        # 칼럼 이름 바꾸기
        df.rename(columns={'index': 'CROSSWALK_ID'}, inplace=True)

        df.to_sql("TB_CROSSWALK", self.engine, if_exists='fail', index=False)
        self.commit_db()
        self.create_PK_query('TB_CROSSWALK_ID_seq', 'TB_CROSSWALK', 'CROSSWALK_ID')

    def migration_TB_HOSPITAL(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        self.start_conn()
        pstmt = """SELECT * FROM "TB_HOSPITAL" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['GOVERNMENT_CODE', 'MANAGE_CODE', 'LICENSE_DATE', 'BUSINESS_STATUS',
                                    'STATE_CODE', 'STATE_NAME', 'TEL', 'ROAD_ADDRESS', 'BUSINESS_NAME',
                                    'BUSINESS_TYPE', 'latitude', 'longitude', 'ID']

        new_col_list = ['ID', 'BUSINESS_NAME', 'BUSINESS_TYPE', 'ROAD_ADDRESS', 'latitude', 'longitude']
        df = df[new_col_list]

        # 칼럼 이름 바꾸기
        df.rename(columns={"ID": "HOSPITAL_ID"}, inplace=True)
        df.rename(columns={"latitude": "LATITUDE"}, inplace=True)
        df.rename(columns={"longitude": "LONGITUDE"}, inplace=True)

        # 추가 칼럼(후에 사용할) 만들어 놓기

        df.to_sql("TB_HOSPITAL", self.engine, if_exists='fail', index=False)
        self.commit_db()
        self.create_PK_query('TB_HOSPITAL_ID_seq', 'TB_HOSPITAL', 'HOSPITAL_ID')

    def migration_TB_LIVING_INFO(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        self.start_conn()
        pstmt = """SELECT * FROM "TB_LIVING_INFO" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['LVN_ADDRESS', 'LVN_NAME', 'LVN_COUNT', 'LVN_FAMILY', 'LVN_DATE',
                                    'LATITUDE', 'LONGITUDE', 'LVN_NO']

        new_col_list = ['LVN_NO', 'LVN_NAME', 'LVN_COUNT', 'LVN_FAMILY', 'LVN_ADDRESS', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list]

        # 칼럼 이름 바꾸기
        df.rename(columns={"LVN_NO": "LIVING_INFO_ID"}, inplace=True)

        # 추가 칼럼(후에 사용할) 만들어 놓기

        df.to_sql("TB_LIVING_INFO", self.engine, if_exists='fail', index=False)
        self.commit_db()
        self.create_PK_query('TB_LIVING_INFO_ID_seq', 'TB_LIVING_INFO', 'LIVING_INFO_ID')

    def migration_TB_PARIS(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        self.start_conn()
        pstmt = """SELECT * FROM "TB_PARIS_FINAL" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        # print(df.columns)
        # # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['PARIS_ID', 'PARIS_NAME', 'PARIS_ADDRESS', 'LATITUDE', 'LONGITUDE', 'AREA_SIZE',
                                    'OPEN_DATE', 'CLOSE_DATE', 'IS_OPEN_STATE', 'RIVAL_COUNT_NEAR_500',
                                    'RIVAL_COUNT_NEAR_1000', 'MONTHLY_SHOP_REVENUE',
                                    'MONTHLY_SHOP_SALE_TRANSACTION_COUNT', 'DAILY_FLOATING_POPULATION',
                                    'LIVING_WORKER_POPULATION', 'LIVING_WORKER_AVG_REVENUE', 'LIVING_POPULATION',
                                    'LIVING_POPULATION_AVG_REVENUE']

        df.to_sql("TB_PARIS", self.engine, if_exists='fail', index=False)
        self.commit_db()
        self.create_PK_query('TB_PARIS_ID_seq', 'TB_PARIS', 'PARIS_ID')

    def migration_TB_PARKING(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        self.start_conn()
        pstmt = """SELECT * FROM "TB_PARKING" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        # print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['MANAGE_NUMBER', 'PARKING_NAME', 'PARKING_CLASS', 'PARKING_TYPE',
                                    'ROAD_ADDRESS', 'BRANCH_ADDRESS', 'PARKING_SAPCE', 'TEL', 'LATITUDE',
                                    'LONGITUDE', 'ID']

        new_col_list = ['ID', 'PARKING_NAME', 'ROAD_ADDRESS', 'PARKING_TYPE', 'PARKING_SAPCE', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list]

        # 칼럼 이름 바꾸기
        df.rename(columns={"ID": "PARKING_ID"}, inplace=True)
        #
        # # 추가 칼럼(후에 사용할) 만들어 놓기
        #
        df.to_sql("TB_PARKING", self.engine, if_exists='fail', index=False)
        self.commit_db()
        self.create_PK_query('TB_PARKING_ID_seq', 'TB_PARKING', 'PARKING_ID')

    def migration_TB_SALES(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        cursor = self.start_conn()
        pstmt = """SELECT * FROM "TB_SALES" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['BASE_YEAR', 'BASE_QUARTER', 'COMM_ID', 'COMM_NAME', 'INDUSTRY_CODE',
                                    'INDUSTRY_NAME', 'SALE_AMT', 'SALE_NUM', 'ROAD_ADDRESS', 'LATITUDE',
                                    'LONGITUDE']

        new_col_list = ['COMM_NAME', 'SALE_AMT', 'SALE_NUM', 'ROAD_ADDRESS', 'LATITUDE',
                        'LONGITUDE']
        df = df[new_col_list]

        # 칼럼 이름 바꾸기
        df = df.reset_index()
        df["index"] = df["index"] + 1
        df.rename(columns={'index': 'MARKET_ID', 'COMM_NAME': "MARKET_NAME"}, inplace=True)
        #
        # # 추가 칼럼(후에 사용할) 만들어 놓기
        #
        df.to_sql("TB_SALES_MARKET", self.engine, if_exists='fail', index=False)
        self.commit_db()

        self.create_PK_query('TB_SALES_MARKET_ID_seq', 'TB_SALES_MARKET', 'MARKET_ID')

        self.end_conn()

    def migration_TB_SCHOOL(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        cursor = self.start_conn()
        pstmt = """SELECT * FROM "TB_SCHOOL" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        # print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['FACILITY_EDU_CODE', 'FACILITY_EDU_NAME', 'OFFICE_EDU_CODE',
                                    'OFFICE_EDU_NAME', 'DO_CODE', 'DO_NAME', 'CITY_CODE', 'CITY_NAME',
                                    'SCHOOL_NAME', 'PUBLIC_PRIVATE', 'EST_TYPE', 'EST_DATE', 'SCHOOL_CHAR',
                                    'DAY_NIGHT', 'NUM_CLASS', 'NUM_STUDENT', 'NUM_TEACHER',
                                    'NUM_SPECIAL_CLASS', 'ROAD_ADDRESS', 'HOMEPAGE', 'TEL', 'FAX',
                                    'MALE_FEMALE', 'ID', 'LATITUDE', 'LONGITUDE']

        new_col_list = ['SCHOOL_NAME', 'PUBLIC_PRIVATE', 'EST_TYPE', 'EST_DATE', 'NUM_CLASS', 'NUM_STUDENT',
                        'NUM_TEACHER', 'ROAD_ADDRESS', 'MALE_FEMALE', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list]

        # 칼럼 이름 바꾸기
        df = df.reset_index()
        df["index"] = df["index"] + 1
        df.rename(columns={'index': "SCHOOL_ID", 'EST_TYPE': 'ESTABLISH_TYPE', 'MALE_FEMALE': 'GENDER_CONSTRAINTS'},
                  inplace=True)
        #
        # # 추가 칼럼(후에 사용할) 만들어 놓기
        #
        df.to_sql("TB_SCHOOL", self.engine, if_exists='fail', index=False)
        self.commit_db()

        self.create_PK_query('TB_SCHOOL_ID_seq', 'TB_SCHOOL', 'SCHOOL_ID')

        self.end_conn()

    def migration_TB_SELLING_AREA(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        cursor = self.start_conn()
        pstmt = """SELECT * FROM "TB_SELLING_AREA" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['SELLING_AREA_ID', 'SELLING_TYPE', 'BUILDING_TYPE', 'CURRENT_STATE',
                                    'ADDRESS', 'AREA_SIZE', 'FLOOR_INFO', 'DEPOSIT', 'RATE_PER_MONTH',
                                    'PREMIUM', 'LATITUDE', 'LONGITUDE', 'RELATION_LINK', 'SELLING_PRICE',
                                    'RIVAL_CNT_300', 'TOUR_CNT_300', 'HOSPITAL_CNT_300', 'STOP_CNT_300',
                                    'LIVING_CNT_300', 'PARKING_CNT_300', 'STATION_CNT_300',
                                    'SCHOOL_CNT_300', 'ACADEMY_CNT_300', 'CROSSWALK_CNT_300']

        new_col_list = ['SELLING_AREA_ID', 'SELLING_TYPE', 'BUILDING_TYPE', 'CURRENT_STATE',
                        'ADDRESS', 'AREA_SIZE', 'FLOOR_INFO', 'DEPOSIT', 'RATE_PER_MONTH',
                        'PREMIUM', 'LATITUDE', 'LONGITUDE', 'RELATION_LINK', 'SELLING_PRICE', ]
        df = df[new_col_list]

        df.to_sql("TB_SELLING_AREA", self.engine, if_exists='fail', index=False)
        self.commit_db()

        self.create_PK_query('TB_SELLING_AREA_ID_seq', 'TB_SELLING_AREA', 'SELLING_AREA_ID')

        self.end_conn()

    def migration_TB_STATION(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        cursor = self.start_conn()
        pstmt = """SELECT * FROM "TB_STATION" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        # print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['STATION_LINE', 'STATION_NAME', 'BRANCH_ADDRESS', 'ROAD_ADDRESS',
                                    'LATITUDE', 'LONGITUDE']
        new_col_list = ['STATION_LINE', 'STATION_NAME', 'ROAD_ADDRESS', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list]
        # 칼럼 이름 바꾸기
        df = df.reset_index()
        df["index"] = df["index"] + 1
        df.rename(columns={'index': "STATION_ID"}, inplace=True)

        df.to_sql("TB_STATION", self.engine, if_exists='fail', index=False)
        self.commit_db()

        self.create_PK_query('TB_STATION_ID_seq', 'TB_STATION', 'STATION_ID')

        self.end_conn()

    def migration_TB_BUS_STOP(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        cursor = self.start_conn()
        pstmt = """SELECT * FROM "TB_STOP" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['STOP_ID', 'CITY_NAME', 'STOP_NAME', 'LATITUDE', 'LONGITUDE']

        new_col_list = ['CITY_NAME', 'STOP_NAME', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list]

        # 칼럼 이름 바꾸기
        df = df.reset_index()
        df["index"] = df["index"] + 1
        df.rename(columns={'index': "BUS_STOP_ID"}, inplace=True)
        # #
        # # # 추가 칼럼(후에 사용할) 만들어 놓기
        # #
        df.to_sql("TB_BUS_STOP", self.engine, if_exists='fail', index=False)
        self.commit_db()

        self.create_PK_query('TB_BUS_STOP_ID_seq', 'TB_BUS_STOP', 'BUS_STOP_ID')

        self.end_conn()

    def migration_TB_ATTRACTION_PLACE(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        cursor = self.start_conn()
        pstmt = """SELECT * FROM "TB_TOUR" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        # print(df.columns)
        # # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['TOUR_NAME', 'TOUR_ADDR_N', 'TOUR_ADDR_O', 'LATITUDE', 'LONGITUDE',
                                    'TOUR_ID']

        new_col_list = ['TOUR_NAME', 'TOUR_ADDR_N', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list]

        # 칼럼 이름 바꾸기
        df = df.reset_index()
        df["index"] = df["index"] + 1
        df.rename(columns={'index': "ATTRACTION_ID"}, inplace=True)

        # 추가 칼럼(후에 사용할) 만들어 놓기

        df.to_sql("TB_ATTRACTION_PLACE", self.engine, if_exists='fail', index=False)
        self.commit_db()
        self.create_PK_query('TB_ATTRACTION_PLACE_ID_seq', 'TB_ATTRACTION_PLACE', 'ATTRACTION_ID')
        self.end_conn()

    def save_paris_excel_on_db(self):
        """
       RESULT_PARIS excel -> db 저장
       :return:
       """
        self.start_conn()
        cursor = self.origin_conn.cursor()
        read_file = pd.read_excel("crawling_sources/_dummy_src/RESULT_PARIS.xlsx")
        df = pd.DataFrame(read_file)
        # df.rename(columns={"INDEX": "PARIS_ID"}, inplace=True)
        # df.drop("PARIS_NO", axis='columns', inplace=True)
        df.to_sql("TB_PARIS_FINAL", self.origin_engine, if_exists='replace', index=False)
        create_pk_query = f"""
            ALTER TABLE "TB_PARIS_FINAL" ADD PRIMARY KEY ("PARIS_ID");
            CREATE SEQUENCE IF NOT EXISTS public."TB_PARIS_FINAL_PK"
                INCREMENT 1
                START 1
                MINVALUE 1
                MAXVALUE 2147483647
                CACHE 1
                OWNED BY "TB_PARIS_FINAL"."PARIS_ID";
            ALTER SEQUENCE public."TB_PARIS_FINAL_PK"
                OWNER TO postgres;"""
        cursor.execute(create_pk_query)
        self.origin_conn.commit()

        # self.create_PK_query('TB_PARIS_FINAL_ID_seq', 'TB_PARIS_FINAL', 'FINAL_PARIS_ID')
        #
        #
        # cursor = self.start_conn()
        # pstmt = """SELECT * FROM "TB_TOUR" """
        # read_table = pd.read_sql(pstmt, self.origin_engine)
        # df = pd.DataFrame(read_table)
        # # print(df.columns)
        # # # 칼럼 추출 + 순서 바꾸기
        # current_column_name_list = ['TOUR_NAME', 'TOUR_ADDR_N', 'TOUR_ADDR_O', 'LATITUDE', 'LONGITUDE',
        #                             'TOUR_ID']
        #
        # new_col_list = ['TOUR_NAME', 'TOUR_ADDR_N', 'LATITUDE', 'LONGITUDE']
        # df = df[new_col_list]
        #
        # # 칼럼 이름 바꾸기
        # df = df.reset_index()
        # df["index"] = df["index"] + 1
        # df.rename(columns={'index': "ATTRACTION_ID"}, inplace=True)
        #
        # # 추가 칼럼(후에 사용할) 만들어 놓기
        #
        # df.to_sql("TB_ATTRACTION_PLACE", self.engine, if_exists='fail', index=False)
        # self.commit_db()
        # self.create_PK_query('TB_ATTRACTION_PLACE_ID_seq', 'TB_ATTRACTION_PLACE', 'ATTRACTION_ID')
        # self.end_conn()
        #

    def create_PK_query(self, sequence_name, table_name, id_name):
        # pk_example_name : TB_PARKING_ID_seq
        cursor = self.start_conn()
        create_pk_query = f"""
            ALTER TABLE "{table_name}" ADD PRIMARY KEY ("{id_name}");
            CREATE SEQUENCE IF NOT EXISTS public."{sequence_name}"
                INCREMENT 1
                START 1
                MINVALUE 1
                MAXVALUE 2147483647
                CACHE 1
                OWNED BY "{table_name}"."{id_name}";
            ALTER SEQUENCE public."{sequence_name}"
                OWNER TO postgres;
            """
        cursor.execute(create_pk_query)
        self.commit_db()
        self.end_conn()

    @staticmethod
    def config_pd_option():
        # pandas 칼럼 다 보이게 설정
        pd.set_option('display.max_columns', None)
        pd.set_option('display.width', 1000)

    def create_TB_rival_business(self):
        df = pd.read_csv(r"crawling_sources/_dummy_src/가맹점 주변 경쟁업체.csv")
        print(df)
        # with open(r"crawling_sources/_dummy_src/가맹점 주변 경쟁업체.csv", 'r', encoding='utf-8')


if __name__ == '__main__':
    main()
    conn = DBConnector(test_option=True)
    conn.create_TB_rival_business()


