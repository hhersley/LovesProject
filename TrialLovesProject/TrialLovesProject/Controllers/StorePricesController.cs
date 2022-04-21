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
    public class StorePricesController : Controller
    {
        private DB_128040_lovesEntities db = new DB_128040_lovesEntities();

        // GET: StorePrices
        public ActionResult Index()
        {
            var storePrices = db.StorePrices.Include(s => s.Grade1).Include(s => s.Store);
            return View(storePrices.ToList());
        }

        // GET: StorePrices/Details/5
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

        // GET: StorePrices/Create
        public ActionResult Create()
        {
            ViewBag.Grade = new SelectList(db.Grades, "GradeId", "Name");
            ViewBag.StoreNumber = new SelectList(db.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: StorePrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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






















    //// GET: StorePrices/Edit/5
    //public ActionResult Edit(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    StorePrice storePrice = db.StorePrices.Find(id);
    //    if (storePrice == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    ViewBag.Grade = new SelectList(db.Grades, "GradeId", "Name", storePrice.Grade);
    //    ViewBag.StoreNumber = new SelectList(db.Stores, "StoreId", "StoreId", storePrice.StoreNumber);
    //    return View(storePrice);
    //}

    //// POST: StorePrices/Edit/5
    //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit([Bind(Include = "Id,StoreNumber,Grade,PreviousPrice,NewPrice,PriceDifference,TimeStamp")] StorePrice storePrice)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        db.Entry(storePrice).State = EntityState.Modified;
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
    //    ViewBag.Grade = new SelectList(db.Grades, "GradeId", "Name", storePrice.Grade);
    //    ViewBag.StoreNumber = new SelectList(db.Stores, "StoreId", "StoreId", storePrice.StoreNumber);
    //    return View(storePrice);
    //}

    //// GET: StorePrices/Delete/5
    //public ActionResult Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    StorePrice storePrice = db.StorePrices.Find(id);
    //    if (storePrice == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(storePrice);
    //}

    //// POST: StorePrices/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public ActionResult DeleteConfirmed(int id)
    //{
    //    StorePrice storePrice = db.StorePrices.Find(id);
    //    db.StorePrices.Remove(storePrice);
    //    db.SaveChanges();
    //    return RedirectToAction("Index");
    //}

    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        db.Dispose();
    //    }
    //    base.Dispose(disposing);
    //}
}
}
