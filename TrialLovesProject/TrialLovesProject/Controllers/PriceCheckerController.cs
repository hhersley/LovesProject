using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrialLovesProject.Models;

namespace TrialLovesProject.Controllers
{
    public class PriceCheckerController : Controller
    {
        private DB_128040_lovesEntities db = new DB_128040_lovesEntities();

        // GET: PriceChecker
        public ActionResult Index(int tbostore, double tboprice)
        {
           
            var storePrices = db.StorePrices.Include(s => s.Grade1).Include(s => s.Store).Where(s => s.StoreNumber==tbostore).OrderByDescending(s => s.TimeStamp).Take(1).SingleOrDefault();

            storePrices.PreviousPrice = storePrices.NewPrice;
            storePrices.NewPrice = Convert.ToDecimal(tboprice);

            return View(storePrices);
        }

        // GET: PriceChecker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorePrice storePrice = db.StorePrices.Find(id);
            if (storePrice == null)
            {
                return HttpNotFound();
            }
            return View(storePrice);
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

        // GET: PriceChecker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorePrice storePrice = db.StorePrices.Find(id);
            if (storePrice == null)
            {
                return HttpNotFound();
            }
            ViewBag.Grade = new SelectList(db.Grades, "GradeId", "Name", storePrice.Grade);
            ViewBag.StoreNumber = new SelectList(db.Stores, "StoreId", "StoreId", storePrice.StoreNumber);
            return View(storePrice);
        }

        // POST: PriceChecker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StoreNumber,Grade,PreviousPrice,NewPrice,PriceDifference,TimeStamp")] StorePrice storePrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storePrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Grade = new SelectList(db.Grades, "GradeId", "Name", storePrice.Grade);
            ViewBag.StoreNumber = new SelectList(db.Stores, "StoreId", "StoreId", storePrice.StoreNumber);
            return View(storePrice);
        }

     

 
    }
}
