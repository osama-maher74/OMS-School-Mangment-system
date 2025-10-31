using lab1.DAL;
using lab1.Models;
using lab1.Models.ViewModel;
using lab1.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLayer;

namespace lab1.Controllers 
{
    [Authorize(Roles = "Instractour,Admin")]
    public class DepartmentController : Controller
    {

        ITIDbContext dbContext;
        IEntityRepo<Departments> dEpartmentRepo;//new DEpartmentRepo();
        DepartmentCourseRepo courseRepo;

        public DepartmentController(IEntityRepo<Departments> _departmentrepo,DepartmentCourseRepo _departmentCourseRepo ,ITIDbContext _dbContext )
        {
            dEpartmentRepo = _departmentrepo;
            courseRepo= _departmentCourseRepo;
            dbContext = _dbContext;
        }

        
        public IActionResult Index()
        {
            var departments = dEpartmentRepo.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        { 
            return View();

        }
        [HttpPost]
        public IActionResult Create(Departments dept)
        {
            dEpartmentRepo.Insert(dept);
            dEpartmentRepo.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dep = dEpartmentRepo.Get(id.Value);
            if (dep == null)
            {
                return NotFound();
            }
            var students = dEpartmentRepo.Get(id.Value);
            StdDetailsVM stdDetailsVM = new StdDetailsVM
            {
                Dept = dep,
                DeptStd = students.DeptID == id.Value ? students.Students : null
            };
            return View(stdDetailsVM);
        }
        public IActionResult Delete(int? id)
        {

            if (id == null)
                return BadRequest();
            var dep = dEpartmentRepo.Get(id.Value);
            if (dep == null)
            {
                return NotFound();
            }
            dEpartmentRepo.Delete(dep.DeptID);
            dEpartmentRepo.Save();
            return RedirectToAction("Index");
        }   
        //get
        public IActionResult Edit(int? id)
        {
            if(id==null)
                return BadRequest();
            var dep = dEpartmentRepo.Get(id.Value);
            if (dep == null)
            {
                return NotFound();
            }
            return View(dep);
        }
        //post
        [HttpPost]
        public IActionResult Edit(Departments dept)
        {
            if (dept == null)
            {
                return BadRequest();
            }
            dEpartmentRepo.Update(dept);
            dEpartmentRepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult editcourses(int? id)
        {

            if (id == null)
                return BadRequest();
            var model =courseRepo.GetDepartmentsCourse(id.Value);
            return View(model);
            



        }
        [HttpPost]
        public IActionResult editcourses(PostDeptCourseUpdateVM model)
        {

            if (model == null)
                return BadRequest();

            courseRepo.UpdataDeptCourses(model);

            courseRepo.save();

            return RedirectToAction("Index");
            // return View(model);



        }

        public IActionResult ViewCourses(int? id)
        { 
        
            if (id == null)
                return BadRequest();

          var dept=  courseRepo.GetDeptWithCourses(id.Value);

        return View(dept);
        
        }
        public IActionResult UpdateStudentDegree(int deptid,int crsid)
        {

         var dept=   dbContext.Departments.Include(s => s.Students).FirstOrDefault(s => s.DeptID == deptid);
            var course = dbContext.Courses.FirstOrDefault(s => s.Id == crsid);
            ViewBag.course = course;
            return View(dept);
        
        }
        [HttpPost]
        public IActionResult UpdateStudentDegree(int deptid,int crsid,Dictionary<int,int> degree)
        {
            foreach (var item in degree)
            {
                dbContext.StudentCourse.Add(new StudentCourse()
                {
                    CourseId=crsid,
                    StudentId=item.Key,
                    Degree=item.Value


                });
            }
             dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
