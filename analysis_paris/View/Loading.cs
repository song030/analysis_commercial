using System;
using System.Threading;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class Loading : Form {
        private Thread countdownThread;

        public Loading() {
            InitializeComponent();
            //this.BackColor = Color.Transparent;
        }

        private void StartCountdown() {
            // Wait for 3 seconds
            Thread.Sleep(3000);

            // Close the form using the UI thread
            if (!IsDisposed) {
                this.Invoke(new Action(() => this.Close()));
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            countdownThread?.Abort();
            this.Close();
        }

        private void payLoading_Load(object sender, EventArgs e) {
            countdownThread = new Thread(new ThreadStart(StartCountdown));
            countdownThread.Start();
        }
    }
}