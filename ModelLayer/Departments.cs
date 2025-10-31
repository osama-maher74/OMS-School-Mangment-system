using System.Collections.Generic;
using ModelLayer;

namespace lab1.Models
{
    public class Departments
    {
        public int DeptID { get; set; }

        public string DeptName { get; set; }

       public int Capacity { get; set; }
        public bool Status { get; set; } = true;

        public List<Student> Students { get; set; } = new List<Student>();

        public List<Course> Courses { get; set; } = new List<Course>();

        override public string ToString()
        {
            return $"DeptID: {DeptID}, DeptName: {DeptName}, Capacity: {Capacity}";
        }


    }
}
