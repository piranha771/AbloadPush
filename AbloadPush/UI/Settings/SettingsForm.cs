﻿using AbloadPush.ImageService;
using AbloadPush.ImageService.Abload;
using AbloadPush.UI.Abload;
using AbloadPush.UI.Abload.Settings;
using System;
using System.Windows.Forms;

namespace AbloadPush.UI.Settings
{
    public partial class SettingsForm : Form
    {

        private IImageServiceProvider service;
        private Config config;

        private ILoginControl lc; 
    
        internal IImageServiceProvider Service
        {
            get => service;
            set
            {
                service = value;
                service.LoginComplete += LoginComplete;
                service.LogoutComplete += LogoutComplete;

                if (lc != null)
                {
                    flpContent.Controls.Remove(lc as UserControl);
                    lc.Login -= Login;
                    lc.Logout -= Logout;
                }
                if (service.Name == AbloadService.Address)
                {
                    lc = new AbloadLoginUc()
                    {
                        Anchor = AnchorStyles.Left | AnchorStyles.Top
                    };
                    lc.Login += Login;
                    lc.Logout += Logout;
                    flpContent.Controls.Add(lc as UserControl);
                    flpContent.Controls.SetChildIndex(lc as UserControl, 0);
                }
            }
        }

        internal Config Config { get => config; set => config = value; }      

        public SettingsForm()
        {
            InitializeComponent();
            
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            //ReadFromSettings();
        }

        private void SettingsForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                ReadFromSettings();
            }
            else
            {
                WriteToSettings();
            }
        }

        private void ReadFromSettings()
        {
            ReadGeneralSettings();

            if (service.Name == AbloadService.Address)
            {
                ReadAbloadSettings();
            }
        }

        private void ReadGeneralSettings()
        {
            localCopyUc1.DoSaveDirectory = config.DoSaveToDisk;
            localCopyUc1.SaveDirectory = config.ImagePath;
        }

        private void WriteToSettings()
        {
            config.DoSaveToDisk = localCopyUc1.DoSaveDirectory;
            config.ImagePath = localCopyUc1.SaveDirectory;
            config.Save();
        }

        private async void ReadAbloadSettings()
        {
            var abload = service as AbloadService;
            var isLoggedIn = await abload.IsLoggedIn();
            if (isLoggedIn)
            {
                var cookies = config.Cookies.GetCookies(new Uri(AbloadService.Address));
                var sessioncookie = cookies[AbloadService.SessionCookieName];
                if (sessioncookie == null)
                {
                    throw new InvalidOperationException("Services responds as logged in, but there is no valid session cookie!");
                }
                string sessionValue = sessioncookie.Value;
                if (string.IsNullOrEmpty(sessionValue))
                {
                    throw new InvalidOperationException("Services responds as logged in, but there is no valid session cookie!");
                }

                lc.Evidence = sessionValue;
                lc.Expires = sessioncookie.Expires.ToString("yyyy-MM-dd HH:mm:ss");
                lc.ShowEvidence();
            }
            else
            {
                lc.ShowLogin();
            }
        }

        private void Login(object sender, EventArgs e)
        {
            Service.Login(lc.LoginData);
        }

        private void LoginComplete(object sender, LoginResult result)
        {
            if (result.Success)
            {
                WriteToSettings();
                ReadFromSettings();
            }
            else
            {
                MessageBox.Show(null, "Login has failed:\r\n\r\n" + result.Reason, "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogoutComplete(object sender, LogoutResult result)
        {
            WriteToSettings();
            ReadFromSettings();
        }

        private void Logout(object sender, EventArgs e)
        {
            Service.Logout();
        }
    }
}
