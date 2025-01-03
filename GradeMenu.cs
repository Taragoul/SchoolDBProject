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