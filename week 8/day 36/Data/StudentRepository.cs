using Dapper;
using Microsoft.Data.Sqlite;
using StudentCourseSystem.Models;

namespace StudentCourseSystem.Data
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Fetch all students with their course details (JOIN)
        public IEnumerable<Student> GetAllStudentsWithCourse()
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = @"
                SELECT s.StudentId, s.StudentName, s.CourseId,
                       c.CourseId, c.CourseName
                FROM Students s
                INNER JOIN Courses c ON s.CourseId = c.CourseId
                ORDER BY s.StudentName;
            ";

            return connection.Query<Student, Course, Student>(
                sql,
                (student, course) =>
                {
                    student.Course = course;
                    return student;
                },
                splitOn: "CourseId"
            );
        }

        // Fetch a single student with course
        public Student? GetStudentById(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = @"
                SELECT s.StudentId, s.StudentName, s.CourseId,
                       c.CourseId, c.CourseName
                FROM Students s
                INNER JOIN Courses c ON s.CourseId = c.CourseId
                WHERE s.StudentId = @Id;
            ";

            return connection.Query<Student, Course, Student>(
                sql,
                (student, course) =>
                {
                    student.Course = course;
                    return student;
                },
                new { Id = id },
                splitOn: "CourseId"
            ).FirstOrDefault();
        }

        // Add a new student
        public void AddStudent(Student student)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Execute(
                "INSERT INTO Students (StudentName, CourseId) VALUES (@StudentName, @CourseId);",
                student
            );
        }

        // Delete a student
        public void DeleteStudent(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Execute("DELETE FROM Students WHERE StudentId = @Id;", new { Id = id });
        }
    }
}
