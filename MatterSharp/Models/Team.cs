using System;

namespace MatterSharp.Models
{
    public class Team
    {
        public Team(Rest.Models.Team team)
        {
            Id = team.Id;
            CreateAt = UnixEpochConverter.Convert(team.CreateAt);
            UpdateAt = UnixEpochConverter.Convert(team.UpdateAt);
            DeleteAt = UnixEpochConverter.Convert(team.DeleteAt);
            DisplayName = team.DisplayName;
            Name = team.Name;
            Email = team.Email;
            Type = ParseTeamType(team.Type);
            CompanyName = team.CompanyName;
            AllowedDomains = team.AllowedDomains;
            InviteId = team.InviteId;
            AllowOpenInvite = team.AllowOpenInvite;
        }

        public string Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeleteAt { get; set; }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public TeamType Type { get; set; }

        public string CompanyName { get; set; }

        public string AllowedDomains { get; set; }

        public string InviteId { get; set; }

        public bool AllowOpenInvite { get; set; }

        private static TeamType ParseTeamType(string value)
        {
            switch (value)
            {
                case "O":
                    return TeamType.Open;
                case "I":
                    return TeamType.Invite;
                default:
                    throw new ArgumentException($"Cannot parse team type \"{value}\".");
            }
        }
    }
}