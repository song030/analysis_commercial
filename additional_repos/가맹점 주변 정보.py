import json
import os
import warnings

import pandas as pd
import requests
from haversine import haversine
from sqlalchemy import create_engine, text


class Databases():
    def __init__(self):
        self.engine = create_engine('postgresql://postgres:1234@10.10.20.117:5432/db_analysis_test')

    def __del__(self):
        self.engine.dispose()


class StoreListInRadius:
    def __init__(self, lon, lat, radius=1000, pageNo=1, numOfRows=1000, type='json'):
        # url 요청
        warnings.filterwarnings('ignore')
        self.serviceKey = "bFkE1kin%2BQxIOJEUwxIKbJoPniaQKaOv4hGb0GlOAaAzCxUdCok621WZJL8tQMEK8mTvD7IKFFfMlCXRlCO8Hw%3D%3D"
        self.url = f'http://apis.data.go.kr/B553077/api/open/sdsc2/storeListInRadius?radius={radius}&cx={lon}&cy={lat}&numOfRows={numOfRows}&serviceKey={self.serviceKey}&type={type}'
        self.response = requests.get(self.url, verify=False)
        self.r_data = json.loads(self.response.text)

    def get_dataframe(self):
        try:
            df = pd.DataFrame(self.r_data['body']['items'])
        except:
            df = pd.DataFrame(self.r_data['body']['items'], index=[0])
        df.columns = self.r_data['header']['columns']
        return df


name = '발달상권'

db = Databases()
table_name = '"TB_PARIS"'
read_file = pd.read_sql(f'select * from {table_name}', db.engine)
data_df = pd.DataFrame(read_file)
id_list = data_df.PARIS_ID.to_list()
lon_list = data_df.LONGITUDE.to_list()
lat_list = data_df.LATITUDE.to_list()

# # 가맹정 주변 정보
# for id, lon, lat in zip(id_list, lon_list, lat_list):
#     try:
#         storeList = StoreListInRadius(lon, lat)
#         df = storeList.get_dataframe()
#         distance_list = []
#         rival = df[df.상권업종중분류코드 == 'R103']
#         for i, row in rival.iterrows():
#             distance = haversine((lat, lon), (row.위도, row.경도), unit='m')
#             distance_list.append(distance)
#         rival['PARIS_ID'] = id
#         rival['DISTANCE'] = distance_list
#
#         print(rival)
#         # 최초 생성 이후 mode는 append
#         if not os.path.exists(f'가맹점 주변 {name}.csv'):
#             rival.to_csv(f'가맹점 주변 {name}.csv', index=False, mode='w', encoding='utf-8-sig')
#         else:
#             rival.to_csv(f'가맹점 주변 {name}.csv', index=False, mode='a', encoding='utf-8-sig', header=False)
#     except:
#         print(id)

table_name1 = '"TB_PARIS"'
table_name2 = '"TB_SALES_MARKET"'
col = "PARIS_ID"
type = 'MARKET'
col_1000 = f'{type}_COUNT_NEAR_1000'
col_500 = f'{type}_COUNT_NEAR_500'
col_distance = f'{type}_NEAR_DISTANCE'

db = Databases()
read_file1 = pd.read_sql(f'select * from {table_name1}', db.engine)
data_df1 = pd.DataFrame(read_file1)
id_list = data_df1.PARIS_ID.to_list()
lon_list = data_df1.LONGITUDE.to_list()
lat_list = data_df1.LATITUDE.to_list()

# 비교할 데이터 불러오기
# try:
#     for id, lon, lat in zip(id_list, lon_list, lat_list):
#         db = Databases()
#         read_file2 = pd.read_sql(f'select * from {table_name2}', db.engine)
#         data_df2 = pd.DataFrame(read_file2)
#         for i, row in data_df2.iterrows():
#             distance = haversine((lat, lon), (row.LATITUDE, row.LONGITUDE), unit='m')
#             dict_info = {}
#             if int(distance) <= 1000:
#                 for col in data_df2.columns:
#                     dict_info[col] = []
#                 dict_info['DISTANCE'] = []
#                 dict_info['PARIS_ID'] = []
#                 for k, v in row.items():
#                     dict_info[k].append(v)
#                 dict_info['DISTANCE'].append(distance)
#                 dict_info['PARIS_ID'].append(id)
#                 df_info = pd.DataFrame(dict_info)
#                 print(df_info)
#
#                 if not os.path.exists(f'가맹점 주변 {name}.csv'):
#                     df_info.to_csv(f'가맹점 주변 {name}.csv', index=False, mode='w', encoding='utf-8-sig')
#                 else:
#                     df_info.to_csv(f'가맹점 주변 {name}.csv', index=False, mode='a', encoding='utf-8-sig', header=False)
# except Exception as e:
#     # print(id)
#     print(e)

# 개수 넣기
for id in id_list:
    df_csv = pd.read_csv(f'가맹점 주변 {name}.csv')
    df_csv = df_csv[df_csv.PARIS_ID == id]
    df_info_1000 = df_csv[df_csv.DISTANCE <= 1000]
    df_info_500 = df_csv[df_csv.DISTANCE <= 500]

    cnt_1000 = df_info_1000.PARIS_ID.count()
    cnt_500 = df_info_500.PARIS_ID.count()

    update_query_1000 = f"UPDATE {table_name1} SET \"{col_1000}\" = {cnt_1000}  WHERE \"{col}\" = \'{id}\'"
    update_query_500 = f"UPDATE {table_name1} SET \"{col_500}\" = {cnt_500}  WHERE \"{col}\" = \'{id}\'"

    with db.engine.begin() as conn:
        conn.execute(text(update_query_1000))
        conn.execute(text(update_query_500))

# 가까운 거리 넣기
for id in id_list:
    df_csv = pd.read_csv(f'가맹점 주변 {name}.csv')
    df_csv = df_csv[df_csv.PARIS_ID == id]
    if len(df_csv) != 0:
        df_info_distance = df_csv.DISTANCE.to_list()
        min_distance = min(df_info_distance)
        print(min_distance)
        update_query_distance = f"UPDATE {table_name1} SET \"{col_distance}\" = {int(min_distance)}  WHERE \"{col}\" = \'{id}\'"
        with db.engine.begin() as conn:
            conn.execute(text(update_query_distance))
    else:
        update_query_distance = f"UPDATE {table_name1} SET \"{col_distance}\" = {0}  WHERE \"{col}\" = \'{id}\'"
        with db.engine.begin() as conn:
            conn.execute(text(update_query_distance))
