import joblib
import pandas as pd
from sklearn.ensemble import RandomForestRegressor
from sklearn.metrics import r2_score, mean_squared_error
from analysis.make_dataset import MakeParisDatasets, MakeSellingDatasets

class PredictValue:
    def __init__(self, train_df: pd.DataFrame, test_df: pd.DataFrame):
        """
        데이터 생성
        :param train_df: 훈련할 데이터
        :param test_df: 예측할 데이터
        """
        self.train_df = train_df
        self.test_df = test_df

    def make_predict_model(self):
        """
        :return: 예측 모델
        """
        # 독립 변수
        X = self.train_df[[
            '학교_500',
            '학교_1000',
            '학원_500',
            '학원_1000',
            '지하철역_500',
            '지하철역_1000',
            '버스정거장_500',
            '버스정거장_1000',
            '여가시설_500',
            '여가시설_1000',
            '일일유동인구',
            '거주인구',
            '거주직장인평균소득',
            '거주인구평균소득'
        ]]
        # 종속변수
        y = self.train_df['월매출']

        test_data = self.test_df[[
            '학교_500',
            '학교_1000',
            '학원_500',
            '학원_1000',
            '지하철역_500',
            '지하철역_1000',
            '버스정거장_500',
            '버스정거장_1000',
            '여가시설_500',
            '여가시설_1000',
            '일일유동인구',
            '거주인구',
            '거주직장인평균소득',
            '거주인구평균소득'
        ]]

        # 랜덤 포레스트 모델 생성
        model = RandomForestRegressor(n_estimators=100)

        # 모델 훈련
        model.fit(X, y)

        # 정규화
        # scaler = MinMaxScaler()
        # normalized_data = scaler.fit_transform(new_df.values)

        joblib.dump(model, 'model.pkl')

        # 결과
        # predicted_prices = model.predict(test_data)

        # 성능 측정
        # y_pred = model.predict(X)
        # mse = mean_squared_error(y, y_pred)
        # r2 = r2_score(y, y_pred)
        # print("평균 제곱 오차 (MSE):", mse)
        # print("R-squared (결정 계수):", r2)

if __name__ == '__main__':
    # 데이터 생성
    # 매장
    md = MakeParisDatasets()
    datasets = md.get_dataset()
    paris_df = pd.DataFrame(datasets)

    # 매물
    md = MakeSellingDatasets()
    datasets = md.get_dataset()
    selling_df = pd.DataFrame(datasets)

    model = PredictValue(paris_df, selling_df)
    model.make_predict_model()