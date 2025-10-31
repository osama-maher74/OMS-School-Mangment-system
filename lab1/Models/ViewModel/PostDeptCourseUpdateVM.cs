namespace lab1.Models.ViewModel
{
    public class PostDeptCourseUpdateVM
    {

        public int deptId { get; set; }
        public int[] coursestoremove { get; set; }
        public int[] corsestoadd { get; set; }
    }
}
