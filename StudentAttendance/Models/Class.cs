using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StudentAttendance.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentAttendance.Models
{
    public class Class
    {
        public Class()
        {
            Attendances = new List<Attendance>();
            Course = new Course();
            Teacher = new Teacher();
        }
        [Key]
        public int ClassID { get; set; }

        [ForeignKey("Course")]
        public int? CourseID { get; set; }


        [ForeignKey("Teacher")]
        public int? TeacherID { get; set; }

        public string Schedule { get; set; }

        [ValidateNever]
        public virtual ICollection<Attendance> Attendances { get; set; }

        [ValidateNever]
        public virtual Course Course { get; set; }

        [ValidateNever]
        public virtual Teacher Teacher { get; set; }

    }

}


