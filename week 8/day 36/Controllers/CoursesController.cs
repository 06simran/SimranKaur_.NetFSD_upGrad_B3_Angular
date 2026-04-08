using Microsoft.AspNetCore.Mvc;
using StudentCourseSystem.Data;
using StudentCourseSystem.Models;

namespace StudentCourseSystem.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseRepository _courseRepo;

        public CoursesController(CourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        // GET: /Courses — list all courses with enrolled students
        public IActionResult Index()
        {
            var courses = _courseRepo.GetAllCoursesWithStudents();
            return View(courses);
        }

        // GET: /Courses/Details/5
        public IActionResult Details(int id)
        {
            var course = _courseRepo.GetCourseById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        // GET: /Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.AddCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // POST: /Courses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _courseRepo.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
