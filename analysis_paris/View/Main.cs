using System;
using System.Drawing;
using System.Windows.Forms;

namespace analysis_paris {
    public partial class Main : Form {

        private Button currentButton;
        private Timer gifTimer;

        public Main() {
            InitializeComponent();

            // Gif 설정 이후 애니메이션 1회 재생
            Gif_Start("sample_chart", new PictureBox());

        }

        // 버튼 클릭 구현
        public void SetSelectedButtonUI(object button) {
            var btn = (Button)button;
            //Highlight Button
            btn.BackColor = Color.FromArgb(107, 83, 255);
            btn.ForeColor = Color.WhiteSmoke;
            // Unhighlight Button
            if (currentButton != null && currentButton != btn) {
                currentButton.BackColor = this.BackColor;
                currentButton.ForeColor = Color.FromArgb(124, 141, 181);
            }

            currentButton = btn;
        }

        /// <summary>
        /// 스플리터 슬라이드 애니메이션
        /// </summary>
        /// <param name="splitter">대상 스플리터</param>
        /// <param name="isTargetPanel1">슬라이드할 패널이 1인지 여부</param>
        /// <param name="stepSize">슬라이드 간격 : 클수록 빨라짐</param>
        public void SplitterAnimationCollapse(SplitContainer splitter, bool isTargetPanel1, int stepSize) {
            try {
                int originalDistance = Convert.ToInt32(splitter.Tag); // 태그에 저장한 스플리터 기준 위치
                int currentDistance = splitter.SplitterDistance; // 현재 스플리터 위치

                if (isTargetPanel1) { // panel1 토글

                    if (splitter.Panel1Collapsed) { // panel1 펼치기
                        splitter.Panel1Collapsed = false;
                        while (true) {
                            currentDistance += stepSize;

                            if (currentDistance >= originalDistance) {
                                splitter.SplitterDistance = originalDistance;
                                break;
                            }

                            splitter.SplitterDistance = currentDistance;
                            Application.DoEvents();
                        }
                    }
                    else { // panel1 접기
                        while (true) {
                            currentDistance -= stepSize;

                            if (currentDistance <= 0) {
                                splitter.Panel1Collapsed = true;
                                break;
                            }

                            splitter.SplitterDistance = currentDistance;
                            Application.DoEvents();
                        }
                    }
                }
                else { // panel2 토글

                    if (splitter.Panel2Collapsed) { // panel2 펼치기
                        splitter.Panel2Collapsed = false;
                        splitter.SplitterDistance = splitter.Width;

                        while (true) {
                            currentDistance -= stepSize;

                            if (currentDistance <= originalDistance) {
                                splitter.SplitterDistance = originalDistance;
                                break;
                            }

                            splitter.SplitterDistance = currentDistance;
                            Application.DoEvents();
                        }
                    }
                    else { // panel2 접기
                        while (true) {
                            currentDistance += stepSize;

                            if (currentDistance >= splitter.Width) {
                                splitter.Panel2Collapsed = true;
                            }

                            splitter.SplitterDistance = currentDistance;
                            Application.DoEvents();
                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        // gif 재생
        private void Gif_Start(string gifName, PictureBox picture) {
            // GIF 파일을 리소스에서 가져오기
            Image gifImage = (Image)Properties.Resources.ResourceManager.GetObject($"{gifName}", System.Globalization.CultureInfo.CurrentUICulture);

            // PictureBox에 GIF 이미지 설정
            picture.Image = gifImage;

            // Timer 설정
            gifTimer = new Timer();
            gifTimer.Interval = gifImage.GetFrameCount(new System.Drawing.Imaging.FrameDimension(gifImage.FrameDimensionsList[0])) * 10; // GIF 애니메이션 지속 시간 설정
            gifTimer.Tick += GifTimer_Tick;

            // Timer 시작
            gifTimer.Enabled = true;
        }

        // 타이머 종료 시 gif 정지
        private void GifTimer_Tick(object sender, EventArgs e) {
            // Timer 중지
            gifTimer.Enabled = false;
            chartGifBox.Enabled = false;
        }

    }
}
