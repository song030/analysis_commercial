using System.Collections.Generic;
using System.Windows.Forms;

namespace analysis_paris.View {

    public partial class ModeGroupControl : UserControl {

        private List<ModeControl> _modeList = new List<ModeControl>();

        public ModeGroupControl() {
            InitializeComponent();

            foreach (ModeControl item in layoutFrame.Controls) {
                item.Click += mode_Click;
                _modeList.Add(item);
            }

            _modeList[0].Checked = true;
        }

        private void mode_Click(object sender, System.EventArgs e) {
            //throw new System.NotImplementedException();
            var mode = (ModeControl)sender;

            if (mode.Checked) {
                return;
            }

            foreach (var item in _modeList) {
                if (item == mode)
                    item.Checked = true;
                else
                    item.Checked = false;
            }
        }
    }
}
