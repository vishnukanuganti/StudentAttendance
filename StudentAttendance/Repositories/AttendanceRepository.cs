using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;
using StudentAttendance.Repositories;

namespace StudentAttendance.Repositories
{
    public class AttendanceRepository : IRepository<Attendance>
    {
        StudentDbContext context;
        public AttendanceRepository(StudentDbContext context)
        {
            this.context = context;
        }
        public bool Add(Attendance entity)
        {
            bool b = false;
            try
            {
                DbSet<Attendance> attendances = context.Attendances;
                attendances.Add(entity);
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

        public bool Delete(Attendance entity)
        {
            DbSet<Attendance> attendances = context.Attendances;
            attendances.Remove(entity);
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

        public List<Attendance> GetAll()
        {
            DbSet<Attendance> attendances = context.Attendances;
            return attendances.ToList();
        }

        public Attendance Search(object id)
        {
            string AttendanceId = (string)id;
            DbSet<Attendance> attendances = context.Attendances;
            Attendance attendance = attendances.Find(AttendanceId);
            return attendance;
        }

        public bool Update(Attendance entity)
        {
            context.Attendances.Update(entity);
            return context.SaveChanges() > 0;
        }
    }
}