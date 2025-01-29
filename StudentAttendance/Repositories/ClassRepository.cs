using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;
using StudentAttendance.Repositories;

namespace StudentAttendance.Repositories
{
    public class ClassRepository : IRepository<Class>
    {
        StudentDbContext context;
        public ClassRepository(StudentDbContext context)
        {
            this.context = context;
        }
        public bool Add(Class entity)
        {
            bool b = false;
            try
            {
                DbSet<Class> classes = context.Classes;
                classes.Add(entity);
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

        public bool Delete(Class entity)
        {
            DbSet<Class> classes = context.Classes;
            classes.Remove(entity);
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

        public List<Class> GetAll()
        {
            DbSet<Class> classes = context.Classes;
            return classes.ToList();
        }

        public Class Search(object id)
        {
            string ClassId = (string)id;
            DbSet<Class> classes = context.Classes;
            Class Class =classes.Find(ClassId);
            return Class;
        }
        public bool Update(Class entity)
        {
            context.Classes.Update(entity);
            return context.SaveChanges() > 0;
        }
    }
}