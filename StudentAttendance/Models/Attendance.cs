using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentAttendance.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace StudentAttendance.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [ForeignKey("Student")]
        public int? StudentID { get; set; }

        [ForeignKey("Class")]
        public int? ClassID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AttendanceDate { get; set; }

        [Required]
        public string Status { get; set; }


        [ValidateNever]
        public virtual Class Class { get; set; }

        [ValidateNever]
        public virtual Student Student { get; set; }
    }
}
