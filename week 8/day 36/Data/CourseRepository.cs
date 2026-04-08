using Dapper;
using Microsoft.Data.Sqlite;
using StudentCourseSystem.Models;

namespace StudentCourseSystem.Data
{
    public class CourseRepository
    {
        private readonly string _connectionString;

        public CourseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Fetch all courses with their enrolled students
        public IEnumerable<Course> GetAllCoursesWithStudents()
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = @"
                SELECT c.CourseId, c.CourseName,
                       s.StudentId, s.StudentName, s.CourseId
                FROM Courses c
                LEFT JOIN Students s ON c.CourseId = s.CourseId
                ORDER BY c.CourseName, s.StudentName;
            ";

            var courseDictionary = new Dictionary<int, Course>();

            connection.Query<Course, Student, Course>(
                sql,
                (course, student) =>
                {
                    if (!courseDictionary.TryGetValue(course.CourseId, out var existingCourse))
                    {
                        existingCourse = course;
                        courseDictionary[course.CourseId] = existingCourse;
                    }

                    if (student != null && student.StudentId != 0)
                    {
                        existingCourse.Students.Add(student);
                    }

                    return existingCourse;
                },
                splitOn: "StudentId"
            );

            return courseDictionary.Values;
        }

        // Fetch a single course with its students
        public Course? GetCourseById(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = @"
                SELECT c.CourseId, c.CourseName,
                       s.StudentId, s.StudentName, s.CourseId
                FROM Courses c
                LEFT JOIN Students s ON c.CourseId = s.CourseId
                WHERE c.CourseId = @Id
                ORDER BY s.StudentName;
            ";

            Course? result = null;

            connection.Query<Course, Student, Course>(
                sql,
                (course, student) =>
                {
                    if (result == null) result = course;
                    if (student != null && student.StudentId != 0)
                        result.Students.Add(student);
                    return course;
                },
                new { Id = id },
                splitOn: "StudentId"
            );

            return result;
        }

        // Get all courses (for dropdown)
        public IEnumerable<Course> GetAllCourses()
        {
            using var connection = new SqliteConnection(_connectionString);
            return connection.Query<Course>("SELECT CourseId, CourseName FROM Courses ORDER BY CourseName;");
        }

        // Add a new course
        public void AddCourse(Course course)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Execute(
                "INSERT INTO Courses (CourseName) VALUES (@CourseName);",
                course
            );
        }

        // Delete a course
        public void DeleteCourse(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Execute("DELETE FROM Courses WHERE CourseId = @Id;", new { Id = id });
        }
    }
}
