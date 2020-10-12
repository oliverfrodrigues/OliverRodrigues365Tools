using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Portals.MetadataTranslationManager
{
    public class DataGridHelper
    {
        public DataGridViewColumn SelectColumn { get; set; }
        public DataGridViewColumn IdColumn { get; set; }
        public DataGridViewColumn AttributeColumnLogicalName { get; set; }
        public DataGridViewColumn AttributeDisplayNameColumn { get; set; }
        public DataGridViewColumn NameColumn { get; set; }
        public DataGridViewColumn JsonPathColumn { get; set; }
        public DataGridViewColumn SettingsJsonColumn { get; set; }

        public DataGridHelper()
        {
            SelectColumn = new DataGridViewCheckBoxColumn();
            SelectColumn.Name = "selected";

            IdColumn = new DataGridViewTextBoxColumn();
            IdColumn.Name = "id";
            IdColumn.HeaderText = "ID";
            IdColumn.Visible = false;

            AttributeColumnLogicalName = new DataGridViewTextBoxColumn();
            AttributeColumnLogicalName.Name = "attributelogicalname";
            AttributeColumnLogicalName.HeaderText = "Attribute Logical Name";
            AttributeColumnLogicalName.Visible = false;

            AttributeDisplayNameColumn = new DataGridViewTextBoxColumn();
            AttributeDisplayNameColumn.Name = "attribute";
            AttributeDisplayNameColumn.HeaderText = "Attribute";

            JsonPathColumn = new DataGridViewTextBoxColumn();
            JsonPathColumn.Name = "jsonPath";
            JsonPathColumn.HeaderText = "JSON Path";
            JsonPathColumn.Visible = false;

            SettingsJsonColumn = new DataGridViewTextBoxColumn();
            SettingsJsonColumn.Name = "settingsColumn";
            SettingsJsonColumn.HeaderText = "Settings JSON";
            SettingsJsonColumn.Visible = false;

            NameColumn = new DataGridViewTextBoxColumn();
            NameColumn.Name = "name";
            NameColumn.HeaderText = "Name";
        }

        public TabPage GenerateTab(string displayName, int countRecord, out DataGridView grid, PluginControlBase control)
        {
            TabPage tbPage = new TabPage(string.Format("{0} ({1})", displayName, countRecord));
            tbPage.AutoScroll = true;
            grid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(grid)).BeginInit();
            control.SuspendLayout();
            grid.Parent = tbPage;
            grid.ScrollBars = ScrollBars.Horizontal;

            grid.AutoSize = true;
            //grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Dock = DockStyle.Fill;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToOrderColumns = false;
            grid.AllowUserToResizeColumns = true;
            grid.AllowUserToResizeRows = true;
            grid.ReadOnly = true;
            control.ResumeLayout(false);

            return tbPage;
        }

    }
}
