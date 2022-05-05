using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TrialLovesProject.Models;

namespace TrialLovesProject.Controllers
{
    public class PriceCheckerController : Controller
    {
        private DB_128040_lovesEntities db = new DB_128040_lovesEntities();

        // GET: PriceChecker
        public ActionResult Index(int? tbostore, double? tboprice)
        {
            var storePrices = db.StorePrices.Include(s => s.Grade1).Include(s => s.Store).Where(s => s.StoreNumber == tbostore).OrderByDescending(s => s.TimeStamp).Take(1);

            //var storePrices = db.StorePrices.Include(s => s.Grade1).Include(s => s.Store).Where(s => s.StoreNumber == tbostore).OrderByDescending(s => s.TimeStamp).Take(1).SingleOrDefault();
            foreach (var item in storePrices)
            {

                if (tboprice < Convert.ToDouble(item.NewPrice + item.Store.Threshold) && (tboprice > Convert.ToDouble(item.NewPrice - item.Store.Threshold)) == true)
                {
                    item.PreviousPrice = Convert.ToDecimal(item.NewPrice);
                    item.NewPrice = Convert.ToDecimal(tboprice);
                    item.TimeStamp = DateTime.Now;
                    return View(storePrices.ToList());


                }
                else if (tboprice < Convert.ToDouble(item.NewPrice + item.Store.Threshold) && (tboprice > Convert.ToDouble(item.NewPrice - item.Store.Threshold)) == false)
                {
                    continue;
                }
            }
            return View(storePrices.ToList());

        }



        // GET: PriceChecker/Create
        public ActionResult Create()
        {
            ViewBag.Grade = new SelectList(db.Grades, "GradeId", "Name");
            ViewBag.StoreNumber = new SelectList(db.Stores, "StoreId", "StoreId");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StoreNumber,Grade,PreviousPrice,NewPrice,PriceDifference,TimeStamp")] StorePrice storePrice)
        {
            if (ModelState.IsValid)
            {




                db.StorePrices.Add(storePrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Grade = new SelectList(db.Grades, "GradeId", "Name", storePrice.Grade);
            ViewBag.StoreNumber = new SelectList(db.Stores, "StoreId", "StoreId", storePrice.StoreNumber);
            return View(storePrice);
        }
    }
//        [HttpGet]
//        public ActionResult ExportingAction()
//        {
//            List<ExportData> exports = new List<ExportData>();
//            exports.AddRange(new ExportData[] {
//new ExportData{

//StoreNumber =1,
//Grade = 1, 
//PreviousPrice = Convert.ToDecimal(3.45), 
//NewPrice = Convert.ToDecimal(3.55), 
//PriceDifference = Convert.ToDecimal(.10), 
//TimeStamp = DateTime.Now,

//    },

//    new ExportData{
//    StoreNumber =1,
//Grade = 2,
//PreviousPrice = Convert.ToDecimal(3.55),
//NewPrice = Convert.ToDecimal(3.65),
//PriceDifference = Convert.ToDecimal(.10),
//TimeStamp = DateTime.Now,
//}, 
//    new ExportData
//    {
//        StoreNumber =1,
//Grade = 3,
//PreviousPrice = Convert.ToDecimal(3.65),
//NewPrice = Convert.ToDecimal(3.75),
//PriceDifference = Convert.ToDecimal(.10),
//TimeStamp = DateTime.Now,
//    }

//                }
//            ); ;
//            TempData["Data"] = exports;
//            return View(exports);
//        }

//        [HttpGet]
//        [ActionName("Download")]
//        public void Download()
//        {
//            List<ExportData> emps = TempData["Data"] as List<ExportData>;
//            var grid = new System.Web.UI.WebControls.GridView();
//            grid.DataSource = emps;
//            grid.DataBind();
//            Response.ClearContent();
//            Response.Buffer = true;
//            Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
//            Response.ContentType = "application/ms-excel";
//            Response.Charset = "";
//            var sw = new StringWriter();
//            HtmlTextWriter htw = new HtmlTextWriter(sw);
//            grid.RenderControl(htw);
//            Response.Output.Write(sw.ToString());
//            Response.Flush();
//            Response.End();
//            TempData["Data"] = emps;
//        }

//    }

 
    }

