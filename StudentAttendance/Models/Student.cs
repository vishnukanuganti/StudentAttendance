using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Models
{
    public class Student
    {
        public Student()
        {
            Classes = new List<Class>();
            Attendances = new List<Attendance>();
        }

        [Key]
        public int StudentID { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }


        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
