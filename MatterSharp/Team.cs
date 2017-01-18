using System;

namespace MatterSharp
{
    public class Team
    {
        public string Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeleteAt { get; set; }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Type { get; set; }

        public string CompanyName { get; set; }

        public string AllowedDomains { get; set; }

        public string InviteId { get; set; }

        public bool AllowOpenInvite { get; set; }
    }
}