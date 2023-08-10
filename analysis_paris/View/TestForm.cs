using System.Threading;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class TestForm : Form {

        public TestForm() {
            InitializeComponent();
            #region Splash Window Test
            //int sleepTime = 1000;
            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            splashthread.IsBackground = true;
            splashthread.Start();
            #endregion

        }
    }
}
