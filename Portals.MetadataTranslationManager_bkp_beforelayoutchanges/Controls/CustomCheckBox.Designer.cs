namespace Portals.MetadataTranslationManager.Controls
{
    partial class CustomCheckBox
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
            this.btnCheckBox = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // btnCheckBox
            // 
            this.btnCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckBox.FlatAppearance.BorderSize = 0;
            this.btnCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckBox.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCheckBox.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckBox.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.btnCheckBox.IconColor = System.Drawing.Color.Black;
            this.btnCheckBox.IconSize = 24;
            this.btnCheckBox.Location = new System.Drawing.Point(0, 0);
            this.btnCheckBox.Name = "btnCheckBox";
            this.btnCheckBox.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnCheckBox.Rotation = 0D;
            this.btnCheckBox.Size = new System.Drawing.Size(206, 45);
            this.btnCheckBox.TabIndex = 13;
            this.btnCheckBox.Text = "Add your text here";
            this.btnCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckBox.UseVisualStyleBackColor = true;
            this.btnCheckBox.Click += new System.EventHandler(this.btnCheckBox_Click);
            // 
            // CustomCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCheckBox);
            this.Name = "CustomCheckBox";
            this.Size = new System.Drawing.Size(206, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnCheckBox;
    }
}
