using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;
using StudentAttendance.Repositories;

namespace StudentAttendance.Repositories
{
    public class GradeRepository : IRepository<Grade>
    {
        StudentDbContext context;
        public GradeRepository(StudentDbContext context)
        {
            this.context = context;
        }
        public bool Add(Grade entity)
        {
            bool b = false;
            try
            {
                DbSet<Grade> grades = context.Grades;
                grades.Add(entity);
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

        public bool Delete(Grade entity)
        {
            DbSet<Grade> grades = context.Grades;
            grades.Remove(entity);
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

        public List<Grade> GetAll()
        {
            DbSet<Grade> grades = context.Grades;
            return grades.ToList();
        }

        public Grade Search(object id)
        {
            string GradeId = (string)id;
            DbSet<Grade> grades = context.Grades;
            Grade grade = grades.Find(GradeId);
            return grade;
        }

        public bool Update(Grade entity)
        {
            context.Grades.Update(entity);
            return context.SaveChanges() > 0;
        }
    }
}