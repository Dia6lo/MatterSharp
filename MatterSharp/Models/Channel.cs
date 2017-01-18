using System;

namespace MatterSharp.Models
{
    public class Channel
    {
        public Channel() { }

        public Channel(Rest.Models.Channel channel)
        {
            Id = channel.Id;
            CreateAt = UnixEpochConverter.Convert(channel.CreateAt);
            UpdateAt = UnixEpochConverter.Convert(channel.UpdateAt);
            DeleteAt = UnixEpochConverter.Convert(channel.DeleteAt);
            TeamId = channel.TeamId;
            Type = ParseChannelType(channel.Type);
            DisplayName = channel.DisplayName;
            Name = channel.Name;
            Header = channel.Header;
            Purpose = channel.Purpose;
            LastPostAt = UnixEpochConverter.Convert(channel.LastPostAt);
            TotalMessageCount = channel.TotalMsgCount;
            ExtraUpdateAt = UnixEpochConverter.Convert(channel.ExtraUpdateAt);
            CreatorId = channel.CreatorId;
        }

        public string Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeleteAt { get; set; }

        public string TeamId { get; set; }

        public ChannelType Type { get; set; }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Purpose { get; set; }

        public DateTime LastPostAt { get; set; }

        public int TotalMessageCount { get; set; }

        public DateTime ExtraUpdateAt { get; set; }

        public string CreatorId { get; set; }

        private static ChannelType ParseChannelType(string value)
        {
            switch (value)
            {
                case "O":
                    return ChannelType.Open;
                case "P":
                    return ChannelType.Private;
                case "D":
                    return ChannelType.Direct;
                default:
                    throw new ArgumentException($"Cannot parse channel type \"{value}\".");
            }
        }
    }
}