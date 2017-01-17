using System;
using Newtonsoft.Json;

namespace MatterSharp
{
    public class User
    {
        public string Id { get; set; }

        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime CreateAt { get; set; }

        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime UpdateAt { get; set; }

        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime DeleteAt { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public bool EmailVerified { get; set; }

        public string Password { get; set; }

        public string AuthData { get; set; }

        public string AuthService { get; set; }

        public string Roles { get; set; }

        public string Locale { get; set; }

        // TODO
        public object NotifyProps { get; set; }

        // TODO
        public object Props { get; set; }

        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime LastPasswordUpdate { get; set; }

        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime LastPictureUpdate { get; set; }

        public int FailedAttempts { get; set; }

        public bool MfaActive { get; set; }

        public string MfaSecret { get; set; }
    }
}