import requests


def using_kakao_api():
    app_key = ''
    rest_api_key = ''
    url = f'https://kapi.kakao.com/v2/user/me?secure_resource=false'
    ACCESS_TOKEN = ""
    headers = {'Authorization': f"Bearer {ACCESS_TOKEN}"}

    try:
        response = requests.get(url, headers=headers)
        response.raise_for_status()
        data = response.json()
        return data
    except requests.exceptions.RequestException as e:
        print(f"Error occurred: {e}")
        return []


def using_SBFinance_api():
    end_point = "http://apis.data.go.kr/1160100/service/GetSBFinanceInfoService"
    category_ = "/getSisInfo"
    encoding_key = ""
    decoding_key = ""
    dict_query = {"serviceKey": f"{decoding_key}", "pageNo": 1, "numOfRows": 10}
    query = ""
    for k, v in dict_query.items():
        query = query + f"?{k}={v}"
    url = end_point + category_ + query

    try:
        response = requests.get(url)
        response.raise_for_status()
        data = response.json()
        return data
    except requests.exceptions.RequestException as e:
        print(f"Error occurred: {e}")
        return []

if __name__ == "__main__":
    results = using_SBFinance_api()
    print(results)
