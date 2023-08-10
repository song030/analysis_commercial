# -----------------------------------------------------------
# 파이썬으로 GIF 또는 맵 구현하는 파이썬 파일입니다.
# 작성자 : 송민정
# 작성일자 : 2023-08-08
# 명령어 예시 :
#       ex)
# 예상 리턴은 관련 함수를 검색바랍니다.
# -----------------------------------------------------------

import sys

import pandas as pd

import common

from Class.FTP import *
from Class.Graph import Graph
from Class.KakaoMap import KakaoMap


class ReportMethod:
    ## 함수 이름을 str로 저장해서 씁니다. (오탈자 예방용) calling_method_name_list ##
    get_selling_area_report = 'get_selling_area_report'
    get_location_report = 'get_location_report'


def main():
    calling_method_name, other_parameters = common.split_system_argument_values(sys.argv)
    # calling_method_name, other_parameters = (ReportMethod.get_selling_area_report, 10)
    factory = MapFactory()
    result = pd.DataFrame

    # 가맹점 조회
    if calling_method_name == ReportMethod.get_selling_area_report:
        # ========== 가맹점/매물정보 분기점 만들기
        selling_area_id = int(other_parameters[0])
        factory.get_selling_area_report(selling_area_id)
        # print(f"메소드 {ReportMethod.get_selling_area_report} 호출됨. 전달된 가맹점 아이디 : {selling_area_id}")

    elif calling_method_name == ReportMethod.get_location_report:
        latitude, longitude = map(float, other_parameters[0], other_parameters[1])
        factory.get_location_report(latitude, longitude)
        # print(f"메소드 {ReportMethod.get_location_report} 호출됨. 전달된 위도 : {latitude},  경도 : {longitude}")

    factory.get_graph()


class MapFactory:

    def __init__(self):
        self.result = None
        self.ftp = FTP()
        self.ftp.connect()
        from db_connector import DBConnector
        from python_controller import Path
        self.conn = DBConnector(test_option=True, config_path=Path().CONFIG_PATH)
        self.file_path = Path().db_connector_path[:-15]

    def get_selling_area_report(self, selling_area_id):
        # ----- 검색 결과 가져오기
        self.result = self.conn.get_selling_area_by_id(selling_area_id)
        # ----- 지도 생성&업로드
        kakao_map = KakaoMap()

        kakao_map.create_map(self.result["LATITUDE"][0], self.result["LONGITUDE"][0], level=3, title=self.result["ADDRESS"][0])
        kakao_map.set_control(True)

        file_path = self.file_path+r"\Map\test_map2.html"

        kakao_map.save_map(file_path)
        self.ftp.save_file(file_path)

    def get_location_report(self, latitude, longitude):
        pass

    def get_graph(self):
        # ----- 그래프 생성&업로드
        # --- bar test
        model1 = self.conn.get_selling_area_by_id(13)
        model2 = self.conn.get_selling_area_by_id(25)

        graph = Graph(700, 500)

        # ========== 그래프데이터 수정하는곳!!
        # graph.set_data([비교대상 df 3개][출력할 컬럼명])
        # df는 원하는 출력순으로 넣어주시면 됩니다.
        # 출력할 컬럼명에 상호 이름(해당 장소를 구분할수 있는 이름)이 와야합니다. 데이터가 dict 형식으로 저장돼
        graph.set_ticks(["학원 500", "버스정거장 500", "횡단보도 500"])
        graph.set_data([self.result, model1, model2], ['SELLING_AREA_ID', 'RIVAL_COUNT_NEAR_500', 'LEISURE_COUNT_NEAR_500', 'LEISURE_COUNT_NEAR_1000'])
        
        file_path = self.file_path+r"\Graph\test_bar.gif"
        graph.save_gif(file_path)
        self.ftp.save_file(file_path)

        # --- pie test
        data = {'Apple': 34, 'Banana': 32, 'Melon': 16, 'Grapes': 18}

        graph = Graph(700, 500, "pie")
        graph.set_color(['silver', 'gold', 'whitesmoke', 'lightgray'])
        graph.set_data(data)

        file_path = self.file_path+r"\Graph\test_pie.gif"
        graph.save_gif(file_path)
        self.ftp.save_file(file_path)
        self.ftp.disconnect()


if __name__ == '__main__':
    main()