using ModelLayer;

namespace lab1.Models.ViewModel
{
    public class GetEditDeptCoursesVM
    {
        public Departments departments { get; set; }

        public List<Course> CoursesAllReadyInDept { get; set; }
        public List<Course> CoursesNotInDept { get; set; }

    }
}
 