namespace MatterSharp.Rest.Models
{
    public class Channel
    {
        public string Id { get; set; }

        public long CreateAt { get; set; }

        public long UpdateAt { get; set; }

        public long DeleteAt { get; set; }

        public string TeamId { get; set; }

        public string Type { get; set; }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Purpose { get; set; }

        public long LastPostAt { get; set; }

        public int TotalMsgCount { get; set; }

        public long ExtraUpdateAt { get; set; }

        public string CreatorId { get; set; }
    }
}