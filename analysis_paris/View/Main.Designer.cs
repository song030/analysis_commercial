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
            this.layoutMainBoard = new System.Windows.Forms.TableLayoutPanel();
            this.splitDataBoard = new System.Windows.Forms.SplitContainer();
            this.layoutMainTable = new System.Windows.Forms.TableLayoutPanel();
            this.lblMainTableTitle = new System.Windows.Forms.Label();
            this.splitChart = new System.Windows.Forms.SplitContainer();
            this.splitTableMap = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblSubTableTitle = new System.Windows.Forms.Label();
            this.mapBrowser = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.chartGifBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tblModeMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMenuCollapse = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChart = new analysis_paris.View.CheckedButton();
            this.btnTable = new analysis_paris.View.CheckedButton();
            this.btnMap = new analysis_paris.View.CheckedButton();
            this.modeControl1 = new analysis_paris.View.ModeControl();
            this.modeControl2 = new analysis_paris.View.ModeControl();
            this.modeControl3 = new analysis_paris.View.ModeControl();
            this.tableLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMainBoard)).BeginInit();
            this.splitMainBoard.Panel1.SuspendLayout();
            this.splitMainBoard.Panel2.SuspendLayout();
            this.splitMainBoard.SuspendLayout();
            this.layoutMainBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDataBoard)).BeginInit();
            this.splitDataBoard.Panel1.SuspendLayout();
            this.splitDataBoard.Panel2.SuspendLayout();
            this.splitDataBoard.SuspendLayout();
            this.layoutMainTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitChart)).BeginInit();
            this.splitChart.Panel1.SuspendLayout();
            this.splitChart.Panel2.SuspendLayout();
            this.splitChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTableMap)).BeginInit();
            this.splitTableMap.Panel1.SuspendLayout();
            this.splitTableMap.Panel2.SuspendLayout();
            this.splitTableMap.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGifBox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tblModeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.Controls.Add(this.splitMainBoard, 1, 0);
            this.tableLayoutMain.Controls.Add(this.tblModeMenu, 0, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1072, 603);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // splitMainBoard
            // 
            this.splitMainBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMainBoard.Location = new System.Drawing.Point(72, 0);
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
            this.splitMainBoard.Size = new System.Drawing.Size(1000, 603);
            this.splitMainBoard.SplitterDistance = 144;
            this.splitMainBoard.TabIndex = 144;
            this.splitMainBoard.Tag = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(144, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // layoutMainBoard
            // 
            this.layoutMainBoard.ColumnCount = 1;
            this.layoutMainBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutMainBoard.Controls.Add(this.splitDataBoard, 0, 1);
            this.layoutMainBoard.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.layoutMainBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMainBoard.Location = new System.Drawing.Point(0, 0);
            this.layoutMainBoard.Margin = new System.Windows.Forms.Padding(0);
            this.layoutMainBoard.Name = "layoutMainBoard";
            this.layoutMainBoard.RowCount = 2;
            this.layoutMainBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.462687F));
            this.layoutMainBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.53732F));
            this.layoutMainBoard.Size = new System.Drawing.Size(852, 603);
            this.layoutMainBoard.TabIndex = 0;
            // 
            // splitDataBoard
            // 
            this.splitDataBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDataBoard.Location = new System.Drawing.Point(0, 45);
            this.splitDataBoard.Margin = new System.Windows.Forms.Padding(0);
            this.splitDataBoard.Name = "splitDataBoard";
            // 
            // splitDataBoard.Panel1
            // 
            this.splitDataBoard.Panel1.Controls.Add(this.layoutMainTable);
            this.splitDataBoard.Panel1.Padding = new System.Windows.Forms.Padding(16);
            // 
            // splitDataBoard.Panel2
            // 
            this.splitDataBoard.Panel2.Controls.Add(this.splitChart);
            this.splitDataBoard.Panel2.Padding = new System.Windows.Forms.Padding(16);
            this.splitDataBoard.Size = new System.Drawing.Size(852, 558);
            this.splitDataBoard.SplitterDistance = 280;
            this.splitDataBoard.SplitterWidth = 1;
            this.splitDataBoard.TabIndex = 0;
            this.splitDataBoard.Tag = "0";
            // 
            // layoutMainTable
            // 
            this.layoutMainTable.ColumnCount = 1;
            this.layoutMainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMainTable.Controls.Add(this.lblMainTableTitle, 0, 1);
            this.layoutMainTable.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.layoutMainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMainTable.Location = new System.Drawing.Point(16, 16);
            this.layoutMainTable.Margin = new System.Windows.Forms.Padding(0);
            this.layoutMainTable.Name = "layoutMainTable";
            this.layoutMainTable.RowCount = 3;
            this.layoutMainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.layoutMainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.layoutMainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMainTable.Size = new System.Drawing.Size(248, 526);
            this.layoutMainTable.TabIndex = 0;
            // 
            // lblMainTableTitle
            // 
            this.lblMainTableTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMainTableTitle.AutoSize = true;
            this.lblMainTableTitle.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMainTableTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.lblMainTableTitle.Location = new System.Drawing.Point(0, 95);
            this.lblMainTableTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblMainTableTitle.Name = "lblMainTableTitle";
            this.lblMainTableTitle.Size = new System.Drawing.Size(63, 16);
            this.lblMainTableTitle.TabIndex = 1;
            this.lblMainTableTitle.Text = "검색 결과";
            // 
            // splitChart
            // 
            this.splitChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChart.Location = new System.Drawing.Point(16, 16);
            this.splitChart.Margin = new System.Windows.Forms.Padding(0);
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
            this.splitChart.Size = new System.Drawing.Size(539, 526);
            this.splitChart.SplitterDistance = 219;
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
            this.splitTableMap.Panel2.Controls.Add(this.mapBrowser);
            this.splitTableMap.Size = new System.Drawing.Size(539, 219);
            this.splitTableMap.SplitterDistance = 292;
            this.splitTableMap.TabIndex = 0;
            this.splitTableMap.Tag = "292";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridView2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSubTableTitle, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(292, 219);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 45);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(286, 171);
            this.dataGridView2.TabIndex = 1;
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
            // mapBrowser
            // 
            this.mapBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapBrowser.Location = new System.Drawing.Point(0, 0);
            this.mapBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.mapBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.mapBrowser.Name = "mapBrowser";
            this.mapBrowser.Size = new System.Drawing.Size(243, 219);
            this.mapBrowser.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.chartGifBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(539, 306);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // chartGifBox
            // 
            this.chartGifBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(255)))));
            this.chartGifBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGifBox.Image = global::analysis_paris.Properties.Resources.sample_chart;
            this.chartGifBox.Location = new System.Drawing.Point(0, 42);
            this.chartGifBox.Margin = new System.Windows.Forms.Padding(0);
            this.chartGifBox.Name = "chartGifBox";
            this.chartGifBox.Size = new System.Drawing.Size(539, 264);
            this.chartGifBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.chartGifBox.TabIndex = 0;
            this.chartGifBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.label1.Location = new System.Drawing.Point(0, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "분석 차트";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.Controls.Add(this.btnChart, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnTable, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMap, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(846, 39);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tblModeMenu
            // 
            this.tblModeMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.tblModeMenu.ColumnCount = 2;
            this.tblModeMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tblModeMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblModeMenu.Controls.Add(this.btnExit, 1, 8);
            this.tblModeMenu.Controls.Add(this.btnMenuCollapse, 1, 0);
            this.tblModeMenu.Controls.Add(this.modeControl1, 0, 1);
            this.tblModeMenu.Controls.Add(this.modeControl2, 0, 2);
            this.tblModeMenu.Controls.Add(this.modeControl3, 0, 3);
            this.tblModeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblModeMenu.Location = new System.Drawing.Point(0, 0);
            this.tblModeMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tblModeMenu.Name = "tblModeMenu";
            this.tblModeMenu.RowCount = 9;
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblModeMenu.Size = new System.Drawing.Size(72, 603);
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
            this.btnExit.Location = new System.Drawing.Point(6, 556);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 33);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
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
            this.btnMenuCollapse.Location = new System.Drawing.Point(6, 13);
            this.btnMenuCollapse.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuCollapse.Name = "btnMenuCollapse";
            this.btnMenuCollapse.Size = new System.Drawing.Size(66, 33);
            this.btnMenuCollapse.TabIndex = 0;
            this.btnMenuCollapse.Text = "메뉴";
            this.btnMenuCollapse.UseVisualStyleBackColor = true;
            this.btnMenuCollapse.Click += new System.EventHandler(this.btnMenuCollapse_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 124);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(248, 402);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.Color.White;
            this.btnChart.BorderRadius = 0;
            this.btnChart.Checkable = true;
            this.btnChart.Checked = false;
            this.btnChart.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnChart.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(36)))));
            this.btnChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChart.FlatAppearance.BorderSize = 0;
            this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChart.ForeColor = System.Drawing.Color.Black;
            this.btnChart.Location = new System.Drawing.Point(671, 0);
            this.btnChart.Margin = new System.Windows.Forms.Padding(0);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(175, 39);
            this.btnChart.TabIndex = 2;
            this.btnChart.Text = "그래프";
            this.btnChart.UncheckedBackColor = System.Drawing.Color.White;
            this.btnChart.UncheckedForeColor = System.Drawing.Color.Black;
            this.btnChart.UseVisualStyleBackColor = false;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.Color.White;
            this.btnTable.BorderRadius = 0;
            this.btnTable.Checkable = true;
            this.btnTable.Checked = false;
            this.btnTable.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnTable.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(36)))));
            this.btnTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTable.FlatAppearance.BorderSize = 0;
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTable.ForeColor = System.Drawing.Color.Black;
            this.btnTable.Location = new System.Drawing.Point(321, 0);
            this.btnTable.Margin = new System.Windows.Forms.Padding(0);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(175, 39);
            this.btnTable.TabIndex = 4;
            this.btnTable.Text = "표";
            this.btnTable.UncheckedBackColor = System.Drawing.Color.White;
            this.btnTable.UncheckedForeColor = System.Drawing.Color.Black;
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnMap
            // 
            this.btnMap.BackColor = System.Drawing.Color.White;
            this.btnMap.BorderRadius = 0;
            this.btnMap.Checkable = true;
            this.btnMap.Checked = false;
            this.btnMap.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.btnMap.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(36)))));
            this.btnMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMap.FlatAppearance.BorderSize = 0;
            this.btnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMap.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMap.ForeColor = System.Drawing.Color.Black;
            this.btnMap.Location = new System.Drawing.Point(496, 0);
            this.btnMap.Margin = new System.Windows.Forms.Padding(0);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(175, 39);
            this.btnMap.TabIndex = 3;
            this.btnMap.Text = "지도";
            this.btnMap.UncheckedBackColor = System.Drawing.Color.White;
            this.btnMap.UncheckedForeColor = System.Drawing.Color.Black;
            this.btnMap.UseVisualStyleBackColor = false;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // modeControl1
            // 
            this.modeControl1.BaseColor = System.Drawing.Color.Empty;
            this.modeControl1.Checked = false;
            this.tblModeMenu.SetColumnSpan(this.modeControl1, 2);
            this.modeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modeControl1.HighlightColor = System.Drawing.Color.Empty;
            this.modeControl1.Location = new System.Drawing.Point(0, 60);
            this.modeControl1.Margin = new System.Windows.Forms.Padding(0);
            this.modeControl1.ModeIcon = null;
            this.modeControl1.ModeName = null;
            this.modeControl1.ModeType = null;
            this.modeControl1.Name = "modeControl1";
            this.modeControl1.Size = new System.Drawing.Size(72, 48);
            this.modeControl1.TabIndex = 5;
            // 
            // modeControl2
            // 
            this.modeControl2.BaseColor = System.Drawing.Color.Empty;
            this.modeControl2.Checked = false;
            this.tblModeMenu.SetColumnSpan(this.modeControl2, 2);
            this.modeControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modeControl2.HighlightColor = System.Drawing.Color.Empty;
            this.modeControl2.Location = new System.Drawing.Point(0, 108);
            this.modeControl2.Margin = new System.Windows.Forms.Padding(0);
            this.modeControl2.ModeIcon = null;
            this.modeControl2.ModeName = null;
            this.modeControl2.ModeType = null;
            this.modeControl2.Name = "modeControl2";
            this.modeControl2.Size = new System.Drawing.Size(72, 48);
            this.modeControl2.TabIndex = 6;
            // 
            // modeControl3
            // 
            this.modeControl3.BaseColor = System.Drawing.Color.Empty;
            this.modeControl3.Checked = false;
            this.tblModeMenu.SetColumnSpan(this.modeControl3, 2);
            this.modeControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modeControl3.HighlightColor = System.Drawing.Color.Empty;
            this.modeControl3.Location = new System.Drawing.Point(0, 156);
            this.modeControl3.Margin = new System.Windows.Forms.Padding(0);
            this.modeControl3.ModeIcon = null;
            this.modeControl3.ModeName = null;
            this.modeControl3.ModeType = null;
            this.modeControl3.Name = "modeControl3";
            this.modeControl3.Size = new System.Drawing.Size(72, 48);
            this.modeControl3.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1072, 603);
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
            this.layoutMainBoard.ResumeLayout(false);
            this.splitDataBoard.Panel1.ResumeLayout(false);
            this.splitDataBoard.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDataBoard)).EndInit();
            this.splitDataBoard.ResumeLayout(false);
            this.layoutMainTable.ResumeLayout(false);
            this.layoutMainTable.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGifBox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tblModeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tblModeMenu;
        private System.Windows.Forms.SplitContainer splitMainBoard;
        private System.Windows.Forms.TableLayoutPanel layoutMainBoard;
        private System.Windows.Forms.SplitContainer splitDataBoard;
        private System.Windows.Forms.Label lblMainTableTitle;
        private System.Windows.Forms.SplitContainer splitChart;
        private System.Windows.Forms.SplitContainer splitTableMap;
        private System.Windows.Forms.WebBrowser mapBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox chartGifBox;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMenuCollapse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblSubTableTitle;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel layoutMainTable;
        private View.CheckedButton btnTable;
        private View.CheckedButton btnMap;
        private View.CheckedButton btnChart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Type;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private View.ModeControl modeControl1;
        private View.ModeControl modeControl2;
        private View.ModeControl modeControl3;
    }
}

