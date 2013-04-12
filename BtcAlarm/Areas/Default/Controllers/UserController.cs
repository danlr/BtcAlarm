using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtcAlarm.Areas.Default.Controllers
{
    using BtcAlarm.Controllers;
    using BtcAlarm.Model;
    using BtcAlarm.Models.ViewModels;

    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            //todo: show context user or registration
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            var newUser = new UserView();
            return View(newUser);
        }

        [HttpPost]
        public ActionResult Register(UserView userView)
        {
            var anyUser = Repository.Users.Any(p => string.Compare(p.Email, userView.Email) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Email", "Please provide another email");
            }

            if (ModelState.IsValid)
            {
                var user = (User)ModelMapper.Map(userView, typeof(UserView), typeof(User));
                //TODO: Сохранить
            }

            return View(userView);
        }
    }
}
