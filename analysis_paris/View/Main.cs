using analysis_paris.View;
using System;
using System.Windows.Forms;

namespace analysis_paris {
    public partial class Main : Form {

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

            mapBrowser.Navigate("http://song030s.dothome.co.kr/Map/test_map.html");
        }

        // 프로그램을 종료한다.
        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        // gif 재생
        private void Gif_Start(string imgUrl, PictureBox picture) {
            // GIF 파일을 리소스에서 가져오기
            //Image gifImage = (Image)Properties.Resources.ResourceManager.GetObject($"{gifName}", System.Globalization.CultureInfo.CurrentUICulture);

            // PictureBox에 GIF 이미지 설정
            picture.ImageLocation = imgUrl;

            // Timer 설정
            gifTimer = new Timer();
            // GIF 애니메이션 지속 시간 설정
            //gifTimer.Interval = gifImage.GetFrameCount(new System.Drawing.Imaging.FrameDimension(gifImage.FrameDimensionsList[0])) * 15;
            gifTimer.Interval = 3200;
            gifTimer.Tick += GifTimer_Tick;

            // Timer 시작
            chartGifBox.Enabled = true;
            gifTimer.Enabled = true;
        }

        // 타이머 종료 시 gif 정지
        private void GifTimer_Tick(object sender, EventArgs e) {
            // Timer 중지
            gifTimer.Enabled = false;
            chartGifBox.Enabled = false;
        }

        // 메뉴 버튼 클릭 시 와이드 메뉴 활성화 상태 전환
        private void btnMenuCollapse_Click(object sender, EventArgs e) {
            if (splitMainBoard.Panel1Collapsed) {
                splitMainBoard.Panel1Collapsed = false;
            }
            else {
                splitMainBoard.Panel1Collapsed = true;
            }
        }

        // ======================================= 데이터 보드 영역 활성화 이벤트 ==========================================
        private void Collapse_Event(object sender, EventArgs e) {
            Board_Collapse();
            Table_Map_Collapse();
        }

        // 현재 활성화된 버튼을 확인한 후 해당 영역을 활성화한다. → 버튼 클릭 이벤트 추려보기
        private void Table_Map_Collapse() {
            // 표/지도 체크 확인
            var tableVisible = btnTable.Checked;
            var mapVisible = btnMap.Checked;

            if (!tableVisible && !mapVisible) {
                splitChart.Panel1Collapsed = true;

                if (!btnChart.Checked)
                    splitDataBoard.Panel2Collapsed = true;
            }
            else {
                splitDataBoard.Panel2Collapsed = false;
                splitChart.Panel1Collapsed = false;

                if (btnTable.Checked && !btnMap.Checked) {
                    splitTableMap.Panel1Collapsed = false;
                    splitTableMap.Panel2Collapsed = true;
                }
                else if (!btnTable.Checked && btnMap.Checked) {
                    splitTableMap.Panel1Collapsed = true;
                    splitTableMap.Panel2Collapsed = false;
                }
                else {
                    splitTableMap.Panel1Collapsed = false;
                    splitTableMap.Panel2Collapsed = false;
                }
            }
        }

        private void Board_Collapse() {
            // 차트 체크 확인
            if (!btnChart.Checked) {
                if (!btnTable.Checked && !btnMap.Checked) {
                    splitDataBoard.Panel2Collapsed = true;
                    return;
                }

                splitChart.Panel2Collapsed = true;
            }
            else {
                splitDataBoard.Panel2Collapsed = false;
                splitChart.Panel2Collapsed = false;
            }
        }
        // =================================================================================

        // 현재 좌표 검색 버튼 클릭 시 발생할 맵 브라우저 전체 출력 기능 임시 사용 중
        private void buttonEventTest_Click(object sender, EventArgs e) {
            btnTable.Checked = false;
            btnMap.Checked = true;
            btnChart.Checked = false;

            splitTableMap.Panel1Collapsed = true;
            splitTableMap.Panel2Collapsed = false;  // 지도만 보여주기
            splitChart.Panel2Collapsed = true;
            splitDataBoard.Panel1Collapsed = true;
            splitMainBoard.Panel1Collapsed = true;
        }

        // 검색 결과 영역이 바뀔 때 컨트롤 사이즈 최적화
        private void flowSearchList_SizeChanged(object sender, EventArgs e) {
            flowSearchList.SuspendLayout();
            foreach (ListItemControl listItem in flowSearchList.Controls) {
                listItem.Width = flowSearchList.Width - 20;
            }
            flowSearchList.ResumeLayout();
        }

        // 검색 버튼 클릭 시
        private void btnSearch_Click(object sender, EventArgs e) {
            while (true) {
                var item = new ListItemControl();
                flowSearchList.Controls.Add(item);
                if (flowSearchList.Controls.Count == 10)
                    break;
            }
        }
    }
}