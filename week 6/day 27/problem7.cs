using System;

class Program
{
    static void Main()
    {
        IStudentRepository repo = new StudentRepository();

        repo.AddStudent(new Student { StudentId = 1, StudentName = "Aman", Course = "C#" });
        repo.AddStudent(new Student { StudentId = 2, StudentName = "Riya", Course = "Java" });

        Console.WriteLine("\nAll Students:");
        foreach (var s in repo.GetAllStudents())
        {
            Console.WriteLine($"{s.StudentId} - {s.StudentName} - {s.Course}");
        }

        Console.WriteLine("\nFind Student ID 1:");
        var student = repo.GetStudentById(1);
        Console.WriteLine(student?.StudentName);

        repo.DeleteStudent(1);

        Console.WriteLine("\nAfter Deletion:");
        foreach (var s in repo.GetAllStudents())
        {
            Console.WriteLine($"{s.StudentId} - {s.StudentName}");
        }
    }
}