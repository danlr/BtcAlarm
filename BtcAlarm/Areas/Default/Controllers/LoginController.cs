namespace BtcAlarm.Areas.Default.Controllers
{
    using System.Web.Mvc;

    using BtcAlarm.Controllers;
    using BtcAlarm.Models.ViewModels;

    public class LoginController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(new LoginView());
        }

        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if (this.ModelState.IsValid)
            {
                var user = this.Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return this.RedirectToAction("Index", "Home");
                }
                this.ModelState["Password"].Errors.Add("*");
                this.ModelState["Email"].Errors.Add("*");
            }
            return this.View(loginView);
        }


        [HttpGet]
        public ActionResult Ajax()
        {
            return this.View(new LoginView());
        }

        [HttpPost]
        public ActionResult Ajax(LoginView loginView)
        {
            if (this.ModelState.IsValid)
            {
                var user = this.Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return View("_Reload");
                }
                this.ModelState["Password"].Errors.Add("*");
                this.ModelState["Email"].Errors.Add("*");
            }
            return this.View(loginView);
        }

        public ActionResult Logout()
        {
            this.Auth.LogOut();
            return this.RedirectToAction("Index", "Home");
        }
    }
}