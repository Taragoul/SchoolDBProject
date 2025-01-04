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
                Console.WriteLine("4. List Active Classes");
                Console.WriteLine("5. Back to Main Menu");
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
                        ListActiveClasses();
                        break;
                    case "5":
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
        private static void AddStudent()
        {
            using var context = new ProjectSchoolContext();
            Console.Clear();
            var student = new Student();

            Console.Write("First Name: ");
            student.StudentFirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            student.StudentLastName = Console.ReadLine();

            Console.Write("Email: ");
            student.StudentEmail = Console.ReadLine();

            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine("Student added successfully. Press Enter to return.");
            Console.ReadLine();
        }

        private static void ListStudentsInClass()
        {
            using var context = new ProjectSchoolContext();
            Console.Clear();
            Console.WriteLine("=== Select Class ===");
            var classes = context.Classes.ToList();

            foreach (var c in classes)
            {
                Console.WriteLine($"{c.ClassId}. {c.ClassName}");
            }

            Console.Write("\nEnter Class ID: ");
            if (int.TryParse(Console.ReadLine(), out int classId))
            {
                var students = context.Enrollments
                    .Where(e => e.ClassId == classId)
                    .Include(e => e.Student)
                    .Select(e => e.Student)
                    .ToList();

                Console.Clear();
                Console.WriteLine($"Students in Class {classId}:");
                PrintStudents(students);
            }
        }
        private static void ListActiveClasses()
        {
            using var context = new ProjectSchoolContext();
            Console.Clear();
            Console.WriteLine("=== Active Classes ===\n");

            var activeClasses = context.Classes
                .Where(c => c.Enrollments.Any())
                .Select(c => new
                {
                    c.ClassName,
                    c.Description,
                    StudentCount = c.Enrollments.Count()
                })
                .ToList();

            if (activeClasses.Count > 0)
            {
                foreach (var c in activeClasses)
                {
                    Console.WriteLine($"Class: {c.ClassName}");
                    Console.WriteLine($"Description: {c.Description}");
                    Console.WriteLine($"Enrolled Students: {c.StudentCount}\n");
                }
            }
            else
            {
                Console.WriteLine("No active classes found.");
            }
            Console.WriteLine($"Press Enter to return.");
            Console.ReadLine();
        }

    }
}