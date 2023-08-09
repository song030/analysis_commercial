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
from matplotlib import rcParams
from matplotlib.animation import FuncAnimation, PillowWriter

import numpy as np
import warnings


# 한글 환경 설정
def setting_styles_basic():
    rcParams['font.family'] = 'Malgun Gothic'
    rcParams['axes.unicode_minus'] = False

# 인치 → 픽셀 단위 변경
def inch_to_pixel(inch):
    return inch * 0.010416666


# 그래프 경고창 무시
warnings.filterwarnings('ignore')


class Graph:
    # ----- 정보 관련 변수
    # 비교 대상 이름
    models = list()
    
    # --- 표현 종류
    # 라벨 (X)
    ticks = list()      # 이름 리스트
    ticks_size = 0      # x 갯수
    values_x = list()   # x 위치

    # 값 (Y)
    original_data = {}
    # 애니메이션용 값 정보
    ani_data = {}
    max_y = 0
    # 본래 값 정보 리스트

    # ----- 그래프 관련 변수
    graph_type = "bar"
    flg = None
    # frame = 26 → 11 → 21
    total_frame = 21
    interval = 0.01
    width = 0.25
    add = 0

    # 그래프 표현 색상
    colors = ['#181C3F', '#494B6F', '#6B53FF', '#f1A08B', '#eFBC00', '#01DCCD', '#5D99FE', '#2A2D56']
    # 비어있는 파이 표현 색상
    blank_color = "white"

    def __init__(self, width: int, height: int, graph_type="bar"):
        setting_styles_basic()

        # 크기 설정 (인치단위)
        self.flg = plt.figure(figsize=(inch_to_pixel(width), inch_to_pixel(height)))

        # 그래프 초기화
        self.graph_type = graph_type
        if graph_type == "bar":
            plt.bar([], [])

        elif graph_type == "pie":

            self.add = 100 // self.total_frame
            if 100 % self.total_frame > 0:
                self.add += 1

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
    def set_data(self, data: dict):
        self.original_data = data
        self.models = list(data.keys())

        if self.graph_type == "bar":
            self.max_y = 0
            for key, value in data.items():
                max_value = max(value)
                if max_value > self.max_y:
                    self.max_y = max_value
            self.max_y += 5
            plt.ylim(0.1, self.max_y)
            plt.xlim(-1, self.ticks_size * len(self.models))

            for i in range(len(self.models)):
                self.ani_data[self.models[i]] = [0 for _ in range(self.ticks_size)]

        elif self.graph_type == "pie":
            self.ani_data = list(data.values())
            # plt.pie(self.ani_data, labels=self.models, autopct='%.1f%%', shadow=True)

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
                for idx, value in enumerate(values_y):
                    self.ani_data[model][idx] = self.original_data[model][idx] / self.total_frame * frame

                plt.bar(pos, self.ani_data[model], width=self.width, color=self.colors[index])
                index += 1

            plt.legend(self.models, loc=(0.0, 1.02), ncol=3)
            plt.xlim(-1, self.ticks_size)
            plt.ylim(0.1, self.max_y)
            plt.xticks(range(self.ticks_size), labels=self.ticks, fontsize=10, rotation=45)
            plt.tight_layout()

        elif self.graph_type == "pie":
            frame = frame * self.add

            sum = 0
            limit = 0
            size_check = False
            self.ani_data = list()
            # {'Apple':34, 'Banana':32, 'Melon':16, 'Grapes':18}
            for model, value in self.original_data.items():
                if limit == 0:
                    limit = value
                elif frame > limit:
                    limit += value

                if frame <= limit:
                    value = frame - sum
                    size_check = True

                sum += value
                self.ani_data.append(value)

                if size_check:
                    break

            if frame != 100:
                autopct = None
                self.ani_data.append(100 - frame)
                models = self.models[:len(self.ani_data) - 1]
                models.append("")

                colors = self.colors[:len(self.ani_data) - 1]
                colors.append(self.blank_color)
            else:
                autopct = '%.1f%%'
                models = self.models
                colors = self.colors

            plt.pie(self.ani_data, labels=models, autopct=autopct, shadow=True, colors=colors)

    # gif 저장
    def save_gif(self, file_path='graph_ani.gif', repeat=False):
        # 그래프 애니메이션 생성
        graph_ani = FuncAnimation(fig=self.flg, func=self.update, frames=self.total_frame, interval=self.interval, repeat=repeat)
        graph_ani.save(file_path, writer='.pillowWriter', dpi=100, fps=int(self.interval*1000))
        print("그래프 저장 완료")

    # 그래프 출력
    def show_plt(self, repeat=False):
        graph_ani = FuncAnimation(fig=self.flg, func=self.update, frames=self.total_frame, interval=self.interval, repeat=repeat)
        plt.show()

