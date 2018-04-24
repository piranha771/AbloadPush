using System;
using System.IO;
using System.Threading.Tasks;

namespace AbloadPush.ImageService
{
    interface IImageServiceProvider
    {
        string Name { get; }
        UploadResult LastUploadResult { get; }

        event EventHandler<LoginResult> LoginComplete;
        event EventHandler<LogoutResult> LogoutComplete;
        event EventHandler<UploadResult> UploadFinished;

        void Login(ILoginData loginData);
        Task<bool> IsLoggedIn();
        void Logout();
        void Upload(Stream imageData);   
    }
}
