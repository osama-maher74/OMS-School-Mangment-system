using lab1.Models;
using lab1.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    public class TestController : Controller
    {


        public ViewResult Details()
        {
            string title = "Student Details";
                ViewData["Title"] = title;

            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, Name = "body", Age = 21 });
            students.Add(new Student { Id = 2, Name = "Bob", Age = 22 });
            students.Add(new Student { Id = 3, Name = "Charlie", Age = 23 });
            students.Add(new Student { Id = 4, Name = "Diana", Age = 24 });
            students.Add(new Student { Id = 5, Name = "Eve", Age = 25 });

            Departments dept = new Departments();
            dept.DeptID = 101;
            dept.DeptName = "Computer Science";

             StdDetailsVM stdDetailsVM = new StdDetailsVM();
            stdDetailsVM.Dept = dept;
            stdDetailsVM.DeptStd = students;
            return View(stdDetailsVM);
            
        }

        public ViewResult Show()
        {
            return View();
        }

        public int add()
        { 

        return 5 + 10;
       
        }
        public int add2(int? a, int? b)
        {
            return (a ?? 0) + (b ?? 0);
        }



        public IActionResult Index()
        {
            return View();
        }


    }
}
