using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentAttendance.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendance.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public string GradeAwarded { get; set; }

        [ValidateNever]
        public Student Student { get; set; }

        [ValidateNever]
        public Course Course { get; set; }

    }
}
