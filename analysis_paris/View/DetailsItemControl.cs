using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class DetailsItemControl : UserControl {

        private string _name;

        public string DetailName {
            get { return _name; }
            set { _name = value; lblDetailName.Text = value; }
        }

        private string _value;

        public string DetailValue {
            get { return _value; }
            set { _value = value; lblDetailValue.Text = value; }
        }

        public DetailsItemControl(string aName, string aValue) {
            InitializeComponent();

            DetailName = aName;
            DetailValue = aValue;
        }
    }
}
