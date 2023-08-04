using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class CheckedButton : Button {

        #region Properties
        private int _borderRadius;
        private bool _checkable;
        private bool _checked;

        private Color _checkedBackColor;
        private Color _uncheckedBackColor;
        private Color _checkedForeColor;
        private Color _uncheckedForeColor;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);


        [Category("Custom Props")]
        public bool Checkable {
            get { return _checkable; }
            set {
                _checkable = value;
                if (_checkable) {
                    this.Click += Button_Click;
                }
                else {
                    this.Click -= Button_Click;
                }
            }
        }


        [Category("Custom Props")]
        public int BorderRadius {
            get { return _borderRadius; }
            set {
                _borderRadius = value;
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, _borderRadius, _borderRadius));
                this.Invalidate();
            }
        }

        [Category("Custom Props")]
        public bool Checked {
            get { return _checked; }
            set {
                _checked = value;
                CheckedChange();
            }
        }

        [Category("Custom Props")]
        public Color CheckedBackColor {
            get { return _checkedBackColor; }
            set {
                _checkedBackColor = value;

                if (_checked == true) {
                    this.BackColor = _checkedBackColor;
                    this.Invalidate();
                }
            }
        }

        [Category("Custom Props")]
        public Color UncheckedBackColor {
            get { return _uncheckedBackColor; }
            set {
                _uncheckedBackColor = value;

                if (_checked == false)
                    this.BackColor = _uncheckedBackColor;
                this.Invalidate();
            }
        }

        [Category("Custom Props")]
        public Color CheckedForeColor {
            get { return _checkedForeColor; }
            set {
                _checkedForeColor = value;

                if (_checked == true) {
                    this.ForeColor = _checkedForeColor;
                    this.Invalidate();
                }
            }
        }

        [Category("Custom Props")]
        public Color UncheckedForeColor {
            get { return _uncheckedForeColor; }
            set {
                _uncheckedForeColor = value;

                if (_checked == false) {
                    this.ForeColor = _uncheckedForeColor;
                    this.Invalidate();
                }
            }
        }
        #endregion

        // Constructor
        public CheckedButton() {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 80);

            _uncheckedBackColor = Color.White;
            _uncheckedForeColor = Color.Black;
            this.BackColor = _uncheckedBackColor;
            this.ForeColor = _uncheckedForeColor;
            this.Resize += CheckedButton_Resize;
        }

        // Methods
        private void CheckedButton_Resize(object sender, EventArgs e) {
            if (_borderRadius > this.Height)
                _borderRadius = this.Height;

            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, _borderRadius, _borderRadius));
        }

        private void Button_Click(object sender, EventArgs e) {
            if (_checked == true) {
                this.Checked = false;
            }
            else {
                this.Checked = true;
            }

            CheckedChange();
        }

        private void CheckedChange() {
            if (_checked == false) {
                this.BackColor = _uncheckedBackColor;
                this.ForeColor = _uncheckedForeColor;
            }
            else {
                this.BackColor = _checkedBackColor;
                this.ForeColor = _checkedForeColor;
            }
        }

    }
}
