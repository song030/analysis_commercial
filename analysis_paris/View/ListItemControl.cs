using System;
using System.Drawing;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class ListItemControl : UserControl {

        #region Properties
        private int _id;

        public int ItemId {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        // Constructor
        public ListItemControl() {
            InitializeComponent();
        }

        // 데이터 이식 동적 생성 시
        public ListItemControl(int itemId, string itemType, string itemAddr, double itemArea, int itemScore) {
            InitializeComponent();

            // 데이터 적용 : 매매타입, 주소, 면적, 거래조건, 스코어
            _id = itemId;
            lblType.Text = itemType;
            lblAddr.Text = itemAddr;
            lblArea.Text = $"{itemArea}m²";
            // 거래조건 추가 예정
            lblScore.Text = $"{itemScore}";

            // 스타일 적용
            if (itemType == "매매") {
                lblType.ForeColor = Color.FromArgb(254, 206, 0);
            }
        }

        // 모든 컨트롤에 클릭 이벤트 연결
        public new event EventHandler Click {
            add {
                base.Click += value;

                foreach (Control item in this.Controls) {
                    item.Click += value;
                    foreach (Control itemitem in item.Controls) {
                        itemitem.Click += value;
                    }
                }
            }
            remove {
                base.Click -= value;

                foreach (Control item in this.Controls) {
                    item.Click -= value;
                    foreach (Control itemitem in item.Controls) {
                        itemitem.Click -= value;
                    }
                }
            }
        }
    }
}
