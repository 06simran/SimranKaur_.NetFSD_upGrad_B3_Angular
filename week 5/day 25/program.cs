using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Day25Assignment
{
    class Program
    {
        // Automatically finds your Mac's Documents folder
        static string baseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Documents", "Day25Work");

        static void Main(string[] args)
        {
            // Ensure our working directory exists on your Mac
            if (!Directory.Exists(baseFolder)) Directory.CreateDirectory(baseFolder);

            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("======= DAY 25 ASSIGNMENT MENU (MAC) =======");
                Console.WriteLine("1. Problem 1: Log Message Writer (FileStream)");
                Console.WriteLine("2. Problem 2: File Auditor (FileInfo)");
                Console.WriteLine("3. Problem 3: Performance Evaluator (Tuples)");
                Console.WriteLine("4. Problem 4: Directory Structure Analyzer");
                Console.WriteLine("5. Problem 5: Disk Monitor (DriveInfo)");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect a problem to run: ");
                
                if (!int.TryParse(Console.ReadLine(), out choice)) continue;

                switch (choice)
                {
                    case 1: RunProblem1(); break;
                    case 2: RunProblem2(); break;
                    case 3: RunProblem3(); break;
                    case 4: RunProblem4(); break;
                    case 5: RunProblem5(); break;
                }
                
                if(choice != 6) {
                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ReadLine();
                }

            } while (choice != 6);
        }

        // --- PROBLEM 1: FILESTREAM ---
        static void RunProblem1()
        {
            string filePath = Path.Combine(baseFolder, "log.txt");
            Console.Write("Enter log message: ");
            string msg = Console.ReadLine() + Environment.NewLine;

            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                byte[] data = Encoding.UTF8.GetBytes(msg);
                fs.Write(data, 0, data.Length);
            }
            Console.WriteLine("Saved to: " + filePath);
        }

        // --- PROBLEM 2: FILEINFO ---
        static void RunProblem2()
        {
            Console.WriteLine($"Auditing folder: {baseFolder}");
            DirectoryInfo di = new DirectoryInfo(baseFolder);
            FileInfo[] files = di.GetFiles();

            foreach (var f in files)
                Console.WriteLine($"- {f.Name} ({f.Length} bytes) Created: {f.CreationTime}");
            
            Console.WriteLine("Total Files: " + files.Length);
        }

        // --- PROBLEM 3: TUPLES & PATTERN MATCHING ---
        static void RunProblem3()
        {
            Console.Write("Enter Monthly Sales: ");
            double sales = double.Parse(Console.ReadLine()!);
            Console.Write("Enter Rating (1-5): ");
            int rating = int.Parse(Console.ReadLine()!);

            // Tuple Return
            var result = (sales, rating);

            // Pattern Matching Switch Expression
            string status = result switch {
                ( >= 100000, >= 4) => "High Performer",
                ( >= 50000, >= 3) => "Average Performer",
                _ => "Needs Improvement"
            };

            Console.WriteLine($"Result: {status}");
        }

        // --- PROBLEM 4: DIRECTORY INFO ---
        static void RunProblem4()
        {
            // On Mac, we can check the User root
            string root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            DirectoryInfo di = new DirectoryInfo(root);
            
            // Getting top 5 directories to avoid long lists
            var dirs = di.GetDirectories().Take(5); 

            foreach (var d in dirs) {
                try {
                    Console.WriteLine($"Folder: {d.Name} | Files: {d.GetFiles().Length}");
                } catch { /* Skip folders with no permission */ }
            }
        }

        // --- PROBLEM 5: DRIVE INFO ---
        static void RunProblem5()
        {
            DriveInfo di = new DriveInfo("/"); // Main Mac HD
            double freePercent = ((double)di.AvailableFreeSpace / di.TotalSize) * 100;

            Console.WriteLine($"Drive: {di.Name}");
            Console.WriteLine($"Free Space: {di.AvailableFreeSpace / 1073741824} GB");
            
            if (freePercent < 15) Console.WriteLine("!!! WARNING: LOW DISK SPACE !!!");
            else Console.WriteLine("Disk health: Good");
        }
    }
}