def split_system_argument_values(sys_argv: list[str]) -> tuple[str, list[str]]:
    system_parameters = sys_argv[1:]
    calling_method_name = system_parameters[0]
    other_parameters = list()  # 파라미터가 없으면 [], 빈 리스트이고, 있으면 list(str)형태입니다.

    if len(system_parameters) != 1:
        other_parameters.extend(system_parameters[1:])  # 띄워쓰기 대로 구분

    return calling_method_name, other_parameters


def assert_parameters(parameters):
    assert parameters is not None, f"파라미터를 입력해야합니다. 현재 입력값 : {parameters}"