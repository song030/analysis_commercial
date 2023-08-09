namespace analysis_paris.View
{
    partial class ListItemControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAddr = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPOption = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblAddr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblArea, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblScore, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPOption, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblAddr
            // 
            this.lblAddr.AutoSize = true;
            this.lblAddr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddr.Font = new System.Drawing.Font("나눔고딕", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddr.Location = new System.Drawing.Point(45, 0);
            this.lblAddr.Name = "lblAddr";
            this.lblAddr.Size = new System.Drawing.Size(134, 60);
            this.lblAddr.TabIndex = 1;
            this.lblAddr.Text = "서울특별시 강동구 강일동 고덕강일2지구 성산타워2\r\n";
            this.lblAddr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddr.Click += new System.EventHandler(this.Control_Click);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblArea.Font = new System.Drawing.Font("나눔고딕", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblArea.Location = new System.Drawing.Point(185, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(57, 60);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "4198.37m²";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblArea.Click += new System.EventHandler(this.Control_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore.Font = new System.Drawing.Font("나눔고딕", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScore.Location = new System.Drawing.Point(311, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(36, 60);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "총점";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScore.Click += new System.EventHandler(this.Control_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblType.Font = new System.Drawing.Font("나눔고딕", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(180)))), ((int)(((byte)(232)))));
            this.lblType.Location = new System.Drawing.Point(3, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(36, 60);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "월세\r\n매매";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblType.Click += new System.EventHandler(this.Control_Click);
            // 
            // lblPOption
            // 
            this.lblPOption.AutoSize = true;
            this.lblPOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPOption.Font = new System.Drawing.Font("나눔고딕", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPOption.Location = new System.Drawing.Point(248, 0);
            this.lblPOption.Name = "lblPOption";
            this.lblPOption.Size = new System.Drawing.Size(57, 60);
            this.lblPOption.TabIndex = 5;
            this.lblPOption.Text = "보증금 9000\r\n월세 360\r\n권리금 0";
            this.lblPOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPOption.Click += new System.EventHandler(this.Control_Click);
            // 
            // ListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ListItemControl";
            this.Size = new System.Drawing.Size(350, 60);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAddr;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPOption;
    }
}
