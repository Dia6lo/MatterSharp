namespace MatterSharp.Rest.Models
{
    public class Team
    {
        public string Id { get; set; }

        public long CreateAt { get; set; }

        public long UpdateAt { get; set; }

        public long DeleteAt { get; set; }

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