# -----------------------------------------------------------
# C#에서 해당 파이썬 소스를 동작시키는 컨트롤러입니다.
# 작성자 : 박광현
# 작성일자 : 2023-08-07
# 명령어 예시 :
# IN C# Processing source code
#   Arguments = $"{scriptPath} {parameters}";
#       ex) "python_controller get_paris_list"; : PARIS 정보 리스트로 가져옴
#       ex) "python_controller get_paris_report 24";  : PARIS_ID 24번 정보 가져오기
#       ex) "python_controller get_sale_area_report 1511";  : SALE_AREA_ID 1511번 정보 가져오기
#       ex) "python_controller get_location_report 37.127445 124.12579"; : 위도 37.127445, 경도 124.12579의 정보 가져오기
# 예상 리턴은 관련 함수를 검색바랍니다.
# -----------------------------------------------------------
#
""" 팀장님 추가해야하는 클래스 + 메서드
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

    public List<Paris> JSONConverterParis(string json_str) {
        var parisList = JsonConvert.DeserializeObject<List<Paris>>(json_str);
        return parisList;
    }
    public List<SellingArea> JSONConverterSellingArea(string json_str) {
        var parisList = JsonConvert.DeserializeObject<List<SellingArea>>(json_str);
        return parisList;
    }



"""

import os
import sys

import common


class Path:
    python_interpreter = r"""C:\Users\kdt99\Desktop\analysis_paris\venv\Scripts\python.exe"""
    db_connector_path = r"""C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\db_connector.py"""
    analysis_report_factory = r"""C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\analysis_report_factory.py"""


class Method:
    ## 함수 이름을 str로 저장해서 씁니다. (오탈자 예방용) calling_method_name_list ##
    get_all_paris_list = 'get_all_paris_list'
    get_paris_by_id = 'get_paris_by_id'
    get_all_selling_area_list = 'get_all_selling_area_list'
    get_sale_area_report = 'get_sale_area_report'
    get_location_report = 'get_location_report'
    get_location_information = 'get_location_information'


def main():
    """
    calling_method_name에 따라 다르게 결과값을 도출하도록 동작하도록 합니다.
    parameter는 필수가 아닙니다.
    :return:
    """
    calling_method_name, other_parameters = common.split_system_argument_values(sys.argv)
    other_parameters = " ".join(other_parameters)  # string으로 다시 보낼 예정이라 join 필요

    if calling_method_name in [Method.get_all_paris_list,
                               Method.get_paris_by_id,
                               Method.get_all_selling_area_list,
                               Method.get_location_information]:
        os.system(f"{Path.python_interpreter} {Path.db_connector_path} {calling_method_name} {other_parameters}")

    elif calling_method_name in [Method.get_sale_area_report, Method.get_location_report]:
        os.system(f"{Path.python_interpreter} {Path.analysis_report_factory} {calling_method_name} {other_parameters}")

    else:
        raise "함수 오류"


if __name__ == '__main__':
    main()
