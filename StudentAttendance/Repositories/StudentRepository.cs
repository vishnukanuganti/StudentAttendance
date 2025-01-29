using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;
using StudentAttendance.Repositories;

namespace StudentAttendance.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        StudentDbContext context;
        public StudentRepository(StudentDbContext context)
        {
            this.context = context;
        }
        public bool Add(Student entity)
        {
            bool b = false;
            try
            {
                DbSet<Student> students = context.Students;
                students.Add(entity);
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

        public bool Delete(Student entity)
        {
            DbSet<Student> students = context.Students;
            students.Remove(entity);
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

        public List<Student> GetAll()
        {
            DbSet<Student> students = context.Students;
            return students.ToList();
        }

        public Student Search(object id)
        {
            string studentId = (string)id;
            DbSet<Student> students = context.Students;
            Student student = students.Find(studentId);
            return student;
        }

        public bool Update(Student entity)
        {
            context.Students.Update(entity);
            return context.SaveChanges() > 0;
        }
    }
}