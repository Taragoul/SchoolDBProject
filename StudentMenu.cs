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