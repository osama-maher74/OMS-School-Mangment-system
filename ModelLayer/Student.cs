using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelLayer;

namespace lab1.Models
{
 
    public class Student
    {

        public  int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public  string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public  string Email { get; set; }

        [Range(22,32)]
        public  int Age { get; set; }


        [ForeignKey("Department")]
        public int DeptID { get; set; }
        public Departments Department { get; set; }

        public List<StudentCourse> studentCourses { get; set; }= new List<StudentCourse>();

        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, DeptID: {DeptID}";
        }
    }
}
