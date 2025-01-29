using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Models;
//using StudentAttendance.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace StudentAttendance.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly StudentDbContext _context;

        public AssignmentsController(StudentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var assignments = _context.Assignments.Include(a => a.Course).ToList();
            return View(assignments);
        }

        public IActionResult Details(int id)
        {
            var assignment = _context.Assignments.Include(a => a.Course).FirstOrDefault(a => a.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        public IActionResult Create()
        {
            //ViewBag.Courses = new SelectList(_context.Courses.ToList(), "CourseId", "CourseName");
            List<SelectListItem> courses = _context.Courses.ToList().Select(x => new SelectListItem { Value = x.CourseID.ToString(), Text = x.CourseName}).ToList();
            ViewBag.courses = courses;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Courses"] = new SelectList(_context.Courses, "CourseId", "CourseName", assignment.CourseId);
            List<SelectListItem> courses = _context.Courses.ToList().Select(x => new SelectListItem { Value = x.CourseID.ToString(), Text = x.CourseName }).ToList();
            ViewBag.courses = courses;
            return View(assignment);
        }

        public IActionResult Edit(int id)
        {
            var assignment = _context.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }
            List<SelectListItem> courses = _context.Courses.ToList().Select(x => new SelectListItem { Value = x.CourseID.ToString(), Text = x.CourseName }).ToList();
            ViewBag.courses = courses;
            return View(assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Assignments.Update(assignment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            List<SelectListItem> courses = _context.Courses.ToList().Select(x => new SelectListItem { Value = x.CourseID.ToString(), Text = x.CourseName }).ToList();
            ViewBag.courses = courses;
            return View(assignment);
        }

        public IActionResult Delete(int id)
        {
            var assignment = _context.Assignments.Include(a => a.Course).FirstOrDefault(a => a.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var assignment = _context.Assignments.Find(id);
            _context.Assignments.Remove(assignment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
