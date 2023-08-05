using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class ModeControl : UserControl {
        public ModeControl() {
            InitializeComponent();
            this._checked = true;
        }

        #region Properties
        private string _baseImage;
        private bool _checked;

        [Category("Custom Props")]
        public string BaseImage {
            get { return _baseImage; }
            set {
                _baseImage = value;
                iconBox.Image = (Image)Properties.Resources.ResourceManager.GetObject($"icon_{value}_w", System.Globalization.CultureInfo.CurrentUICulture);
            }
        }

        [Category("Custom Props")]
        public bool Checked {
            get { return _checked; }
            set {
                _checked = value;
                if (_checked) {
                    Mode_Select();
                }
                else {
                    Mode_Unselect();
                }
            }
        }
        #endregion

        public void Mode_Select() {
            selectedMarker.BackColor = Color.FromArgb(254, 218, 36);
            iconBox.Image = (Image)Properties.Resources.ResourceManager.GetObject($"icon_{_baseImage}_y", System.Globalization.CultureInfo.CurrentUICulture);
            _checked = true;
        }

        public void Mode_Unselect() {
            selectedMarker.BackColor = Color.FromArgb(255, 255, 255);
            iconBox.Image = (Image)Properties.Resources.ResourceManager.GetObject($"icon_{_baseImage}_w", System.Globalization.CultureInfo.CurrentUICulture);
            _checked = false;
        }

        private void iconBox_Click(object sender, System.EventArgs e) {
            this.OnClick(e);
        }
    }
}
