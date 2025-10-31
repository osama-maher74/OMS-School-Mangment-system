using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1.Models;

namespace ModelLayer
{
    public class Course
    {
        public int Id { get; set; }
        public string CrsName { get; set; }
        public int CrsDuration { get; set; }

        public List<Departments> Departments { get; set; } = new List<Departments>();

        public List<StudentCourse> CourseStudent { get; set; } = new List<StudentCourse>();

    }
}
