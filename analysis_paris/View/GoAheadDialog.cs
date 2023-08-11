using analysis_paris.DAO;
using analysis_paris.View;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace analysis_paris.Resources {
    public partial class GoAheadDialog : Form {

        public bool goAhead;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public GoAheadDialog() {
            InitializeComponent();
        }

        public GoAheadDialog(SellingArea target) {
            InitializeComponent();

            // target info 할당
            if (target.SELLING_TYPE == "매매") {
                tableLayout.RowStyles[3].Height = 0;
                tableLayout.RowStyles[4].Height = 0;
                tableLayout.RowStyles[5].Height = 0;
            }
            else {
                tableLayout.RowStyles[2].Height = 0;
            }

            targetAddr.Text = string.Empty;
            targetSize.Text = string.Empty;
            targetPrice.Text = string.Empty;
        }

        private void GoAheadDialog_Load(object sender, EventArgs e) {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 6, 6));

            goAhead = false;

            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowGyeongYeong));
            splashthread.IsBackground = true;
            splashthread.Start();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            goAhead = true;
            this.Close();
        }

        private void btnCalcel_Click(object sender, EventArgs e) {
            goAhead = false;
            this.Close();
        }
    }
}
