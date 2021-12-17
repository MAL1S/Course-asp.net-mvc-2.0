using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Course.Models;
using PagedList;

namespace Course.Views
{
    public class SubjectsController : Controller
    {
        private UniversityDB2Entities db = new UniversityDB2Entities();

        // GET: Subjects
        public ViewResult Index(string sortOrder, string currentFilter, string CurrentFilter1, string SearchKeeperString, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NumberSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (SearchKeeperString != null || searchString != null)
            {
                page = 1;
            }
            else if (searchString == null)
            {
                searchString = CurrentFilter1;
            }
            else if (SearchKeeperString == null)
            {
                SearchKeeperString = currentFilter;
            }


            ViewBag.CurrentFilter = SearchKeeperString;
            ViewBag.CurrentFilter1 = searchString;

            var Subject = from s in db.Subject select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Subject = Subject.Where(s => s.ID.ToString() == searchString);
            }
            else if (!String.IsNullOrEmpty(SearchKeeperString))
            {
                Subject = Subject.Where(s => s.SubjectName == SearchKeeperString);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Subject = Subject.OrderByDescending(s => s.ID);
                    break;
                default:
                    Subject = Subject.OrderBy(s => s.ID);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Subject.ToPagedList(pageNumber, pageSize));
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubjectName,TeacherName")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Subject.Add(subject);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Error: " + ex.InnerException.InnerException.Message);
                }
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SubjectName,TeacherName")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subject.Find(id);
            db.Subject.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
