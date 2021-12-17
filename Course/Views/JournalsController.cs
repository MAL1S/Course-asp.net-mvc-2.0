using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Course.Models;
using System.Data.Entity.Infrastructure;

namespace UD1.Views
{
    public class JournalsController : Controller
    {
        private UniversityDB2Entities db = new UniversityDB2Entities();

        // GET: Journals
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

            var Journal = from s in db.Journal select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Journal = Journal.Where(s => s.RecordID.ToString() == searchString);
            }
            else if (!String.IsNullOrEmpty(SearchKeeperString))
            {
                Journal = Journal.Where(s => s.Subject_ID.ToString() == SearchKeeperString);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Journal = Journal.OrderByDescending(s => s.RecordID);
                    break;
                default:
                    Journal = Journal.OrderBy(s => s.RecordID);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Journal.ToPagedList(pageNumber, pageSize));
        }

        // GET: Journals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Journal.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // GET: Journals/Create
        public ActionResult Create()
        {
            ViewBag.Subject_ID = new SelectList(db.Subject, "ID", "SubjectTeacher");
            return View();
        }

        // POST: Journals/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordID,Subject_ID,Student_ID,Mark,MarkDate")] Journal journal)
        {
            DateTime d1 = new DateTime(2010, 1, 1, 0, 0, 0);
            DateTime d2 = new DateTime(2022, 1, 1, 0, 0, 0); 

            if (ModelState.IsValid)
            {
                try
                {   if (!(journal.MarkDate.Date > d1 && journal.MarkDate.Date < d2)) throw new DbUpdateException("Неправильная дата");
                    db.Journal.Add(journal);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    //ModelState.AddModelError("", "Error: " + ex.InnerException.InnerException.Message);
                    ModelState.AddModelError("", "Клиента не существует");
                }
            }

            ViewBag.Subject_ID = new SelectList(db.Subject, "ID", "SubjectTeacher", journal.Subject_ID);
            return View(journal);
        }

        // GET: Journals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Journal.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subject_ID = new SelectList(db.Subject, "ID", "SubjectTeacher", journal.Subject_ID);
            return View(journal);
        }

        // POST: Journals/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordID,Subject_ID,Student_ID,Mark,MarkDate")] Journal journal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.Subject_ID = new SelectList(db.Subject, "ID", "SubjectTeacher", journal.Subject_ID);
            return View(journal);
        }

        // GET: Journals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Journal.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Journal journal = db.Journal.Find(id);
            db.Journal.Remove(journal);
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
