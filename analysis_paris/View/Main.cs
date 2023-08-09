using analysis_paris.DAO;
using analysis_paris.Factory;
using analysis_paris.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace analysis_paris {
    public partial class Main : Form {

        private bool gifAnimated = false;
        private Timer gifBarTimer;
        private Timer gifPieTimer;
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
            layoutMapBox.RowStyles[0].Height = 0;
            btnTable.Checked = true;
            splitTableMap.Panel2Collapsed = true;
            splitChart.Panel2Collapsed = true;

            gifBarTimer = new Timer();
            gifBarTimer.Interval = 2600;
            gifBarTimer.Tick += GifBar_Stop;

            gifPieTimer = new Timer();
            gifPieTimer.Interval = 2650;
            gifPieTimer.Tick += GifPie_Stop;

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

        // 검색 모드 변경 시 적용할 내용
        private void SetSearchMode(int modeIndex) {
            btnTable.Checked = false;
            btnMap.Checked = false;
            btnChart.Checked = false;

            layoutMapBox.RowStyles[0].Height = 0;
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
                    layoutMapBox.RowStyles[0].Height = 60;
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
        private void SearchButton_Click(object sender, EventArgs e) {
            int currentSearchMode = modeIconGroup.CurrentChedckedIndex;
            string searchKeyword = string.Empty;

            switch (currentSearchMode) {
                case 0:
                    SellingArea_Search(searchKeyword);
                    break;
                case 1:
                    searchKeyword = searchBox.Text;
                    Paris_Search(searchKeyword);
                    break;
                default:
                    break;
            }
        }

        // 매물 검색 시 ListItemControl 생성
        private void SellingArea_Search(string searchKeyword) {
            string resultString = Percussion.GetScriptResult(TriggerType.AllSellingArea, searchKeyword);

            List<SellingArea> target = JSONConverter.JSONConverterSellingArea(resultString);

            foreach (SellingArea item in target) {
                ListItemControl itemControl = new ListItemControl(item);
                flowSearchList.Controls.Add(itemControl);
            }
        }

        // 기존 매장 검색 시 ListItemControl 생성
        private void Paris_Search(string searchKeyword) {
            string resultString = Percussion.GetScriptResult(TriggerType.ParisById, searchKeyword);

            List<Paris> target = JSONConverter.JSONConverterParis(resultString);

            foreach (Paris item in target) {
                ListItemControl itemcontrol = new ListItemControl(item);
                itemcontrol.Click += ListItem_Click;
                flowSearchList.Controls.Add(itemcontrol);
            }
        }

        // 리스트 아이템 클릭 시 주변 정보 리스트 업데이트
        private void ListItem_Click(object sender, EventArgs e) {
            ListItemControl target = (ListItemControl)sender;

            // 기존 매장 항목 클릭 시
            if (target.SellingArea is null) {
                Console.WriteLine("파리 바게뜨 매장 검색");

                DetailsItemControl detail = new DetailsItemControl();
                flowDetails.Controls.Add(detail);
                DetailsItemControl detail_1 = new DetailsItemControl();
                flowDetails.Controls.Add(detail_1);
                DetailsItemControl detail_2 = new DetailsItemControl();
                flowDetails.Controls.Add(detail_2);
            }

            // 임시 차트 이미지 설정
            SetGraphUrl("http://song030s.dothome.co.kr/Graph/test_bar.gif", "http://song030s.dothome.co.kr/Graph/test_pie.gif");
            gifAnimated = false;
            // 임시 gif 시작!
            GifBar_Start();
            GifPie_Start();
        }

        // 주변 정보 영역이 바뀔 때 컨트롤 사이즈 최적화
        private void flowDetails_SizeChanged(object sender, EventArgs e) {
            flowDetails.SuspendLayout();
            foreach (DetailsItemControl detail in flowDetails.Controls) {
                detail.Width = flowDetails.Width - 20;
            }
            flowDetails.ResumeLayout();
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
            }
            else if (chartCheck && !otherCheck) {
                splitDataBoard.Panel2Collapsed = false;
                splitChart.Panel2Collapsed = false;
                splitChart.Panel1Collapsed = true;
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
        // gif Url 설정
        private void SetGraphUrl(string barUrl, string pieUrl) {
            graphBoxBar.ImageLocation = $"{barUrl}";
            graphBoxPie.ImageLocation = $"{pieUrl}";
        }

        // gifBar gif 재생
        private void GifBar_Start() {
            if (gifAnimated) { return; }

            // Timer 시작
            graphBoxBar.Enabled = true;
            gifBarTimer.Enabled = true;
        }

        // gifPie 재생
        private void GifPie_Start() {
            if (gifAnimated) { return; }

            graphBoxPie.Enabled = true;
            gifPieTimer.Enabled = true;
        }

        // 타이머 종료 시 gif 정지
        private void GifBar_Stop(object sender, EventArgs e) {
            // Timer 중지
            gifBarTimer.Enabled = false;
            graphBoxBar.Enabled = false;
            gifAnimated = true;
        }
        private void GifPie_Stop(object sender, EventArgs e) {
            // Timer 중지
            gifPieTimer.Enabled = false;
            graphBoxPie.Enabled = false;
            gifAnimated = true;
        }

        #endregion

    }
}