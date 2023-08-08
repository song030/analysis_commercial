# -----------------------------------------------------------
# 파이썬으로 PostgreSQL 접근하는 파이썬 파일입니다.
# 작성자 : 박광현
# 작성일자 : 2023-08-09
# 명령어 예시 :
#       ex)
# 예상 리턴은 관련 함수를 검색바랍니다.
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
    get_paris_by_id = 'get_paris_by_id'


def main():
    calling_method_name, other_parameters = common.split_system_argument_values(sys.argv)

    if calling_method_name == DBMethod.get_all_paris_list:
        connector = DBConnector(test_option=True)
        connector.find_all_paris()

    elif calling_method_name == DBMethod.get_paris_by_id:
        paris_id = int(other_parameters[0])
        print(f"메소드 {DBMethod.get_paris_by_id} 호출됨. 전달된 빵집 아이디 : {paris_id}")


class DBConnector:
    # ===================== BASIC ============================ #
    _instance = None
    CONFIG_PATH = r"C:\Users\KDT107\Desktop\analysis_commercial\analysis_paris\bin\Debug\db_configuration.json"

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
        # print(df.columns)
        for i in df["PARIS_NAME"]:
            print(i, end="|")


if __name__ == '__main__':
    main()
    # conn = DBConnector()
    # conn.find_all_paris()
