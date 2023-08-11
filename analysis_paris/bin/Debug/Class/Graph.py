# -----------------------------------------------------------
# 파이썬으로 그래프를 GIF로 저장하는 파이썬 파일입니다.
# 작성자 : 송민정
# 작성일자 : 2023-08-08
# 명령어 예시 :
#       ex) ----- bar graph
#       ex) graph = Graph(700, 500) : 객체 생성 (이미지 크기)
#       ex) graph.set_ticks(ticks) : x값 라벨설정
#       ex) graph.set_data(data) : 출력할 데이터 설정 (일단 dict 형식으로 구현 key:model, value:value)
#       ex) graph.show_plt() : 그래프 출력

#       ex) ----- pie graph
#       ex) graph = Graph(700, 500, "pie") : 객체 생성 (이미지 크기, 그래프 종류 설정)
#       ex) graph.set_data(data) : 출력할 데이터 설정 (일단 dict 형식으로 구현 key:name, value:value)
#       ex) graph.save_gif(file_path) : gif 파일로 저장
# 예상 리턴은 관련 함수를 검색바랍니다.
# -----------------------------------------------------------


import matplotlib.pyplot as plt
import pandas as pd
from matplotlib import rcParams
from matplotlib.animation import FuncAnimation, PillowWriter

import numpy as np
import warnings


# 한글 환경 설정
def setting_styles_basic():
    rcParams['animation.writer'] = 'pillow'
    rcParams['font.family'] = 'Malgun Gothic'
    rcParams['axes.unicode_minus'] = False


# 인치 → 픽셀 단위 변경
def inch_to_pixel(inch):
    return inch * 0.010416666


# 그래프 경고창 무시
warnings.filterwarnings(action='ignore')


class Graph:
    def __init__(self, width: int, height: int, graph_type="bar"):
        setting_styles_basic()

        # ----- 정보 관련 변수
        # 비교 대상 이름
        self.models = list()

        # --- 표현 종류
        # 라벨 (X)
        self.ticks = list()  # 이름 리스트
        self.ticks_size = 0  # x 갯수
        self.values_x = list()  # x 위치

        # 값 (Y)
        self.original_data = None
        # 애니메이션용 값 정보
        self.ani_data = None
        self.max_y = 0
        # 본래 값 정보 리스트

        # ----- 그래프 관련 변수
        self.graph_type = "bar"
        self.flg = None
        # frame = 26 → 11 → 21
        self.total_frame = 11
        self.interval = 0.01
        self.width = 0.25
        self.add = 0
        self.delay_frame = 5
        self.total_value = 100

        # 그래프 표현 색상
        self.colors = ['#181C3F', '#494B6F', '#6B53FF', '#f1A08B', '#eFBC00', '#01DCCD', '#5D99FE', '#2A2D56']
        # 비어있는 파이 표현 색상
        self.blank_color = "white"

        # 크기 설정 (인치단위)
        self.flg = plt.figure(figsize=(inch_to_pixel(width), inch_to_pixel(height)))

        # 그래프 초기화
        self.graph_type = graph_type
        if graph_type == "bar":
            plt.bar([], [])

        elif graph_type == "pie":
            plt.pie([], [])

    # 그래프 데이터 표현 색상 설정
    def set_color(self, color: list):
        self.colors = color

    # x값 설정 (이름, 크기, 위치)
    def set_ticks(self, ticks: list):
        self.ticks = ticks
        self.ticks_size = len(ticks)
        self.values_x = [i for i in range(self.ticks_size)]

    # 정보 설정
    def set_data(self, data, columns: list[str] = None):
        if self.graph_type == "bar":
            # [ df, df, df ]
            data: list[pd.DataFrame]

            self.original_data = dict()
            self.models = list()
            self.max_y = 0

            for idx, value in enumerate(data):
                value: pd.DataFrame
                model = value[columns[0]][0]
                if len(model) > 15:
                    model = model[-15:]
                df = value[columns[1:]]
                value = df.values[0]
                self.models.append(model)
                self.original_data[model] = value

                max_value = max(value)
                if max_value > self.max_y:
                    self.max_y = max_value

            self.max_y += 5
            plt.ylim(0.1, self.max_y)
            plt.xlim(-1, self.ticks_size * len(self.models))

            self.ani_data = {}
            for i in range(len(self.models)):
                self.ani_data[self.models[i]] = [0 for _ in range(self.ticks_size)]

        elif self.graph_type == "pie":
            data: dict
            self.models = list(data.keys())
            self.original_data = list(data.values())
            self.ani_data = list(data.values())
            plt.pie(self.ani_data, labels=self.models, shadow=True)

            self.total_value = sum(self.original_data)
            self.add = self.total_value // self.total_frame
            if self.total_value % self.total_frame > 0:
                self.add += 1

    # bar graph - 모델, 요소 종류에 따른 위치 계산
    def compute_pos(self, i):
        index = np.arange(self.ticks_size)
        n = len(self.models)
        correction = i - 0.5 * (n - 1)
        return index + self.width * correction

    # 애니메이션 효과를 위한 값 변화
    def update(self, frame):
        plt.cla()

        if self.graph_type == "bar":
            index = 0
            # 모델 반복 구간
            for model, values_y in self.original_data.items():
                # y값 반복 구간
                pos = self.compute_pos(index)

                if frame >= self.total_frame:
                    plt.bar(pos, self.original_data[model], width=self.width, color=self.colors[index])
                else:
                    for idx, value in enumerate(values_y):
                        self.ani_data[model][idx] = self.original_data[model][idx] / self.total_frame * frame

                    plt.bar(pos, self.ani_data[model], width=self.width, color=self.colors[index])

                index += 1

            plt.legend(self.models, loc=(0.0, 1.02), ncol=3)
            plt.xlim(-1, self.ticks_size)
            plt.ylim(0.1, self.max_y)
            plt.xticks(self.values_x, labels=self.ticks, fontsize=10, rotation=45)
            plt.tight_layout()

        elif self.graph_type == "pie":
            frame = frame * self.add

            if frame >= self.total_value:
                plt.pie(self.original_data, labels=self.models, autopct='%.1f%%', shadow=True, colors=self.colors)
            else:
                _sum = 0
                last_value = 0
                # {'Apple':34, 'Banana':32, 'Melon':16, 'Grapes':18}
                for idx, value in enumerate(self.original_data):
                    _sum += value
                    if frame <= _sum:
                        last_value = frame - (_sum-value)
                        self.ani_data = self.original_data[:idx]
                        break
                    else:
                        last_value = value

                self.ani_data.append(last_value)
                self.ani_data.append(self.total_value - frame)

                _len = len(self.ani_data)-1
                models = self.models[:_len]
                models.append("")

                colors = self.colors[:_len]
                colors.append(self.blank_color)
                plt.pie(self.ani_data, labels=models, shadow=True, colors=colors)

            plt.title("Score 분석")

    # gif 저장
    def save_gif(self, file_path='graph_ani.gif', repeat=False):
        # 그래프 애니메이션 생성
        graph_ani = FuncAnimation(fig=self.flg, func=self.update, frames=self.total_frame + self.delay_frame,
                                  interval=self.interval, repeat=repeat)
        graph_ani.save(file_path, dpi=100, fps=int(self.interval * 1000))
        print("그래프 저장 완료")

    # 그래프 출력
    def show_plt(self, repeat=False):
        graph_ani = FuncAnimation(fig=self.flg, func=self.update, frames=self.total_frame + self.delay_frame,
                                  interval=self.interval, repeat=repeat)
        plt.show()
