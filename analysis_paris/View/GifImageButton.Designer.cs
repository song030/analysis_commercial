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
            this.roundedButton = new CustomControls.RoundedButton();
            this.gifBox = new System.Windows.Forms.PictureBox();
            this.gifButtonTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gifBox)).BeginInit();
            this.SuspendLayout();
            // 
            // roundedButton
            // 
            this.roundedButton.BackColor = System.Drawing.Color.White;
            this.roundedButton.BackgroundColor = System.Drawing.Color.White;
            this.roundedButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(53)))), ((int)(((byte)(134)))));
            this.roundedButton.BorderRadius = 24;
            this.roundedButton.BorderSize = 2;
            this.roundedButton.FlatAppearance.BorderSize = 0;
            this.roundedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.roundedButton.ForeColor = System.Drawing.Color.White;
            this.roundedButton.Location = new System.Drawing.Point(3, 3);
            this.roundedButton.Name = "roundedButton";
            this.roundedButton.Size = new System.Drawing.Size(294, 48);
            this.roundedButton.TabIndex = 0;
            this.roundedButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.roundedButton.TextColor = System.Drawing.Color.White;
            this.roundedButton.UseVisualStyleBackColor = false;
            this.roundedButton.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.roundedButton.MouseHover += new System.EventHandler(this.Controls_MouseHover);
            // 
            // gifBox
            // 
            this.gifBox.BackColor = System.Drawing.Color.White;
            this.gifBox.Location = new System.Drawing.Point(50, 6);
            this.gifBox.Margin = new System.Windows.Forms.Padding(6);
            this.gifBox.Name = "gifBox";
            this.gifBox.Size = new System.Drawing.Size(62, 42);
            this.gifBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gifBox.TabIndex = 1;
            this.gifBox.TabStop = false;
            this.gifBox.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.gifBox.MouseHover += new System.EventHandler(this.Controls_MouseHover);
            // 
            // gifButtonTitle
            // 
            this.gifButtonTitle.AutoSize = true;
            this.gifButtonTitle.BackColor = System.Drawing.Color.White;
            this.gifButtonTitle.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gifButtonTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.gifButtonTitle.Location = new System.Drawing.Point(133, 18);
            this.gifButtonTitle.Name = "gifButtonTitle";
            this.gifButtonTitle.Size = new System.Drawing.Size(128, 17);
            this.gifButtonTitle.TabIndex = 2;
            this.gifButtonTitle.Text = "선택한 위치로 검색";
            this.gifButtonTitle.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.gifButtonTitle.MouseHover += new System.EventHandler(this.Controls_MouseHover);
            // 
            // GifImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gifButtonTitle);
            this.Controls.Add(this.gifBox);
            this.Controls.Add(this.roundedButton);
            this.Name = "GifImageButton";
            this.Size = new System.Drawing.Size(300, 54);
            this.Load += new System.EventHandler(this.GifImageButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gifBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RoundedButton roundedButton;
        private System.Windows.Forms.PictureBox gifBox;
        private System.Windows.Forms.Label gifButtonTitle;
    }
}
