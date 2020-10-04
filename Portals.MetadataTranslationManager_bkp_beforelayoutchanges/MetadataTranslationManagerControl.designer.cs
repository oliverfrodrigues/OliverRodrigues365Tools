namespace Portals.MetadataTranslationManager
{
    partial class MetadataTranslatorControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetadataTranslatorControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadEnvironment = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.cbxActiveRecords = new Portals.MetadataTranslationManager.Controls.CustomCheckBox();
            this.cbxModifiedAfter = new Portals.MetadataTranslationManager.Controls.CustomCheckBox();
            this.dtpCreatedAfter = new System.Windows.Forms.DateTimePicker();
            this.cbxCreatedAfter = new Portals.MetadataTranslationManager.Controls.CustomCheckBox();
            this.dtpModifiedAfter = new System.Windows.Forms.DateTimePicker();
            this.ddlWebsite = new System.Windows.Forms.ComboBox();
            this.lblWebSite = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.tbGrid = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlEntitiesLanguages = new System.Windows.Forms.Panel();
            this.languagePicker = new Portals.MetadataTranslationManager.Controls.LanguagePickerControl();
            this.entityPicker = new Portals.MetadataTranslationManager.Controls.EntityPickerControl();
            this.menuControl = new Portals.MetadataTranslationManager.Controls.MenuControl();
            this.toolStripMenu.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.tbGrid.SuspendLayout();
            this.pnlEntitiesLanguages.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbLoadEnvironment,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1448, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            this.toolStripMenu.Visible = false;
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(77, 28);
            this.tsbClose.Text = "Close ";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbLoadEnvironment
            // 
            this.tsbLoadEnvironment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLoadEnvironment.Name = "tsbLoadEnvironment";
            this.tsbLoadEnvironment.Size = new System.Drawing.Size(133, 28);
            this.tsbLoadEnvironment.Text = "Load Environment";
            this.tsbLoadEnvironment.Click += new System.EventHandler(this.tsbLoadEnvironment_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.AutoSize = true;
            this.pnlRight.Controls.Add(this.pnlFilters);
            this.pnlRight.Controls.Add(this.pnlGrid);
            this.pnlRight.Location = new System.Drawing.Point(579, 11);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(1001, 892);
            this.pnlRight.TabIndex = 7;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.cbxActiveRecords);
            this.pnlFilters.Controls.Add(this.cbxModifiedAfter);
            this.pnlFilters.Controls.Add(this.dtpCreatedAfter);
            this.pnlFilters.Controls.Add(this.cbxCreatedAfter);
            this.pnlFilters.Controls.Add(this.dtpModifiedAfter);
            this.pnlFilters.Controls.Add(this.ddlWebsite);
            this.pnlFilters.Controls.Add(this.lblWebSite);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1001, 138);
            this.pnlFilters.TabIndex = 8;
            // 
            // cbxActiveRecords
            // 
            this.cbxActiveRecords.Checked = true;
            this.cbxActiveRecords.Location = new System.Drawing.Point(468, 25);
            this.cbxActiveRecords.Name = "cbxActiveRecords";
            this.cbxActiveRecords.Size = new System.Drawing.Size(206, 45);
            this.cbxActiveRecords.TabIndex = 1;
            // 
            // cbxModifiedAfter
            // 
            this.cbxModifiedAfter.Checked = false;
            this.cbxModifiedAfter.Location = new System.Drawing.Point(17, 69);
            this.cbxModifiedAfter.Name = "cbxModifiedAfter";
            this.cbxModifiedAfter.Size = new System.Drawing.Size(206, 45);
            this.cbxModifiedAfter.TabIndex = 3;
            // 
            // dtpCreatedAfter
            // 
            this.dtpCreatedAfter.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpCreatedAfter.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.dtpCreatedAfter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedAfter.Location = new System.Drawing.Point(229, 25);
            this.dtpCreatedAfter.Name = "dtpCreatedAfter";
            this.dtpCreatedAfter.Size = new System.Drawing.Size(152, 30);
            this.dtpCreatedAfter.TabIndex = 5;
            // 
            // cbxCreatedAfter
            // 
            this.cbxCreatedAfter.Checked = false;
            this.cbxCreatedAfter.Location = new System.Drawing.Point(17, 18);
            this.cbxCreatedAfter.Name = "cbxCreatedAfter";
            this.cbxCreatedAfter.Size = new System.Drawing.Size(206, 45);
            this.cbxCreatedAfter.TabIndex = 2;
            // 
            // dtpModifiedAfter
            // 
            this.dtpModifiedAfter.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.dtpModifiedAfter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedAfter.Location = new System.Drawing.Point(229, 76);
            this.dtpModifiedAfter.Name = "dtpModifiedAfter";
            this.dtpModifiedAfter.Size = new System.Drawing.Size(152, 30);
            this.dtpModifiedAfter.TabIndex = 4;
            // 
            // ddlWebsite
            // 
            this.ddlWebsite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlWebsite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlWebsite.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlWebsite.FormattingEnabled = true;
            this.ddlWebsite.Location = new System.Drawing.Point(565, 78);
            this.ddlWebsite.Name = "ddlWebsite";
            this.ddlWebsite.Size = new System.Drawing.Size(262, 36);
            this.ddlWebsite.TabIndex = 7;
            // 
            // lblWebSite
            // 
            this.lblWebSite.AutoSize = true;
            this.lblWebSite.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebSite.Location = new System.Drawing.Point(476, 78);
            this.lblWebSite.Name = "lblWebSite";
            this.lblWebSite.Size = new System.Drawing.Size(78, 28);
            this.lblWebSite.TabIndex = 6;
            this.lblWebSite.Text = "Website";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.tbGrid);
            this.pnlGrid.Location = new System.Drawing.Point(0, 185);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(998, 704);
            this.pnlGrid.TabIndex = 0;
            // 
            // tbGrid
            // 
            this.tbGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGrid.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbGrid.Controls.Add(this.tabPage1);
            this.tbGrid.Controls.Add(this.tabPage2);
            this.tbGrid.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrid.Location = new System.Drawing.Point(0, 281);
            this.tbGrid.Name = "tbGrid";
            this.tbGrid.SelectedIndex = 0;
            this.tbGrid.Size = new System.Drawing.Size(998, 447);
            this.tbGrid.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(990, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(990, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlEntitiesLanguages
            // 
            this.pnlEntitiesLanguages.Controls.Add(this.languagePicker);
            this.pnlEntitiesLanguages.Controls.Add(this.entityPicker);
            this.pnlEntitiesLanguages.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEntitiesLanguages.Location = new System.Drawing.Point(258, 0);
            this.pnlEntitiesLanguages.Name = "pnlEntitiesLanguages";
            this.pnlEntitiesLanguages.Size = new System.Drawing.Size(315, 903);
            this.pnlEntitiesLanguages.TabIndex = 8;
            // 
            // languagePicker
            // 
            this.languagePicker._orgService = null;
            this.languagePicker.AutoSize = true;
            this.languagePicker.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.languagePicker.Location = new System.Drawing.Point(0, 620);
            this.languagePicker.Name = "languagePicker";
            this.languagePicker.Size = new System.Drawing.Size(315, 283);
            this.languagePicker.TabIndex = 7;
            // 
            // entityPicker
            // 
            this.entityPicker._orgService = null;
            this.entityPicker.AutoSize = true;
            this.entityPicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.entityPicker.Location = new System.Drawing.Point(0, 0);
            this.entityPicker.Name = "entityPicker";
            this.entityPicker.Size = new System.Drawing.Size(315, 724);
            this.entityPicker.TabIndex = 6;
            // 
            // menuControl
            // 
            this.menuControl.AutoSize = true;
            this.menuControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuControl.Location = new System.Drawing.Point(0, 0);
            this.menuControl.Name = "menuControl";
            this.menuControl.Size = new System.Drawing.Size(258, 903);
            this.menuControl.TabIndex = 6;
            this.menuControl.ButtonCloseClicked += new System.EventHandler(this.menuControl_ButtonCloseClicked);
            this.menuControl.ButtonLoadEnvironmentClicked += new System.EventHandler(this.menuControl_ButtonLoadEnvironmentClicked);
            this.menuControl.ButtonLoadDataClicked += new System.EventHandler(this.menuControl_ButtonLoadDataClicked);
            this.menuControl.ButtonExportDataClicked += new System.EventHandler(this.menuControl_ButtonExportDataClicked);
            this.menuControl.ButtonImportDataClicked += new System.EventHandler(this.menuControl_ButtonImportDataClicked);
            // 
            // MetadataTranslatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlEntitiesLanguages);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.menuControl);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MetadataTranslatorControl";
            this.Size = new System.Drawing.Size(1580, 903);
            this.Load += new System.EventHandler(this.MetadataTranslatorControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.tbGrid.ResumeLayout(false);
            this.pnlEntitiesLanguages.ResumeLayout(false);
            this.pnlEntitiesLanguages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private Portals.MetadataTranslationManager.Controls.MenuControl menuControl;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbLoadEnvironment;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.TabControl tbGrid;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlEntitiesLanguages;
        private Controls.LanguagePickerControl languagePicker;
        private Controls.EntityPickerControl entityPicker;
        private Controls.CustomCheckBox cbxActiveRecords;
        private Controls.CustomCheckBox cbxModifiedAfter;
        private Controls.CustomCheckBox cbxCreatedAfter;
        private System.Windows.Forms.DateTimePicker dtpCreatedAfter;
        private System.Windows.Forms.DateTimePicker dtpModifiedAfter;
        private System.Windows.Forms.ComboBox ddlWebsite;
        private System.Windows.Forms.Label lblWebSite;
        private System.Windows.Forms.Panel pnlFilters;
    }
}
