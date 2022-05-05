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

            //ExportResults exports = new ExportResults();
            //var lstStudents = (from Student in exports.Students
            //                   select Student);
            //return View(lstStudents);
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
        public string ConvertDatatableToXML(DataTable dataTable)
        {
            MemoryStream str = new MemoryStream();
            dataTable.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return (xmlstr);
            //File.WriteAllText("Data.csv", csv);


            //string filePath = "";
            //xmlstr.WriteXml(filePath);
        }
    }













    //public ActionResult ()
    //{
    //    CodingvilaEntities entities = new CodingvilaEntities();
    //    var lstStudents = (from Student in entities.Students
    //                       select Student);
    //    return View(lstStudents);
    //}

    //[HttpPost]
    //public FileResult ExportToCSV()
    //{
    //    #region Get list of Students from Database

    //    CodingvilaEntities entities = new CodingvilaEntities();
    //    List<object> lstStudents = (from Student in entities.Students.ToList()
    //                                select new[] { Student.RollNo.ToString(),
    //                                                            Student.EnrollmentNo,
    //                                                            Student.Name,
    //                                                            Student.Branch,
    //                                                            Student.University
    //                              }).ToList<object>();

    //    #endregion

    //    #region Create Name of Columns

    //    var names = typeof(Student).GetProperties()
    //                .Select(property => property.Name)
    //                .ToArray();

    //    lstStudents.Insert(0, names.Where(x => x != names[0]).ToArray());

    //    #endregion

    //    #region Generate CSV

    //    StringBuilder sb = new StringBuilder();
    //    foreach (var item in lstStudents)
    //    {
    //        string[] arrStudents = (string[])item;
    //        foreach (var data in arrStudents)
    //        {
    //            //Append data with comma(,) separator.
    //            sb.Append(data + ',');
    //        }
    //        //Append new line character.
    //        sb.Append("\r\n");
    //    }

    //    #endregion

    //    #region Download CSV

    //    return File(Encoding.ASCII.GetBytes(sb.ToString()), "text/csv", "Students.csv");

    //    #endregion
    //}












    //public ActionResult WriteDataToExcel()
    //{
    //    DataTable dt = getData();
    //    //Name of File  
    //    string fileName = "Sample.xlsx";
    //    using (XLWorkbook wb = new XLWorkbook())
    //    {
    //        //Add DataTable in worksheet  
    //        wb.Worksheets.Add(dt);
    //        using (MemoryStream stream = new MemoryStream())
    //        {
    //            wb.SaveAs(stream);
    //            //Return xlsx Excel File  
    //            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    //        }
    //    }
    //}

    //DataTable getData()
    //{
    //    throw new NotImplementedException();
    //}




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
