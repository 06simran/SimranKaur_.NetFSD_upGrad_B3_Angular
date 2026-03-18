using System;

class Program
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== MAIN MENU =====");
            Console.WriteLine("1. Student Record System");
            Console.WriteLine("2. Safe Division Calculator");
            Console.WriteLine("3. Stack Based Undo System");
            Console.WriteLine("4. Employee Management (Linked List)");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n=== Student Record System ===");
                    StudentManager sm = new StudentManager();
                    sm.AddStudents();
                    sm.DisplayStudents();
                    sm.SearchStudent();
                    break;

                case 2:
                    Console.WriteLine("\n=== Safe Division Calculator ===");
                    Calculator calc = new Calculator();

                    Console.Write("Enter Numerator: ");
                    int num = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter Denominator: ");
                    int den = int.Parse(Console.ReadLine()!);

                    calc.Divide(num, den);
                    break;

                case 3:
                    Console.WriteLine("\n=== Stack Undo System ===");
                    RunStackMenu();
                    break;

                case 4:
                    Console.WriteLine("\n=== Employee Management ===");
                    RunEmployeeMenu();
                    break;

                case 5:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again!");
                    break;
            }

        } while (choice != 5);
    }

    // -------- STACK MENU --------
    static void RunStackMenu()
    {
        StackUndo stack = new StackUndo();
        int ch;

        do
        {
            Console.WriteLine("\n1. Add Action");
            Console.WriteLine("2. Undo");
            Console.WriteLine("3. Back");

            Console.Write("Enter choice: ");
            ch = int.Parse(Console.ReadLine()!);

            switch (ch)
            {
                case 1:
                    Console.Write("Enter action: ");
                    string action = Console.ReadLine()!;
                    stack.Push(action);
                    break;

                case 2:
                    stack.Pop();
                    break;

                case 3:
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (ch != 3);
    }

    // -------- EMPLOYEE MENU --------
    static void RunEmployeeMenu()
    {
        EmployeeLinkedList list = new EmployeeLinkedList();
        int ch;

        do
        {
            Console.WriteLine("\n1. Insert at Beginning");
            Console.WriteLine("2. Insert at End");
            Console.WriteLine("3. Delete by ID");
            Console.WriteLine("4. Display");
            Console.WriteLine("5. Back");

            Console.Write("Enter choice: ");
            ch = int.Parse(Console.ReadLine()!);

            switch (ch)
            {
                case 1:
                    Console.Write("Enter ID: ");
                    int id1 = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter Name: ");
                    string name1 = Console.ReadLine()!;
                    list.InsertAtBeginning(id1, name1);
                    break;

                case 2:
                    Console.Write("Enter ID: ");
                    int id2 = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter Name: ");
                    string name2 = Console.ReadLine()!;
                    list.InsertAtEnd(id2, name2);
                    break;

                case 3:
                    Console.Write("Enter ID to delete: ");
                    int id3 = int.Parse(Console.ReadLine()!);
                    list.Delete(id3);
                    break;

                case 4:
                    list.Display();
                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (ch != 5);
    }
}