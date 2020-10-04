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

        public CustomCheckBox(bool checkedByDefault)
        {
            InitializeComponent();

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
