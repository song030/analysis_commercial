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

    ftp = FTP()
    ftp.connect()

    directory = os.getcwd()[:-5]

    if calling_method_name == ReportMethod.get_sale_area_report:
        sale_area_id = int(other_parameters[0])
        print(f"메소드 {ReportMethod.get_sale_area_report} 호출됨. 전달된 매물 아이디 : {sale_area_id}")

        # ===== 검색 결과 가져오는 부분 추가하기

        # ----- 지도 생성&업로드
        latitude = 36.9835439723529
        longitude = 126.920112642654

        kakao_map = KakaoMap()

        kakao_map.create_map(latitude, longitude, 3)
        kakao_map.set_control(True)
        kakao_map.set_mouse_over(True)
        kakao_map.create_main_marker(latitude, longitude, "파리바게뜨 안중현화점", "파리바게뜨 정보입니다.")

        file_path = directory+"Map\\test_map2.html"
        kakao_map.save_map(file_path)
        ftp.save_file(file_path)

    elif calling_method_name == ReportMethod.get_location_report:
        latitude, longitude = map(float, other_parameters)
        print(f"메소드 {ReportMethod.get_location_report} 호출됨. 전달된 위도 : {latitude},  경도 : {longitude}")

        # ===== 검색 결과 가져오는 부분 추가하기

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
    file_path = directory + "Graph\\test_bar.gif"
    graph.save_gif(file_path)
    ftp.save_file(file_path)

    # --- pie test
    data = {'Apple': 34, 'Banana': 32, 'Melon': 16, 'Grapes': 18}

    graph = Graph(700, 500, "pie")
    graph.set_color(['silver', 'gold', 'whitesmoke', 'lightgray'])
    graph.set_data(data)

    file_path = directory + "Graph\\test_pie.gif"
    graph.save_gif(file_path)
    ftp.save_file(file_path)

    ftp.disconnect()


if __name__ == '__main__':
    main()
