using System;
using System.Collections.Generic;

public record Student(int RollNo, string Name, string Course, int Marks);

public class StudentManager
{
    private List<Student> students = new List<Student>();

    public void AddStudents()
    {
        Console.Write("Enter number of students: ");
        int n;

        // Input validation
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Invalid input! Enter a valid number: ");
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Enter Details for Student {i + 1} ---");

            int roll, marks;

            Console.Write("Roll Number: ");
            while (!int.TryParse(Console.ReadLine(), out roll))
            {
                Console.Write("Invalid! Enter valid Roll Number: ");
            }

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Course: ");
            string course = Console.ReadLine()!;

            Console.Write("Marks: ");
            while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0)
            {
                Console.Write("Invalid! Enter valid Marks: ");
            }

            students.Add(new Student(roll, name, course, marks));
        }

        // 👉 Automatically display after input
        DisplayStudents();
    }

    public void DisplayStudents()
    {
        Console.WriteLine("\n===== STUDENT RECORDS =====");

        if (students.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        foreach (var s in students)
        {
            Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
        }
    }

    public void SearchStudent()
    {
        Console.Write("\nEnter Roll Number to search: ");
        int roll;

        while (!int.TryParse(Console.ReadLine(), out roll))
        {
            Console.Write("Invalid! Enter valid Roll Number: ");
        }

        var found = students.Find(s => s.RollNo == roll);

        Console.WriteLine("\n===== SEARCH RESULT =====");

        if (found != null)
        {
            Console.WriteLine($"Roll No: {found.RollNo} | Name: {found.Name} | Course: {found.Course} | Marks: {found.Marks}");
        }
        else
        {
            Console.WriteLine("Student not found");
        }
    }
}