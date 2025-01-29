
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;

namespace StudentAttendance.Models
{
    public class StudentDbContext : IdentityDbContext<ApplicationUser>
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        //public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public virtual DbSet<Attendance> Attendances { get; set; }

        public virtual DbSet<Class> Classes { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }

        internal static object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
