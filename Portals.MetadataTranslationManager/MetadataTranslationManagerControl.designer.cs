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
            this.lblWebSite = new System.Windows.Forms.Label();
            this.ddlWebsite = new System.Windows.Forms.ComboBox();
            this.dtpModifiedAfter = new System.Windows.Forms.DateTimePicker();
            this.dtpCreatedAfter = new System.Windows.Forms.DateTimePicker();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblPanelMenu = new System.Windows.Forms.TableLayoutPanel();
            this.flowPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadEnvironment = new FontAwesome.Sharp.IconButton();
            this.btnLoadData = new FontAwesome.Sharp.IconButton();
            this.btnExport = new FontAwesome.Sharp.IconButton();
            this.btnImportData = new FontAwesome.Sharp.IconButton();
            this.flowPanelExit = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.tblLayoutEntitiesLanguages = new System.Windows.Forms.TableLayoutPanel();
            this.lvLanguages = new System.Windows.Forms.ListView();
            this.hdEntity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvEntities = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEntities = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblPanelLanguagesSelection = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearSelectionLanguages = new FontAwesome.Sharp.IconButton();
            this.btnSelectAllLanguages = new FontAwesome.Sharp.IconButton();
            this.tblPanelEntitiesSelection = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearSelectionEntities = new FontAwesome.Sharp.IconButton();
            this.btnSelectAllEntities = new FontAwesome.Sharp.IconButton();
            this.tblLayoutFiltersGrid = new System.Windows.Forms.TableLayoutPanel();
            this.panelFields = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxActiveRecords = new Portals.MetadataTranslationManager.Controls.CustomCheckBox();
            this.cbxModifiedAfter = new Portals.MetadataTranslationManager.Controls.CustomCheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbxCreatedAfter = new Portals.MetadataTranslationManager.Controls.CustomCheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbGrid = new System.Windows.Forms.TabControl();
            this.toolStripMenu.SuspendLayout();
            this.tblLayoutMain.SuspendLayout();
            this.tblPanelMenu.SuspendLayout();
            this.flowPanelMenu.SuspendLayout();
            this.flowPanelExit.SuspendLayout();
            this.tblLayoutEntitiesLanguages.SuspendLayout();
            this.tblPanelLanguagesSelection.SuspendLayout();
            this.tblPanelEntitiesSelection.SuspendLayout();
            this.tblLayoutFiltersGrid.SuspendLayout();
            this.panelFields.SuspendLayout();
            this.tbGrid.SuspendLayout();
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
            this.toolStripMenu.Size = new System.Drawing.Size(1580, 31);
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
            // dtpModifiedAfter
            // 
            this.dtpModifiedAfter.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.dtpModifiedAfter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedAfter.Location = new System.Drawing.Point(229, 76);
            this.dtpModifiedAfter.Name = "dtpModifiedAfter";
            this.dtpModifiedAfter.Size = new System.Drawing.Size(152, 30);
            this.dtpModifiedAfter.TabIndex = 4;
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
            // tblLayoutMain
            // 
            this.tblLayoutMain.ColumnCount = 3;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 358F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Controls.Add(this.tblPanelMenu, 0, 0);
            this.tblLayoutMain.Controls.Add(this.tblLayoutEntitiesLanguages, 1, 0);
            this.tblLayoutMain.Controls.Add(this.tblLayoutFiltersGrid, 2, 0);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 1;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutMain.Size = new System.Drawing.Size(1692, 729);
            this.tblLayoutMain.TabIndex = 5;
            // 
            // tblPanelMenu
            // 
            this.tblPanelMenu.BackColor = System.Drawing.Color.Purple;
            this.tblPanelMenu.ColumnCount = 1;
            this.tblPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 244F));
            this.tblPanelMenu.Controls.Add(this.flowPanelMenu, 0, 1);
            this.tblPanelMenu.Controls.Add(this.flowPanelExit, 0, 2);
            this.tblPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanelMenu.Location = new System.Drawing.Point(3, 3);
            this.tblPanelMenu.Name = "tblPanelMenu";
            this.tblPanelMenu.RowCount = 3;
            this.tblPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tblPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPanelMenu.Size = new System.Drawing.Size(214, 723);
            this.tblPanelMenu.TabIndex = 2;
            // 
            // flowPanelMenu
            // 
            this.flowPanelMenu.BackColor = System.Drawing.Color.Purple;
            this.flowPanelMenu.Controls.Add(this.btnLoadEnvironment);
            this.flowPanelMenu.Controls.Add(this.btnLoadData);
            this.flowPanelMenu.Controls.Add(this.btnExport);
            this.flowPanelMenu.Controls.Add(this.btnImportData);
            this.flowPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelMenu.Location = new System.Drawing.Point(3, 147);
            this.flowPanelMenu.Name = "flowPanelMenu";
            this.flowPanelMenu.Size = new System.Drawing.Size(238, 391);
            this.flowPanelMenu.TabIndex = 0;
            // 
            // btnLoadEnvironment
            // 
            this.btnLoadEnvironment.FlatAppearance.BorderSize = 0;
            this.btnLoadEnvironment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadEnvironment.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLoadEnvironment.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadEnvironment.ForeColor = System.Drawing.Color.White;
            this.btnLoadEnvironment.IconChar = FontAwesome.Sharp.IconChar.Server;
            this.btnLoadEnvironment.IconColor = System.Drawing.Color.White;
            this.btnLoadEnvironment.IconSize = 24;
            this.btnLoadEnvironment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadEnvironment.Location = new System.Drawing.Point(3, 3);
            this.btnLoadEnvironment.Name = "btnLoadEnvironment";
            this.btnLoadEnvironment.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnLoadEnvironment.Rotation = 0D;
            this.btnLoadEnvironment.Size = new System.Drawing.Size(241, 43);
            this.btnLoadEnvironment.TabIndex = 8;
            this.btnLoadEnvironment.Text = "Load Environment";
            this.btnLoadEnvironment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadEnvironment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadEnvironment.UseVisualStyleBackColor = true;
            this.btnLoadEnvironment.Click += new System.EventHandler(this.btnLoadEnvironment_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.FlatAppearance.BorderSize = 0;
            this.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadData.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLoadData.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadData.ForeColor = System.Drawing.Color.White;
            this.btnLoadData.IconChar = FontAwesome.Sharp.IconChar.Table;
            this.btnLoadData.IconColor = System.Drawing.Color.White;
            this.btnLoadData.IconSize = 24;
            this.btnLoadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadData.Location = new System.Drawing.Point(3, 52);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnLoadData.Rotation = 0D;
            this.btnLoadData.Size = new System.Drawing.Size(193, 43);
            this.btnLoadData.TabIndex = 12;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnExport.IconColor = System.Drawing.Color.White;
            this.btnExport.IconSize = 24;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(3, 101);
            this.btnExport.Name = "btnExport";
            this.btnExport.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnExport.Rotation = 0D;
            this.btnExport.Size = new System.Drawing.Size(193, 43);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export Data";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImportData
            // 
            this.btnImportData.FlatAppearance.BorderSize = 0;
            this.btnImportData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportData.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnImportData.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportData.ForeColor = System.Drawing.Color.White;
            this.btnImportData.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.btnImportData.IconColor = System.Drawing.Color.White;
            this.btnImportData.IconSize = 24;
            this.btnImportData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportData.Location = new System.Drawing.Point(3, 150);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnImportData.Rotation = 0D;
            this.btnImportData.Size = new System.Drawing.Size(193, 43);
            this.btnImportData.TabIndex = 14;
            this.btnImportData.Text = "Import Data";
            this.btnImportData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // flowPanelExit
            // 
            this.flowPanelExit.BackColor = System.Drawing.Color.Purple;
            this.flowPanelExit.Controls.Add(this.btnClose);
            this.flowPanelExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelExit.Location = new System.Drawing.Point(3, 544);
            this.flowPanelExit.Name = "flowPanelExit";
            this.flowPanelExit.Size = new System.Drawing.Size(238, 176);
            this.flowPanelExit.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconSize = 24;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnClose.Rotation = 0D;
            this.btnClose.Size = new System.Drawing.Size(222, 43);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tblLayoutEntitiesLanguages
            // 
            this.tblLayoutEntitiesLanguages.ColumnCount = 1;
            this.tblLayoutEntitiesLanguages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutEntitiesLanguages.Controls.Add(this.lvLanguages, 0, 5);
            this.tblLayoutEntitiesLanguages.Controls.Add(this.lvEntities, 0, 2);
            this.tblLayoutEntitiesLanguages.Controls.Add(this.lblEntities, 0, 0);
            this.tblLayoutEntitiesLanguages.Controls.Add(this.label1, 0, 3);
            this.tblLayoutEntitiesLanguages.Controls.Add(this.tblPanelLanguagesSelection, 0, 4);
            this.tblLayoutEntitiesLanguages.Controls.Add(this.tblPanelEntitiesSelection, 0, 1);
            this.tblLayoutEntitiesLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutEntitiesLanguages.Location = new System.Drawing.Point(223, 3);
            this.tblLayoutEntitiesLanguages.Name = "tblLayoutEntitiesLanguages";
            this.tblLayoutEntitiesLanguages.RowCount = 6;
            this.tblLayoutEntitiesLanguages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblLayoutEntitiesLanguages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayoutEntitiesLanguages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblLayoutEntitiesLanguages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblLayoutEntitiesLanguages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayoutEntitiesLanguages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblLayoutEntitiesLanguages.Size = new System.Drawing.Size(352, 723);
            this.tblLayoutEntitiesLanguages.TabIndex = 0;
            // 
            // lvLanguages
            // 
            this.lvLanguages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lvLanguages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvLanguages.CheckBoxes = true;
            this.lvLanguages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdEntity});
            this.lvLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLanguages.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLanguages.ForeColor = System.Drawing.Color.White;
            this.lvLanguages.FullRowSelect = true;
            this.lvLanguages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLanguages.HideSelection = false;
            this.lvLanguages.Location = new System.Drawing.Point(3, 575);
            this.lvLanguages.MultiSelect = false;
            this.lvLanguages.Name = "lvLanguages";
            this.lvLanguages.ShowItemToolTips = true;
            this.lvLanguages.Size = new System.Drawing.Size(346, 145);
            this.lvLanguages.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLanguages.TabIndex = 17;
            this.lvLanguages.UseCompatibleStateImageBehavior = false;
            this.lvLanguages.View = System.Windows.Forms.View.Details;
            this.lvLanguages.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvLanguages_ItemChecked);
            // 
            // hdEntity
            // 
            this.hdEntity.Text = "Entity";
            this.hdEntity.Width = 306;
            // 
            // lvEntities
            // 
            this.lvEntities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lvEntities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvEntities.CheckBoxes = true;
            this.lvEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEntities.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvEntities.ForeColor = System.Drawing.Color.White;
            this.lvEntities.FullRowSelect = true;
            this.lvEntities.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvEntities.HideSelection = false;
            this.lvEntities.Location = new System.Drawing.Point(0, 110);
            this.lvEntities.Margin = new System.Windows.Forms.Padding(0);
            this.lvEntities.MultiSelect = false;
            this.lvEntities.Name = "lvEntities";
            this.lvEntities.Size = new System.Drawing.Size(352, 352);
            this.lvEntities.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvEntities.TabIndex = 16;
            this.lvEntities.UseCompatibleStateImageBehavior = false;
            this.lvEntities.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Entity";
            this.columnHeader1.Width = 306;
            // 
            // lblEntities
            // 
            this.lblEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEntities.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntities.Location = new System.Drawing.Point(0, 0);
            this.lblEntities.Margin = new System.Windows.Forms.Padding(0);
            this.lblEntities.Name = "lblEntities";
            this.lblEntities.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblEntities.Size = new System.Drawing.Size(352, 50);
            this.lblEntities.TabIndex = 15;
            this.lblEntities.Text = "ENTITIES";
            this.lblEntities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 462);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(352, 50);
            this.label1.TabIndex = 12;
            this.label1.Text = "LANGUAGES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblPanelLanguagesSelection
            // 
            this.tblPanelLanguagesSelection.ColumnCount = 2;
            this.tblPanelLanguagesSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelLanguagesSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelLanguagesSelection.Controls.Add(this.btnClearSelectionLanguages, 1, 0);
            this.tblPanelLanguagesSelection.Controls.Add(this.btnSelectAllLanguages, 0, 0);
            this.tblPanelLanguagesSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanelLanguagesSelection.Location = new System.Drawing.Point(0, 512);
            this.tblPanelLanguagesSelection.Margin = new System.Windows.Forms.Padding(0);
            this.tblPanelLanguagesSelection.Name = "tblPanelLanguagesSelection";
            this.tblPanelLanguagesSelection.RowCount = 1;
            this.tblPanelLanguagesSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelLanguagesSelection.Size = new System.Drawing.Size(352, 60);
            this.tblPanelLanguagesSelection.TabIndex = 0;
            // 
            // btnClearSelectionLanguages
            // 
            this.btnClearSelectionLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearSelectionLanguages.FlatAppearance.BorderSize = 0;
            this.btnClearSelectionLanguages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSelectionLanguages.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnClearSelectionLanguages.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSelectionLanguages.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.btnClearSelectionLanguages.IconColor = System.Drawing.Color.Black;
            this.btnClearSelectionLanguages.IconSize = 24;
            this.btnClearSelectionLanguages.Location = new System.Drawing.Point(176, 0);
            this.btnClearSelectionLanguages.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearSelectionLanguages.Name = "btnClearSelectionLanguages";
            this.btnClearSelectionLanguages.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnClearSelectionLanguages.Rotation = 0D;
            this.btnClearSelectionLanguages.Size = new System.Drawing.Size(176, 60);
            this.btnClearSelectionLanguages.TabIndex = 13;
            this.btnClearSelectionLanguages.Text = "Clear Selection";
            this.btnClearSelectionLanguages.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearSelectionLanguages.UseVisualStyleBackColor = true;
            this.btnClearSelectionLanguages.Click += new System.EventHandler(this.btnClearSelectionLanguages_Click);
            // 
            // btnSelectAllLanguages
            // 
            this.btnSelectAllLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectAllLanguages.FlatAppearance.BorderSize = 0;
            this.btnSelectAllLanguages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAllLanguages.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSelectAllLanguages.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAllLanguages.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            this.btnSelectAllLanguages.IconColor = System.Drawing.Color.Black;
            this.btnSelectAllLanguages.IconSize = 24;
            this.btnSelectAllLanguages.Location = new System.Drawing.Point(0, 0);
            this.btnSelectAllLanguages.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectAllLanguages.Name = "btnSelectAllLanguages";
            this.btnSelectAllLanguages.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnSelectAllLanguages.Rotation = 0D;
            this.btnSelectAllLanguages.Size = new System.Drawing.Size(176, 60);
            this.btnSelectAllLanguages.TabIndex = 12;
            this.btnSelectAllLanguages.Text = "Select All";
            this.btnSelectAllLanguages.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectAllLanguages.UseVisualStyleBackColor = true;
            this.btnSelectAllLanguages.Click += new System.EventHandler(this.btnSelectAllLanguages_Click);
            // 
            // tblPanelEntitiesSelection
            // 
            this.tblPanelEntitiesSelection.ColumnCount = 2;
            this.tblPanelEntitiesSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelEntitiesSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelEntitiesSelection.Controls.Add(this.btnClearSelectionEntities, 0, 0);
            this.tblPanelEntitiesSelection.Controls.Add(this.btnSelectAllEntities, 0, 0);
            this.tblPanelEntitiesSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanelEntitiesSelection.Location = new System.Drawing.Point(0, 50);
            this.tblPanelEntitiesSelection.Margin = new System.Windows.Forms.Padding(0);
            this.tblPanelEntitiesSelection.Name = "tblPanelEntitiesSelection";
            this.tblPanelEntitiesSelection.RowCount = 1;
            this.tblPanelEntitiesSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelEntitiesSelection.Size = new System.Drawing.Size(352, 60);
            this.tblPanelEntitiesSelection.TabIndex = 1;
            // 
            // btnClearSelectionEntities
            // 
            this.btnClearSelectionEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearSelectionEntities.FlatAppearance.BorderSize = 0;
            this.btnClearSelectionEntities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSelectionEntities.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnClearSelectionEntities.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSelectionEntities.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.btnClearSelectionEntities.IconColor = System.Drawing.Color.Black;
            this.btnClearSelectionEntities.IconSize = 24;
            this.btnClearSelectionEntities.Location = new System.Drawing.Point(176, 0);
            this.btnClearSelectionEntities.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearSelectionEntities.Name = "btnClearSelectionEntities";
            this.btnClearSelectionEntities.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnClearSelectionEntities.Rotation = 0D;
            this.btnClearSelectionEntities.Size = new System.Drawing.Size(176, 60);
            this.btnClearSelectionEntities.TabIndex = 18;
            this.btnClearSelectionEntities.Text = "Clear Selection";
            this.btnClearSelectionEntities.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearSelectionEntities.UseVisualStyleBackColor = true;
            this.btnClearSelectionEntities.Click += new System.EventHandler(this.btnClearSelectionEntities_Click);
            // 
            // btnSelectAllEntities
            // 
            this.btnSelectAllEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectAllEntities.FlatAppearance.BorderSize = 0;
            this.btnSelectAllEntities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAllEntities.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSelectAllEntities.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAllEntities.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            this.btnSelectAllEntities.IconColor = System.Drawing.Color.Black;
            this.btnSelectAllEntities.IconSize = 24;
            this.btnSelectAllEntities.Location = new System.Drawing.Point(0, 0);
            this.btnSelectAllEntities.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectAllEntities.Name = "btnSelectAllEntities";
            this.btnSelectAllEntities.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnSelectAllEntities.Rotation = 0D;
            this.btnSelectAllEntities.Size = new System.Drawing.Size(176, 60);
            this.btnSelectAllEntities.TabIndex = 17;
            this.btnSelectAllEntities.Text = "Select All";
            this.btnSelectAllEntities.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectAllEntities.UseVisualStyleBackColor = true;
            this.btnSelectAllEntities.Click += new System.EventHandler(this.btnSelectAllEntities_Click);
            // 
            // tblLayoutFiltersGrid
            // 
            this.tblLayoutFiltersGrid.ColumnCount = 1;
            this.tblLayoutFiltersGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutFiltersGrid.Controls.Add(this.tbGrid, 0, 1);
            this.tblLayoutFiltersGrid.Controls.Add(this.panelFields, 0, 0);
            this.tblLayoutFiltersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutFiltersGrid.Location = new System.Drawing.Point(581, 3);
            this.tblLayoutFiltersGrid.Name = "tblLayoutFiltersGrid";
            this.tblLayoutFiltersGrid.RowCount = 2;
            this.tblLayoutFiltersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblLayoutFiltersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayoutFiltersGrid.Size = new System.Drawing.Size(1108, 723);
            this.tblLayoutFiltersGrid.TabIndex = 1;
            // 
            // panelFields
            // 
            this.panelFields.Controls.Add(this.label5);
            this.panelFields.Controls.Add(this.label4);
            this.panelFields.Controls.Add(this.label3);
            this.panelFields.Controls.Add(this.cbxActiveRecords);
            this.panelFields.Controls.Add(this.cbxModifiedAfter);
            this.panelFields.Controls.Add(this.dateTimePicker2);
            this.panelFields.Controls.Add(this.comboBox1);
            this.panelFields.Controls.Add(this.label2);
            this.panelFields.Controls.Add(this.dateTimePicker1);
            this.panelFields.Controls.Add(this.cbxCreatedAfter);
            this.panelFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFields.Location = new System.Drawing.Point(3, 3);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(1102, 174);
            this.panelFields.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Modified After";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Created After";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(494, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Website";
            // 
            // cbxActiveRecords
            // 
            this.cbxActiveRecords.Checked = true;
            this.cbxActiveRecords.Location = new System.Drawing.Point(438, 32);
            this.cbxActiveRecords.Name = "cbxActiveRecords";
            this.cbxActiveRecords.Size = new System.Drawing.Size(50, 45);
            this.cbxActiveRecords.TabIndex = 8;
            // 
            // cbxModifiedAfter
            // 
            this.cbxModifiedAfter.Checked = false;
            this.cbxModifiedAfter.Location = new System.Drawing.Point(26, 83);
            this.cbxModifiedAfter.Name = "cbxModifiedAfter";
            this.cbxModifiedAfter.Size = new System.Drawing.Size(34, 45);
            this.cbxModifiedAfter.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(238, 90);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(152, 30);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(526, 89);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(262, 31);
            this.comboBox1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(442, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Website";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(238, 39);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(152, 30);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // cbxCreatedAfter
            // 
            this.cbxCreatedAfter.Checked = false;
            this.cbxCreatedAfter.Location = new System.Drawing.Point(26, 32);
            this.cbxCreatedAfter.Name = "cbxCreatedAfter";
            this.cbxCreatedAfter.Size = new System.Drawing.Size(34, 45);
            this.cbxCreatedAfter.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1100, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1100, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbGrid
            // 
            this.tbGrid.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbGrid.Controls.Add(this.tabPage1);
            this.tbGrid.Controls.Add(this.tabPage2);
            this.tbGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGrid.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrid.Location = new System.Drawing.Point(0, 180);
            this.tbGrid.Margin = new System.Windows.Forms.Padding(0);
            this.tbGrid.Name = "tbGrid";
            this.tbGrid.SelectedIndex = 0;
            this.tbGrid.Size = new System.Drawing.Size(1108, 543);
            this.tbGrid.TabIndex = 4;
            // 
            // MetadataTranslatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayoutMain);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MetadataTranslatorControl";
            this.Size = new System.Drawing.Size(1692, 729);
            this.Load += new System.EventHandler(this.MetadataTranslatorControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tblLayoutMain.ResumeLayout(false);
            this.tblPanelMenu.ResumeLayout(false);
            this.flowPanelMenu.ResumeLayout(false);
            this.flowPanelExit.ResumeLayout(false);
            this.tblLayoutEntitiesLanguages.ResumeLayout(false);
            this.tblPanelLanguagesSelection.ResumeLayout(false);
            this.tblPanelEntitiesSelection.ResumeLayout(false);
            this.tblLayoutFiltersGrid.ResumeLayout(false);
            this.panelFields.ResumeLayout(false);
            this.panelFields.PerformLayout();
            this.tbGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbLoadEnvironment;
        private System.Windows.Forms.Label lblWebSite;
        private System.Windows.Forms.ComboBox ddlWebsite;
        private System.Windows.Forms.DateTimePicker dtpModifiedAfter;
        private System.Windows.Forms.DateTimePicker dtpCreatedAfter;
        private System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tblLayoutEntitiesLanguages;
        private System.Windows.Forms.TableLayoutPanel tblPanelMenu;
        private System.Windows.Forms.FlowLayoutPanel flowPanelMenu;
        private FontAwesome.Sharp.IconButton btnLoadEnvironment;
        private System.Windows.Forms.FlowLayoutPanel flowPanelExit;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnLoadData;
        private FontAwesome.Sharp.IconButton btnExport;
        private FontAwesome.Sharp.IconButton btnImportData;
        private System.Windows.Forms.TableLayoutPanel tblPanelLanguagesSelection;
        private System.Windows.Forms.TableLayoutPanel tblPanelEntitiesSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEntities;
        private System.Windows.Forms.ListView lvLanguages;
        private System.Windows.Forms.ColumnHeader hdEntity;
        private System.Windows.Forms.ListView lvEntities;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private FontAwesome.Sharp.IconButton btnSelectAllEntities;
        private FontAwesome.Sharp.IconButton btnClearSelectionEntities;
        private FontAwesome.Sharp.IconButton btnSelectAllLanguages;
        private FontAwesome.Sharp.IconButton btnClearSelectionLanguages;
        private System.Windows.Forms.TableLayoutPanel tblLayoutFiltersGrid;
        private System.Windows.Forms.Panel panelFields;
        private Controls.CustomCheckBox cbxActiveRecords;
        private Controls.CustomCheckBox cbxModifiedAfter;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Controls.CustomCheckBox cbxCreatedAfter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tbGrid;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
