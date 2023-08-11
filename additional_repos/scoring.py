import pandas as pd

from analysis.make_dataset import MakeParisDatasets, MakeSellingDatasets

class Scoring:
    def __init__(self, df: pd.DataFrame):
        mpd = MakeParisDatasets()
        datasets = mpd.get_dataset()
        paris_df = pd.DataFrame(datasets)
        self.paris_df = paris_df


    def get_score(self):
        # 점수 부여
        plus_score_list = [20, 40, 60, 80, 100]
        minus_score_list = [-20, -40, -60, -80, -100]

        #  plus 가중치
        plus_independents = [
            self.paris_df.월매출,
            self.paris_df.거주인구평균소득,
            self.paris_df.거주직장인평균소득,
            self.paris_df.거주인구,
            self.paris_df.학원_500,
            self.paris_df.여가시설_1000,
            self.paris_df.일일유동인구,
            self.paris_df.학교_1000,
            self.paris_df.학원_1000,
            self.paris_df.여가시설_500,
            self.paris_df.학교_500,
            self.paris_df.지하철역_500,
            self.paris_df.지하철역_1000,
            self.paris_df.버스정거장_500,
            self.paris_df.버스정거장_1000,
            self.paris_df.버스정거장_500,
        ]

        # 가중치 총합 1.2
        plus_weights = [
            0.3,  # 월매출
            0.1,  # 거주인구평균소득
            0.1,  # 거주직장인평군소득
            0.05,  # 거주인구
            0.05,  # 학원_500
            0.05,  # 여가시설_1000
            0.05,  # 일일유동인구
            0.05,  # 학교_1000
            0.05,  # 학원_1000
            0.05,  # 여가시설_500
            0.05,  # 학교_500
            0.05,  # 지하철역_500
            0.05,  # 지하철역_1000
            0.05,  # 버스정거장_1000
            0.05  # 버스정거장_500
        ]

        df_list = []
        for independent, weight in zip(plus_independents, plus_weights):
            score_cut = pd.cut(independent, 5, labels=plus_score_list)
            result = score_cut.astype(float) * weight
            result = result.astype(int)
            df_list.append(result.to_frame())

        # minus
        minus_independents = [
            self.paris_df.경쟁업체_500,
            self.paris_df.경쟁업체_1000
        ]

        # 가중치 총합 - 0.2
        minus_weights = [
            -0.1  # 경쟁업체_500
            -0.1  # 경쟁업체_1000
        ]

        for independent, weight in zip(minus_independents, minus_weights):
            score_cut = pd.cut(independent, 5, labels=minus_score_list)
            result = score_cut.astype(float) * weight
            result = result.astype(int)
            df_list.append(result.to_frame())

        # 데이터프레임 합치기
        # df_list.append(self.df.SELLING_AREA_ID.to_frame())
        # concat_df = pd.concat(df_list, axis=1)
        # df_score = concat_df.set_index(keys=['SELLING_AREA_ID'], drop=True)
        df_score = pd.concat(df_list, axis=1)

        # 점수 계산
        df_score['SCORE'] = df_score.sum(axis=1)

        return df_score['SCORE']


if __name__ == '__main__':
    # 데이터 생성

    # 매장
    mpd = MakeParisDatasets()
    datasets = mpd.get_dataset()
    paris_df = pd.DataFrame(datasets)
    paris = Scoring(paris_df)
    paris_score = paris.get_score()
    print(paris_score)

    # 매물
    msd = MakeSellingDatasets()
    datasets = msd.get_dataset()
    selling_df = pd.DataFrame(datasets)
    selling = Scoring(selling_df)
    selling_score = selling.get_score()
    print(selling_score)
