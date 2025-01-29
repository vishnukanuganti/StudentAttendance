using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace StudentAttendance.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Classes = new List<Class>();
        }

        [Key]
        public int TeacherID { get; set; }

        [Required]

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }



        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Class> Classes { get; set; }

    }
}
