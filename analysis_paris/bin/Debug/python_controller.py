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
import sys


class Method:
    ## 함수 이름을 str로 저장해서 씁니다. (오탈자 예방용) calling_method_name_list ##
    get_paris_list = 'get_paris_list'
    get_paris_report = 'get_paris_report'
    get_sale_area_report = 'get_sale_area_report'
    get_location_report = 'get_location_report'



def main():
    """
    calling_method_name에 따라 다르게 결과값을 도출하도록 동작하도록 합니다.
    parameter는 필수가 아닙니다.
    :return:
    """
    parameter_string = '|'.join(sys.argv[1:])
    input_command = parameter_string.split('|')
    calling_method_name = input_command[0]
    parameters = None  # 파라미터가 없으면 None이고, 있으면 list(str)형태입니다.
    if len(input_command) != 0:
        parameters = input_command[1:]

    if calling_method_name == Method.get_paris_list:
        print('get_paris_list 함수 로직 실행함')

    elif calling_method_name == Method.get_paris_report:
        assert parameters is not None, f"파라미터를 입력해야합니다. 현재 입력값 : {parameters}"
        paris_id = int(parameters[0])
        print(f'PARIS TABLE {paris_id}번 정보를 조회함')

    elif calling_method_name == Method.get_sale_area_report:
        assert parameters is not None, f"파라미터를 입력해야합니다. 현재 입력값 : {parameters}"
        sale_area_id = int(parameters[0])
        print(f'SALE AREA TABLE  {sale_area_id}번 정보를 조회함')


    elif calling_method_name == Method.get_location_report:
        assert parameters is not None and len(parameters) == 2, f"파라미터를 입력해야합니다. 현재 입력값 : {parameters}"
        latitude, longitude = map(int, parameters)
        print(f'위도 : {latitude}, 경도: {longitude} 좌표값으로 크롤링 함')


if __name__ == '__main__':
    main()
