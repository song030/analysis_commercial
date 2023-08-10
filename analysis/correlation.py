import pandas as pd
from scipy.stats import kendalltau
from analysis.make_dataset import MakeParisDatasets, MakeSellingDatasets

class Correlation:
    def __init__(self, df: pd.DataFrame):
        self.df = df

    def show_correlation(self):
        """
        상관관계 측정
        :return:
        """
        # 양의 상관관계를 가지고 유의미한 지표
        plus_list = {}
        # 음의 상관관계를 가지고 유의미한 지표
        minus_list = {}

        for k, v in datasets.items():
            if k != '월매출':
                corr_coefficient, p_value = kendalltau(self.df['월매출'], self.df[k])

                # 결과 출력
                print("상관계수:", corr_coefficient)
                print("유의확률:", p_value)

                # 유의수준 설정 및 유의여부 판단
                alpha = 0.05
                if p_value < alpha:
                    print(f"유의수준 {alpha}에서 월매출과 {k}의 상관관계는 유의미합니다.")
                    if corr_coefficient > 0:
                        plus_list[k] = corr_coefficient
                    elif corr_coefficient < 0:
                        minus_list[k] = corr_coefficient
                else:
                    print(f"유의수준 {alpha}에서 월매출과 {k}의 상관관계는 유의미하지 않습니다.")

        # 상관계수 높은 순 정렬
        # high_plus_corr = sorted(plus_list.items(), key=lambda x: x[1], reverse=True)
        # for t in high_plus_corr:
        #     print(t[0])

        print(f"양의 상관관계 : {plus_list}")
        print(f"음의 상관관계 : {minus_list}")


if __name__ == "__main__":
    # 데이터 생성
    # 매장
    md = MakeParisDatasets()
    datasets = md.get_dataset()
    paris_df = pd.DataFrame(datasets)
    paris_corr = Correlation(paris_df)
    paris_corr.show_correlation()

    # 매물
    md = MakeSellingDatasets()
    datasets = md.get_dataset()
    selling_df = pd.DataFrame(datasets)
    selling_corr = Correlation(paris_df)
    selling_corr.show_correlation()

