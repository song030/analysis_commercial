# -----------------------------------------------------------
# 파이썬으로 GIF 또는 맵 구현하는 파이썬 파일입니다.
# 작성자 : 송민정
# 작성일자 : 2023-08-08
# 명령어 예시 :
#       ex)
# 예상 리턴은 관련 함수를 검색바랍니다.
# -----------------------------------------------------------

import sys
import os

import pandas as pd

import common
import numpy as np

from Class.FTP import *
from Class.Graph import Graph
from Class.KakaoMap import KakaoMap


class ReportMethod:
    ## 함수 이름을 str로 저장해서 씁니다. (오탈자 예방용) calling_method_name_list ##
    get_sale_area_report = 'get_sale_area_report'
    get_location_report = 'get_location_report'


def main():
    calling_method_name, other_parameters = common.split_system_argument_values(sys.argv)
    # calling_method_name, other_parameters = (ReportMethod.get_sale_area_report, 10)
    print(other_parameters)

    ftp = FTP()
    ftp.connect()

    from db_connector import DBConnector
    conn = DBConnector(test_option=True)

    result = pd.DataFrame

    # 가맹점 조회
    if calling_method_name == ReportMethod.get_sale_area_report:

        # ========== 가맹정/매물정보 분기점 만들기

        # ----- 검색 결과 가져오기
        sale_area_id = int(other_parameters[0])
        result = conn.find_paris_by_id(sale_area_id)
        print(f"메소드 {ReportMethod.get_sale_area_report} 호출됨. 전달된 가맹점 아이디 : {sale_area_id}")

        # ----- 지도 생성&업로드
        kakao_map = KakaoMap()

        kakao_map.create_map(result["LATITUDE"][0], result["LONGITUDE"][0], level=3, title=result["PARIS_NAME"][0])
        kakao_map.set_control(True)

        file_path = r"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\Map\test_map2.html"
        kakao_map.save_map(file_path)
        ftp.save_file(file_path)

    elif calling_method_name == ReportMethod.get_location_report:
        latitude, longitude = map(float, other_parameters)
        print(f"메소드 {ReportMethod.get_location_report} 호출됨. 전달된 위도 : {latitude},  경도 : {longitude}")

        # ===== 위경도로 검색하도록 수정 하기
        sale_area_id = int(other_parameters)
        result = conn.find_paris_by_id(sale_area_id)
        print(f"메소드 {ReportMethod.get_sale_area_report} 호출됨. 전달된 가맹점 아이디 : {sale_area_id}")

    # ----- 그래프 생성&업로드
    # --- bar test
    models = ['model A', 'model B', 'model C']
    ticks = ["횡단보도수", "인근 정거장수", "인근 지하철수", "인근 주거 세대수"]
    _range = [45, 150, 6, 76]

    data = dict()
    for i in range(len(models)):
        data[models[i]] = np.random.randint(0, _range, size=len(ticks))
    graph = Graph(700, 500)
    graph.set_ticks(ticks)
    graph.set_data(data)
    file_path = r"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\Graph\test_bar.gif"
    graph.save_gif(file_path)
    ftp.save_file(file_path)

    # --- pie test
    data = {'Apple': 34, 'Banana': 32, 'Melon': 16, 'Grapes': 18}

    graph = Graph(700, 500, "pie")
    graph.set_color(['silver', 'gold', 'whitesmoke', 'lightgray'])
    graph.set_data(data)

    file_path = r"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\Graph\test_pie.gif"
    graph.save_gif(file_path)
    ftp.save_file(file_path)

    ftp.disconnect()


if __name__ == '__main__':
    main()
