using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;
using StudentAttendance.Repositories;

namespace StudentAttendance.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        StudentDbContext context;
        public CourseRepository(StudentDbContext context)
        {
            this.context = context;
        }
        public bool Add(Course entity)
        {
            bool b = false;
            try
            {
                DbSet<Course> courses = context.Courses;
                courses.Add(entity);
                int r = context.SaveChanges();
                if (r > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return b;
        }

        public bool Delete(Course entity)
        {
            DbSet<Course> courses = context.Courses;
            courses.Remove(entity);
            int r = context.SaveChanges();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Course> GetAll()
        {
            DbSet<Course> courses = context.Courses;
            return courses.ToList();
        }

        public Course Search(object id)
        {
            string CourseId = (string)id;
            DbSet<Course> courses = context.Courses;
            Course course = courses.Find(CourseId);
            return course;
        }

        public bool Update(Course entity)
        {
            context.Courses.Update(entity);
            return context.SaveChanges() > 0;
        }
    }
}