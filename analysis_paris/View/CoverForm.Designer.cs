namespace analysis_paris.View {
    partial class CoverForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.BackgroundPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPic)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundPic
            // 
            this.BackgroundPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundPic.Image = global::analysis_paris.Properties.Resources.first_back;
            this.BackgroundPic.Location = new System.Drawing.Point(0, 0);
            this.BackgroundPic.Margin = new System.Windows.Forms.Padding(0);
            this.BackgroundPic.Name = "BackgroundPic";
            this.BackgroundPic.Size = new System.Drawing.Size(1296, 729);
            this.BackgroundPic.TabIndex = 0;
            this.BackgroundPic.TabStop = false;
            this.BackgroundPic.Click += new System.EventHandler(this.BackgroundPic_Click);
            // 
            // CoverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 729);
            this.Controls.Add(this.BackgroundPic);
            this.Name = "CoverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoverForm";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BackgroundPic;
    }
}