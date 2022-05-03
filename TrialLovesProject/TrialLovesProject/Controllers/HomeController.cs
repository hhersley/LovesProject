using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrialLovesProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

      //viewbag for error message
    public ActionResult SaveInfo()
        {
            return View();
        }

    }
}