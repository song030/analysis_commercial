using analysis_paris.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace analysis_paris {
    public partial class Main : Form {

        private Timer gifTimer;
        List<Label> ModeLabelList = new List<Label>();

        // Constructor
        public Main() {
            InitializeComponent();
        }

        // 화면 출력 시 초기화
        private void Main_Load(object sender, EventArgs e) {
            // 모드 리스트 구성
            ModeLabelList.Add(lblSearchStore);
            ModeLabelList.Add(lblSearchEiffel);
            ModeLabelList.Add(lblSearchPin);

            // 화면 영역 Collapse 설정
            btnTable.Checked = true;
            splitTableMap.Panel2Collapsed = true;
            splitChart.Panel2Collapsed = true;

            // 맵 브라우저 설정
            mapBrowser.Navigate("http://song030s.dothome.co.kr/Map/test_map.html");
        }

        // 검색 모드 선택 메뉴 영역
        #region MenuArea
        // 프로그램을 종료한다.
        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
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

        // 모드 아이콘 클릭 이벤트
        private void modeGroup_Click(object sender, EventArgs e) {
            var target = (ModeGroupControl)sender;
            int targetIndex = target.CurrentChedckedIndex;

            SelectedLabelChange(targetIndex);
            SetSearchMode(targetIndex);
        }

        // 모드 라벨 클릭 이벤트
        private void modeLabel_Click(object sender, EventArgs e) {
            Label target = (Label)sender;
            int targetIndex = ModeLabelList.IndexOf(target);

            modeIconGroup.SetSelectedMode(targetIndex);
            SelectedLabelChange(targetIndex);
            SetSearchMode(targetIndex);
        }

        // 현재 선택된 모드 라벨 하이라이트 변경
        private void SelectedLabelChange(int targetIndex) {

            foreach (var item in ModeLabelList.Select((value, index) => (value, index))) {
                if (item.index == targetIndex)
                    item.value.ForeColor = Color.FromArgb(254, 218, 36);
                else
                    item.value.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void SetSearchMode(int modeIndex) {
            btnTable.Checked = false;
            btnMap.Checked = false;
            btnChart.Checked = false;

            layoutSearchResult.RowStyles[0].Height = 98;

            switch (modeIndex) {
                case 0:
                    btnTable.Checked = true;
                    DataBoard_Collapse();
                    splitDataBoard.Panel1Collapsed = false;
                    break;

                case 1:
                    btnTable.Checked = true;
                    DataBoard_Collapse();
                    splitDataBoard.Panel1Collapsed = false;
                    break;

                case 2:
                    layoutSearchResult.RowStyles[0].Height = 0;

                    btnMap.Checked = true;
                    DataBoard_Collapse();
                    splitDataBoard.Panel1Collapsed = true;
                    break;
            }
        }
        #endregion

        // 검색창 및 검색 결과 영역
        #region SearchArea
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
        #endregion

        // 데이터 보드 영역
        #region DataBoardCollapse
        // 데이터 버튼 클릭 이벤트
        private void Collapse_Event(object sender, EventArgs e) {
            DataBoard_Collapse();
        }

        // 데이터 시각화 영역 collapse : 현재 활성화된 버튼을 확인한 후 해당 영역을 활성화한다.
        private void DataBoard_Collapse() {
            bool chartCheck = btnChart.Checked;
            bool otherCheck = false;

            if (btnTable.Checked || btnMap.Checked)
                otherCheck = true;

            if (chartCheck && otherCheck) {
                splitDataBoard.Panel2Collapsed = false;
                splitChart.Panel2Collapsed = false;
                splitChart.Panel1Collapsed = false;
                TableMapBoard_Collapse();
                Gif_Start("http://song030s.dothome.co.kr/Graph/test_graph.gif", chartGifBox);
            }
            else if (chartCheck && !otherCheck) {
                splitDataBoard.Panel2Collapsed = false;
                splitChart.Panel2Collapsed = false;
                splitChart.Panel1Collapsed = true;
                Gif_Start("http://song030s.dothome.co.kr/Graph/test_graph.gif", chartGifBox);
            }
            else if (!chartCheck && otherCheck) {
                splitDataBoard.Panel2Collapsed = false;
                splitChart.Panel1Collapsed = false;
                splitChart.Panel2Collapsed = true;
                TableMapBoard_Collapse();
            }
            else {
                splitDataBoard.Panel1Collapsed = false;
                splitDataBoard.Panel2Collapsed = true;
            }
        }

        // 표-지도 영역 collapse
        private void TableMapBoard_Collapse() {
            bool tableCheck = btnTable.Checked;
            bool mapCheck = btnMap.Checked;

            if (tableCheck && !mapCheck) {
                splitTableMap.Panel1Collapsed = false;
                splitTableMap.Panel2Collapsed = true;
            }
            else if (!tableCheck && mapCheck) {
                splitTableMap.Panel2Collapsed = false;
                splitTableMap.Panel1Collapsed = true;
            }
            else {
                splitTableMap.Panel1Collapsed = false;
                splitTableMap.Panel2Collapsed = false;
            }
        }
        #endregion

        // 그래프 gif 재생 제한
        #region GifTimerEvent
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
        #endregion
    }
}