namespace Portals.MetadataTranslationManager.Controls
{
    partial class MenuControl
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnImportData = new FontAwesome.Sharp.IconButton();
            this.btnExport = new FontAwesome.Sharp.IconButton();
            this.btnLoadData = new FontAwesome.Sharp.IconButton();
            this.btnLoadEnvironment = new FontAwesome.Sharp.IconButton();
            this.pnlMenuBottom = new System.Windows.Forms.Panel();
            this.pnlMenuTop = new System.Windows.Forms.Panel();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Purple;
            this.pnlMenu.Controls.Add(this.btnImportData);
            this.pnlMenu.Controls.Add(this.btnExport);
            this.pnlMenu.Controls.Add(this.btnLoadData);
            this.pnlMenu.Controls.Add(this.btnLoadEnvironment);
            this.pnlMenu.Controls.Add(this.pnlMenuBottom);
            this.pnlMenu.Controls.Add(this.pnlMenuTop);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(258, 503);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnImportData
            // 
            this.btnImportData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImportData.FlatAppearance.BorderSize = 0;
            this.btnImportData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportData.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnImportData.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportData.ForeColor = System.Drawing.Color.White;
            this.btnImportData.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.btnImportData.IconColor = System.Drawing.Color.White;
            this.btnImportData.IconSize = 28;
            this.btnImportData.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnImportData.Location = new System.Drawing.Point(0, 257);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnImportData.Rotation = 0D;
            this.btnImportData.Size = new System.Drawing.Size(258, 43);
            this.btnImportData.TabIndex = 7;
            this.btnImportData.Text = "Import Data";
            this.btnImportData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnExport.IconColor = System.Drawing.Color.White;
            this.btnExport.IconSize = 28;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnExport.Location = new System.Drawing.Point(0, 214);
            this.btnExport.Name = "btnExport";
            this.btnExport.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnExport.Rotation = 0D;
            this.btnExport.Size = new System.Drawing.Size(258, 43);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export Data";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadData.FlatAppearance.BorderSize = 0;
            this.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadData.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLoadData.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadData.ForeColor = System.Drawing.Color.White;
            this.btnLoadData.IconChar = FontAwesome.Sharp.IconChar.Table;
            this.btnLoadData.IconColor = System.Drawing.Color.White;
            this.btnLoadData.IconSize = 28;
            this.btnLoadData.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLoadData.Location = new System.Drawing.Point(0, 171);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnLoadData.Rotation = 0D;
            this.btnLoadData.Size = new System.Drawing.Size(258, 43);
            this.btnLoadData.TabIndex = 5;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnLoadEnvironment
            // 
            this.btnLoadEnvironment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadEnvironment.FlatAppearance.BorderSize = 0;
            this.btnLoadEnvironment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadEnvironment.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLoadEnvironment.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadEnvironment.ForeColor = System.Drawing.Color.White;
            this.btnLoadEnvironment.IconChar = FontAwesome.Sharp.IconChar.Server;
            this.btnLoadEnvironment.IconColor = System.Drawing.Color.White;
            this.btnLoadEnvironment.IconSize = 28;
            this.btnLoadEnvironment.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLoadEnvironment.Location = new System.Drawing.Point(0, 128);
            this.btnLoadEnvironment.Name = "btnLoadEnvironment";
            this.btnLoadEnvironment.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnLoadEnvironment.Rotation = 0D;
            this.btnLoadEnvironment.Size = new System.Drawing.Size(258, 43);
            this.btnLoadEnvironment.TabIndex = 4;
            this.btnLoadEnvironment.Text = "Load Environment";
            this.btnLoadEnvironment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadEnvironment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadEnvironment.UseVisualStyleBackColor = true;
            this.btnLoadEnvironment.Click += new System.EventHandler(this.btnLoadEnvironment_Click);
            // 
            // pnlMenuBottom
            // 
            this.pnlMenuBottom.Controls.Add(this.btnClose);
            this.pnlMenuBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenuBottom.Location = new System.Drawing.Point(0, 403);
            this.pnlMenuBottom.Name = "pnlMenuBottom";
            this.pnlMenuBottom.Size = new System.Drawing.Size(258, 100);
            this.pnlMenuBottom.TabIndex = 1;
            // 
            // pnlMenuTop
            // 
            this.pnlMenuTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuTop.Name = "pnlMenuTop";
            this.pnlMenuTop.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.pnlMenuTop.Size = new System.Drawing.Size(258, 128);
            this.pnlMenuTop.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconSize = 28;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnClose.Rotation = 0D;
            this.btnClose.Size = new System.Drawing.Size(258, 43);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMenu);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(262, 503);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenuBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlMenuTop;
        private System.Windows.Forms.Panel pnlMenuBottom;
        private FontAwesome.Sharp.IconButton btnLoadEnvironment;
        private FontAwesome.Sharp.IconButton btnLoadData;
        private FontAwesome.Sharp.IconButton btnExport;
        private FontAwesome.Sharp.IconButton btnImportData;
        private FontAwesome.Sharp.IconButton btnClose;
    }
}
