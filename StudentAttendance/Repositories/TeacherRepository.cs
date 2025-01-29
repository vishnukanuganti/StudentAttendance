using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;
using StudentAttendance.Repositories;

namespace StudentAttendance.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        StudentDbContext context;
        public TeacherRepository(StudentDbContext context)
        {
            this.context = context;
        }
        public bool Add(Teacher entity)
        {
            bool b = false;
            try
            {
                DbSet<Teacher> teachers = context.Teachers;
                teachers.Add(entity);
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

        public bool Delete(Teacher entity)
        {
            DbSet<Teacher> teachers = context.Teachers;
            teachers.Remove(entity);
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

        public List<Teacher> GetAll()
        {
            DbSet<Teacher> teachers = context.Teachers;
            return teachers.ToList();
        }

        public Teacher Search(object id)
        {
            string teacherId = (string)id;
            DbSet<Teacher> teachers = context.Teachers;
            Teacher teacher = teachers.Find(teacherId);
            return teacher;
        }

        public bool Update(Teacher entity)
        {
            context.Teachers.Update(entity);
            return context.SaveChanges() > 0;
        }
    }
}