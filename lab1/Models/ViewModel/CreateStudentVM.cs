using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab1.Models.ViewModel
{
    public class CreateStudentVM
    {
        public Student student { get; set; }    
        public List<Departments> Departments { get; set; }

    }
}
