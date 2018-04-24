namespace AbloadPush.ImageService
{
    public class LoginResult
    {
        private bool success;
        private string reason;

        public string Reason { get => reason; set => reason = value; }
        public bool Success { get => success; set => success = value; }
    }
}