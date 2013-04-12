namespace BtcAlarm.Global.Auth
{
    using System;
    using System.Linq;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;

    using BtcAlarm.Tools;

    using Ninject;

    using BtcAlarm.Model;

    public class CustomAuthentication : IAuthentication
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private const string CookieName = "__AUTH_COOKIE";

        private IPrincipal currentUser;

        private HttpContext httpContext;

        public HttpContext HttpContext
        {
            get
            {
                return this.httpContext;
            }
            set
            {
                this.httpContext = value;
            }
        }

        [Inject]
        public IRepository Repository { get; set; }

        public User Login(string userName, string password, bool isPersistent)
        {
            string passwordHash = Md5Hash.Calculate(password);

            User retUser = this.Repository.Login(userName, passwordHash);
            if (retUser != null)
            {
                this.CreateCookie(userName, isPersistent);
            }
            return retUser;
        }

        public User Login(string userName)
        {
            User retUser = this.Repository.Users.FirstOrDefault(p => string.Compare(p.Email, userName, true) == 0);
            if (retUser != null)
            {
                this.CreateCookie(userName);
            }
            return retUser;
        }

        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  userName,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  isPersistent,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var authCookie = new HttpCookie(CookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            this.HttpContext.Response.Cookies.Set(authCookie);
        }

        public void LogOut()
        {
            var httpCookie = this.HttpContext.Response.Cookies[CookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        public IPrincipal CurrentUser
        {
            get
            {
                if (this.currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie = this.HttpContext.Request.Cookies.Get(CookieName);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            if (ticket != null)
                            {
                                this.currentUser = new UserProvider(ticket.Name, this.Repository);
                            }
                            else
                            {
                                this.currentUser = new UserProvider(null, null);
                            }
                        }
                        else
                        {
                            this.currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed authentication: " + ex.Message);
                        this.currentUser = new UserProvider(null, null);
                    }
                }
                return this.currentUser;
            }
        }
    }
}