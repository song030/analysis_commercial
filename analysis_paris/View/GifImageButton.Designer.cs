namespace analysis_paris.View {
    partial class GifImageButton {
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
            this.layoutButtonFrame = new System.Windows.Forms.TableLayoutPanel();
            this.gifIconBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.layoutButtonFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifIconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutButtonFrame
            // 
            this.layoutButtonFrame.BackColor = System.Drawing.Color.White;
            this.layoutButtonFrame.ColumnCount = 3;
            this.layoutButtonFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutButtonFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.77966F));
            this.layoutButtonFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.22034F));
            this.layoutButtonFrame.Controls.Add(this.gifIconBox, 1, 0);
            this.layoutButtonFrame.Controls.Add(this.label1, 2, 0);
            this.layoutButtonFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutButtonFrame.Location = new System.Drawing.Point(0, 0);
            this.layoutButtonFrame.Name = "layoutButtonFrame";
            this.layoutButtonFrame.RowCount = 1;
            this.layoutButtonFrame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutButtonFrame.Size = new System.Drawing.Size(294, 55);
            this.layoutButtonFrame.TabIndex = 0;
            // 
            // gifIconBox
            // 
            this.gifIconBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gifIconBox.Location = new System.Drawing.Point(23, 3);
            this.gifIconBox.Name = "gifIconBox";
            this.gifIconBox.Size = new System.Drawing.Size(67, 49);
            this.gifIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gifIconBox.TabIndex = 0;
            this.gifIconBox.TabStop = false;
            this.gifIconBox.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.gifIconBox.MouseHover += new System.EventHandler(this.Controls_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.label1.Location = new System.Drawing.Point(96, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(195, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "선택한 위치로 검색";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.Controls_MouseHover);
            // 
            // GifImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutButtonFrame);
            this.Name = "GifImageButton";
            this.Size = new System.Drawing.Size(294, 55);
            this.Load += new System.EventHandler(this.GifImageButton_Load);
            this.layoutButtonFrame.ResumeLayout(false);
            this.layoutButtonFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifIconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutButtonFrame;
        private System.Windows.Forms.PictureBox gifIconBox;
        private System.Windows.Forms.Label label1;
    }
}
