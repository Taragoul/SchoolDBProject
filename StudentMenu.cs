using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolDBProject.Models;

namespace SchoolDBProject
{
    public class StudentMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Student Menu ===");
                Console.WriteLine("1. List All Students");
                Console.WriteLine("2. Add New Student");
                Console.WriteLine("3. Students in a specific Class");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListStudents();
                        break;
                    case "2":
                        AddStudent();
                        break;
                    case "3":
                        ListStudentsInClass();
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
        private static void ListStudents()
        {
            using var context = new ProjectSchoolContext();
            Console.Clear();
            Console.Write("Limit results to how many students? (Enter 0 for all): ");

            if (int.TryParse(Console.ReadLine(), out int limit) && limit > 0)
            {
                var students = context.Students.Take(limit).ToList();
                PrintStudents(students);
            }
            else
            {
                var students = context.Students.ToList();
                PrintStudents(students);
            }
        }

        private static void PrintStudents(System.Collections.Generic.List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("=== Student List ===");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.StudentFirstName} {s.StudentLastName} - {s.StudentEmail}");
            }
            Console.WriteLine("\nPress Enter to return.");
            Console.ReadLine();
        }