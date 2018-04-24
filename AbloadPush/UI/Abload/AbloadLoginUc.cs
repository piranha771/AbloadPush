using System;
using System.Windows.Forms;
using AbloadPush.ImageService;

namespace AbloadPush.UI.Abload
{
    public partial class AbloadLoginUc : UserControl, ILoginControl
    {
        public event EventHandler Login;
        public event EventHandler Logout;

        public ILoginData LoginData
        {
            get => new LoginData()
            {
                Identifier = tbUsername.Text.Trim(),
                Secret = tbPassword.Text
            };
        }

        public string Evidence { get => lCookie.Text; set => lCookie.Text = value; }
        public string Expires { get => lExpires.Text; set => lExpires.Text = value; }

        public AbloadLoginUc()
        {
            InitializeComponent();
        }

        public void ShowEvidence()
        {
            gbCookie.BringToFront();
        }

        public void ShowLogin()
        {
            gbAbloadLogin.BringToFront();
        }

        private void BLogout_Click(object sender, EventArgs e)
        {
            Logout(sender, e);
        }

        private void BLogin_Click(object sender, EventArgs e)
        {
            Login(sender, e);
        }
    }
}
