using analysis_paris.DAO;
using analysis_paris.Factory;
using analysis_paris.Resources;
using analysis_paris.View;
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace analysis_paris {
    public partial class Main : Form {

        private ChromiumWebBrowser mapBrowser = null;   // 지도 API 연결할 Control
        private bool gifAnimated = false;   // 그래프 GIF 재생 확인
        private System.Windows.Forms.Timer graphGifTimer;   // 그래프 GIf 타이머
        List<Label> ModeLabelList = new List<Label>();  // 검색 모드 라벨 리스트
        SellingArea targetArea = null;  // 최종 보고서에 출력할 매물 정보

        // Constructor
        public Main() {
            InitializeComponent();
        }

        // 화면 출력 시 초기화
        private void Main_Load(object sender, EventArgs e) {
            CoverForm coverForm = new CoverForm();
            coverForm.ShowDialog();

            #region Cef Sharp
            // 객체 생성
            CefSettings settings = new CefSettings();
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            Cef.Initialize(settings);

            //웹 사이트 이동
            mapBrowser = new ChromiumWebBrowser("http://song030s.dothome.co.kr/Map/test_map2.html");
            //한국어 설정
            mapBrowser.BrowserSettings.AcceptLanguageList = "ko-KR";
            //Main Form에 CefSharp컨트롤 추가
            this.layoutMapBox.Controls.Add(mapBrowser, 0, 1);
            //Main Form 전체 영역에 붙이기
            mapBrowser.Dock = DockStyle.Fill;
            #endregion

            // 모드 리스트 구성
            ModeLabelList.Add(lblSearchStore);
            ModeLabelList.Add(lblSearchEiffel);
            ModeLabelList.Add(lblSearchPin);

            // 화면 영역 Collapse 설정
            layoutMapBox.RowStyles[0].Height = 0;
            btnTable.Checked = true;
            btnChart.Enabled = false;
            splitTableMap.Panel2Collapsed = true;
            splitChart.Panel2Collapsed = true;

            // 그래프 타이머 설정
            graphGifTimer = new System.Windows.Forms.Timer();
            graphGifTimer.Interval = 1580;
            graphGifTimer.Tick += Graph_Stop;
        }

        // 로딩 화면 출력
        private void Loading_Start() {
            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            splashthread.IsBackground = true;
            splashthread.Start();
        }

        // 검색 모드 선택 메뉴 영역
        #region MenuArea
        // 프로그램 종료 버튼 hover event → Gif로 변경 예정
        private void btnExit_MouseHover(object sender, EventArgs e) {
            btnExit.Image = Properties.Resources.icon_exit_y;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e) {
            btnExit.Image = Properties.Resources.icon_exit_w;
        }

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
            SearchArea_Clear();

            btnSearchClose.Enabled = true;
            btnTable.Enabled = true;
            btnChart.Enabled = false;
            btnSearchClose.Checked = false;
            btnTable.Checked = false;
            btnMap.Checked = false;
            btnChart.Checked = false;

            layoutMapBox.RowStyles[0].Height = 0;
            layoutSearchResult.RowStyles[0].Height = 98;

            btnGoAhead.Visible = false;

            if (modeIndex != 2)
                btnMap.Enabled = true;

            mapBrowser.LoadUrl("http://song030s.dothome.co.kr/Map/test_map2.html");

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
                    // 좌표 검색 화면으로 전환
                    mapBrowser.LoadUrl("http://song030s.dothome.co.kr/Map/search.html");
                    layoutSearchResult.RowStyles[0].Height = 0;
                    layoutMapBox.RowStyles[0].Height = 60;
                    btnMap.Checked = true;
                    btnSearchClose.Enabled = false;
                    btnTable.Enabled = false;
                    btnMap.Enabled = false;
                    DataBoard_Collapse();
                    splitDataBoard.Panel1Collapsed = true;
                    break;
            }
        }
        #endregion

        // 검색창 및 검색 결과 영역
        #region SearchArea
        // 검색어 입력 시 Enter 사용 가능
        private void searchBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SearchButton_Click(sender, e);
            }
        }

        // 검색 영역 초기화
        private void SearchArea_Clear() {
            searchBox.Text = string.Empty;
            flowSearchList.Controls.Clear();
            flowDetails.Controls.Clear();
        }

        // 검색 결과 영역이 바뀔 때 컨트롤 사이즈 최적화
        private void flowSearchList_SizeChanged(object sender, EventArgs e) {
            flowSearchList.SuspendLayout();
            foreach (ListItemControl listItem in flowSearchList.Controls) {
                listItem.Width = flowSearchList.Width - 20;
            }
            flowSearchList.ResumeLayout();
            // 스크롤 리셋
            flowSearchList.AutoScroll = false;
            flowSearchList.AutoScroll = true;
        }

        // 검색 버튼 클릭 시
        private void SearchButton_Click(object sender, EventArgs e) {
            int currentSearchMode = modeIconGroup.CurrentChedckedIndex;
            string searchKeyword = searchBox.Text;
            lblSearchAlert.Visible = false;
            flowSearchList.Controls.Clear();



            switch (currentSearchMode) {
                case 0:
                    SellingArea_Search(searchKeyword);
                    break;
                case 1:
                    Paris_Search(searchKeyword);
                    break;
                default:
                    break;
            }
            SplashScreen.CloseSplashScreen();   // 로딩 스레드 종료
        }

        // 주변 정보 영역이 바뀔 때 컨트롤 사이즈 최적화
        private void flowDetails_SizeChanged(object sender, EventArgs e) {
            flowDetails_reset();
        }

        private void flowDetails_reset() {
            flowDetails.SuspendLayout();
            foreach (DetailsItemControl detail in flowDetails.Controls) {
                detail.Width = flowDetails.Width - 20;
            }
            flowDetails.ResumeLayout();
            // 스크롤 리셋
            flowDetails.HorizontalScroll.Maximum = 0;
            flowDetails.AutoScroll = false;
            flowDetails.AutoScroll = true;
        }

        // 검색 박스 닫기 버튼
        private void btnSearchClose_Click(object sender, EventArgs e) {
            CheckableButton target = (CheckableButton)sender;

            if (target.Checked) {
                splitDataBoard.Panel2Collapsed = false;
                splitDataBoard.Panel1Collapsed = true;
            }
            else {
                splitDataBoard.Panel1Collapsed = false;
            }
        }

        #endregion

        // 파이썬 스크립트 실행 후 반환 결과 출력 관련 영역
        #region 
        // 매물 검색 → ListItemControl 생성
        private void SellingArea_Search(string searchKeyword) {
            if (searchKeyword == string.Empty) {
                lblSearchAlert.Visible = true;
                return;
            }

            Loading_Start();    // 로딩 스레드 시작
            string resultString = Percussion.GetScriptResult(TriggerType.SellingAreaAddress, searchKeyword);

            List<SellingArea> target = JSONConverter.JSONConverterSellingArea(resultString);

            if (target.Count == 0) {
                ListItemControl listItemControl = new ListItemControl();
                flowSearchList.Controls.Add(listItemControl);
            }
            else {
                if (target.Count > 400)
                    target = target.GetRange(0, 400);

                foreach (SellingArea item in target) {
                    ListItemControl itemControl = new ListItemControl(item);
                    itemControl.Click += ListItem_Click;
                    flowSearchList.Controls.Add(itemControl);
                }
            }
        }

        // 매장 검색 → ListItemControl 생성
        private void Paris_Search(string searchKeyword) {
            if (searchKeyword == string.Empty) {
                lblSearchAlert.Visible = true;
                return;
            }

            Loading_Start();    // 로딩 스레드 시작
            string resultString = Percussion.GetScriptResult(TriggerType.ParisByAddress, searchKeyword);

            List<Paris> target = JSONConverter.JSONConverterParis(resultString);
            if (target.Count == 0) {
                ListItemControl listItemControl = new ListItemControl();
                flowSearchList.Controls.Add(listItemControl);
            }
            else {
                foreach (Paris item in target) {
                    ListItemControl itemControl = new ListItemControl(item);
                    itemControl.Click += ListItem_Click;
                    flowSearchList.Controls.Add(itemControl);
                }
            }
        }

        // 선택한 좌표로 검색 시 상세 정보 화면 활성화
        private async void mapSearchButton_Click(object sender, EventArgs e) {
            Loading_Start();    // 로딩 스레드 시작

            JavascriptResponse response = await mapBrowser.EvaluateScriptAsync("document.getElementById('clickLatlng').innerHTML");
            string targetLocation = response.Result.ToString();
            string resultString = Percussion.GetScriptResult(TriggerType.LocationInfo, targetLocation);
            resultString = resultString.Replace(Environment.NewLine, string.Empty);
            resultString.Trim();

            if (resultString.Equals("ADDRESS_ERROR") || resultString.Equals("ADDRESS_ERRORADDRESS_ERROR")) {
                SplashScreen.CloseSplashScreen();   // 로딩 스레드 종료
                MessageBox.Show("주소를 조회할 수 없습니다.");
                return;
            }

            flowDetails.Controls.Clear();

            // 좌표 검색 결과
            LocationInfoDTO locationInfo = JSONConverter.JSONConverterLocationInfo(resultString);
            Dictionary<string, Tuple<string, string>> dictionary_ = locationInfo.GetAttributes();

            foreach (var item in dictionary_) {
                if (item.Value.Item2 != "0") {
                    DetailsItemControl detail = new DetailsItemControl(item.Value.Item1, item.Value.Item2);
                    flowDetails.Controls.Add(detail);
                }
            }
            flowDetails_reset();

            btnTable.Enabled = true;
            btnChart.Enabled = true;

            btnTable.Checked = true;
            btnMap.Checked = true;
            btnChart.Checked = true;

            layoutMapBox.RowStyles[0].Height = 0;
            mapBrowser.Refresh();
            DataBoard_Collapse();

            Report_Update(-1, "LocationInfo");
        }

        // 리스트 아이템 클릭 시 주변 정보 리스트 업데이트
        private void ListItem_Click(object sender, EventArgs e) {
            ListItemControl target = (ListItemControl)sender;
            int targetId = new int();

            flowDetails.Controls.Clear();

            Loading_Start();    // 로딩 스레드 시작
            Dictionary<string, Tuple<string, string>> dictionary_;

            // 기존 매장 항목 클릭 시
            if (target.SellingArea is null) {
                targetId = target.ParisInfo.PARIS_ID;
                Report_Update(targetId, "paris");
                dictionary_ = target.ParisInfo.GetAttributes();
            }
            // 매물 항목 클릭 시
            else {
                btnGoAhead.Visible = true;
                targetArea = target.SellingArea;
                targetId = target.SellingArea.SELLING_AREA_ID;
                Report_Update(targetId, "selling_area");
                dictionary_ = target.SellingArea.GetAttributes();
            }

            foreach (var item in dictionary_) {
                if (item.Value.Item2 != "0") {
                    string value_;

                    if ("매매가(만원)보증금(만원)월세(만원)권리금(만원)".Contains(item.Value.Item1) && (item.Value.Item2 == "0" || item.Value.Item2 == string.Empty))
                        value_ = "협의";
                    else {
                        value_ = item.Value.Item2;
                    }
                    DetailsItemControl detail = new DetailsItemControl(item.Value.Item1, value_);
                    flowDetails.Controls.Add(detail);
                }
            }
            flowDetails_reset();
        }

        // 선택 항목에 대한 지도 및 차트 갱신
        private void Report_Update(int targetId, string targetType) {
            if (targetId != -1)
                Percussion.GetScriptResult(TriggerType.StoreReport, $"{targetId} {targetType}");

            mapBrowser.Refresh();
            if (targetId != -1) {
                mapBrowser.LoadUrl("http://song030s.dothome.co.kr/Map/test_map2.html");
            }
            else {
                //mapBrowser.LoadUrl("http://song030s.dothome.co.kr/Map/search.html");
            }
            graphBoxBar.Refresh();
            graphBoxPie.Refresh();
            graphBoxBar.ImageLocation = "http://song030s.dothome.co.kr/Graph/test_bar.gif";
            graphBoxPie.ImageLocation = "http://song030s.dothome.co.kr/Graph/test_pie.gif";

            gifAnimated = false;
            btnChart.Enabled = true;

            SplashScreen.CloseSplashScreen();   // 로딩 스레드 종료

            if (!splitChart.Panel2Collapsed) {
                Graph_Start();
            }
        }
        #endregion

        // 데이터 보드 활성화 관련 이벤트 영역
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

                // gif 시작!
                Graph_Start();
            }
            else if (chartCheck && !otherCheck) {
                splitDataBoard.Panel2Collapsed = false;
                splitChart.Panel2Collapsed = false;
                splitChart.Panel1Collapsed = true;

                // gif 시작!
                Graph_Start();
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
        // graph gif 재생
        private void Graph_Start() {
            if (gifAnimated)
                return;

            graphGifTimer.Start();
            graphBoxPie.Enabled = true;
            graphBoxBar.Enabled = true;
            gifAnimated = true;
        }

        // 타이머 종료 및 gif 정지
        private void Graph_Stop(object sender, EventArgs e) {
            graphBoxBar.Enabled = false;
            graphBoxPie.Enabled = false;
            graphGifTimer.Stop();
        }

        #endregion

        // 진행 시켜 버튼 클릭 이벤트
        private void btnGoAhead_Click(object sender, EventArgs e) {
            GoAheadDialog goAheadDialog = new GoAheadDialog(targetArea);
            goAheadDialog.ShowDialog();
        }
    }
}