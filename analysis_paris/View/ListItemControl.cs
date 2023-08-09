using analysis_paris.DAO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class ListItemControl : UserControl {

        #region Properties
        private Paris _paris;

        public Paris ParisInfo {
            get { return _paris; }
            set { _paris = value; }
        }

        private SellingArea _sellingArea;

        public SellingArea SellingArea {
            get { return _sellingArea; }
            set { _sellingArea = value; }
        }
        #endregion

        // Constructor
        public ListItemControl(Paris _itemInfo) {
            InitializeComponent();

            _paris = _itemInfo;
            lblType.Text = _paris.PARIS_NAME;
            lblAddr.Text = _paris.PARIS_ADDRESS;
            lblArea.Text = $"{_paris.AREA_SIZE}m²";
            lblPOption.Text = $"{_paris.MONTHLY_SHOP_REVENUE}";
            lblScore.Text = $"55";
        }

        public ListItemControl(SellingArea _itemInfo) {
            InitializeComponent();

            _sellingArea = _itemInfo;
            lblType.Text = _sellingArea.SELLING_TYPE;
            //lblAddr.Text = _paris.PARIS_ADDRESS;
            //lblArea.Text = $"{_paris.AREA_SIZE}m²";
            //lblPOption.Text = $"{_paris.MONTHLY_SHOP_REVENUE}";
            lblScore.Text = $"55";

            // 스타일 적용
            if (_sellingArea.SELLING_TYPE == "매매") {
                lblType.ForeColor = Color.FromArgb(254, 206, 0);
            }
        }

        // 모든 컨트롤에 클릭 이벤트 연결
        private void Control_Click(object sender, EventArgs e) {
            this.OnClick(e);
        }
    }
}
