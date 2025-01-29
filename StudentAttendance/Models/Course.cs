using StudentAttendance.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Models
{
    public class Course
    {
        public Course()
        {
            Classes = new List<Class>();
            Grades = new List<Grade>();
           
            Assignments = new List<Assignment>();

        }

        [Key]
        public int CourseID { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseCode { get; set; }

        public int? Credits { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }


        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }




    }
}
