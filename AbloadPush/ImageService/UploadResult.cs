namespace AbloadPush.ImageService
{
    class UploadResult
    {
        public enum UploadStatus
        {
            Succeeded,
            Aborted,
            Rejected,
            Failed
        }

        private UploadStatus status;
        private string imageUrl;
        private object reason;

        internal UploadStatus Status { get => status; set => status = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public object Reason { get => reason; set => reason = value; }
    }
}
