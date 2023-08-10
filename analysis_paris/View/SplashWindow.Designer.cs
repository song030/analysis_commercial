namespace analysis_paris.View {
    partial class SplashWindow {
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
            this.pictureSplash = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureSplash
            // 
            this.pictureSplash.BackColor = System.Drawing.Color.Transparent;
            this.pictureSplash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureSplash.Image = global::analysis_paris.Properties.Resources.loading;
            this.pictureSplash.Location = new System.Drawing.Point(0, 0);
            this.pictureSplash.Name = "pictureSplash";
            this.pictureSplash.Size = new System.Drawing.Size(280, 280);
            this.pictureSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSplash.TabIndex = 0;
            this.pictureSplash.TabStop = false;
            // 
            // SplashWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(280, 280);
            this.Controls.Add(this.pictureSplash);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashWindow";
            this.TransparencyKey = System.Drawing.Color.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSplash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureSplash;
    }
}