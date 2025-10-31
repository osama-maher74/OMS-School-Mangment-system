using lab1.DAL;
using lab1.Models;
using lab1.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using ModelLayer;

namespace lab1.Repo
{
    public class DepartmentCourseRepo
    {
        public ITIDbContext db;
        public DepartmentCourseRepo(ITIDbContext _db )
        {
            db = _db;
            
        }

        public GetEditDeptCoursesVM GetDepartmentsCourse(int? deptid)
        {
            
            GetEditDeptCoursesVM model =new GetEditDeptCoursesVM();

            model.departments= db.Departments.Include(d=>d.Courses).FirstOrDefault(s => s.DeptID ==deptid);
            model.CoursesAllReadyInDept = model.departments.Courses;
            var allCorses =db.Courses.ToList();
            model.CoursesNotInDept = allCorses.Except(model.CoursesAllReadyInDept).ToList();
            return model;
        }

        public void UpdataDeptCourses(PostDeptCourseUpdateVM model)
        {
            var dept = db.Departments.Include(s => s.Courses).FirstOrDefault(s => s.DeptID == model.deptId);

            if (model.coursestoremove != null)
            {
                foreach (var item in model.coursestoremove)
                {
                    var c = db.Courses.FirstOrDefault(s => s.Id == item);
                    dept.Courses.Remove(c);
                }
            }

            if (model.corsestoadd != null)
            {
                foreach (var item in model.corsestoadd)
                {
                    var c = db.Courses.FirstOrDefault(s => s.Id == item);
                    dept.Courses.Add(c);
                }
            }
          //  save();

        }

        public Departments GetDeptWithCourses(int id)
        {

            return db.Departments.Include(s => s.Courses).FirstOrDefault(s => s.DeptID == id);
        
        
        }



        public void save () 
        
        {
            db.SaveChanges(); 
        }




    }
}
