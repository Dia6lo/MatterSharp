namespace MatterSharp.Rest.Models
{
    public class User
    {
        public string Id { get; set; }

        public long CreateAt { get; set; }

        public long UpdateAt { get; set; }

        public long DeleteAt { get; set; }

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

        public long LastPasswordUpdate { get; set; }

        public long LastPictureUpdate { get; set; }

        public int FailedAttempts { get; set; }

        public bool MfaActive { get; set; }

        public string MfaSecret { get; set; }
    }
}