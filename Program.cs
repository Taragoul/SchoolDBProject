using System;

namespace SchoolDBProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== School Database Management ===");
                Console.WriteLine("1. Student Menu");
                Console.WriteLine("2. Grade Menu");
                Console.WriteLine("3. Personnel Menu");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        StudentMenu.Show();
                        break;
                    case "2":
                        GradeMenu.Show();
                        break;
                    case "3":
                        PersonnelMenu.Show();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
