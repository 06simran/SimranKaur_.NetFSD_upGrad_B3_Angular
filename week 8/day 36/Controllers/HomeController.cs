using Microsoft.AspNetCore.Mvc;
using StudentCourseSystem.Data;

namespace StudentCourseSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentRepository _studentRepo;
        private readonly CourseRepository _courseRepo;

        public HomeController(StudentRepository studentRepo, CourseRepository courseRepo)
        {
            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
        }

        public IActionResult Index()
        {
            ViewBag.TotalStudents = _studentRepo.GetAllStudentsWithCourse().Count();
            ViewBag.TotalCourses = _courseRepo.GetAllCourses().Count();
            return View();
        }
    }
}
