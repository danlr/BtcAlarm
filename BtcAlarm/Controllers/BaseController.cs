using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtcAlarm.Controllers
{
    using BtcAlarm.Model;

    using Ninject;

    public class BaseController : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

    }
}
