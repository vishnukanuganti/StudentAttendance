using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Models;
//using StudentAttendance.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace StudentAttendance.Controllers
{
    public class GradesController : Controller
    {
        private readonly StudentDbContext _context;

        public GradesController(StudentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var grades = _context.Grades.Include(g => g.Student).Include(g => g.Course).ToList();
            

            return View(grades);
        }

        public IActionResult Details(int id)
        {
            var grade = _context.Grades.Include(g => g.Student).Include(g => g.Course).FirstOrDefault(g => g.GradeId == id);
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        public IActionResult Create()
        {
            //ViewData["Students"] = new SelectList(_context.Students, "StudentId", "FullName");
            //ViewData["Courses"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            var students = _context.Students.Select(s => new SelectListItem
            {
                Value = s.StudentID.ToString(),
                Text = s.FirstName
            }).ToList();

            var courses = _context.Courses.Select(c => new SelectListItem
            {
                Value = c.CourseID.ToString(),
                Text = c.CourseName
            }).ToList();

            // Pass the lists to the view using ViewBag
            ViewBag.Students = students;
            ViewBag.Courses = courses;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Grade grade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grade);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Students"] = new SelectList(_context.Students, "StudentId", "FullName", grade.StudentId);
            //ViewData["Courses"] = new SelectList(_context.Courses, "CourseId", "CourseName", grade.CourseId);
            var students = _context.Students.Select(s => new SelectListItem
            {
                Value = s.StudentID.ToString(),
                Text = s.FirstName
            }).ToList();

            var courses = _context.Courses.Select(c => new SelectListItem
            {
                Value = c.CourseID.ToString(),
                Text = c.CourseName
            }).ToList();

            // Pass the lists to the view using ViewBag
            ViewBag.Students = students;
            ViewBag.Courses = courses;
            return View(grade);
        }

        public IActionResult Edit(int id)
        {
            var grade = _context.Grades.Find(id);
            if (grade == null)
            {
                return NotFound();
            }
            //ViewData["Students"] = new SelectList(_context.Students, "StudentId", "FullName", grade.StudentId);
            //ViewData["Courses"] = new SelectList(_context.Courses, "CourseId", "CourseName", grade.CourseId);
            var students = _context.Students.Select(s => new SelectListItem
            {
                Value = s.StudentID.ToString(),
                Text = s.FirstName
            }).ToList();

            var courses = _context.Courses.Select(c => new SelectListItem
            {
                Value = c.CourseID.ToString(),
                Text = c.CourseName
            }).ToList();

            // Pass the lists to the view using ViewBag
            ViewBag.Students = students;
            ViewBag.Courses = courses;
            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Grade grade)
        {
            if (id != grade.GradeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(grade);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Students"] = new SelectList(_context.Students, "StudentId", "FullName", grade.StudentId);
            //ViewData["Courses"] = new SelectList(_context.Courses, "CourseId", "CourseName", grade.CourseId);
            var students = _context.Students.Select(s => new SelectListItem
            {
                Value = s.StudentID.ToString(),
                Text = s.FirstName
            }).ToList();

            var courses = _context.Courses.Select(c => new SelectListItem
            {
                Value = c.CourseID.ToString(),
                Text = c.CourseName
            }).ToList();

            // Pass the lists to the view using ViewBag
            ViewBag.Students = students;
            ViewBag.Courses = courses;
            return View(grade);
        }

        public IActionResult Delete(int id)
        {
            var grade = _context.Grades.Include(g => g.Student).Include(g => g.Course).FirstOrDefault(g => g.GradeId == id);
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var grade = _context.Grades.Find(id);
            _context.Grades.Remove(grade);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
