namespace BtcAlarm.Global.Auth
{
    using System.Security.Principal;

    using BtcAlarm.Model;

    public class UserIndentity : IIdentity, IUserProvider
    {
        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.User != null;
            }
        }

        public string Name
        {
            get
            {
                if (this.User != null)
                {
                    return this.User.Email;
                }
                return "anonymous";
            }
        }

        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                this.User = repository.GetUser(email);
            }
        }
    }
}