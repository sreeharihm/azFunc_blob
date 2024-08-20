namespace TaskApp.Services.ApiModel
{
    public class Logs
    {
        public string Name { get; set; } = default!;

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string BlobId { get; set; }
    }
}
