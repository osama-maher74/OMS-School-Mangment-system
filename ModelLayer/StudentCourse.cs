using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1.Models;

namespace ModelLayer
{
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public int? Degree{ get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}
