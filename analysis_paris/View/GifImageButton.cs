using System;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class GifImageButton : UserControl {
        public GifImageButton() {
            InitializeComponent();
        }

        private void GifImageButton_Load(object sender, EventArgs e) {
            gifBox.Image = Properties.Resources.magnifying_glass_stop;

            // click
            gifBox.Click += Controls_Click;
            gifButtonTitle.Click += Controls_Click;
            roundedButton.Click += Controls_Click;
        }

        private void Controls_Click(object sender, EventArgs e) {
            this.OnClick(e);
        }

        private void Controls_MouseHover(object sender, EventArgs e) {
            gifBox.Image = Properties.Resources.magnifying_glass;
        }

        private void Controls_MouseLeave(object sender, EventArgs e) {
            gifBox.Image = Properties.Resources.magnifying_glass_stop;
        }

    }
}
