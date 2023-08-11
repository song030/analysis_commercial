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


        // No Info Constructor
        public ListItemControl() {
            InitializeComponent();
            lblType.Text = "";
            lblArea.Text = "";
            lblPOption.Text = "";
            lblScore.Text = "";

            lblAddr.Text = "검색 결과 없음";
            lblAddr.Font = new Font(lblAddr.Font.Name, 10, FontStyle.Bold);
        }


        // Paris Constructor
        public ListItemControl(Paris _itemInfo) {
            InitializeComponent();

            _paris = _itemInfo;
            lblType.Text = _paris.PARIS_NAME;
            lblAddr.Text = _paris.PARIS_ADDRESS;
            lblArea.Text = $"{_paris.AREA_SIZE}m²";
            lblPOption.Text = $"{_paris.MONTHLY_SHOP_REVENUE:#,##}";
            lblScore.Text = $"{_paris.SCORE}";
        }

        // SellingArea Constructor
        public ListItemControl(SellingArea _itemInfo) {
            InitializeComponent();

            _sellingArea = _itemInfo;
            lblType.Text = _sellingArea.SELLING_TYPE;
            lblAddr.Text = _sellingArea.ADDRESS;
            lblArea.Text = $"{_sellingArea.AREA_SIZE}m²";
            lblScore.Text = $"{_sellingArea.SCORE}";

            // 타입별 적용
            if (_sellingArea.SELLING_TYPE == "매매") {
                if (_sellingArea.SELLING_PRICE == 0)
                    lblPOption.Text = "협의";
                else
                    lblPOption.Text = $"{_sellingArea.SELLING_PRICE}만원";
                lblType.ForeColor = Color.FromArgb(254, 206, 0);
            }
            else {
                string deposit = $"{_sellingArea.DEPOSIT}";
                if (_sellingArea.DEPOSIT < 1)
                    deposit = "협의";

                string rate = $"{_sellingArea.RATE_PER_MONTH}";
                if (_sellingArea.RATE_PER_MONTH < 1)
                    rate = "협의";

                string premium = $"{_sellingArea.PREMIUM}";
                if (_sellingArea.PREMIUM < 1)
                    premium = "협의";

                lblPOption.Text = $"보 {deposit}\n월 {rate}\n권 {premium}";
            }
        }

        // 모든 컨트롤에 클릭 이벤트 연결
        private void Control_Click(object sender, EventArgs e) {
            this.OnClick(e);
        }
    }
}
