using Microsoft.EntityFrameworkCore;
using StudentAttendance.Repositories;
using StudentAttendance.Models;

namespace StudentAttendance.Repositories
{
    public class AssignmentRepository : IRepository<Assignment>
    {
        StudentDbContext context;
        public AssignmentRepository(StudentDbContext context)
        {
            this.context = context;
        }
        public bool Add(Assignment entity)
        {
            bool b = false;
            try
            {
                DbSet<Assignment> assignments = context.Assignments;
                assignments.Add(entity);
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

        public bool Delete(Assignment entity)
        {
            DbSet<Assignment> assignments = context.Assignments;
            assignments.Remove(entity);
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

        public List<Assignment> GetAll()
        {
            DbSet<Assignment> assignments = context.Assignments;
            return assignments.ToList();
        }

        public Assignment Search(object id)
        {
            string AssignmentId = (string)id;
            DbSet<Assignment> assignments = context.Assignments;
            Assignment assignment = assignments.Find(AssignmentId);
            return assignment;
        }

        public bool Update(Assignment entity)
        {
            context.Assignments.Update(entity);
            return context.SaveChanges() > 0;
        }
    }
}