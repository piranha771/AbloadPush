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
        private string reason;

        internal UploadStatus Status { get => status; set => status = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public string Reason { get => reason; set => reason = value; }
    }
}
