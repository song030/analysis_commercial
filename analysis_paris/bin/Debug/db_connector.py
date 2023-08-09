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
""" For 팀장님
public class Paris {
        public int PARIS_ID { get; set; }
        public string PARIS_NAME { get; set; }
        public string PARIS_ADDRESS { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public double AREA_SIZE { get; set; }
        public DateTime? OPEN_DATE { get; set; }
        public DateTime? CLOSE_DATE { get; set; }
        public string IS_OPEN_STATE { get; set; }
        public int RIVAL_COUNT_NEAR_500 { get; set; }
        public int RIVAL_COUNT_NEAR_1000 { get; set; }
        public int MONTHLY_SHOP_REVENUE { get; set; }
        public int MONTHLY_SHOP_SALE_TRANSACTION_COUNT { get; set; }
        public int DAILY_FLOATING_POPULATION { get; set; }
        public int LIVING_WORKER_POPULATION { get; set; }
        public int LIVING_WORKER_AVG_REVENUE { get; set; }
        public int LIVING_POPULATION { get; set; }
        public int LIVING_POPULATION_AVG_REVENUE { get; set; }
        public int ATTRACTION_COUNT_NEAR_500 { get; set; }
        public int ATTRACTION_COUNT_NEAR_1000 { get; set; }
        public int ACADEMY_COUNT_NEAR_500 { get; set; }
        public int ACADEMY_COUNT_NEAR_1000 { get; set; }
        public int STOP_COUNT_NEAR_500 { get; set; }
        public int STOP_COUNT_NEAR_1000 { get; set; }
        public int CROSSWALK_COUNT_NEAR_500 { get; set; }
        public int CROSSWALK_COUNT_NEAR_1000 { get; set; }
        public int HOSPITAL_COUNT_NEAR_500 { get; set; }
        public int HOSPITAL_COUNT_NEAR_1000 { get; set; }
        public int PARKING_COUNT_NEAR_500 { get; set; }
        public int PARKING_COUNT_NEAR_1000 { get; set; }
        public int SCHOOL_COUNT_NEAR_500 { get; set; }
        public int SCHOOL_COUNT_NEAR_1000 { get; set; }
        public int STATION_COUNT_NEAR_500 { get; set; }
        public int STATION_COUNT_NEAR_1000 { get; set; }
        public int LIVING_COUNT_NEAR_500 { get; set; }
        public int LIVING_COUNT_NEAR_1000 { get; set; }
        public int RIVAL_NEAR_DISTANCE { get; set; }
        public int LIVING_NEAR_DISTANCE { get; set; }
        public int SCHOOL_NEAR_DISTANCE { get; set; }
        public int ACADEMY_NEAR_DISTANCE { get; set; }
        public int HOSPITAL_NEAR_DISTANCE { get; set; }
        public int STATION_NEAR_DISTANCE { get; set; }
        public int STOP_NEAR_DISTANCE { get; set; }
        public int PARKING_NEAR_DISTANCE { get; set; }
        public int ATTRACTION_NEAR_DISTANCE { get; set; }
        public int CROSSWALK_NEAR_DISTANCE { get; set; }
        public int LEISURE_COUNT_NEAR_500 { get; set; }
        public int LEISURE_COUNT_NEAR_1000 { get; set; }
        public int LEISURE_NEAR_DISTANCE { get; set; }
    }

    public class SellingArea {
        public int SELLING_AREA_ID { get; set; }
        public string SELLING_TYPE { get; set; }
        public string BUILDING_TYPE { get; set; }
        public string CURRENT_STATE { get; set; }
        public string ADDRESS { get; set; }
        public double AREA_SIZE { get; set; }
        public string FLOOR_INFO { get; set; }
        public long DEPOSIT { get; set; }
        public long RATE_PER_MONTH { get; set; }
        public long PREMIUM { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public string RELATION_LINK { get; set; }
        public long SELLING_PRICE { get; set; }
        public int RIVAL_CNT_300 { get; set; }
        public int TOUR_CNT_300 { get; set; }
        public int HOSPITAL_CNT_300 { get; set; }
        public int STOP_CNT_300 { get; set; }
        public int LIVING_CNT_300 { get; set; }
        public int PARKING_CNT_300 { get; set; }
        public int STATION_CNT_300 { get; set; }
        public int SCHOOL_CNT_300 { get; set; }
        public int ACADEMY_CNT_300 { get; set; }
        public int CROSSWALK_CNT_300 { get; set; }
    }

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
    find_selling_area_by_address = 'find_selling_area_by_address'


def main():
    calling_method_name, other_parameters = common.split_system_argument_values(sys.argv)
    from python_controller import Path # Path만 가져옴
    connector = DBConnector(test_option=True, config_path=Path().CONFIG_PATH)
    if calling_method_name == DBMethod.get_all_paris_list:
        connector.find_all_paris()

    elif calling_method_name == DBMethod.get_all_selling_area_list:
        connector.find_all_selling_area()

    elif calling_method_name == DBMethod.get_paris_by_id:
        paris_id = other_parameters[0]
        connector.find_paris_by_id(paris_id)

    elif calling_method_name == DBMethod.get_location_information:
        latitude, longitude = other_parameters
        connector.calculate_location_score(latitude, longitude)

    elif calling_method_name == DBMethod.find_selling_area_by_address:
        search_word = " ".join(other_parameters[0:])
        connector.find_selling_area_by_address(search_word)


class DBConnector:
    # ===================== BASIC ============================ #
    _instance = None
    def read_config(self):
        """db 접속 정보는 config file에서 관리함, json으로 읽어서 dictionary 로 반환함 """
        with open(self.CONFIG_PATH, 'r', encoding='utf-8') as config_file:
            config_dict = json.load(config_file)
            return config_dict

    def __new__(cls, **kwargs):
        if not isinstance(cls._instance, cls):
            cls._instance = object.__new__(cls)
        return cls._instance

    def __init__(self, test_option=False, config_path=None):
        self.conn = None
        self.engine = None
        self.origin_conn = None
        self.origin_engine = None
        self.CONFIG_PATH = config_path
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
        pstmt = """select * from "TB_PARIS" """
        df = pd.read_sql(pstmt, self.engine)[:1]
        print(df.to_json(orient='records'))
        self.end_conn()
        return df

    def find_paris_by_id(self, paris_id):
        self.start_conn()

        pstmt = f"""select * from "TB_PARIS" where "PARIS_ID" = {paris_id} """
        df = pd.read_sql(pstmt, self.engine)

        print(df.to_json(orient='records'))
        self.end_conn()
        return df

    def find_all_selling_area(self):
        self.start_conn()
        pstmt = """select * from "TB_SELLING_AREA" """
        df = pd.read_sql(pstmt, self.engine)
        print(df.to_json(orient='records'))
        self.end_conn()
        return df

    def calculate_location_score(self, latitude, longitude):
        print("10점 만점에 10점")

    @staticmethod
    def search_word_cleaning(word: str) -> list[str]:
        result_list = list()
        delete_word_list = ["시", "구", "대로", "번길", "길", "동"]
        for w in delete_word_list:
            word = word.replace(w, '')
        word_list = word.split(" ")
        for w in word_list:
            if not w.isdigit(): # 숫자만 이뤄진 검색어는 제외시키고 검색단어 설정 하기
                result_list.append(w)
        return result_list

    def find_selling_area_by_address(self, word):
        self.start_conn()
        # 단어를 찢어서 검색하고, 중복되는 것은 제거해야함
        searching_word_list = self.search_word_cleaning(word)
        total_df = pd.DataFrame()
        for w in searching_word_list[::-1]:
            pstmt = f"""select * from "TB_SELLING_AREA" where "ADDRESS" like %s """
            params = f"%{w}%"
            df = pd.read_sql(pstmt, self.engine, params=(params,))
            total_df = pd.concat([total_df, df])
            total_df.drop_duplicates(["SELLING_AREA_ID"], keep="first")
        print(total_df.to_json(orient='records'))
        self.end_conn()
        return total_df


if __name__ == '__main__':
    main()
    # conn = DBConnector(test_option=True)
    # conn.find_selling_area_by_address("수원시 권선구")
