using Dapper;
using Microsoft.Data.Sqlite;

namespace StudentCourseSystem.Data
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Initialize()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            // Create Courses table
            connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Courses (
                    CourseId INTEGER PRIMARY KEY AUTOINCREMENT,
                    CourseName TEXT NOT NULL
                );
            ");

            // Create Students table with FK
            connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Students (
                    StudentId INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentName TEXT NOT NULL,
                    CourseId INTEGER NOT NULL,
                    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
                );
            ");

            // Seed data if empty
            var courseCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Courses");
            if (courseCount == 0)
            {
                connection.Execute(@"
                    INSERT INTO Courses (CourseName) VALUES
                    ('Computer Science'),
                    ('Mathematics'),
                    ('Physics'),
                    ('Business Administration');
                ");

                connection.Execute(@"
                    INSERT INTO Students (StudentName, CourseId) VALUES
                    ('Alice Johnson', 1),
                    ('Bob Smith', 1),
                    ('Carol White', 2),
                    ('David Brown', 2),
                    ('Eva Martinez', 3),
                    ('Frank Lee', 1),
                    ('Grace Kim', 4),
                    ('Henry Wilson', 3);
                ");
            }
        }
    }
}
