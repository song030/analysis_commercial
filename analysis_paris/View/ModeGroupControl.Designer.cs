namespace analysis_paris.View {
    partial class ModeGroupControl {
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.layoutFrame = new System.Windows.Forms.TableLayoutPanel();
            this.modeControl1 = new analysis_paris.View.ModeControl();
            this.modeControl2 = new analysis_paris.View.ModeControl();
            this.modeControl3 = new analysis_paris.View.ModeControl();
            this.layoutFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutFrame
            // 
            this.layoutFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.layoutFrame.ColumnCount = 1;
            this.layoutFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutFrame.Controls.Add(this.modeControl1, 0, 0);
            this.layoutFrame.Controls.Add(this.modeControl2, 0, 1);
            this.layoutFrame.Controls.Add(this.modeControl3, 0, 2);
            this.layoutFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutFrame.Location = new System.Drawing.Point(0, 0);
            this.layoutFrame.Margin = new System.Windows.Forms.Padding(0);
            this.layoutFrame.Name = "layoutFrame";
            this.layoutFrame.RowCount = 3;
            this.layoutFrame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutFrame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutFrame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutFrame.Size = new System.Drawing.Size(80, 150);
            this.layoutFrame.TabIndex = 0;
            // 
            // modeControl1
            // 
            this.modeControl1.BaseImage = "store";
            this.modeControl1.Checked = false;
            this.modeControl1.Location = new System.Drawing.Point(0, 0);
            this.modeControl1.Margin = new System.Windows.Forms.Padding(0);
            this.modeControl1.Name = "modeControl1";
            this.modeControl1.Size = new System.Drawing.Size(80, 49);
            this.modeControl1.TabIndex = 0;
            // 
            // modeControl2
            // 
            this.modeControl2.BaseImage = "eiffel";
            this.modeControl2.Checked = false;
            this.modeControl2.Location = new System.Drawing.Point(0, 49);
            this.modeControl2.Margin = new System.Windows.Forms.Padding(0);
            this.modeControl2.Name = "modeControl2";
            this.modeControl2.Size = new System.Drawing.Size(80, 49);
            this.modeControl2.TabIndex = 1;
            // 
            // modeControl3
            // 
            this.modeControl3.BaseImage = "pin";
            this.modeControl3.Checked = false;
            this.modeControl3.Location = new System.Drawing.Point(0, 98);
            this.modeControl3.Margin = new System.Windows.Forms.Padding(0);
            this.modeControl3.Name = "modeControl3";
            this.modeControl3.Size = new System.Drawing.Size(80, 52);
            this.modeControl3.TabIndex = 2;
            // 
            // ModeControlGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutFrame);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ModeControlGroup";
            this.Size = new System.Drawing.Size(80, 150);
            this.layoutFrame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutFrame;
        private ModeControl modeControl1;
        private ModeControl modeControl2;
        private ModeControl modeControl3;
    }
}
