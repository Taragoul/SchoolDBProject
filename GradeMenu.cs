using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolDBProject.Models;

namespace SchoolDBProject
{
    public class GradeMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Grade Menu ===");
                Console.WriteLine("1. List All Grades");
                Console.WriteLine("2. Highest, Lowest, and Average Grade in a Class");
                Console.WriteLine("3. Add New Grade");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListGrades();
                        break;
                    case "2":
                        GradeStatistics();
                        break;
                    case "3":
                        AddGrade();
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
        private static void ListGrades()
        {
            using var context = new ProjectSchoolContext();
            Console.Clear();
            Console.Write("Limit results to how many grades? (Enter 0 for all): ");

            if (int.TryParse(Console.ReadLine(), out int limit) && limit > 0)
            {
                var grades = context.Grades
                    .Include(g => g.Class)
                    .Include(g => g.Student)
                    .Include(g => g.Teacher)
                    .OrderBy(g => g.GradeDate)
                    .Take(limit)
                    .ToList();

                PrintGrades(grades);
            }
            else
            {
                var grades = context.Grades
                    .Include(g => g.Class)
                    .Include(g => g.Student)
                    .Include(g => g.Teacher)
                    .OrderBy(g => g.GradeDate)
                    .ToList();

                PrintGrades(grades);
            }
        }
        private static void PrintGrades(System.Collections.Generic.List<Grade> grades)
        {
            Console.Clear();
            Console.WriteLine("=== Grade List ===");
            foreach (var g in grades)
            {
                Console.WriteLine($"{g.Student.StudentFirstName} {g.Student.StudentLastName} - {g.Class.ClassName} - {g.Grade1} - {g.GradeDate:yyyy-MM-dd} - Teacher: {g.Teacher.PersonnelFirstName} {g.Teacher.PersonnelLastName}");
            }
            Console.WriteLine("\nPress Enter to return.");
            Console.ReadLine();
        }