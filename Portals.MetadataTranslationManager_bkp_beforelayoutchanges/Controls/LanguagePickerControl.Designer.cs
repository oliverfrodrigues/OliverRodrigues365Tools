namespace Portals.MetadataTranslationManager.Controls
{
    partial class LanguagePickerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pblEntities = new System.Windows.Forms.Panel();
            this.pnlSelectionButtons = new System.Windows.Forms.Panel();
            this.pblClearSelectionButtom = new System.Windows.Forms.Panel();
            this.btnClearSelection = new FontAwesome.Sharp.IconButton();
            this.pnlSelectAllButtom = new System.Windows.Forms.Panel();
            this.btnSelectAll = new FontAwesome.Sharp.IconButton();
            this.pnlLanguageLabel = new System.Windows.Forms.Panel();
            this.lblEntities = new System.Windows.Forms.Label();
            this.lvLanguages = new System.Windows.Forms.ListView();
            this.hdEntity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pblEntities.SuspendLayout();
            this.pnlSelectionButtons.SuspendLayout();
            this.pblClearSelectionButtom.SuspendLayout();
            this.pnlSelectAllButtom.SuspendLayout();
            this.pnlLanguageLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pblEntities
            // 
            this.pblEntities.AutoSize = true;
            this.pblEntities.Controls.Add(this.pnlSelectionButtons);
            this.pblEntities.Controls.Add(this.pnlLanguageLabel);
            this.pblEntities.Controls.Add(this.lvLanguages);
            this.pblEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pblEntities.Location = new System.Drawing.Point(0, 0);
            this.pblEntities.Name = "pblEntities";
            this.pblEntities.Size = new System.Drawing.Size(344, 287);
            this.pblEntities.TabIndex = 0;
            // 
            // pnlSelectionButtons
            // 
            this.pnlSelectionButtons.Controls.Add(this.pblClearSelectionButtom);
            this.pnlSelectionButtons.Controls.Add(this.pnlSelectAllButtom);
            this.pnlSelectionButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectionButtons.Location = new System.Drawing.Point(0, 44);
            this.pnlSelectionButtons.Name = "pnlSelectionButtons";
            this.pnlSelectionButtons.Size = new System.Drawing.Size(344, 52);
            this.pnlSelectionButtons.TabIndex = 11;
            // 
            // pblClearSelectionButtom
            // 
            this.pblClearSelectionButtom.Controls.Add(this.btnClearSelection);
            this.pblClearSelectionButtom.Dock = System.Windows.Forms.DockStyle.Right;
            this.pblClearSelectionButtom.Location = new System.Drawing.Point(178, 0);
            this.pblClearSelectionButtom.Name = "pblClearSelectionButtom";
            this.pblClearSelectionButtom.Size = new System.Drawing.Size(166, 52);
            this.pblClearSelectionButtom.TabIndex = 1;
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearSelection.FlatAppearance.BorderSize = 0;
            this.btnClearSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSelection.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnClearSelection.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSelection.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.btnClearSelection.IconColor = System.Drawing.Color.Black;
            this.btnClearSelection.IconSize = 24;
            this.btnClearSelection.Location = new System.Drawing.Point(0, 0);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnClearSelection.Rotation = 0D;
            this.btnClearSelection.Size = new System.Drawing.Size(166, 52);
            this.btnClearSelection.TabIndex = 12;
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // pnlSelectAllButtom
            // 
            this.pnlSelectAllButtom.Controls.Add(this.btnSelectAll);
            this.pnlSelectAllButtom.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSelectAllButtom.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectAllButtom.Name = "pnlSelectAllButtom";
            this.pnlSelectAllButtom.Size = new System.Drawing.Size(172, 52);
            this.pnlSelectAllButtom.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectAll.FlatAppearance.BorderSize = 0;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            this.btnSelectAll.IconColor = System.Drawing.Color.Black;
            this.btnSelectAll.IconSize = 24;
            this.btnSelectAll.Location = new System.Drawing.Point(0, 0);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnSelectAll.Rotation = 0D;
            this.btnSelectAll.Size = new System.Drawing.Size(172, 52);
            this.btnSelectAll.TabIndex = 11;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // pnlLanguageLabel
            // 
            this.pnlLanguageLabel.Controls.Add(this.lblEntities);
            this.pnlLanguageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLanguageLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlLanguageLabel.Name = "pnlLanguageLabel";
            this.pnlLanguageLabel.Size = new System.Drawing.Size(344, 44);
            this.pnlLanguageLabel.TabIndex = 12;
            // 
            // lblEntities
            // 
            this.lblEntities.AutoSize = true;
            this.lblEntities.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntities.Location = new System.Drawing.Point(89, 9);
            this.lblEntities.Name = "lblEntities";
            this.lblEntities.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblEntities.Size = new System.Drawing.Size(130, 28);
            this.lblEntities.TabIndex = 10;
            this.lblEntities.Text = "LANGUAGES";
            // 
            // lvLanguages
            // 
            this.lvLanguages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lvLanguages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvLanguages.CheckBoxes = true;
            this.lvLanguages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdEntity});
            this.lvLanguages.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLanguages.ForeColor = System.Drawing.Color.White;
            this.lvLanguages.FullRowSelect = true;
            this.lvLanguages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLanguages.HideSelection = false;
            this.lvLanguages.Location = new System.Drawing.Point(7, 102);
            this.lvLanguages.MultiSelect = false;
            this.lvLanguages.Name = "lvLanguages";
            this.lvLanguages.ShowItemToolTips = true;
            this.lvLanguages.Size = new System.Drawing.Size(334, 178);
            this.lvLanguages.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLanguages.TabIndex = 8;
            this.lvLanguages.UseCompatibleStateImageBehavior = false;
            this.lvLanguages.View = System.Windows.Forms.View.Details;
            this.lvLanguages.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvLanguages_ItemChecked);
            // 
            // hdEntity
            // 
            this.hdEntity.Text = "Entity";
            this.hdEntity.Width = 306;
            // 
            // LanguagePickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pblEntities);
            this.Name = "LanguagePickerControl";
            this.Size = new System.Drawing.Size(344, 287);
            this.pblEntities.ResumeLayout(false);
            this.pnlSelectionButtons.ResumeLayout(false);
            this.pblClearSelectionButtom.ResumeLayout(false);
            this.pnlSelectAllButtom.ResumeLayout(false);
            this.pnlLanguageLabel.ResumeLayout(false);
            this.pnlLanguageLabel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pblEntities;
        private System.Windows.Forms.Panel pnlSelectionButtons;
        private System.Windows.Forms.Panel pblClearSelectionButtom;
        private FontAwesome.Sharp.IconButton btnClearSelection;
        private System.Windows.Forms.Panel pnlSelectAllButtom;
        private FontAwesome.Sharp.IconButton btnSelectAll;
        private System.Windows.Forms.Panel pnlLanguageLabel;
        private System.Windows.Forms.Label lblEntities;
        private System.Windows.Forms.ListView lvLanguages;
        private System.Windows.Forms.ColumnHeader hdEntity;
    }
}
