using Microsoft.EntityFrameworkCore;
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
        private static void ListPersonnel()
        {
            using var context = new ProjectSchoolContext();
            Console.Clear();
            var personnel = context.Personnel.Include(p => p.Role).ToList();

            Console.WriteLine("=== Personnel List ===");
            foreach (var p in personnel)
            {
                Console.WriteLine($"{p.PersonnelFirstName} {p.PersonnelLastName} - {p.PersonnelEmail} - Role: {p.Role.RoleName}");
            }

            Console.WriteLine("\nPress Enter to return.");
            Console.ReadLine();
        }
        private static void AddPersonnel()
        {
            using var context = new ProjectSchoolContext();
            Console.Clear();
            var personnel = new Personnel();

            Console.Write("First Name: ");
            personnel.PersonnelFirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            personnel.PersonnelLastName = Console.ReadLine();

            Console.Write("Email: ");
            personnel.PersonnelEmail = Console.ReadLine();

            Console.WriteLine("Select Role:");
            var roles = context.Roles.ToList();
            foreach (var r in roles)
            {
                Console.WriteLine($"{r.RoleId}. {r.RoleName}");
            }

            Console.Write("Enter Role ID: ");
            if (int.TryParse(Console.ReadLine(), out int roleId) && roles.Any(r => r.RoleId == roleId))
            {
                personnel.RoleId = roleId;
                context.Personnel.Add(personnel);
                context.SaveChanges();
                Console.WriteLine("Personnel added successfully. Press Enter to return.");
            }
            else
            {
                Console.WriteLine("Invalid Role. Operation cancelled.");
            }
            Console.ReadLine();
        }