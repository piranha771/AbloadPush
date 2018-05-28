namespace AbloadPush.UI.Settings
{
    partial class LocalCopyUc
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLocalCopy = new System.Windows.Forms.GroupBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.cbDoMakeCopy = new System.Windows.Forms.CheckBox();
            this.gbLocalCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLocalCopy
            // 
            this.gbLocalCopy.Controls.Add(this.bBrowse);
            this.gbLocalCopy.Controls.Add(this.tbPath);
            this.gbLocalCopy.Controls.Add(this.cbDoMakeCopy);
            this.gbLocalCopy.Location = new System.Drawing.Point(3, 3);
            this.gbLocalCopy.Name = "gbLocalCopy";
            this.gbLocalCopy.Size = new System.Drawing.Size(315, 82);
            this.gbLocalCopy.TabIndex = 0;
            this.gbLocalCopy.TabStop = false;
            this.gbLocalCopy.Text = "Local Copy";
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(234, 53);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(75, 23);
            this.bBrowse.TabIndex = 2;
            this.bBrowse.Text = "Browse";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(6, 56);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(222, 20);
            this.tbPath.TabIndex = 1;
            // 
            // cbDoMakeCopy
            // 
            this.cbDoMakeCopy.AutoSize = true;
            this.cbDoMakeCopy.Location = new System.Drawing.Point(6, 19);
            this.cbDoMakeCopy.Name = "cbDoMakeCopy";
            this.cbDoMakeCopy.Size = new System.Drawing.Size(113, 17);
            this.cbDoMakeCopy.TabIndex = 0;
            this.cbDoMakeCopy.Text = "Make a local copy";
            this.cbDoMakeCopy.UseVisualStyleBackColor = true;
            // 
            // LocalCopyUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLocalCopy);
            this.Name = "LocalCopyUc";
            this.Size = new System.Drawing.Size(321, 85);
            this.gbLocalCopy.ResumeLayout(false);
            this.gbLocalCopy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLocalCopy;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.CheckBox cbDoMakeCopy;
    }
}
