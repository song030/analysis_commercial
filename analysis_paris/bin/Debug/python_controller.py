# -----------------------------------------------------------
# C#에서 해당 파이썬 소스를 동작시키는 컨트롤러입니다.
# 작성자 : 박광현
# 작성일자 : 2023-08-07
# 명령어 예시 :
# IN C# Processing source code
#   Arguments = $"{scriptPath} {parameters}";
#       ex) "python_controller get_all_paris_list"; : PARIS 정보 리스트로 가져옴
#       ex) "python_controller get_paris_by_id 24";  : PARIS_ID 24번 정보 가져오기
#       ex) "python_controller get_location_information 37.127445 124.12579"; : 위도 37.127445, 경도 124.12579의 정보 가져오기
# 예상 리턴은 관련 함수를 검색바랍니다.
# -----------------------------------------------------------
#

import getpass

import os
import sys

import common


class Path:

    def __init__(self):
        user_name = getpass.getuser()
        if user_name == "KDT107":
            self.debug_path = r"C:\Users\KDT107\Desktop\analysis_commercial\analysis_paris\bin\Debug"
            self.python_interpreter = r"C:\Users\KDT107\Desktop\analysis_commercial\venv\Scripts\python.exe"
            self.db_connector_path = r"C:\Users\KDT107\Desktop\analysis_commercial\analysis_paris\bin\Debug\db_connector.py"
            self.analysis_report_factory = r"C:\Users\KDT107\Desktop\analysis_commercial\analysis_paris\bin\Debug\analysis_report_factory.py"
            self.CONFIG_PATH = r"C:\Users\KDT107\Desktop\analysis_commercial\analysis_paris\bin\Debug\db_configuration.json"
        elif user_name == "kdt99":
            self.debug_path = r"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug"
            self.python_interpreter = r"C:\Users\kdt99\Desktop\analysis_paris\venv\Scripts\python.exe"
            self.db_connector_path = r"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\db_connector.py"
            self.analysis_report_factory = r"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\analysis_report_factory.py"
            self.CONFIG_PATH = r"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\db_configuration.json"
        elif user_name == "kdt117":
            self.debug_path = r"D:\SMJ\PYTHON\0410\Team\analysis_commericial\analysis_paris\bin\Debug"
            self.python_interpreter = r"C:\Users\kdt117\AppData\Local\Programs\Python\Python311\python.exe"
            self.db_connector_path = r"D:\SMJ\PYTHON\0410\Analysiscommericial\analysis_paris\bin\Debug\db_connector.py"
            self.analysis_report_factory = r"D:\SMJ\PYTHON\0410\Analysiscommericial\analysis_paris\bin\Debug\analysis_report_factory.py"
            self.CONFIG_PATH = r"D:\SMJ\PYTHON\0410\Analysiscommericial\analysis_paris\bin\Debug\db_configuration.json"
        elif user_name == "kdt112":
            self.debug_path = r"C:\Users\kdt112\Desktop\analysis_commercial\analysis_paris\bin\Debug"
            self.python_interpreter = r"C:\Users\kdt112\AppData\Local\Programs\Python\Python311\python.exe"
            self.db_connector_path = r"C:\Users\kdt112\Desktop\analysis_commercial\analysis_paris\bin\Debug\db_connector.py"
            self.analysis_report_factory = r"C:\Users\kdt112\Desktop\analysis_commercial\analysis_paris\bin\Debug\analysis_report_factory.py"
            self.CONFIG_PATH = r"C:\Users\kdt112\Desktop\analysis_commercial\analysis_paris\bin\Debug\db_configuration.json"


class Method:
    ## 함수 이름을 str로 저장해서 씁니다. (오탈자 예방용) calling_method_name_list ##
    get_all_paris_list = 'get_all_paris_list'
    get_paris_by_id = 'get_paris_by_id'
    get_all_selling_area_list = 'get_all_selling_area_list'
    get_selling_area_report = 'get_selling_area_report'
    get_location_report = 'get_location_report'
    get_location_information = 'get_location_information'
    find_selling_area_by_address = 'find_selling_area_by_address'
    get_selling_area_by_id = 'get_selling_area_by_id'
    find_paris_by_address = 'find_paris_by_address'


def main():
    """
    calling_method_name에 따라 다르게 결과값을 도출하도록 동작하도록 합니다.
    parameter는 필수가 아닙니다.
    :return:
    """
    calling_method_name, other_parameters = common.split_system_argument_values(sys.argv)
    other_parameters = " ".join(other_parameters)  # string으로 다시 보낼 예정이라 join 필요
    path = Path()
    if calling_method_name in [Method.get_all_paris_list,
                               Method.get_paris_by_id,
                               Method.get_all_selling_area_list,
                               Method.find_selling_area_by_address,
                               Method.get_selling_area_by_id,
                               Method.find_paris_by_address,
                               Method.get_location_information]:
        os.system(f"{path.python_interpreter} {path.db_connector_path} {calling_method_name} {other_parameters}")

    elif calling_method_name in [Method.get_selling_area_report, Method.get_location_report]:
        os.system(f"{path.python_interpreter} {path.analysis_report_factory} {calling_method_name} {other_parameters}")

    else:
        raise "함수 오류"


if __name__ == '__main__':
    main()