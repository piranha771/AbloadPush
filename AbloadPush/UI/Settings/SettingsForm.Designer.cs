namespace AbloadPush.UI.Settings
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.localCopyUc1 = new AbloadPush.UI.Settings.LocalCopyUc();
            this.flpContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpContent
            // 
            this.flpContent.AutoSize = true;
            this.flpContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpContent.Controls.Add(this.localCopyUc1);
            this.flpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpContent.Location = new System.Drawing.Point(0, 0);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(327, 277);
            this.flpContent.TabIndex = 1;
            // 
            // localCopyUc1
            // 
            this.localCopyUc1.DoSaveDirectory = false;
            this.localCopyUc1.Location = new System.Drawing.Point(3, 3);
            this.localCopyUc1.Name = "localCopyUc1";
            this.localCopyUc1.SaveDirectory = "";
            this.localCopyUc1.Size = new System.Drawing.Size(326, 85);
            this.localCopyUc1.TabIndex = 1;
            // 
            // SettingsForm
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(327, 277);
            this.Controls.Add(this.flpContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.SettingsForm_VisibleChanged);
            this.flpContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private LocalCopyUc localCopyUc1;
    }
}