namespace analysis_paris {
    partial class Main {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitMainBoard = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearchStore = new System.Windows.Forms.Label();
            this.lblSearchEiffel = new System.Windows.Forms.Label();
            this.lblSearchPin = new System.Windows.Forms.Label();
            this.layoutMainBoard = new System.Windows.Forms.TableLayoutPanel();
            this.splitDataBoard = new System.Windows.Forms.SplitContainer();
            this.layoutSearchResult = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearchResult = new System.Windows.Forms.Label();
            this.layoutSearchBox = new System.Windows.Forms.TableLayoutPanel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.lblModeName = new System.Windows.Forms.Label();
            this.searchUnderbar = new System.Windows.Forms.Label();
            this.flowSearchList = new System.Windows.Forms.FlowLayoutPanel();
            this.splitChart = new System.Windows.Forms.SplitContainer();
            this.splitTableMap = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSubTableTitle = new System.Windows.Forms.Label();
            this.flowDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutMapBox = new System.Windows.Forms.TableLayoutPanel();
            this.mapBrowser = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.graphBoxBar = new System.Windows.Forms.PictureBox();
            this.graphBoxPie = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblProjectTitle = new System.Windows.Forms.Label();
            this.tblModeMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMenuCollapse = new System.Windows.Forms.Button();
            this.btnSearch = new CustomControls.RoundedButton();
            this.btnTable = new analysis_paris.View.CheckedButton();
            this.btnMap = new analysis_paris.View.CheckedButton();
            this.btnChart = new analysis_paris.View.CheckedButton();
            this.modeIconGroup = new analysis_paris.View.ModeGroupControl();
            this.tableLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMainBoard)).BeginInit();
            this.splitMainBoard.Panel1.SuspendLayout();
            this.splitMainBoard.Panel2.SuspendLayout();
            this.splitMainBoard.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.layoutMainBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDataBoard)).BeginInit();
            this.splitDataBoard.Panel1.SuspendLayout();
            this.splitDataBoard.Panel2.SuspendLayout();
            this.splitDataBoard.SuspendLayout();
            this.layoutSearchResult.SuspendLayout();
            this.layoutSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitChart)).BeginInit();
            this.splitChart.Panel1.SuspendLayout();
            this.splitChart.Panel2.SuspendLayout();
            this.splitChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTableMap)).BeginInit();
            this.splitTableMap.Panel1.SuspendLayout();
            this.splitTableMap.Panel2.SuspendLayout();
            this.splitTableMap.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.layoutMapBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphBoxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphBoxPie)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tblModeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Controls.Add(this.splitMainBoard, 1, 0);
            this.tableLayoutMain.Controls.Add(this.tblModeMenu, 0, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1296, 729);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // splitMainBoard
            // 
            this.splitMainBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMainBoard.Location = new System.Drawing.Point(86, 0);
            this.splitMainBoard.Margin = new System.Windows.Forms.Padding(0);
            this.splitMainBoard.Name = "splitMainBoard";
            // 
            // splitMainBoard.Panel1
            // 
            this.splitMainBoard.Panel1.AccessibleName = "splitPanelMenu";
            this.splitMainBoard.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitMainBoard.Panel2
            // 
            this.splitMainBoard.Panel2.Controls.Add(this.layoutMainBoard);
            this.splitMainBoard.Size = new System.Drawing.Size(1210, 729);
            this.splitMainBoard.SplitterDistance = 126;
            this.splitMainBoard.TabIndex = 144;
            this.splitMainBoard.Tag = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblSearchStore, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSearchEiffel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblSearchPin, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(126, 729);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblSearchStore
            // 
            this.lblSearchStore.AutoSize = true;
            this.lblSearchStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchStore.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSearchStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(36)))));
            this.lblSearchStore.Location = new System.Drawing.Point(0, 86);
            this.lblSearchStore.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.lblSearchStore.Name = "lblSearchStore";
            this.lblSearchStore.Size = new System.Drawing.Size(126, 48);
            this.lblSearchStore.TabIndex = 1;
            this.lblSearchStore.Text = "매물 검색";
            this.lblSearchStore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSearchStore.Click += new System.EventHandler(this.modeLabel_Click);
            // 
            // lblSearchEiffel
            // 
            this.lblSearchEiffel.AutoSize = true;
            this.lblSearchEiffel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchEiffel.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSearchEiffel.ForeColor = System.Drawing.Color.White;
            this.lblSearchEiffel.Location = new System.Drawing.Point(0, 146);
            this.lblSearchEiffel.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.lblSearchEiffel.Name = "lblSearchEiffel";
            this.lblSearchEiffel.Size = new System.Drawing.Size(126, 48);
            this.lblSearchEiffel.TabIndex = 2;
            this.lblSearchEiffel.Text = "매장 검색";
            this.lblSearchEiffel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSearchEiffel.Click += new System.EventHandler(this.modeLabel_Click);
            // 
            // lblSearchPin
            // 
            this.lblSearchPin.AutoSize = true;
            this.lblSearchPin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchPin.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSearchPin.ForeColor = System.Drawing.Color.White;
            this.lblSearchPin.Location = new System.Drawing.Point(0, 206);
            this.lblSearchPin.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.lblSearchPin.Name = "lblSearchPin";
            this.lblSearchPin.Size = new System.Drawing.Size(126, 48);
            this.lblSearchPin.TabIndex = 3;
            this.lblSearchPin.Text = "좌표 검색";
            this.lblSearchPin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSearchPin.Click += new System.EventHandler(this.modeLabel_Click);
            // 
            // layoutMainBoard
            // 
            this.layoutMainBoard.ColumnCount = 1;
            this.layoutMainBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMainBoard.Controls.Add(this.splitDataBoard, 0, 1);
            this.layoutMainBoard.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.layoutMainBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMainBoard.Location = new System.Drawing.Point(0, 0);
            this.layoutMainBoard.Margin = new System.Windows.Forms.Padding(0);
            this.layoutMainBoard.Name = "layoutMainBoard";
            this.layoutMainBoard.RowCount = 2;
            this.layoutMainBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.layoutMainBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMainBoard.Size = new System.Drawing.Size(1080, 729);
            this.layoutMainBoard.TabIndex = 0;
            // 
            // splitDataBoard
            // 
            this.splitDataBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDataBoard.IsSplitterFixed = true;
            this.splitDataBoard.Location = new System.Drawing.Point(20, 82);
            this.splitDataBoard.Margin = new System.Windows.Forms.Padding(20);
            this.splitDataBoard.Name = "splitDataBoard";
            // 
            // splitDataBoard.Panel1
            // 
            this.splitDataBoard.Panel1.Controls.Add(this.layoutSearchResult);
            // 
            // splitDataBoard.Panel2
            // 
            this.splitDataBoard.Panel2.Controls.Add(this.splitChart);
            this.splitDataBoard.Size = new System.Drawing.Size(1040, 627);
            this.splitDataBoard.SplitterDistance = 371;
            this.splitDataBoard.SplitterWidth = 8;
            this.splitDataBoard.TabIndex = 0;
            this.splitDataBoard.Tag = "0";
            // 
            // layoutSearchResult
            // 
            this.layoutSearchResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(255)))));
            this.layoutSearchResult.ColumnCount = 1;
            this.layoutSearchResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSearchResult.Controls.Add(this.lblSearchResult, 0, 1);
            this.layoutSearchResult.Controls.Add(this.layoutSearchBox, 0, 0);
            this.layoutSearchResult.Controls.Add(this.flowSearchList, 0, 2);
            this.layoutSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutSearchResult.Location = new System.Drawing.Point(0, 0);
            this.layoutSearchResult.Margin = new System.Windows.Forms.Padding(0);
            this.layoutSearchResult.Name = "layoutSearchResult";
            this.layoutSearchResult.RowCount = 3;
            this.layoutSearchResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.layoutSearchResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.layoutSearchResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSearchResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutSearchResult.Size = new System.Drawing.Size(371, 627);
            this.layoutSearchResult.TabIndex = 0;
            // 
            // lblSearchResult
            // 
            this.lblSearchResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearchResult.AutoSize = true;
            this.lblSearchResult.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSearchResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.lblSearchResult.Location = new System.Drawing.Point(0, 111);
            this.lblSearchResult.Margin = new System.Windows.Forms.Padding(0);
            this.lblSearchResult.Name = "lblSearchResult";
            this.lblSearchResult.Size = new System.Drawing.Size(63, 16);
            this.lblSearchResult.TabIndex = 1;
            this.lblSearchResult.Text = "검색 결과";
            // 
            // layoutSearchBox
            // 
            this.layoutSearchBox.ColumnCount = 3;
            this.layoutSearchBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSearchBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 286F));
            this.layoutSearchBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.layoutSearchBox.Controls.Add(this.searchBox, 1, 1);
            this.layoutSearchBox.Controls.Add(this.btnSearch, 2, 1);
            this.layoutSearchBox.Controls.Add(this.lblModeName, 0, 0);
            this.layoutSearchBox.Controls.Add(this.searchUnderbar, 0, 3);
            this.layoutSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutSearchBox.Location = new System.Drawing.Point(0, 0);
            this.layoutSearchBox.Margin = new System.Windows.Forms.Padding(0);
            this.layoutSearchBox.Name = "layoutSearchBox";
            this.layoutSearchBox.RowCount = 5;
            this.layoutSearchBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.layoutSearchBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSearchBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.layoutSearchBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.layoutSearchBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.layoutSearchBox.Size = new System.Drawing.Size(371, 98);
            this.layoutSearchBox.TabIndex = 3;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.BackColor = System.Drawing.Color.White;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchBox.Location = new System.Drawing.Point(37, 50);
            this.searchBox.Margin = new System.Windows.Forms.Padding(0);
            this.searchBox.MaxLength = 20;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(286, 26);
            this.searchBox.TabIndex = 1;
            this.searchBox.WordWrap = false;
            // 
            // lblModeName
            // 
            this.lblModeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblModeName.AutoSize = true;
            this.layoutSearchBox.SetColumnSpan(this.lblModeName, 2);
            this.lblModeName.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblModeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.lblModeName.Location = new System.Drawing.Point(0, 13);
            this.lblModeName.Margin = new System.Windows.Forms.Padding(0);
            this.lblModeName.Name = "lblModeName";
            this.lblModeName.Size = new System.Drawing.Size(63, 16);
            this.lblModeName.TabIndex = 6;
            this.lblModeName.Text = "주소 검색";
            // 
            // searchUnderbar
            // 
            this.searchUnderbar.AutoSize = true;
            this.searchUnderbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.layoutSearchBox.SetColumnSpan(this.searchUnderbar, 3);
            this.searchUnderbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchUnderbar.Location = new System.Drawing.Point(0, 89);
            this.searchUnderbar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.searchUnderbar.Name = "searchUnderbar";
            this.searchUnderbar.Size = new System.Drawing.Size(368, 3);
            this.searchUnderbar.TabIndex = 7;
            // 
            // flowSearchList
            // 
            this.flowSearchList.AutoScroll = true;
            this.flowSearchList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowSearchList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(255)))));
            this.flowSearchList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowSearchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSearchList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowSearchList.Location = new System.Drawing.Point(0, 140);
            this.flowSearchList.Margin = new System.Windows.Forms.Padding(0);
            this.flowSearchList.Name = "flowSearchList";
            this.flowSearchList.Size = new System.Drawing.Size(371, 487);
            this.flowSearchList.TabIndex = 4;
            this.flowSearchList.WrapContents = false;
            this.flowSearchList.SizeChanged += new System.EventHandler(this.flowSearchList_SizeChanged);
            // 
            // splitChart
            // 
            this.splitChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChart.Location = new System.Drawing.Point(0, 0);
            this.splitChart.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.splitChart.Name = "splitChart";
            this.splitChart.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitChart.Panel1
            // 
            this.splitChart.Panel1.Controls.Add(this.splitTableMap);
            // 
            // splitChart.Panel2
            // 
            this.splitChart.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitChart.Size = new System.Drawing.Size(661, 627);
            this.splitChart.SplitterDistance = 259;
            this.splitChart.SplitterWidth = 1;
            this.splitChart.TabIndex = 0;
            this.splitChart.Tag = "";
            // 
            // splitTableMap
            // 
            this.splitTableMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTableMap.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitTableMap.Location = new System.Drawing.Point(0, 0);
            this.splitTableMap.Margin = new System.Windows.Forms.Padding(0);
            this.splitTableMap.Name = "splitTableMap";
            // 
            // splitTableMap.Panel1
            // 
            this.splitTableMap.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitTableMap.Panel2
            // 
            this.splitTableMap.Panel2.Controls.Add(this.layoutMapBox);
            this.splitTableMap.Size = new System.Drawing.Size(661, 259);
            this.splitTableMap.SplitterDistance = 330;
            this.splitTableMap.SplitterWidth = 16;
            this.splitTableMap.TabIndex = 0;
            this.splitTableMap.Tag = "292";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblSubTableTitle, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowDetails, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 259);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblSubTableTitle
            // 
            this.lblSubTableTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubTableTitle.AutoSize = true;
            this.lblSubTableTitle.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTableTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.lblSubTableTitle.Location = new System.Drawing.Point(3, 13);
            this.lblSubTableTitle.Name = "lblSubTableTitle";
            this.lblSubTableTitle.Size = new System.Drawing.Size(63, 16);
            this.lblSubTableTitle.TabIndex = 0;
            this.lblSubTableTitle.Text = "주변 정보";
            // 
            // flowDetails
            // 
            this.flowDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowDetails.AutoScroll = true;
            this.flowDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowDetails.Location = new System.Drawing.Point(3, 45);
            this.flowDetails.Name = "flowDetails";
            this.flowDetails.Size = new System.Drawing.Size(324, 211);
            this.flowDetails.TabIndex = 1;
            this.flowDetails.WrapContents = false;
            this.flowDetails.SizeChanged += new System.EventHandler(this.flowDetails_SizeChanged);
            // 
            // layoutMapBox
            // 
            this.layoutMapBox.ColumnCount = 1;
            this.layoutMapBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMapBox.Controls.Add(this.mapBrowser, 0, 1);
            this.layoutMapBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMapBox.Location = new System.Drawing.Point(0, 0);
            this.layoutMapBox.Name = "layoutMapBox";
            this.layoutMapBox.RowCount = 2;
            this.layoutMapBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.layoutMapBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMapBox.Size = new System.Drawing.Size(315, 259);
            this.layoutMapBox.TabIndex = 0;
            // 
            // mapBrowser
            // 
            this.mapBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapBrowser.Location = new System.Drawing.Point(3, 63);
            this.mapBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.mapBrowser.Name = "mapBrowser";
            this.mapBrowser.Size = new System.Drawing.Size(309, 193);
            this.mapBrowser.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lblChartTitle, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(661, 367);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.lblChartTitle.Location = new System.Drawing.Point(0, 13);
            this.lblChartTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(63, 16);
            this.lblChartTitle.TabIndex = 1;
            this.lblChartTitle.Text = "분석 차트";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.graphBoxBar, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.graphBoxPie, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 45);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(655, 319);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // graphBoxBar
            // 
            this.graphBoxBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphBoxBar.Location = new System.Drawing.Point(3, 3);
            this.graphBoxBar.Name = "graphBoxBar";
            this.graphBoxBar.Size = new System.Drawing.Size(321, 313);
            this.graphBoxBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.graphBoxBar.TabIndex = 0;
            this.graphBoxBar.TabStop = false;
            // 
            // graphBoxPie
            // 
            this.graphBoxPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphBoxPie.Location = new System.Drawing.Point(330, 3);
            this.graphBoxPie.Name = "graphBoxPie";
            this.graphBoxPie.Size = new System.Drawing.Size(322, 313);
            this.graphBoxPie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.graphBoxPie.TabIndex = 1;
            this.graphBoxPie.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.Controls.Add(this.lblProjectTitle, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnTable, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMap, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnChart, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(9);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1062, 44);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lblProjectTitle
            // 
            this.lblProjectTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblProjectTitle.AutoSize = true;
            this.lblProjectTitle.Font = new System.Drawing.Font("KBO 다이아고딕 Bold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProjectTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.lblProjectTitle.Location = new System.Drawing.Point(3, 11);
            this.lblProjectTitle.Name = "lblProjectTitle";
            this.lblProjectTitle.Size = new System.Drawing.Size(171, 22);
            this.lblProjectTitle.TabIndex = 5;
            this.lblProjectTitle.Text = "주팀장과 소금빵 공장";
            // 
            // tblModeMenu
            // 
            this.tblModeMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.tblModeMenu.ColumnCount = 1;
            this.tblModeMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblModeMenu.Controls.Add(this.btnExit, 0, 4);
            this.tblModeMenu.Controls.Add(this.btnMenuCollapse, 0, 0);
            this.tblModeMenu.Controls.Add(this.modeIconGroup, 0, 2);
            this.tblModeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblModeMenu.Location = new System.Drawing.Point(0, 0);
            this.tblModeMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tblModeMenu.Name = "tblModeMenu";
            this.tblModeMenu.RowCount = 5;
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblModeMenu.Size = new System.Drawing.Size(86, 729);
            this.tblModeMenu.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.btnExit.Location = new System.Drawing.Point(10, 682);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 33);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMenuCollapse
            // 
            this.btnMenuCollapse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenuCollapse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnMenuCollapse.FlatAppearance.BorderSize = 0;
            this.btnMenuCollapse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnMenuCollapse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnMenuCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuCollapse.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMenuCollapse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(36)))));
            this.btnMenuCollapse.Location = new System.Drawing.Point(10, 13);
            this.btnMenuCollapse.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuCollapse.Name = "btnMenuCollapse";
            this.btnMenuCollapse.Size = new System.Drawing.Size(66, 33);
            this.btnMenuCollapse.TabIndex = 0;
            this.btnMenuCollapse.Text = "메뉴";
            this.btnMenuCollapse.UseVisualStyleBackColor = true;
            this.btnMenuCollapse.Click += new System.EventHandler(this.btnMenuCollapse_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnSearch.BorderRadius = 1;
            this.btnSearch.BorderSize = 2;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("나눔고딕", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnSearch.Location = new System.Drawing.Point(340, 49);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "OK";
            this.btnSearch.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.Color.White;
            this.btnTable.BorderRadius = 3;
            this.btnTable.Checkable = true;
            this.btnTable.Checked = false;
            this.btnTable.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnTable.CheckedForeColor = System.Drawing.Color.White;
            this.btnTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTable.FlatAppearance.BorderSize = 0;
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnTable.Location = new System.Drawing.Point(540, 3);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(169, 38);
            this.btnTable.TabIndex = 6;
            this.btnTable.Text = "표";
            this.btnTable.UncheckedBackColor = System.Drawing.Color.White;
            this.btnTable.UncheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.Collapse_Event);
            // 
            // btnMap
            // 
            this.btnMap.BackColor = System.Drawing.Color.White;
            this.btnMap.BorderRadius = 3;
            this.btnMap.Checkable = true;
            this.btnMap.Checked = false;
            this.btnMap.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnMap.CheckedForeColor = System.Drawing.Color.White;
            this.btnMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMap.FlatAppearance.BorderSize = 0;
            this.btnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMap.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnMap.Location = new System.Drawing.Point(715, 3);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(169, 38);
            this.btnMap.TabIndex = 7;
            this.btnMap.Text = "지도";
            this.btnMap.UncheckedBackColor = System.Drawing.Color.White;
            this.btnMap.UncheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnMap.UseVisualStyleBackColor = false;
            this.btnMap.Click += new System.EventHandler(this.Collapse_Event);
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.Color.White;
            this.btnChart.BorderRadius = 3;
            this.btnChart.Checkable = true;
            this.btnChart.Checked = false;
            this.btnChart.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnChart.CheckedForeColor = System.Drawing.Color.White;
            this.btnChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChart.FlatAppearance.BorderSize = 0;
            this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnChart.Location = new System.Drawing.Point(890, 3);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(169, 38);
            this.btnChart.TabIndex = 8;
            this.btnChart.Text = "차트";
            this.btnChart.UncheckedBackColor = System.Drawing.Color.White;
            this.btnChart.UncheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnChart.UseVisualStyleBackColor = false;
            this.btnChart.Click += new System.EventHandler(this.Collapse_Event);
            // 
            // modeIconGroup
            // 
            this.modeIconGroup.CurrentChedckedIndex = 0;
            this.modeIconGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modeIconGroup.Location = new System.Drawing.Point(0, 80);
            this.modeIconGroup.Margin = new System.Windows.Forms.Padding(0);
            this.modeIconGroup.Name = "modeIconGroup";
            this.modeIconGroup.Size = new System.Drawing.Size(86, 180);
            this.modeIconGroup.TabIndex = 5;
            this.modeIconGroup.Click += new System.EventHandler(this.modeGroup_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1296, 729);
            this.Controls.Add(this.tableLayoutMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaltBread";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutMain.ResumeLayout(false);
            this.splitMainBoard.Panel1.ResumeLayout(false);
            this.splitMainBoard.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMainBoard)).EndInit();
            this.splitMainBoard.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.layoutMainBoard.ResumeLayout(false);
            this.splitDataBoard.Panel1.ResumeLayout(false);
            this.splitDataBoard.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDataBoard)).EndInit();
            this.splitDataBoard.ResumeLayout(false);
            this.layoutSearchResult.ResumeLayout(false);
            this.layoutSearchResult.PerformLayout();
            this.layoutSearchBox.ResumeLayout(false);
            this.layoutSearchBox.PerformLayout();
            this.splitChart.Panel1.ResumeLayout(false);
            this.splitChart.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitChart)).EndInit();
            this.splitChart.ResumeLayout(false);
            this.splitTableMap.Panel1.ResumeLayout(false);
            this.splitTableMap.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTableMap)).EndInit();
            this.splitTableMap.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.layoutMapBox.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphBoxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphBoxPie)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tblModeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tblModeMenu;
        private System.Windows.Forms.SplitContainer splitMainBoard;
        private System.Windows.Forms.TableLayoutPanel layoutMainBoard;
        private System.Windows.Forms.SplitContainer splitDataBoard;
        private System.Windows.Forms.Label lblSearchResult;
        private System.Windows.Forms.SplitContainer splitChart;
        private System.Windows.Forms.SplitContainer splitTableMap;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMenuCollapse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblSubTableTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel layoutSearchResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel layoutSearchBox;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label lblProjectTitle;
        private System.Windows.Forms.FlowLayoutPanel flowSearchList;
        private CustomControls.RoundedButton btnSearch;
        private View.CheckedButton btnTable;
        private View.CheckedButton btnMap;
        private View.CheckedButton btnChart;
        private System.Windows.Forms.Label lblSearchStore;
        private System.Windows.Forms.Label lblSearchEiffel;
        private System.Windows.Forms.Label lblSearchPin;
        private View.ModeGroupControl modeIconGroup;
        private System.Windows.Forms.Label lblModeName;
        private System.Windows.Forms.Label searchUnderbar;
        private System.Windows.Forms.TableLayoutPanel layoutMapBox;
        private System.Windows.Forms.WebBrowser mapBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox graphBoxBar;
        private System.Windows.Forms.PictureBox graphBoxPie;
        private System.Windows.Forms.FlowLayoutPanel flowDetails;
    }
}

