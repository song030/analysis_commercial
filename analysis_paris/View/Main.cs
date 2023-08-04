using analysis_paris.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace analysis_paris {
    public partial class Main : Form {

        private CheckedButton currentMode;
        private Timer gifTimer;

        // Constructor
        public Main() {
            InitializeComponent();
        }

        // 화면 출력 시 초기화
        private void Main_Load(object sender, EventArgs e) {
            btnTable.Checked = true;
            splitTableMap.Panel2Collapsed = true;
            splitChart.Panel2Collapsed = true;

            mapBrowser.Navigate("http://song030s.dothome.co.kr/map_test.html");
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

        // 와이드 메뉴 활성화 상태 전환
        private void btnMenuCollapse_Click(object sender, EventArgs e) {
            if (splitMainBoard.Panel1Collapsed) {
                splitMainBoard.Panel1Collapsed = false;
            }
            else {
                splitMainBoard.Panel1Collapsed = true;
            }
        }

        // 그래프 활성화 상태 전환
        private void btnChart_Click(object sender, EventArgs e) {
            if (btnChart.Checked && splitChart.Panel2Collapsed) {
                // 전체 비활성화 상태였을 때
                if (splitDataBoard.Panel2Collapsed) {
                    splitChart.Panel1Collapsed = true;
                    splitDataBoard.Panel2Collapsed = false;
                }

                splitChart.Panel2Collapsed = false;
            }
            else if (!btnChart.Checked && !splitChart.Panel2Collapsed) {
                splitChart.Panel2Collapsed = true;

                // 선택 상태 확인
                if (!btnMap.Checked && !btnTable.Checked) {
                    splitDataBoard.Panel2Collapsed = true;
                    return;
                }
            }
        }

        // 맵 브라우저 활성화 상태 전환
        private void btnMap_Click(object sender, EventArgs e) {
            if (btnMap.Checked && splitTableMap.Panel2Collapsed) {
                // 전체 비활성화 상태였을 때
                if (splitDataBoard.Panel2Collapsed) {
                    splitTableMap.Panel1Collapsed = true;
                    splitDataBoard.Panel2Collapsed = false;
                }

                splitTableMap.Panel2Collapsed = false;
            }
            else if (!btnMap.Checked && !splitTableMap.Panel2Collapsed) {
                splitTableMap.Panel2Collapsed = true;

                // 선택 상태 확인
                if (!btnTable.Checked && !btnChart.Checked) {
                    splitDataBoard.Panel2Collapsed = true;
                    return;
                }
            }
        }

        // 주변 정보 테이블 활성화 상태 전환
        private void btnTable_Click(object sender, EventArgs e) {
            if (btnTable.Checked && splitTableMap.Panel1Collapsed) {
                // 전체 비활성화 상태였을 때
                if (splitDataBoard.Panel2Collapsed) {
                    splitTableMap.Panel2Collapsed = true;
                    splitDataBoard.Panel2Collapsed = false;
                }
                splitTableMap.Panel1Collapsed = false;
            }
            else if (!btnTable.Checked && !splitTableMap.Panel1Collapsed) {
                splitTableMap.Panel1Collapsed = true;

                // 선택 상태 확인
                if (!btnMap.Checked && !btnChart.Checked) {
                    splitDataBoard.Panel2Collapsed = true;
                    return;
                }
            }
        }

        // 현재 활성화된 버튼을 확인한 후 해당 영역을 활성화한다. → 버튼 클릭 이벤트 추려보기
        //private void BoardCategory_Change() {
        //    List<CheckedButton> categoryButtons = new List<CheckedButton> { btnTable, btnMap, btnChart };
        //    foreach (var button in categoryButtons) {
        //        if (!button.Checked) {

        //        }
        //    }
        //}

        // 좌표 검색 버튼 클릭 시 맵 브라우저를 전면 출력한다.
        private void btnCoordinate_Click(object sender, EventArgs e) {

            CheckedButton button = (CheckedButton)sender;

            // 무조건 하나의 버튼이 클릭되어 있어야 한다.
            if (button == currentMode) {
                button.Checked = true;
                return;
            }
            else if (button != currentMode) {
                currentMode = button;

            }

            // 하나의 모드를 선택 하면 다른 모드 버튼은 선택 해제한다.

            // 좌표 검색 버튼 클릭 시 맵 브라우저 전체 출력
            //if (btnCoordinate.Checked && !splitDataBoard.Panel1Collapsed) {
            //    lblCoordinateBar.Visible = true;

            //    btnTable.Checked = false;
            //    btnMap.Checked = true;
            //    btnChart.Checked = false;

            //    splitTableMap.Panel1Collapsed = true;
            //    splitTableMap.Panel2Collapsed = false;  // 지도만 보여주기
            //    splitChart.Panel2Collapsed = true;
            //    splitDataBoard.Panel1Collapsed = true;
            //    splitMainBoard.Panel1Collapsed = true;
            //}
        }
    }
}