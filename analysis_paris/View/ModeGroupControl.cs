using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace analysis_paris.View {

    public partial class ModeGroupControl : UserControl {

        private List<ModeControl> _modeList = new List<ModeControl>();
        private int _currentCheckedIndex;

        public int CurrentChedckedIndex {
            get { return _currentCheckedIndex; }
            set { _currentCheckedIndex = value; }
        }

        // Constructor
        public ModeGroupControl() {
            InitializeComponent();

            foreach (ModeControl item in layoutFrame.Controls) {
                item.Click += mode_Click;
                item.Click += Control_Click;
                _modeList.Add(item);
            }

            _modeList[0].Checked = true;
            _currentCheckedIndex = 0;
        }

        // 모드 클릭 이벤트
        private void mode_Click(object sender, System.EventArgs e) {
            //throw new System.NotImplementedException();
            var mode = (ModeControl)sender;

            if (mode.Checked) {
                return;
            }

            int targetIndex = _modeList.IndexOf(mode);
            SetSelectedMode(targetIndex);
        }

        // 선택 모드 변경
        public void SetSelectedMode(int targetIndex) {
            foreach (var item in _modeList.Select((value, index) => (value, index))) {
                if (item.index == targetIndex) {
                    _currentCheckedIndex = item.index;
                    item.value.Checked = true;
                }
                else
                    item.value.Checked = false;
            }
        }

        // 자식 컨트롤에 this 클릭 이벤트 바인딩
        private void Control_Click(object sender, EventArgs e) {
            this.OnClick(e);
        }
    }
}
