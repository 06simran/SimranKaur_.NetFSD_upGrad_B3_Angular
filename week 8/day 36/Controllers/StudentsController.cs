using Microsoft.AspNetCore.Mvc;
using StudentCourseSystem.Data;
using StudentCourseSystem.Models;

namespace StudentCourseSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentRepository _studentRepo;
        private readonly CourseRepository _courseRepo;

        public StudentsController(StudentRepository studentRepo, CourseRepository courseRepo)
        {
            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
        }

        // GET: /Students — list all students with course info
        public IActionResult Index()
        {
            var students = _studentRepo.GetAllStudentsWithCourse();
            return View(students);
        }

        // GET: /Students/Details/5
        public IActionResult Details(int id)
        {
            var student = _studentRepo.GetStudentById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // GET: /Students/Create
        public IActionResult Create()
        {
            ViewBag.Courses = _courseRepo.GetAllCourses();
            return View();
        }

        // POST: /Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Courses = _courseRepo.GetAllCourses();
            return View(student);
        }

        // POST: /Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _studentRepo.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
