using System;
using System.Collections.Generic;

namespace MatterSharp.Models
{
    public class Post
    {
        public Post(Rest.Models.Post post)
        {
            Id = post.Id;
            CreateAt = UnixEpochConverter.Convert(post.CreateAt);
            UpdateAt = UnixEpochConverter.Convert(post.UpdateAt);
            DeleteAt = UnixEpochConverter.Convert(post.DeleteAt);
            UserId = post.UserId;
            ChannelId = post.ChannelId;
            RootId = post.RootId;
            ParentId = post.ParentId;
            OriginalId = post.OriginalId;
            Message = post.Message;
            Type = ParsePostType(post.Type);
            Props = post.Props;
            Hashtags = post.Hashtags;
            Filenames = post.Filenames;
            PendingPostId = post.PendingPostId;
        }

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

        public PostType Type { get; set; }

        public object Props { get; set; }

        public string Hashtags { get; set; }

        public List<object> Filenames { get; set; }

        public string PendingPostId { get; set; }

        private static PostType ParsePostType(string value)
        {
            switch (value)
            {
                case "":
                    return PostType.Default;
                case "slack_attachment":
                    return PostType.SlackAttachment;
                case "system_generic":
                    return PostType.Generic;
                case "system_join_leave":
                    return PostType.JoinLeave;
                case "system_add_remove":
                    return PostType.AddRemove;
                case "system_header_change":
                    return PostType.HeaderChange;
                case "system_displayname_change":
                    return PostType.DisplayNameChange;
                case "system_purpose_change":
                    return PostType.PurposeChange;
                case "system_channel_deleted":
                    return PostType.ChannelDeleted;
                case "system_ephemeral":
                    return PostType.Ephemeral;
                default:
                    throw new ArgumentException($"Cannot parse post type \"{value}\".");
            }
        }
    }
}