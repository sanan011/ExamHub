using System;
using System.Collections.Generic;

namespace ExamHub
{
    public class Program
    {
        public static List<Student> Students = new List<Student>();
        public static List<Admin> Admins = new List<Admin>();

        static void Main(string[] args)
        {
            // Sample data
            Admins.Add(new Admin("admin", "password"));
            Students.Add(new Student(1, "John", "Doe", "student1", "password"));
            Students.Add(new Student(2, "Jane", "Smith", "student2", "pass123"));

            ShowLoginPage();
        }

        public static void ShowLoginPage()
        {
            Console.WriteLine("Welcome to ExamHub! Please select your role:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Student");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AdminLogin();
                    break;
                case "2":
                    StudentLogin();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    ShowLoginPage();
                    break;
            }
        }

        static void AdminLogin()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var admin = Admins.Find(a => a.Username == username && a.Password == password);
            if (admin != null)
            {
                admin.Login();
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                ShowLoginPage();
            }
        }

        static void StudentLogin()
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var student = Students.Find(s => s.ID == studentId);
                if (student != null)
                {
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    if (student.Password == password)
                    {
                        student.Login();
                    }
                    else
                    {
                        Console.WriteLine("Invalid password.");
                        ShowLoginPage();
                    }
                }
                else
                {
                    Console.WriteLine("Student not found.");
                    ShowLoginPage();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
                ShowLoginPage();
            }
        }
    }
}
