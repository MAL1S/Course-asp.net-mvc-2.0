using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Course.Models;
using PagedList;

namespace Course.Views
{
    public class LateStatController : Controller
    {
        private UniversityDB2Entities db = new UniversityDB2Entities();

        // GET: LateStat
        public ViewResult Index()
        {
            return View();
        }

        // GET: LateStat
        public ViewResult Details(DateTime? from, DateTime? to, DateTime? oldFrom, DateTime? oldTo, int? page)
        {
            if (from != null && to != null)
            {
                page = 1;
            }
            else
            {
                from = oldFrom;
                to = oldTo;
            }

            if (from == null || to == null || from?.Date > to?.Date)
            {
                ModelState.AddModelError("", "Первая дата не может быть больше второй");
                TempData["msg"] = "1";
                return View();
            }
            else
            {
                TempData["msg"] = "";
                object[] parameters = {
                new SqlParameter("@date1",SqlDbType.Date) {Value=from},
                new SqlParameter("@date2", SqlDbType.Date) {Value=to}
                };
                db.Database.CommandTimeout = 360;
                IEnumerable<GetFirstTask_Result> query = db.Database.SqlQuery<GetFirstTask_Result>("GetFirstTask @date1, @date2", parameters).ToList();
                int pageSize = 10;
                int pageNumber = (page ?? 1);

                ViewBag.oldTo = to;
                ViewBag.oldFrom = from;
                return View(query.ToPagedList(pageNumber, pageSize));
            }   
        }
    }
}