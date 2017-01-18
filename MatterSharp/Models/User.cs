using System;

namespace MatterSharp.Models
{
    public class User
    {
        public User() { }

        public User(Rest.Models.User user)
        {
            Id = user.Id;
            CreateAt = UnixEpochConverter.Convert(user.CreateAt);
            UpdateAt = UnixEpochConverter.Convert(user.UpdateAt);
            DeleteAt = UnixEpochConverter.Convert(user.DeleteAt);
            Username = user.Username;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Nickname = user.Nickname;
            Email = user.Email;
            EmailVerified = user.EmailVerified;
            Password = user.Password;
            AuthData = user.AuthData;
            AuthService = user.AuthService;
            Roles = user.Roles;
            Locale = user.Locale;
            NotifyProps = user.NotifyProps;
            Props = user.Props;
            LastPasswordUpdate = UnixEpochConverter.Convert(user.LastPasswordUpdate);
            LastPictureUpdate = UnixEpochConverter.Convert(user.LastPictureUpdate);
            FailedAttempts = user.FailedAttempts;
            MfaActive = user.MfaActive;
            MfaSecret = user.MfaSecret;
        }

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