using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class SplashWindow : Form {
        // Fields
        delegate void SplashShowCloseDelegate();
        bool CloseSplashScreenFlag = false;
        bool opacityPlus = true;
        double opacityStep = 0.02;

        // Constructor
        public SplashWindow() {
            InitializeComponent();
        }

        public SplashWindow(Image backImage) {
            InitializeComponent();
            pictureSplash.Image = backImage;
        }

        public void ShowSplashScreen() {
            if (InvokeRequired) {
                BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }

        public void CloseSplashScreen() {
            if (InvokeRequired) {
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }
            CloseSplashScreenFlag = true;
            this.Close();
        }

        private void SplashWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (CloseSplashScreenFlag == false)
                e.Cancel = true;
        }

        private void opacityTimer_Tick(object sender, System.EventArgs e) {
            var currentOpacity = this.Opacity;

            if (opacityPlus) {
                currentOpacity += opacityStep;
                this.Opacity = currentOpacity;

                if (this.Opacity > 1.00 - opacityStep) {
                    Thread.Sleep(300);
                    opacityPlus = false;
                }
            }
            else {
                currentOpacity -= opacityStep;
                this.Opacity = currentOpacity;

                if (this.Opacity < opacityStep) {
                    opacityTimer.Enabled = false;
                    CloseSplashScreen();
                }
            }
        }
    }
}
