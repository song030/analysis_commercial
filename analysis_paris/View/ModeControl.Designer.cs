namespace analysis_paris.View {
    partial class ModeControl {
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
            this.selectedMarker = new System.Windows.Forms.Label();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.layoutFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutFrame
            // 
            this.layoutFrame.ColumnCount = 2;
            this.layoutFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.layoutFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFrame.Controls.Add(this.selectedMarker, 0, 0);
            this.layoutFrame.Controls.Add(this.iconBox, 1, 0);
            this.layoutFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutFrame.Location = new System.Drawing.Point(0, 0);
            this.layoutFrame.Margin = new System.Windows.Forms.Padding(0);
            this.layoutFrame.Name = "layoutFrame";
            this.layoutFrame.RowCount = 1;
            this.layoutFrame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFrame.Size = new System.Drawing.Size(72, 48);
            this.layoutFrame.TabIndex = 0;
            // 
            // selectedMarker
            // 
            this.selectedMarker.AutoSize = true;
            this.selectedMarker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(36)))));
            this.selectedMarker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedMarker.Location = new System.Drawing.Point(0, 0);
            this.selectedMarker.Margin = new System.Windows.Forms.Padding(0);
            this.selectedMarker.Name = "selectedMarker";
            this.selectedMarker.Size = new System.Drawing.Size(5, 48);
            this.selectedMarker.TabIndex = 0;
            this.selectedMarker.Text = "label1";
            this.selectedMarker.Visible = false;
            // 
            // iconBox
            // 
            this.iconBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.iconBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconBox.Location = new System.Drawing.Point(5, 0);
            this.iconBox.Margin = new System.Windows.Forms.Padding(0);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(67, 48);
            this.iconBox.TabIndex = 1;
            this.iconBox.TabStop = false;
            // 
            // ModeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutFrame);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ModeControl";
            this.Size = new System.Drawing.Size(72, 48);
            this.layoutFrame.ResumeLayout(false);
            this.layoutFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutFrame;
        private System.Windows.Forms.Label selectedMarker;
        private System.Windows.Forms.PictureBox iconBox;
    }
}
