using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class CoverForm : Form {

        //Timer backTimer = null;

        public CoverForm() {
            InitializeComponent();
        }

        private void BackgroundPic_Click(object sender, System.EventArgs e) {
            this.Close();
        }
    }
}
