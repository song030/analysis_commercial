using System.Drawing;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class SplashWindow : Form {
        // Fields
        delegate void SplashShowCloseDelegate();
        bool CloseSplashScreenFlag = false;

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
    }
}
