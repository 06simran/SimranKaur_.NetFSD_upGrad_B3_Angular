using System;

class Program
{
    static void Main()
    {
        var repo = new StudentRepository();

        repo.AddStudent(new Student { StudentId = 1, StudentName = "Aman", Marks = 85 });
        repo.AddStudent(new Student { StudentId = 2, StudentName = "Riya", Marks = 90 });

        var report = new ReportGenerator();
        report.GenerateReport(repo.GetAllStudents());
    }
}