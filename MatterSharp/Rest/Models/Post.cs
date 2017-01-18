using System.Collections.Generic;

namespace MatterSharp.Rest.Models
{
    public class Post
    {
        public string Id { get; set; }

        public long CreateAt { get; set; }

        public long UpdateAt { get; set; }

        public long DeleteAt { get; set; }

        public string UserId { get; set; }

        public string ChannelId { get; set; }

        public string RootId { get; set; }

        public string ParentId { get; set; }

        public string OriginalId { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }

        public object Props { get; set; }

        public string Hashtags { get; set; }

        public List<object> Filenames { get; set; }

        public string PendingPostId { get; set; }
    }
}