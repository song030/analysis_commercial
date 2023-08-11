import base64
from io import BytesIO
import numpy as np
import matplotlib.pyplot as plt


def get_png_bytes():
    plt.rcParams['axes.unicode_minus'] = False
    data = np.random.normal(0, 1, 100)

    plt.boxplot(data)

    figfile = BytesIO()

    plt.savefig(figfile, format='png')
    image_bytes = figfile.getvalue()
    return base64.b64encode(image_bytes).decode()


if __name__ == '__main__':
    png_base64 = get_png_bytes()
    print(png_base64)