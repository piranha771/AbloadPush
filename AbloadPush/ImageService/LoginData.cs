namespace AbloadPush.ImageService
{
    class LoginData : ILoginData
    {
        private string identifier;
        private string secret;

        public string Identifier { get => identifier; set => identifier = value; }
        public string Secret { get => secret; set => secret = value; }
    }
}
