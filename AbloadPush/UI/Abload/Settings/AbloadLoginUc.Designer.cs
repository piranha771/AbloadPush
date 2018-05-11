namespace AbloadPush.UI.Abload.Settings
{
    partial class AbloadLoginUc
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
            this.gbAbloadLogin = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bLogin = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.gbCookie = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lExpires = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lCookie = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bLogout = new System.Windows.Forms.Button();
            this.gbAbloadLogin.SuspendLayout();
            this.gbCookie.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAbloadLogin
            // 
            this.gbAbloadLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAbloadLogin.AutoSize = true;
            this.gbAbloadLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbAbloadLogin.Controls.Add(this.label3);
            this.gbAbloadLogin.Controls.Add(this.label2);
            this.gbAbloadLogin.Controls.Add(this.label1);
            this.gbAbloadLogin.Controls.Add(this.bLogin);
            this.gbAbloadLogin.Controls.Add(this.tbPassword);
            this.gbAbloadLogin.Controls.Add(this.tbUsername);
            this.gbAbloadLogin.Location = new System.Drawing.Point(3, 3);
            this.gbAbloadLogin.Name = "gbAbloadLogin";
            this.gbAbloadLogin.Size = new System.Drawing.Size(409, 109);
            this.gbAbloadLogin.TabIndex = 1;
            this.gbAbloadLogin.TabStop = false;
            this.gbAbloadLogin.Text = "Abload: Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Info: No username or password information is stored on this computer.\r\n        Th" +
    "e login information is encrypted during transmission.\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(333, 38);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(70, 23);
            this.bLogin.TabIndex = 2;
            this.bLogin.Text = "Login";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.BLogin_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(165, 40);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(162, 20);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(4, 40);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(155, 20);
            this.tbUsername.TabIndex = 0;
            this.tbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbCookie
            // 
            this.gbCookie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCookie.Controls.Add(this.label6);
            this.gbCookie.Controls.Add(this.lExpires);
            this.gbCookie.Controls.Add(this.label5);
            this.gbCookie.Controls.Add(this.lCookie);
            this.gbCookie.Controls.Add(this.label4);
            this.gbCookie.Controls.Add(this.bLogout);
            this.gbCookie.Location = new System.Drawing.Point(3, 3);
            this.gbCookie.Name = "gbCookie";
            this.gbCookie.Size = new System.Drawing.Size(409, 109);
            this.gbCookie.TabIndex = 7;
            this.gbCookie.TabStop = false;
            this.gbCookie.Text = "Abload: Session Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "You\'re logged in.";
            // 
            // lExpires
            // 
            this.lExpires.AutoSize = true;
            this.lExpires.Location = new System.Drawing.Point(112, 63);
            this.lExpires.Name = "lExpires";
            this.lExpires.Size = new System.Drawing.Size(23, 13);
            this.lExpires.TabIndex = 6;
            this.lExpires.Text = "null";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Expires:";
            // 
            // lCookie
            // 
            this.lCookie.AutoSize = true;
            this.lCookie.Location = new System.Drawing.Point(62, 43);
            this.lCookie.Name = "lCookie";
            this.lCookie.Size = new System.Drawing.Size(23, 13);
            this.lCookie.TabIndex = 4;
            this.lCookie.Text = "null";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cookie:";
            // 
            // bLogout
            // 
            this.bLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bLogout.Location = new System.Drawing.Point(323, 38);
            this.bLogout.Name = "bLogout";
            this.bLogout.Size = new System.Drawing.Size(81, 23);
            this.bLogout.TabIndex = 2;
            this.bLogout.Text = "Logout";
            this.bLogout.UseVisualStyleBackColor = true;
            this.bLogout.Click += new System.EventHandler(this.BLogout_Click);
            // 
            // AbloadLoginUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAbloadLogin);
            this.Controls.Add(this.gbCookie);
            this.Name = "AbloadLoginUc";
            this.Size = new System.Drawing.Size(413, 113);
            this.gbAbloadLogin.ResumeLayout(false);
            this.gbAbloadLogin.PerformLayout();
            this.gbCookie.ResumeLayout(false);
            this.gbCookie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAbloadLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.GroupBox gbCookie;
        private System.Windows.Forms.Label lCookie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bLogout;
        private System.Windows.Forms.Label lExpires;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
