using lab1.DAL;
using lab1.Models;
using lab1.Models.ViewModel;
using lab1.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace lab1.Controllers
{
    [Authorize(Roles = "Instractour,Admin")]
    public class StudentController : Controller
    {
        //   ITIDbContext dbContext = new ITIDbContext();
        IEntityRepo<Student> studentRepo; //new StudentRepo();
        IEntityRepo<Departments> dEpartmentRepo; //new DEpartmentRepo();

        public StudentController(IEntityRepo<Departments> _departmentrepo, IEntityRepo<Student> _studentRepo)
        {
            dEpartmentRepo = _departmentrepo;
            studentRepo = _studentRepo;
        }

        public IActionResult Index()
        {
            var model = studentRepo.GetAll();
            return View(model);
        }
        //get
        public IActionResult Create()
        {
           
            CreateStudentVM model = new CreateStudentVM() { student = new Student() };

            model.Departments = dEpartmentRepo.GetAll();
            return View(model);
        }

        //post
        [HttpPost]
        public IActionResult Create(CreateStudentVM std)
        {
            if (ModelState.IsValid)
            {
            studentRepo.Insert(std.student);
            studentRepo.Save();
            return RedirectToAction("Index");
            }
            else
            {
                std.Departments = dEpartmentRepo.GetAll();
                return View(std);
            }

        }
        //get
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var student = studentRepo.Get(id.Value);
            if (student == null)
                return NotFound();
            var Departments = dEpartmentRepo.GetAll();
            CreateStudentVM model = new CreateStudentVM() { student = student };

            model.Departments = Departments;
            return View(model);


        }
        //post
        [HttpPost]

        public IActionResult Edit(CreateStudentVM std)
        {
          //  dbContext.Students.Update(std.student);
          //  dbContext.SaveChanges();
            studentRepo.Update(std.student);
            studentRepo.Save();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var student = studentRepo.Get(id.Value);

            if (student == null)
                return NotFound();
            studentRepo.Delete(id.Value);
            studentRepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var student = studentRepo.Get(id.Value);
            if (student == null)
                return NotFound();
            return View(student);
        }




    }
}
