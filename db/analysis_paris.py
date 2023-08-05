import json

import pandas as pd
import psycopg2
from sqlalchemy import create_engine

from class_db_connector import DBConnector


def main():
    controller = AnalysisController(test_option=True)
    controller.config_pd_option()
    controller.get_paris_df()


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
        print(df.head(100))


    @staticmethod
    def config_pd_option():
        # pandas 칼럼 다 보이게 설정
        pd.set_option('display.max_columns', None)
        pd.set_option('display.width', 1000)


if __name__ == '__main__':
    main()
