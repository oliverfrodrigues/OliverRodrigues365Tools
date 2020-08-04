using System;
using System.Windows.Forms;

namespace Portals.MetadataTranslationManager.Controls
{
    public partial class CustomCheckBox : UserControl
    {
        public bool Checked { get; set; }

        public CustomCheckBox()
        {
            InitializeComponent();
        }

        public CustomCheckBox(string displayText)
        {
            InitializeComponent();
            btnCheckBox.Text = displayText;
        }

        public CustomCheckBox(string displayText, bool checkedByDefault)
        {
            InitializeComponent();

            btnCheckBox.Text = displayText;
            Checked = checkedByDefault;
            if (Checked)
            {
                btnCheckBox.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            }
            else
            {
                btnCheckBox.IconChar = FontAwesome.Sharp.IconChar.Square;
            }
        }

        private void btnCheckBox_Click(object sender, EventArgs e)
        {
            Checked = !Checked;
            if (Checked)
            {
                btnCheckBox.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            }
            else
            {
                btnCheckBox.IconChar = FontAwesome.Sharp.IconChar.Square;
            }
        }
    }
}
