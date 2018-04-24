namespace AbloadPush.ImageService
{
    public class LogoutResult
    {
        private bool success;
        private string reason;

        public bool Success { get => success; set => success = value; }
        public string Reason { get => reason; set => reason = value; }
    }
}