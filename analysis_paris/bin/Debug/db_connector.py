# -----------------------------------------------------------
# 파이썬으로 PostgreSQL 접근하는 파이썬 파일입니다.
# 작성자 : 박광현
# 작성일자 : 2023-08-09
# 명령어 예시 :
#       ex)
# 예상 리턴은 관련 함수를 검색바랍니다.
"""
지도/맵 출력시 필요한 정보에 대해 정리해 보았습니다.

[ 지도 ]
필수 정보 : 위도, 경도
가맹정 : 지점명
매물조회시 : 주소

[ 그래프 ]
대상 : 선택 장소 정보, 점수 높은 매장의 정보, 점수 평균 매장 정보
출력 항목 : 시연님이 지정하는 항목의 이름과 값(임시로 지하철500, 버스500, 횡단보도500, 주거단지500)
조건 : 바로 출력할 값과 파이로 출력할 값의 구분이 필요함
→ 내부 값들은 리스트가 좋음 (ex: 파이 그래프 컬럼 리스트 / 파이 그래프 값 리스트)
"""

# -----------------------------------------------------------
import json
import sys

import psycopg2
from sqlalchemy import create_engine
import pandas as pd

import common


class DBMethod:
    ## 함수 이름을 str로 저장해서 씁니다. (오탈자 예방용) calling_method_name_list ##
    get_all_paris_list = 'get_all_paris_list'
    get_all_selling_area_list = 'get_all_selling_area_list'
    get_paris_by_id = 'get_paris_by_id'
    get_location_information = 'get_location_information'


def main():
    calling_method_name, other_parameters = common.split_system_argument_values(sys.argv)

    if calling_method_name == DBMethod.get_all_paris_list:
        connector = DBConnector(test_option=True)
        connector.find_all_paris()

    elif calling_method_name == DBMethod.get_all_selling_area_list:
        connector = DBConnector(test_option=True)
        connector.find_all_selling_area()

    elif calling_method_name == DBMethod.get_paris_by_id:
        connector = DBConnector(test_option=True)
        paris_id = other_parameters[0]
        connector.find_paris_by_id(paris_id)

    elif calling_method_name == DBMethod.get_location_information:
        connector = DBConnector(test_option=True)
        latitude, longitude = other_parameters
        connector.calculate_location_score(latitude, longitude)


class DBConnector:
    # ===================== BASIC ============================ #
    _instance = None
    CONFIG_PATH = r"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\db_configuration.json"

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

    def end_conn(self):
        if self.conn is not None:
            self.conn.close()
            self.conn = None

    def commit_db(self):
        self.conn.commit()

    def find_all_paris(self):
        self.start_conn()
        pstmt = """select * from "TB_PARIS_FINAL" """
        df = pd.read_sql(pstmt, self.origin_engine)
        print(df.to_json(orient='records'))
        self.end_conn()

    def find_paris_by_id(self, paris_id):
        self.start_conn()
        pstmt = f"""select * from "TB_PARIS_FINAL" where "PARIS_ID" == {paris_id} """
        df = pd.read_sql(pstmt, self.origin_engine)
        print(df.to_json(orient='records'))
        self.end_conn()

    def find_all_selling_area(self):
        self.start_conn()
        pstmt = """select * from "TB_SELLING_AREA" """
        df = pd.read_sql(pstmt, self.origin_engine)
        print(df.to_json(orient='records'))
        self.end_conn()

    def calculate_location_score(self, latitude, longitude):
        print("10점 만점에 10점")

if __name__ == '__main__':
    main()
