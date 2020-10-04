namespace Portals.MetadataTranslationManager.Controls
{
    partial class EntityPickerControl
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
            this.btnClearSelection = new FontAwesome.Sharp.IconButton();
            this.lvEntities = new System.Windows.Forms.ListView();
            this.hdEntity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlEntitiesLabel = new System.Windows.Forms.Panel();
            this.lblEntities = new System.Windows.Forms.Label();
            this.pnlSelectionButtoms = new System.Windows.Forms.Panel();
            this.pnlClearSelectionButtom = new System.Windows.Forms.Panel();
            this.pnlSelectAllButtom = new System.Windows.Forms.Panel();
            this.btnSelectAll = new FontAwesome.Sharp.IconButton();
            this.pnlEntitiesLabel.SuspendLayout();
            this.pnlSelectionButtoms.SuspendLayout();
            this.pnlClearSelectionButtom.SuspendLayout();
            this.pnlSelectAllButtom.SuspendLayout();
            this.SuspendLayout();
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
            this.btnClearSelection.TabIndex = 16;
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // lvEntities
            // 
            this.lvEntities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lvEntities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvEntities.CheckBoxes = true;
            this.lvEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdEntity});
            this.lvEntities.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvEntities.ForeColor = System.Drawing.Color.White;
            this.lvEntities.FullRowSelect = true;
            this.lvEntities.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvEntities.HideSelection = false;
            this.lvEntities.Location = new System.Drawing.Point(3, 105);
            this.lvEntities.MultiSelect = false;
            this.lvEntities.Name = "lvEntities";
            this.lvEntities.Size = new System.Drawing.Size(334, 616);
            this.lvEntities.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvEntities.TabIndex = 14;
            this.lvEntities.UseCompatibleStateImageBehavior = false;
            this.lvEntities.View = System.Windows.Forms.View.Details;
            // 
            // hdEntity
            // 
            this.hdEntity.Text = "Entity";
            this.hdEntity.Width = 306;
            // 
            // pnlEntitiesLabel
            // 
            this.pnlEntitiesLabel.Controls.Add(this.lblEntities);
            this.pnlEntitiesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEntitiesLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlEntitiesLabel.Name = "pnlEntitiesLabel";
            this.pnlEntitiesLabel.Size = new System.Drawing.Size(340, 47);
            this.pnlEntitiesLabel.TabIndex = 17;
            // 
            // lblEntities
            // 
            this.lblEntities.AutoSize = true;
            this.lblEntities.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntities.Location = new System.Drawing.Point(100, 10);
            this.lblEntities.Name = "lblEntities";
            this.lblEntities.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblEntities.Size = new System.Drawing.Size(96, 28);
            this.lblEntities.TabIndex = 14;
            this.lblEntities.Text = "ENTITIES";
            // 
            // pnlSelectionButtoms
            // 
            this.pnlSelectionButtoms.Controls.Add(this.pnlClearSelectionButtom);
            this.pnlSelectionButtoms.Controls.Add(this.pnlSelectAllButtom);
            this.pnlSelectionButtoms.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectionButtoms.Location = new System.Drawing.Point(0, 47);
            this.pnlSelectionButtoms.Name = "pnlSelectionButtoms";
            this.pnlSelectionButtoms.Size = new System.Drawing.Size(340, 52);
            this.pnlSelectionButtoms.TabIndex = 0;
            // 
            // pnlClearSelectionButtom
            // 
            this.pnlClearSelectionButtom.Controls.Add(this.btnClearSelection);
            this.pnlClearSelectionButtom.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlClearSelectionButtom.Location = new System.Drawing.Point(174, 0);
            this.pnlClearSelectionButtom.Name = "pnlClearSelectionButtom";
            this.pnlClearSelectionButtom.Size = new System.Drawing.Size(166, 52);
            this.pnlClearSelectionButtom.TabIndex = 2;
            // 
            // pnlSelectAllButtom
            // 
            this.pnlSelectAllButtom.Controls.Add(this.btnSelectAll);
            this.pnlSelectAllButtom.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSelectAllButtom.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectAllButtom.Name = "pnlSelectAllButtom";
            this.pnlSelectAllButtom.Size = new System.Drawing.Size(172, 52);
            this.pnlSelectAllButtom.TabIndex = 1;
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
            this.btnSelectAll.TabIndex = 16;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // EntityPickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnlSelectionButtoms);
            this.Controls.Add(this.pnlEntitiesLabel);
            this.Controls.Add(this.lvEntities);
            this.Name = "EntityPickerControl";
            this.Size = new System.Drawing.Size(340, 732);
            this.pnlEntitiesLabel.ResumeLayout(false);
            this.pnlEntitiesLabel.PerformLayout();
            this.pnlSelectionButtoms.ResumeLayout(false);
            this.pnlClearSelectionButtom.ResumeLayout(false);
            this.pnlSelectAllButtom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnClearSelection;
        private System.Windows.Forms.ListView lvEntities;
        private System.Windows.Forms.ColumnHeader hdEntity;
        private System.Windows.Forms.Panel pnlEntitiesLabel;
        private System.Windows.Forms.Label lblEntities;
        private System.Windows.Forms.Panel pnlSelectionButtoms;
        private System.Windows.Forms.Panel pnlSelectAllButtom;
        private System.Windows.Forms.Panel pnlClearSelectionButtom;
        private FontAwesome.Sharp.IconButton btnSelectAll;
    }
}
