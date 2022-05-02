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

        public ActionResult Validate_Click(object sender, EventArgs e)
        {
            //string storechosen = tbostore.text;
            return View("Price Checker", "Index", "PriceChecker");
        }

    }
}