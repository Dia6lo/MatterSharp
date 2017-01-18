using System;
using System.Collections.Generic;

namespace MatterSharp
{
    public class Channel
    {
        public string Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeleteAt { get; set; }

        public string TeamId { get; set; }

        public string Type { get; set; }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Purpose { get; set; }

        public DateTime LastPostAt { get; set; }

        public int TotalMsgCount { get; set; }

        public DateTime ExtraUpdateAt { get; set; }

        public string CreatorId { get; set; }
    }

    public class ChannelsOfTeam
    {
        public List<Channel> Channels { get; set; }
    }
}