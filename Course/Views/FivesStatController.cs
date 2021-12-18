using Course.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course.Views
{
    public class FivesStatController : Controller
    {
        private UniversityDB2Entities db = new UniversityDB2Entities();

        // GET: FivesStat
        public ViewResult Index()
        {
            return View();
        }

        // GET: FivesStat
        public ViewResult Details(int? maxFives, int? maxFivesOld, int? page)
        {
            if (maxFives != null)
            {
                page = 1;
            }
            else
            {
                maxFives = maxFivesOld;
            }

            if (maxFives == null)
            {
                ModelState.AddModelError("", "Данные не введены");
                TempData["msg"] = "1";
                return View();
            }
            else
            {
                TempData["msg"] = "";
                object[] parameters = {
                new SqlParameter("@maxFives",SqlDbType.Int) {Value=maxFives}
                };
                db.Database.CommandTimeout = 360;
                IEnumerable<GetSecondTask_Result> query = db.Database.SqlQuery<GetSecondTask_Result>("GetSecondTask @maxFives", parameters).ToList();
                int pageSize = 10;
                int pageNumber = (page ?? 1);

                ViewBag.maxFivesOld = maxFives;
                return View(query.ToPagedList(pageNumber, pageSize));
            }
        }
    }
}