using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace analysis_paris.View {

    public partial class ModeGroupControl : UserControl {

        #region Properties
        private List<ModeControl> _modeList = new List<ModeControl>();
        private int _currentMode;

        public int CurrentMode {
            get { return _currentMode; }
            set { _currentMode = value; }
        }
        #endregion

        public ModeGroupControl() {
            InitializeComponent();

            foreach (ModeControl item in layoutFrame.Controls) {
                item.Click += mode_Click;
                _modeList.Add(item);
            }
        }

        private void mode_Click(object sender, System.EventArgs e) {
            //throw new System.NotImplementedException();
            var mode = (ModeControl)sender;

            Console.WriteLine(mode.GetType());
        }
    }
}
