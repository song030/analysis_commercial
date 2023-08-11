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
import pickle
import traceback

import joblib
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
    get_selling_area_by_id = 'get_selling_area_by_id'
    get_location_information = 'get_location_information'
    find_paris_by_address = 'find_paris_by_address'
    find_selling_area_by_address = 'find_selling_area_by_address'


def main():
    calling_method_name, other_parameters = common.split_system_argument_values(sys.argv)
    from python_controller import Path  # Path만 가져옴
    connector = DBConnector(test_option=True, config_path=Path().CONFIG_PATH)
    if calling_method_name == DBMethod.get_all_paris_list:
        connector.find_all_paris()

    elif calling_method_name == DBMethod.get_all_selling_area_list:
        connector.find_all_selling_area()

    elif calling_method_name == DBMethod.get_paris_by_id:
        paris_id = other_parameters[0]
        connector.find_paris_by_id(paris_id)

    elif calling_method_name == DBMethod.get_selling_area_by_id:
        selling_area_id = other_parameters[0]
        connector.get_selling_area_by_id(selling_area_id)

    elif calling_method_name == DBMethod.get_location_information:
        latitude, longitude = other_parameters
        connector.calculate_location_score(latitude, longitude)

    elif calling_method_name == DBMethod.find_selling_area_by_address:
        search_word = " ".join(other_parameters[0:])
        connector.find_selling_area_by_address(search_word)

    elif calling_method_name == DBMethod.find_paris_by_address:
        search_word = " ".join(other_parameters[0:])
        connector.find_paris_by_address(search_word)


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
        df.sort_values(by="SCORE", inplace=True, ascending=False)
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

    def get_selling_area_by_id(self, selling_area_id):
        self.start_conn()
        pstmt = f"""select * from "TB_SELLING_AREA" where "SELLING_AREA_ID" = {selling_area_id} """
        df = pd.read_sql(pstmt, self.engine)
        print(df.to_json(orient='records'))
        self.end_conn()
        return df

    def find_all_selling_area(self):
        self.start_conn()
        pstmt = """select * from "TB_SELLING_AREA" """
        df = pd.read_sql(pstmt, self.engine)
        df.sort_values(by="SCORE", inplace=True, ascending=False)
        print(df.to_json(orient='records'))
        self.end_conn()
        return df

    def calculate_location_score(self, latitude, longitude):
        """
        계산해야할 테이블, 칼럼
            TB_SCHOOL - 학교 : 500, 1000
            TB_ACADEMY - 학원 : 500
            TB_STATION - 지하철역 : 500
            TB_BUS_STOP - 버스정거장 : 1000
            TB_LEISURE - 여가시설 : 500 1000
            CRAWLING - 일일 유동인구, 거주인구, 직장인 평균소득, 거주인구 평균소득
            'DAILY_FLOATING_POPULATION', 'LIVING_POPULATION', 'LIVING_WORKER_AVG_REVENUE', 'LIVING_POPULATION_AVG_REVENUE'
        """
        score = 0
        df = self.get_data_frame_by_latitude_and_longitude(latitude, longitude)
        if len(df) != 0:
            result_df = pd.DataFrame(df.iloc[len(df) - 1]).transpose()
            json_string = result_df.to_json()
            data = json.loads(json_string)
            cleaned_data = {key: value["0"] for key, value in data.items()}
            print(cleaned_data)
        SCHOOL_COUNT_NEAR_500 = 0
        SCHOOL_COUNT_NEAR_1000 = 0
        ACADEMY_COUNT_NEAR_500 = 0
        ACADEMY_COUNT_NEAR_1000 = 0
        STATION_COUNT_NEAR_500 = 0
        STATION_COUNT_NEAR_1000 = 0
        STOP_COUNT_NEAR_500 = 0
        STOP_COUNT_NEAR_1000 = 0
        LEISURE_COUNT_NEAR_500 = 0
        LEISURE_COUNT_NEAR_1000 = 0
        RIVAL_COUNT_NEAR_500 = 0
        RIVAL_COUNT_NEAR_1000 = 0
        MONTHLY_SHOP_REVENUE = 0
        DAILY_FLOATING_POPULATION = 0
        LIVING_POPULATION = 0
        LIVING_WORKER_AVG_REVENUE = 0
        LIVING_POPULATION_AVG_REVENUE = 0

        try:
            RIVAL_COUNT_NEAR_500, RIVAL_COUNT_NEAR_1000, MONTHLY_SHOP_REVENUE, DAILY_FLOATING_POPULATION, LIVING_POPULATION, LIVING_WORKER_AVG_REVENUE, LIVING_POPULATION_AVG_REVENUE = \
                self.crawling_elements_with_address(latitude, longitude)
        except:
            # todo 에러 처리 어떻게할지
            result_score = -1
            # traceback.print_exc()
            return result_score

        self.start_conn()
        col_names = ["LATITUDE", "LONGITUDE"]
        pstmt = """ select "LATITUDE", "LONGITUDE" from "TB_SCHOOL" """
        df_school = pd.read_sql(pstmt, self.engine)[col_names]
        SCHOOL_COUNT_NEAR_500, SCHOOL_COUNT_NEAR_1000 = self.count_distance(df_school, latitude, longitude)

        pstmt = """ select "LATITUDE", "LONGITUDE" from "TB_ACADEMY" """
        df_academy = pd.read_sql(pstmt, self.engine)
        ACADEMY_COUNT_NEAR_500, ACADEMY_COUNT_NEAR_1000 = self.count_distance(df_academy, latitude, longitude)

        pstmt = """ select "LATITUDE", "LONGITUDE" from "TB_STATION" """
        df_station = pd.read_sql(pstmt, self.engine)
        STATION_COUNT_NEAR_500, STATION_COUNT_NEAR_1000 = self.count_distance(df_station, latitude, longitude)

        pstmt = """ select "LATITUDE", "LONGITUDE" from "TB_BUS_STOP" """
        df_bus_stop = pd.read_sql(pstmt, self.engine)
        STOP_COUNT_NEAR_500, STOP_COUNT_NEAR_1000 = self.count_distance(df_bus_stop, latitude, longitude)

        pstmt = """ select "위도", "경도" from "TB_LEISURE" """
        df_leisure = pd.read_sql(pstmt, self.engine)  # leisure table 은 column name 수정 필요함
        df_leisure.rename(columns={"위도": "LATITUDE", "경도": "LONGITUDE"}, inplace=True)
        LEISURE_COUNT_NEAR_500, LEISURE_COUNT_NEAR_1000 = self.count_distance(df_leisure, latitude, longitude)

        self.end_conn()

        result_dict = {
            "SCHOOL_COUNT_NEAR_500": [int(SCHOOL_COUNT_NEAR_500)],
            "SCHOOL_COUNT_NEAR_1000": [int(SCHOOL_COUNT_NEAR_1000)],
            "ACADEMY_COUNT_NEAR_500": [int(ACADEMY_COUNT_NEAR_500)],
            "ACADEMY_COUNT_NEAR_1000": [int(ACADEMY_COUNT_NEAR_1000)],
            "STATION_COUNT_NEAR_500": [int(STATION_COUNT_NEAR_500)],
            "STATION_COUNT_NEAR_1000": [int(STATION_COUNT_NEAR_1000)],
            "STOP_COUNT_NEAR_500": [int(STOP_COUNT_NEAR_500)],
            "STOP_COUNT_NEAR_1000": [int(STOP_COUNT_NEAR_1000)],
            "LEISURE_COUNT_NEAR_500": [int(LEISURE_COUNT_NEAR_500)],
            "LEISURE_COUNT_NEAR_1000": [int(LEISURE_COUNT_NEAR_1000)],
            "DAILY_FLOATING_POPULATION": [int(DAILY_FLOATING_POPULATION)],
            "LIVING_POPULATION": [int(LIVING_POPULATION)],
            "LIVING_WORKER_AVG_REVENUE": [int(LIVING_WORKER_AVG_REVENUE)],
            "LIVING_POPULATION_AVG_REVENUE": [int(LIVING_POPULATION_AVG_REVENUE)],
        }
        simulation_df = pd.DataFrame(result_dict)
        EXPECTED_SHOP_REVENUE = self.predict_value_with_model(simulation_df)

        # MONTHLY_SHOP_REVENUE 가 추가되서 Dataset 을 여기서 형성해야함
        result_dict.update({"MONTHLY_SHOP_REVENUE": [int(MONTHLY_SHOP_REVENUE)]})
        result_dict.update({"RIVAL_COUNT_NEAR_500": [int(RIVAL_COUNT_NEAR_500)]})
        result_dict.update({"RIVAL_COUNT_NEAR_1000": [int(RIVAL_COUNT_NEAR_1000)]})
        simulation_df = pd.DataFrame(result_dict)
        data_set_dict = MakeDatasets(simulation_df).get_dataset()

        # Score 계산 로직
        from scoring import Scoring
        score = Scoring(data_set_dict).get_score()

        # DB에 저장할 데이터들
        result_dict.update({"score": [int(score)]})
        result_dict.update({"LATITUDE": [float(latitude)]})
        result_dict.update({"LONGITUDE": [float(longitude)]})
        result_dict.update({"EXPECTED_SHOP_REVENUE": [int(EXPECTED_SHOP_REVENUE)]})

        result_df = pd.DataFrame.from_dict(result_dict)
        result_df.to_sql(name="TB_SEARCH_RESULT", con=self.engine, if_exists="append", schema="public", index=False)

        json_string = result_df.to_json()
        data = json.loads(json_string)
        cleaned_data = {key: value["0"] for key, value in data.items()}
        print(cleaned_data)

    def get_data_frame_by_latitude_and_longitude(self, latitude, longitude):
        pstmt = f"""select * from "TB_SEARCH_RESULT" where "LATITUDE" = {latitude} and "LONGITUDE" = {longitude}"""
        self.start_conn()
        try:
            df = pd.read_sql(pstmt, con=self.engine)
        except:
            df = pd.DataFrame()
        self.end_conn()
        return df

    @staticmethod
    def predict_value_with_model(df):
        """
        모델을 이용해 예측값을 내놓습니다.
        """
        df.rename(columns={
            'SCHOOL_COUNT_NEAR_500': '학교_500',
            'SCHOOL_COUNT_NEAR_1000': '학교_1000',
            'ACADEMY_COUNT_NEAR_500': '학원_500',
            'ACADEMY_COUNT_NEAR_1000': '학원_1000',
            'STATION_COUNT_NEAR_500': '지하철역_500',
            'STATION_COUNT_NEAR_1000': '지하철역_1000',
            'STOP_COUNT_NEAR_500': '버스정거장_500',
            'STOP_COUNT_NEAR_1000': '버스정거장_1000',
            'LEISURE_COUNT_NEAR_500': '여가시설_500',
            'LEISURE_COUNT_NEAR_1000': '여가시설_1000',
            'DAILY_FLOATING_POPULATION': '일일유동인구',
            'LIVING_POPULATION': '거주인구',
            'LIVING_WORKER_AVG_REVENUE': '거주직장인평균소득',
            'LIVING_POPULATION_AVG_REVENUE': '거주인구평균소득'
        }, inplace=True)
        loaded_model = joblib.load('model_random_forest.pkl')
        EXPECTED_SHOP_REVENUE = loaded_model.predict(df)
        return EXPECTED_SHOP_REVENUE[0]

    @staticmethod
    def crawling_elements_with_address(latitude, longitude):
        address = DBConnector.get_address_with_latitude_and_longitude(latitude, longitude)
        if address == '':
            print('ADDRESS_ERROR')
            return
        from selenium import webdriver
        from selenium.webdriver import Keys
        from selenium.webdriver.common.by import By
        from selenium.webdriver import Chrome, ChromeOptions
        import time
        import traceback

        # 화면 작으면 분석 안보임, 크기 키우기
        opts = ChromeOptions()
        opts.add_argument("--window-size=1300,900")
        opts.add_argument('--log-level=3')
        # 창 띄우기
        driver = webdriver.Chrome(options=opts)
        driver.set_window_position(1200, 1600, windowHandle='current')
        driver.implicitly_wait(50)
        driver.get("https://sg.sbiz.or.kr/godo/index.sg")

        # 일주일 안보기
        driver.find_element(By.CSS_SELECTOR, "#help_guide > div > div.foot > div:nth-child(2) > label").click()
        driver.find_element(By.CSS_SELECTOR, "#help_guide > div > div.foot > a").click()

        # 로그인 버튼화면 이동
        page_login_btn = driver.find_element(By.CSS_SELECTOR,
                                             "#menu > div.lay.scrollbarView > div > div.head > div > ul > li > a > span")
        page_login_btn.click()
        time.sleep(1)

        login_id = "mun0392"
        login_pw = "qkrrhkdgus123!"
        edit_line_id = driver.find_element(By.ID, "id")
        edit_line_pw = driver.find_element(By.ID, "pass")
        login_btn = driver.find_element(By.CSS_SELECTOR, "body > div > div.l_content > form > div > input")

        edit_line_id.send_keys(login_id)
        edit_line_pw.send_keys(login_pw)
        login_btn.click()

        container = driver.find_element(By.ID, "container")
        # 첫번째 팝업 끄기
        try:
            x_btn = driver.find_element(By.CLASS_NAME, "option-wrap")
            x_btn.click()
        except:
            traceback.print_exc()
            while True:
                pass
        # 상세분석 버튼 클릭
        detail_btn = container.find_element(By.CSS_SELECTOR, "#toLink > a > h4")
        detail_btn.click()
        time.sleep(3)

        # 좌상단 음식 버튼 클릭
        container = driver.find_element(By.ID, "container")
        food_btn = container.find_element(By.CSS_SELECTOR, "#upjong > ul > li:nth-child(2)")
        food_btn.click()
        time.sleep(0.5)

        # 빵/도넛 클릭
        container = driver.find_element(By.ID, "container")
        bread_btn = container.find_element(By.CSS_SELECTOR,
                                           "#container > div:nth-child(17) > div > div.midd > div.midd > div.searchview.scrollbarView > div > ul > li:nth-child(9) > div > ul > li:nth-child(3) > label > span")
        bread_btn.click()
        time.sleep(0.5)

        # 확인 클릭
        container = driver.find_element(By.ID, "container")
        confirm_btn = container.find_element(By.CSS_SELECTOR, "#checkTypeConfirm > span")
        confirm_btn.click()
        time.sleep(3)

        searching_address = address  # 검색할 주소 부여
        # 검색창 클릭
        container = driver.find_element(By.ID, "container")
        search_box = container.find_element(By.CSS_SELECTOR, "#searchAddress")
        search_box.clear()
        search_box.send_keys(f"{searching_address}")
        search_box.send_keys(Keys.ENTER)
        time.sleep(1.5)

        # 검색 결과 최상단 선택
        searched_label = container.find_element(By.CSS_SELECTOR, "#adrsList > li > label > span")
        searched_label.click()

        # 상권 분석 버튼 클릭
        analysis_sector_btn = container.find_element(By.CSS_SELECTOR,
                                                     "#map > div:nth-child(1) > div > div:nth-child(6) > div:nth-child(2) > div > ul > li.child > label")
        analysis_sector_btn.click()

        radius_sector_btn = container.find_element(By.CSS_SELECTOR,
                                                   "#map > div:nth-child(1) > div > div:nth-child(6) > div:nth-child(2) > div > ul > li.child > div > ul > li:nth-child(2) > label")
        radius_sector_btn.click()

        # 500m 클릭
        distance_btn = container.find_element(By.CSS_SELECTOR,
                                              "#auto_circle > div > div.midd > ul > li:nth-child(5) > label")
        distance_btn.click()
        time.sleep(0.5)

        confirm_btn = container.find_element(By.CSS_SELECTOR,
                                             "#auto_circle > div > div.foot > a:nth-child(2) > span")
        confirm_btn.click()
        time.sleep(0.5)

        # 분석 버튼 클릭
        start_analysis = container.find_element(By.CSS_SELECTOR,
                                                "#map > div:nth-child(1) > div > div:nth-child(6) > div:nth-child(3) > img")
        start_analysis.click()
        time.sleep(5)
        container = driver.find_element(By.ID, "page1")
        rival_count_near_500 = container.find_element(By.CSS_SELECTOR,
                                                      "#page1 > div.report-pop-layer > div.analysis-section.analysis-01 > div.analysis-content > div:nth-child(1) > div > div > span").text
        rival_count_near_500 = rival_count_near_500.replace("개", "").replace(',', '')
        rival_count_near_1000 = container.find_element(By.CSS_SELECTOR,
                                                       "#page1 > div.report-pop-layer > div.analysis-section.analysis-01 > div.analysis-content > div:nth-child(3) > div > div > span").text
        rival_count_near_1000 = rival_count_near_1000.replace("개", "").replace(',', '')
        monthly_shop_revenue = container.find_element(By.CSS_SELECTOR, "#salesSmryInfoCurSaleAmt").text
        monthly_shop_revenue = int(monthly_shop_revenue.replace("만원", "0000").replace(',', ''))
        daily_floating_population = container.find_element(By.CSS_SELECTOR, "#flowPopSmryInfoFlowPop").text
        daily_floating_population = daily_floating_population.replace("명", "").replace(',', '')
        living_population = container.find_element(By.CSS_SELECTOR, "#empAbodePopSmryInfoAbodePop").text
        living_population = living_population.replace("명", "").replace(',', '')
        living_worker_avg_revenue = container.find_element(By.CSS_SELECTOR,
                                                           "#empAbodePopSmryInfoEmpAvgCo").text
        living_worker_avg_revenue = int(living_worker_avg_revenue.replace("만원", "0000").replace(',', ''))
        living_worker_avg_revenue = f"{living_worker_avg_revenue}"
        living_population_avg_revenue = container.find_element(By.CSS_SELECTOR,
                                                               "#empAbodePopSmryInfoAbodeAvgCo").text
        living_population_avg_revenue = int(living_population_avg_revenue.replace("만원", "0000").replace(',', ''))
        living_population_avg_revenue = f"{living_population_avg_revenue}"
        driver.quit()

        return rival_count_near_500, rival_count_near_1000, monthly_shop_revenue, daily_floating_population, living_population, living_worker_avg_revenue, \
            living_population_avg_revenue

    @staticmethod
    def get_address_with_latitude_and_longitude(latitude, longitude):
        import requests
        apiurl = "http://api.vworld.kr/req/address?"
        params = {
            "service": "address",
            "request": "getaddress",
            "crs": "epsg:4326",
            "point": f"{longitude},{latitude}",
            "format": "json",
            "type": "road",
            "key": "9FE80788-D664-31C3-9D9C-219FDABCA26F"
        }

        try:
            response = requests.get(apiurl, params=params)
            if response.status_code == 200:
                json_obj = response.json()
                address = json_obj['response']['result'][0]['text']
                return address
        except:
            return ''

    @staticmethod
    def count_distance(data_frame, latitude, longitude):
        from haversine import haversine
        count_500 = 0
        count_1000 = 0
        for row in data_frame.itertuples():
            distance = haversine((float(latitude), float(longitude)), (row.LATITUDE, row.LONGITUDE), unit='m')
            if distance <= 500:
                count_500 += 1
                count_1000 += 1
            elif 500 < distance <= 1000:
                count_1000 += 1
        return count_500, count_1000

    @staticmethod
    def search_word_cleaning(word: str) -> list[str]:
        result_list = list()
        delete_word_list = ["시", "구", "대로", "번길", "길", "동"]
        for w in delete_word_list:
            word = word.replace(w, '')
        word_list = word.split(" ")
        for w in word_list:
            if not w.isdigit():  # 숫자만 이뤄진 검색어는 제외시키고 검색단어 설정 하기
                result_list.append(w)
        return result_list

    def find_paris_by_address(self, word):
        self.start_conn()
        # 단어를 찢어서 검색하고, 중복되는 것은 제거해야함
        searching_word_list = self.search_word_cleaning(word)
        total_df = pd.DataFrame()
        for w in searching_word_list[::-1]:
            pstmt = f"""select * from "TB_PARIS" where "PARIS_ADDRESS" like %s """
            params = f"%{w}%"
            df = pd.read_sql(pstmt, self.engine, params=(params,))
            total_df = pd.concat([total_df, df])
            total_df.drop_duplicates(["PARIS_ID"], keep="first")
        total_df.sort_values(by="SCORE", inplace=True, ascending=False)
        print(total_df.to_json(orient='records'))
        self.end_conn()
        return total_df

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
        total_df.sort_values(by="SCORE", inplace=True, ascending=False)
        print(total_df.to_json(orient='records'))
        self.end_conn()
        return total_df

    def get_paris_avg(self):
        self.start_conn()
        pstmt = """select * from "TB_PARIS" """
        read_tbl = pd.read_sql(pstmt, con=self.engine)
        df = pd.DataFrame(read_tbl)
        df = df[df.columns.difference(
            ['PARIS_ID', 'PARIS_NAME', 'PARIS_ADDRESS', 'OPEN_DATE', 'CLOSE_DATE', 'IS_OPEN_STATE',
             'CITY'])]
        df = df.mean().astype(int)
        df['PARIS_ID'] = 999
        self.end_conn()
        df = pd.DataFrame(df).transpose()
        print(df)
        return df

    def get_paris_top_10_avg(self):
        self.start_conn()
        pstmt = """select * from "TB_PARIS" order by "SCORE" DESC """
        read_tbl = pd.read_sql(pstmt, con=self.engine)
        df = pd.DataFrame(read_tbl)
        df = df[df.columns.difference(
            ['PARIS_ID', 'PARIS_NAME', 'PARIS_ADDRESS', 'OPEN_DATE', 'CLOSE_DATE', 'IS_OPEN_STATE',
             'CITY'])]
        count_10_percent = int(len(df) * 0.1)
        df = df.head(count_10_percent)
        df = df.mean().astype(int)
        df['PARIS_ID'] = 1000
        self.end_conn()
        df = pd.DataFrame(df).transpose()
        return df

    def get_selling_area_avg(self):
        self.start_conn()
        pstmt = """select * from "TB_SELLING_AREA" """
        read_tbl = pd.read_sql(pstmt, con=self.engine)
        df = pd.DataFrame(read_tbl)

        df = df[df.columns.difference(
            ["SELLING_TYPE",
             'BUILDING_TYPE',
             'CURRENT_STATE',
             'ADDRESS',
             'RELATION_LINK', ])]
        df = df.mean().astype(int)
        df['SELLING_AREA_ID'] = 999
        self.end_conn()
        df = pd.DataFrame(df).transpose()
        print(df)
        return df

    def get_selling_area_top_10_avg(self):
        self.start_conn()
        pstmt = """select * from "TB_SELLING_AREA" order by "SCORE" DESC """
        read_tbl = pd.read_sql(pstmt, con=self.engine)
        df = pd.DataFrame(read_tbl)
        df = df[
            df.columns.difference([
                "SELLING_TYPE",
                'BUILDING_TYPE',
                'CURRENT_STATE',
                'ADDRESS',
                'RELATION_LINK',
            ])]
        count_10_percent = int(len(df) * 0.1)
        df = df.head(count_10_percent)
        df = df.mean().astype(int)
        df['SELLING_AREA_ID'] = 1000
        self.end_conn()
        df = pd.DataFrame(df).transpose()
        return df


class MakeDatasets:
    def __init__(self, df):
        self.data_df = df

    def get_dataset(self):
        """
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
        :return:
        """
        RIVAL_500 = self.data_df.RIVAL_COUNT_NEAR_500.to_list()
        RIVAL_1000 = self.data_df.RIVAL_COUNT_NEAR_1000.to_list()
        MONTHLY_SHOP_REVENUE = self.data_df.MONTHLY_SHOP_REVENUE.to_list()
        LIVING_POPULATION_AVG_REVENUE = self.data_df.LIVING_POPULATION_AVG_REVENUE.to_list()
        LIVING_WORKER_AVG_REVENUE = self.data_df.LIVING_WORKER_AVG_REVENUE.to_list()
        LIVING_POPULATION = self.data_df.LIVING_POPULATION.to_list()
        DAILY_FLOATING_POPULATION = self.data_df.DAILY_FLOATING_POPULATION.to_list()
        ACADEMY_500 = self.data_df.ACADEMY_COUNT_NEAR_500.to_list()
        ACADEMY_1000 = self.data_df.ACADEMY_COUNT_NEAR_1000.to_list()
        SCHOOL_500 = self.data_df.SCHOOL_COUNT_NEAR_500.to_list()
        SCHOOL_1000 = self.data_df.SCHOOL_COUNT_NEAR_1000.to_list()
        LEISURE_500 = self.data_df.LEISURE_COUNT_NEAR_500.to_list()
        LEISURE_1000 = self.data_df.LEISURE_COUNT_NEAR_1000.to_list()
        STATION_500 = self.data_df.STATION_COUNT_NEAR_500.to_list()
        STATION_1000 = self.data_df.STATION_COUNT_NEAR_1000.to_list()
        STOP_500 = self.data_df.STOP_COUNT_NEAR_500.to_list()
        STOP_1000 = self.data_df.STOP_COUNT_NEAR_1000.to_list()

        # 데이터셋 생성
        datasets = {
            '경쟁업체_500': RIVAL_500,
            '경쟁업체_1000': RIVAL_1000,
            '학교_500': SCHOOL_500,
            '학교_1000': SCHOOL_1000,
            '학원_500': ACADEMY_500,
            '학원_1000': ACADEMY_1000,
            '지하철역_500': STATION_500,
            '지하철역_1000': STATION_1000,
            '버스정거장_500': STOP_500,
            '버스정거장_1000': STOP_1000,
            '여가시설_500': LEISURE_500,
            '여가시설_1000': LEISURE_1000,
            '일일유동인구': DAILY_FLOATING_POPULATION,
            '거주인구': LIVING_POPULATION,
            '거주직장인평균소득': LIVING_WORKER_AVG_REVENUE,
            '거주인구평균소득': LIVING_POPULATION_AVG_REVENUE,
            '월매출': MONTHLY_SHOP_REVENUE,
        }
        data_set_df = pd.DataFrame(datasets)
        return data_set_df


if __name__ == '__main__':
    main()
    # from python_controller import Path
    #
    # conn = DBConnector(test_option=True, config_path=Path().CONFIG_PATH)
    # conn.calculate_location_score(37.6855315551009, 126.766235181339)

    # conn.calculate_location_score(37.2399466516839, 127.214951334731)
    # pd.set_option('display.max_columns', None)
    # pd.set_option('display.width', 1000)
    # conn.get_paris_avg()
    # conn.get_paris_top_10_avg()
    # df = conn.get_selling_area_avg()
    # df = conn.get_selling_area_top_10_avg()
    # print(df.ACADEMY_COUNT_NEAR_500[0])
    # conn.get_selling_area_by_id(11)
