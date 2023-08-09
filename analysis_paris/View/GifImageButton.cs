using System;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class GifImageButton : UserControl {
        public GifImageButton() {
            InitializeComponent();
        }

        private void GifImageButton_Load(object sender, EventArgs e) {
            gifIconBox.Image = Properties.Resources.magnifying_glass_stop;
        }

        private void Controls_MouseHover(object sender, EventArgs e) {
            gifIconBox.Image = Properties.Resources.magnifying_glass;
        }

        private void Controls_MouseLeave(object sender, EventArgs e) {
            gifIconBox.Image = Properties.Resources.magnifying_glass_stop;
        }

    }
}
