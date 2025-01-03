using SchoolDBProject.Models;

namespace SchoolDBProject
{
    public class PersonnelMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Personnel Menu ===");
                Console.WriteLine("1. List All Personnel");
                Console.WriteLine("2. Add New Personnel");
                Console.WriteLine("3. Teachers Per Department");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListPersonnel();
                        break;
                    case "2":
                        AddPersonnel();
                        break;
                    case "3":
                        CountTeachersByDepartment();
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
