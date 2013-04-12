namespace BtcAlarm.Areas.Default.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using BtcAlarm.Controllers;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var users = Repository.Users.ToList();
            return View(users);
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}
