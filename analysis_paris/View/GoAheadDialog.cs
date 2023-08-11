using analysis_paris.DAO;
using analysis_paris.View;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace analysis_paris.Resources {
    public partial class GoAheadDialog : Form {

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

            targetAddr.Text = target.ADDRESS;
            targetSize.Text = $"{target.AREA_SIZE}m²";
            targetPrice.Text = $"{target.SELLING_PRICE:#,##} 만원";
            targetDeposit.Text = $"{target.DEPOSIT:#,##} 만원";
            targetRate.Text = $"{target.RATE_PER_MONTH:#,##} 만원";
            targetPremium.Text = $"{target.PREMIUM:#,##} 만원";
            targetRevenue.Text = $"{target.EXPECTED_SHOP_REVENUE:#,##} 원";
            targetScore.Text = $"{target.SCORE} 점";
            targetLink.Text = target.RELATION_LINK;
        }

        private void GoAheadDialog_Load(object sender, EventArgs e) {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 6, 6));
            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowGyeongYeong));
            splashthread.IsBackground = true;
            splashthread.Start();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            string url = targetLink.Text;
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            this.Close();
        }

        private void btnCalcel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
