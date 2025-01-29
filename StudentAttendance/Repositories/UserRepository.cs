using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;
using StudentAttendance.Repositories;

namespace StudentAttendance.Repositories
{
    public class UserRepository : IRepository<ApplicationUser>
    {
        StudentDbContext context;
        public UserRepository(StudentDbContext context)
        {
            this.context = context;
        }
        public bool Add(ApplicationUser entity)
        {
            bool b = false;
            try
            {
                DbSet<ApplicationUser> users = context.Users;
                users.Add(entity);
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

        public bool Delete(ApplicationUser entity)
        {
            DbSet<ApplicationUser> users = context.Users;
            users.Remove(entity);
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

        public List<ApplicationUser> GetAll()
        {
            DbSet<ApplicationUser> users = context.Users;
            return users.ToList();
        }

        public ApplicationUser Search(object id)
        {
            string userId = (string)id;
            DbSet<ApplicationUser> users = context.Users;
            ApplicationUser user  = users.Find(userId);
            return user;
        }

        public bool Update(ApplicationUser entity)
        {
            context.Users.Update(entity);
            return context.SaveChanges () > 0;
        }
    }
}