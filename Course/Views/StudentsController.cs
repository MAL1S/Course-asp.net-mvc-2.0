using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Course.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace Course.Views
{
    public class StudentsController : Controller
    {
        private UniversityDB2Entities db = new UniversityDB2Entities();

        // GET: Students
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

            var Student = from s in db.Student select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Student = Student.Where(s => s.ID.ToString() == searchString);
            }
            else if (!String.IsNullOrEmpty(SearchKeeperString))
            {
                Student = Student.Where(s => s.StudentName == SearchKeeperString);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Student = Student.OrderByDescending(s => s.ID);
                    break;
                default:
                    Student = Student.OrderBy(s => s.ID);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Student.ToPagedList(pageNumber, pageSize));
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentName,Adress,PhoneNumber,Caretaker")] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Student.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index"); 
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Error: " + ex.InnerException.InnerException.Message);
                }
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentName,Adress,PhoneNumber,Caretaker")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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
