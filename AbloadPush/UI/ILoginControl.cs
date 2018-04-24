using AbloadPush.ImageService;
using System;

namespace AbloadPush.UI
{
    interface ILoginControl
    {
        event EventHandler Login;
        event EventHandler Logout;
        ILoginData LoginData { get; }
        string Evidence { get; set; }
        string Expires { get; set; }
        void ShowLogin();
        void ShowEvidence();
    }
}
