import json

import pandas as pd
import psycopg2
from sqlalchemy import create_engine


def main():
    connector = DBConnector(test_option=True)

    connector.migration_TB_SALES()
    # connector.migration_TB_PARKING()
    # connector.migration_TB_LIVING_INFO()
    # connector.config_pd_option()
    # connector.migration_TB_CROSSWALK()
    # connector.create_table()
    # connector.migration_TB_HOSPITAL()
    # connector.migration_TB_ACADEMY()


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

    def migration_TB_PARIS(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        self.start_conn()
        pstmt = """SELECT * FROM "TB_PARIS" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['PARIS_NAME', 'PARIS_ADDRESS', 'LATITUDE', 'LONGITUDE', 'PARIS_NO',
                                    'RIVAL_CNT', 'TOUR_CNT', 'HOSPITAL_CNT', 'STOP_CNT', 'LIVING_CNT',
                                    'PARKING_CNT', 'STATION_CNT', 'SCHOOL_CNT', 'ACADEMY_CNT',
                                    'CROSSWALK_CNT']

        new_col_list = ['LVN_NO', 'LVN_NAME', 'LVN_COUNT', 'LVN_FAMILY', 'LVN_ADDRESS', 'LATITUDE', 'LONGITUDE']
        df = df[new_col_list]

        # 칼럼 이름 바꾸기
        df.rename(columns={"LVN_NO": "LIVING_INFO_ID"}, inplace=True)

        # 추가 칼럼(후에 사용할) 만들어 놓기

        df.to_sql("TB_PARIS", self.engine, if_exists='fail', index=False)
        self.commit_db()

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
    def migration_TB_SALES(self):
        """
        db_TEST -> 'db_analysis_test' or 'db_analysis_main'으로 데이터 복사
        :return:
        """
        self.start_conn()
        pstmt = """SELECT * FROM "TB_SALES" """
        read_table = pd.read_sql(pstmt, self.origin_engine)
        df = pd.DataFrame(read_table)
        # print(df.columns)
        # 칼럼 추출 + 순서 바꾸기
        current_column_name_list = ['MANAGE_NUMBER', 'PARKING_NAME', 'PARKING_CLASS', 'PARKING_TYPE',
                                    'ROAD_ADDRESS', 'BRANCH_ADDRESS', 'PARKING_SAPCE', 'TEL', 'LATITUDE',
                                    'LONGITUDE', 'ID']

        # new_col_list = ['ID', 'PARKING_NAME', 'ROAD_ADDRESS', 'PARKING_TYPE', 'PARKING_SAPCE', 'LATITUDE', 'LONGITUDE']
        # df = df[new_col_list]
        #
        # # 칼럼 이름 바꾸기
        # df.rename(columns={"ID": "PARKING_ID"}, inplace=True)
        # #
        # # # 추가 칼럼(후에 사용할) 만들어 놓기
        # #
        # df.to_sql("TB_SALES_MARKET", self.engine, if_exists='fail', index=False)
        # self.commit_db()
    @staticmethod
    def config_pd_option():
        # pandas 칼럼 다 보이게 설정
        pd.set_option('display.max_columns', None)
        pd.set_option('display.width', 1000)



if __name__ == '__main__':
    main()
