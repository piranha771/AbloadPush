using System;
using System.Windows.Forms;
using AbloadPush.ImageService;
using AbloadPush.Properties;

namespace AbloadPush.UI
{
    class ProcessIcon : IDisposable
	{
        class BaloonShowEventArgs : EventArgs
        {
            public string Link;

            public BaloonShowEventArgs(string link)
            {
                Link = link;
            }
        }

		private readonly NotifyIcon ni = new NotifyIcon();
        private readonly ContextMenu cm;

        private EventHandler lastEventHandler;

		public ProcessIcon(Config settings, IImageServiceProvider service)
		{
            cm = new ContextMenu(settings, service);

            ni.Icon = Resources.AbloadIcon;
			ni.Text = "Abload Push Client";
            ni.Visible = true;     
            ni.ContextMenuStrip = cm.Strip;

            ni.MouseClick += MouseClickIcon;
		}

		public void Dispose()
		{
			ni.Dispose();
		}

		private void MouseClickIcon(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{

			}
		}

        public void NotifyUserSuccess(string title, string text, string link)
        {
            if (lastEventHandler != null)
                ni.BalloonTipClicked -= lastEventHandler;

            lastEventHandler = 
                (sender, e) =>
                {
                    System.Diagnostics.Process.Start(link);
                };
            ni.BalloonTipClicked += lastEventHandler;

            ni.ShowBalloonTip(5000, title, text, ToolTipIcon.None);      
        }

        public void NotifyUserFail(string title, string text, string fullText)
        {
            if (lastEventHandler != null)
                ni.BalloonTipClicked -= lastEventHandler;

            lastEventHandler =
                (sender, e) =>
                {
                    MessageBox.Show(fullText);
                };
            ni.BalloonTipClicked += lastEventHandler;

            ni.ShowBalloonTip(5000, title, text +  "\r\n\r\nClick here for more info.", ToolTipIcon.None);
        }
    }
}