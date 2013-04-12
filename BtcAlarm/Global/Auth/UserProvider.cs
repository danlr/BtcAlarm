namespace BtcAlarm.Global.Auth
{
    using System.Security.Principal;

    using BtcAlarm.Model;

    public class UserProvider : IPrincipal
    {
        private UserIndentity userIdentity;

        public IIdentity Identity
        {
            get
            {
                return this.userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (this.userIdentity.User == null)
            {
                return false;
            }
            return this.userIdentity.User.InRoles(role);
        }


        public UserProvider(string name, IRepository repository)
        {
            this.userIdentity = new UserIndentity();
            this.userIdentity.Init(name, repository);
        }


        public override string ToString()
        {
            return this.userIdentity.Name;
        }
    }
}