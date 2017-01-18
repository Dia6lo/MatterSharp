using System;

namespace MatterSharp
{
    public class User
    {
        public string Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

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

        public object NotifyProps { get; set; }

        public object Props { get; set; }

        public DateTime LastPasswordUpdate { get; set; }

        public DateTime LastPictureUpdate { get; set; }

        public int FailedAttempts { get; set; }

        public bool MfaActive { get; set; }

        public string MfaSecret { get; set; }
    }
}