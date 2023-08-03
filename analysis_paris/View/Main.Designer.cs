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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblModeMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnMenuView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMode1 = new analysis_paris.View.CheckedButton();
            this.btnMode2 = new analysis_paris.View.CheckedButton();
            this.btnMode3 = new analysis_paris.View.CheckedButton();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tblModeMenuWide = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.splitChart = new System.Windows.Forms.SplitContainer();
            this.splitTableMap = new System.Windows.Forms.SplitContainer();
            this.lblTableTitle = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.mapBrowser = new System.Windows.Forms.WebBrowser();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new CustomControls.RoundedButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTable = new analysis_paris.View.CheckedButton();
            this.btnMap = new analysis_paris.View.CheckedButton();
            this.btnChart = new analysis_paris.View.CheckedButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblModeMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.tblModeMenuWide.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitChart)).BeginInit();
            this.splitChart.Panel1.SuspendLayout();
            this.splitChart.Panel2.SuspendLayout();
            this.splitChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTableMap)).BeginInit();
            this.splitTableMap.Panel1.SuspendLayout();
            this.splitTableMap.Panel2.SuspendLayout();
            this.splitTableMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tblModeMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitMain, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 694);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tblModeMenu
            // 
            this.tblModeMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.tblModeMenu.ColumnCount = 1;
            this.tblModeMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblModeMenu.Controls.Add(this.btnMenuView, 0, 0);
            this.tblModeMenu.Controls.Add(this.btnClose, 0, 6);
            this.tblModeMenu.Controls.Add(this.btnMode1, 0, 1);
            this.tblModeMenu.Controls.Add(this.btnMode2, 0, 2);
            this.tblModeMenu.Controls.Add(this.btnMode3, 0, 3);
            this.tblModeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblModeMenu.Location = new System.Drawing.Point(0, 0);
            this.tblModeMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tblModeMenu.Name = "tblModeMenu";
            this.tblModeMenu.RowCount = 7;
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblModeMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblModeMenu.Size = new System.Drawing.Size(80, 694);
            this.tblModeMenu.TabIndex = 0;
            // 
            // btnMenuView
            // 
            this.btnMenuView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenuView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenuView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuView.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMenuView.Location = new System.Drawing.Point(3, 14);
            this.btnMenuView.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuView.Name = "btnMenuView";
            this.btnMenuView.Size = new System.Drawing.Size(74, 25);
            this.btnMenuView.TabIndex = 0;
            this.btnMenuView.Text = ">";
            this.btnMenuView.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(3, 653);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnMode1
            // 
            this.btnMode1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMode1.BorderRadius = 0;
            this.btnMode1.Checkable = true;
            this.btnMode1.Checked = true;
            this.btnMode1.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMode1.CheckedForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMode1.FlatAppearance.BorderSize = 0;
            this.btnMode1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMode1.Location = new System.Drawing.Point(0, 56);
            this.btnMode1.Margin = new System.Windows.Forms.Padding(0);
            this.btnMode1.Name = "btnMode1";
            this.btnMode1.Size = new System.Drawing.Size(80, 40);
            this.btnMode1.TabIndex = 5;
            this.btnMode1.Text = "1";
            this.btnMode1.UncheckedBackColor = System.Drawing.Color.White;
            this.btnMode1.UncheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMode1.UseVisualStyleBackColor = false;
            // 
            // btnMode2
            // 
            this.btnMode2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMode2.BackColor = System.Drawing.Color.White;
            this.btnMode2.BorderRadius = 0;
            this.btnMode2.Checkable = true;
            this.btnMode2.Checked = false;
            this.btnMode2.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMode2.CheckedForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMode2.FlatAppearance.BorderSize = 0;
            this.btnMode2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMode2.Location = new System.Drawing.Point(0, 101);
            this.btnMode2.Margin = new System.Windows.Forms.Padding(0);
            this.btnMode2.Name = "btnMode2";
            this.btnMode2.Size = new System.Drawing.Size(80, 40);
            this.btnMode2.TabIndex = 6;
            this.btnMode2.Text = "2";
            this.btnMode2.UncheckedBackColor = System.Drawing.Color.White;
            this.btnMode2.UncheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMode2.UseVisualStyleBackColor = false;
            // 
            // btnMode3
            // 
            this.btnMode3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMode3.BackColor = System.Drawing.Color.White;
            this.btnMode3.BorderRadius = 0;
            this.btnMode3.Checkable = true;
            this.btnMode3.Checked = false;
            this.btnMode3.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMode3.CheckedForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMode3.FlatAppearance.BorderSize = 0;
            this.btnMode3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMode3.Location = new System.Drawing.Point(0, 144);
            this.btnMode3.Margin = new System.Windows.Forms.Padding(0);
            this.btnMode3.Name = "btnMode3";
            this.btnMode3.Size = new System.Drawing.Size(80, 40);
            this.btnMode3.TabIndex = 7;
            this.btnMode3.Text = "3";
            this.btnMode3.UncheckedBackColor = System.Drawing.Color.White;
            this.btnMode3.UncheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMode3.UseVisualStyleBackColor = false;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.IsSplitterFixed = true;
            this.splitMain.Location = new System.Drawing.Point(80, 0);
            this.splitMain.Margin = new System.Windows.Forms.Padding(0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.tblModeMenuWide);
            this.splitMain.Panel1Collapsed = true;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitMain.Size = new System.Drawing.Size(896, 694);
            this.splitMain.SplitterDistance = 120;
            this.splitMain.SplitterWidth = 1;
            this.splitMain.TabIndex = 1;
            this.splitMain.Tag = "120";
            // 
            // tblModeMenuWide
            // 
            this.tblModeMenuWide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.tblModeMenuWide.ColumnCount = 1;
            this.tblModeMenuWide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblModeMenuWide.Controls.Add(this.label1, 0, 2);
            this.tblModeMenuWide.Controls.Add(this.label2, 0, 3);
            this.tblModeMenuWide.Controls.Add(this.label3, 0, 4);
            this.tblModeMenuWide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblModeMenuWide.Location = new System.Drawing.Point(0, 0);
            this.tblModeMenuWide.Margin = new System.Windows.Forms.Padding(0);
            this.tblModeMenuWide.Name = "tblModeMenuWide";
            this.tblModeMenuWide.RowCount = 6;
            this.tblModeMenuWide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblModeMenuWide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblModeMenuWide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblModeMenuWide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblModeMenuWide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblModeMenuWide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblModeMenuWide.Size = new System.Drawing.Size(120, 100);
            this.tblModeMenuWide.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "mode 1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(12, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "mode 2";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(12, 264);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "mode 3";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(896, 694);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.splitChart, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(307, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(589, 694);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // splitChart
            // 
            this.splitChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChart.Location = new System.Drawing.Point(6, 45);
            this.splitChart.Margin = new System.Windows.Forms.Padding(6);
            this.splitChart.Name = "splitChart";
            this.splitChart.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitChart.Panel1
            // 
            this.splitChart.Panel1.Controls.Add(this.splitTableMap);
            // 
            // splitChart.Panel2
            // 
            this.splitChart.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.splitChart.Panel2.Controls.Add(this.pictureBox1);
            this.splitChart.Panel2.Controls.Add(this.lblChartTitle);
            this.splitChart.Size = new System.Drawing.Size(577, 643);
            this.splitChart.SplitterDistance = 300;
            this.splitChart.SplitterWidth = 6;
            this.splitChart.TabIndex = 1;
            this.splitChart.Tag = "300";
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
            this.splitTableMap.Panel1.AutoScroll = true;
            this.splitTableMap.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.splitTableMap.Panel1.Controls.Add(this.lblTableTitle);
            this.splitTableMap.Panel1.Controls.Add(this.dataGridView2);
            // 
            // splitTableMap.Panel2
            // 
            this.splitTableMap.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.splitTableMap.Panel2.Controls.Add(this.mapBrowser);
            this.splitTableMap.Size = new System.Drawing.Size(577, 300);
            this.splitTableMap.SplitterDistance = 290;
            this.splitTableMap.SplitterWidth = 8;
            this.splitTableMap.TabIndex = 0;
            this.splitTableMap.Tag = "290";
            // 
            // lblTableTitle
            // 
            this.lblTableTitle.AutoSize = true;
            this.lblTableTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTableTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTableTitle.Location = new System.Drawing.Point(1, 0);
            this.lblTableTitle.Name = "lblTableTitle";
            this.lblTableTitle.Size = new System.Drawing.Size(129, 16);
            this.lblTableTitle.TabIndex = 1;
            this.lblTableTitle.Text = "주변 환경 데이터";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 34);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(284, 263);
            this.dataGridView2.TabIndex = 0;
            // 
            // mapBrowser
            // 
            this.mapBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapBrowser.Location = new System.Drawing.Point(0, 0);
            this.mapBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.mapBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.mapBrowser.Name = "mapBrowser";
            this.mapBrowser.Size = new System.Drawing.Size(279, 300);
            this.mapBrowser.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(569, 314);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChartTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblChartTitle.Location = new System.Drawing.Point(3, 0);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(92, 16);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "그래프 위치";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.panel3.Controls.Add(this.btnChart);
            this.panel3.Controls.Add(this.btnMap);
            this.panel3.Controls.Add(this.btnTable);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(589, 39);
            this.panel3.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.74751F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.58721F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.41279F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(301, 688);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 109);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(88)))), ((int)(((byte)(127)))));
            this.btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(88)))), ((int)(((byte)(127)))));
            this.btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSearch.BorderRadius = 0;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::analysis_paris.Properties.Resources.icon_search;
            this.btnSearch.Location = new System.Drawing.Point(250, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(36, 36);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 17;
            this.comboBox1.Location = new System.Drawing.Point(3, 77);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 25);
            this.comboBox1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.label4.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "현재 모드 타이틀";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.label5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(10, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "모드별 검색 키워드";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 127);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 555);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(283, 549);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTable.BorderRadius = 0;
            this.btnTable.Checkable = false;
            this.btnTable.Checked = false;
            this.btnTable.CheckedBackColor = System.Drawing.Color.Black;
            this.btnTable.CheckedForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTable.FlatAppearance.BorderSize = 0;
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.ForeColor = System.Drawing.Color.Black;
            this.btnTable.Location = new System.Drawing.Point(304, 3);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(95, 30);
            this.btnTable.TabIndex = 6;
            this.btnTable.Text = "표";
            this.btnTable.UncheckedBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTable.UncheckedForeColor = System.Drawing.Color.Black;
            this.btnTable.UseVisualStyleBackColor = false;
            // 
            // btnMap
            // 
            this.btnMap.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMap.BorderRadius = 0;
            this.btnMap.Checkable = false;
            this.btnMap.Checked = false;
            this.btnMap.CheckedBackColor = System.Drawing.Color.Black;
            this.btnMap.CheckedForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMap.FlatAppearance.BorderSize = 0;
            this.btnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMap.ForeColor = System.Drawing.Color.Black;
            this.btnMap.Location = new System.Drawing.Point(405, 3);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(87, 30);
            this.btnMap.TabIndex = 7;
            this.btnMap.Text = "지도";
            this.btnMap.UncheckedBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMap.UncheckedForeColor = System.Drawing.Color.Black;
            this.btnMap.UseVisualStyleBackColor = false;
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnChart.BorderRadius = 0;
            this.btnChart.Checkable = false;
            this.btnChart.Checked = false;
            this.btnChart.CheckedBackColor = System.Drawing.Color.Black;
            this.btnChart.CheckedForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnChart.FlatAppearance.BorderSize = 0;
            this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart.ForeColor = System.Drawing.Color.Black;
            this.btnChart.Location = new System.Drawing.Point(498, 3);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(88, 30);
            this.btnChart.TabIndex = 8;
            this.btnChart.Text = "그래프";
            this.btnChart.UncheckedBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnChart.UncheckedForeColor = System.Drawing.Color.Black;
            this.btnChart.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(976, 694);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaltBread";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tblModeMenu.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.tblModeMenuWide.ResumeLayout(false);
            this.tblModeMenuWide.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.splitChart.Panel1.ResumeLayout(false);
            this.splitChart.Panel2.ResumeLayout(false);
            this.splitChart.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitChart)).EndInit();
            this.splitChart.ResumeLayout(false);
            this.splitTableMap.Panel1.ResumeLayout(false);
            this.splitTableMap.Panel1.PerformLayout();
            this.splitTableMap.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTableMap)).EndInit();
            this.splitTableMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblModeMenu;
        private System.Windows.Forms.Button btnMenuView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TableLayoutPanel tblModeMenuWide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.SplitContainer splitChart;
        private System.Windows.Forms.SplitContainer splitTableMap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.RoundedButton btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.WebBrowser mapBrowser;
        private System.Windows.Forms.Label lblTableTitle;
        private View.CheckedButton btnMode1;
        private View.CheckedButton btnMode2;
        private View.CheckedButton btnMode3;
        private View.CheckedButton btnChart;
        private View.CheckedButton btnMap;
        private View.CheckedButton btnTable;
    }
}

