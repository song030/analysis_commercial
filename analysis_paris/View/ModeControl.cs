using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace analysis_paris.View {

    public partial class ModeControl : UserControl {
        public ModeControl() {
            InitializeComponent();
        }

        #region Properties
        #endregion

        public new event EventHandler Click {
            add { this.Click += value; }

            remove { this.Click -= value; }
        }

    }
}
