using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace analysis_paris.View {
    public partial class TestForm : Form {

        private List<Label> ModeLabelList = new List<Label>();

        public TestForm() {
            InitializeComponent();

            ModeLabelList.Add(label1);
            ModeLabelList.Add(label2);
            ModeLabelList.Add(label3);
        }

        private void modeLabel_Click(object sender, EventArgs e) {
            Label target = (Label)sender;
            int targetIndex = ModeLabelList.IndexOf(target);
            modeGroupControl1.SetSelectedMode(targetIndex);
            SelectedLabelChange(targetIndex);
        }

        private void SelectedLabelChange(int targetIndex) {

            foreach (var item in ModeLabelList.Select((value, index) => (value, index))) {
                if (item.index == targetIndex)
                    item.value.ForeColor = Color.Red;
                else
                    item.value.ForeColor = Color.Green;
            }
        }

        private void modeGroupControl_Click(object sender, EventArgs e) {
            var target = (ModeGroupControl)sender;
            int targetIndex = target.CurrentChedckedIndex;
            SelectedLabelChange(targetIndex);
        }
    }
}
