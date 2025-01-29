using Microsoft.AspNetCore.Mvc;
using StudentAttendance.Models;
using StudentAttendance.Repositories;
using System.Linq;

namespace StudentAttendance.Controllers
{
    public class UserController : Controller
    {
        private readonly StudentDbContext _context;

        public UserController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ApplicationUser user)
        {
            //var existingUser = _context.Users
            //    .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            //if (existingUser != null)
            //{
            //    // Set session or authentication cookie here
            //    return RedirectToAction("Dashboard");
            //}
            //ModelState.AddModelError("", "Invalid username or password");
            return View(user);
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Logout()
        {
            // Clear session or authentication cookie here
            return RedirectToAction("Login");
        }
    }
}