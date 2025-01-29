using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;
using StudentAttendance.Models;
using System.Net;


namespace StudentAttendance.Controllers
{
    public class AttendancesController : Controller
    {
        private StudentDbContext db;

        public AttendancesController(StudentDbContext db)
        {
            this.db = db;
        }

        // GET: Attendances
        public ActionResult Index()
        {
            var attendances = db.Attendances.Include(a => a.Class).Include(a => a.Student);
            return View(attendances.ToList());
        }

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Eror");
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return View("Error");
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "Schedule");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include: "AttendanceID,StudentID,ClassID,AttendanceDate,Status")] Attendance attendance)
        {
            //attendance.Student = db.Students.Find(attendance.StudentID);
            //attendance.Class = db.Classes.Find(attendance.ClassID);

            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "Schedule", attendance.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", attendance.StudentID);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return View("Error");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "Schedule", attendance.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", attendance.StudentID);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "AttendanceID,StudentID,ClassID,AttendanceDate,Status")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "Schedule", attendance.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", attendance.StudentID);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return View("Error");
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
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
