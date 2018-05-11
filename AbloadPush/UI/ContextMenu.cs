﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using AbloadPush.Properties;
using AbloadPush.ImageService;
using AbloadPush.UI.Settings;

namespace AbloadPush.UI
{
    class ContextMenu
	{
        private readonly ContextMenuStrip strip;
        private readonly Config config;
        private readonly SettingsForm settingsForm;

        public ContextMenuStrip Strip => strip;

        public ContextMenu(Config config, IImageServiceProvider service)
        {
            this.config = config;
            this.settingsForm = new SettingsForm();
            settingsForm.Config = config;
            settingsForm.Service = service;

            strip = new ContextMenuStrip();

            var settingsItem = new ToolStripMenuItem();
            settingsItem.Text = "Settings";
            settingsItem.Click += new EventHandler(Settings_Click);
            settingsItem.Image = Resources.ic_settings_black_24dp_1x;
            strip.Items.Add(settingsItem);

            var aboutItem = new ToolStripMenuItem();
            aboutItem.Text = "About";
            aboutItem.Click += new EventHandler(About_Click);
            aboutItem.Image = Resources.About;
            //strip.Items.Add(aboutItem);

            var sepItem = new ToolStripSeparator();
            strip.Items.Add(sepItem);

            var exitItem = new ToolStripMenuItem();
            exitItem.Text = "Exit";
            exitItem.Click += new System.EventHandler(Exit_Click);
            exitItem.Image = Resources.ic_exit_to_app_black_24dp_1x;
            strip.Items.Add(exitItem);
        }

        void Settings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        void Explorer_Click(object sender, EventArgs e)
		{
			Process.Start("explorer", null);
		}

		void About_Click(object sender, EventArgs e)
		{

		}

		void Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}