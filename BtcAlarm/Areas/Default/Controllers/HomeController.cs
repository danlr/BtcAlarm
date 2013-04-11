namespace BtcAlarm.Areas.Default.Controllers
{
    using System.Web.Mvc;

    using BtcAlarm.Controllers;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
