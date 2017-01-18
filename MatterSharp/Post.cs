using System;
using System.Collections.Generic;

namespace MatterSharp
{
    public class Post
    {
        public string Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeleteAt { get; set; }

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

    public class PostsOfAChannel
    {
        public List<string> Order { get; set; }

        public Dictionary<string, Post> Posts { get; set; }
    }
}