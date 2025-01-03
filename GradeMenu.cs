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
        private static void GradeStatistics()
        {
            using var context = new ProjectSchoolContext();
            Console.Clear();
            Console.WriteLine("=== Select Class for Stats ===");
            var classes = context.Classes.ToList();

            foreach (var c in classes)
            {
                Console.WriteLine($"{c.ClassId}. {c.ClassName}");
            }

            Console.Write("\nEnter Class ID: ");
            if (int.TryParse(Console.ReadLine(), out int classId))
            {
                var grades = context.Grades
                    .Where(g => g.ClassId == classId)
                    .Select(g => g.Grade1)
                    .ToList();

                if (grades.Count > 0)
                {
                    var gradeValues = grades
                        .Select(g => MapGradeToValue(g))
                        .Where(v => v >= 0)
                        .ToList();

                    if (gradeValues.Count > 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Class {classId} Statistics:");
                        Console.WriteLine("\nGrade Mapping:");
                        Console.WriteLine("A = 4, B = 3, C = 2, D = 1, F = 0\n");
                        Console.WriteLine($"Highest Grade: {gradeValues.Max()}");
                        Console.WriteLine($"Lowest Grade: {gradeValues.Min()}");
                        Console.WriteLine($"Average Grade: {gradeValues.Average():F2}");
                    }
                    else
                    {
                        Console.WriteLine("No valid grades found for this class.");
                    }
                }
                else
                {
                    Console.WriteLine("No grades found for this class.");
                }
            }
            Console.ReadLine();
        }
        private static int MapGradeToValue(string grade)
        {
            return grade.ToUpper() switch
            {
                "A" => 4,
                "B" => 3,
                "C" => 2,
                "D" => 1,
                "F" => 0,
                _ => -1  // Return -1 for invalid grades
            };
        }
        private static void AddGrade()
        {
            using var context = new ProjectSchoolContext();
            Console.Clear();
            var grade = new Grade();

            Console.Write("Student ID: ");
            grade.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Class ID: ");
            grade.ClassId = int.Parse(Console.ReadLine());

            Console.Write("Grade (e.g A-F): ");
            grade.Grade1 = Console.ReadLine();

            Console.Write("Teacher ID: ");
            grade.TeacherId = int.Parse(Console.ReadLine());

            grade.GradeDate = DateTime.Now;

            context.Grades.Add(grade);
            context.SaveChanges();
            Console.WriteLine("Grade added successfully. Press Enter to return.");
            Console.ReadLine();
        }
    }
}