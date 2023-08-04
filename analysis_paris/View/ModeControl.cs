using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace analysis_paris.View {

    public enum ModeType {
        //"District",
        //"OldStore",
        //"Coordinate"
    }

    public partial class ModeControl : UserControl {
        public ModeControl() {
            InitializeComponent();
            this.Click += modeItem_Click;
        }

        #region Properties

        private string _type;
        private string _name;
        private Image _image;

        private bool _checked;
        private Color _baseColor;
        private Color _highlightColor;

        [Category("Custom Properties")]
        public string ModeType {
            get { return _type; }
            set { _type = value; }
        }

        [Category("Custom Properties")]
        public string ModeName {
            get { return _name; }
            set { _name = value; }
        }

        [Category("Custom Properties")]
        public Image ModeIcon {
            get { return _image; }
            set { _image = value; }
            //set { _image = value; iconBox.Image = Resources. }
        }

        [Category("Custom Properties")]
        public bool Checked {
            get { return _checked; }
            set { _checked = value; }
        }

        [Category("Custom Properties")]
        public Color BaseColor {
            get { return _baseColor; }
            set { _baseColor = value; iconBox.BackColor = value; }
        }

        [Category("Custom Properties")]
        public Color HighlightColor {
            get { return _highlightColor; }
            set { _highlightColor = value; }
        }
        #endregion

        public new event EventHandler Click {
            add { iconBox.Click += value; }

            remove { iconBox.Click -= value; }
        }

        public void modeItem_Click(object sender, EventArgs e) {
            if (_checked) {
                selectedMarker.Visible = false;
                iconBox.BackColor = _baseColor;
                _checked = false;
            }
            else {
                selectedMarker.Visible = true;
                iconBox.BackColor = _highlightColor;
                _checked = true;
            }
        }


    }
}
