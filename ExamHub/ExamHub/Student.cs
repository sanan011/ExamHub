using System;
using System.Collections.Generic;

namespace ExamHub
{
    public class Student : UserBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Exam> AssignedExams { get; set; } = new List<Exam>();

        public Student(int id, string name, string surname, string username, string password) : base(username, password)
        {
            ID = id;
            Name = name;
            Surname = surname;
        }

        public override void Login()
        {
            Console.WriteLine($"Student {Name} {Surname} logged in.");
            ShowStudentMenu();
        }

        private void ShowStudentMenu()
        {
            // Debug line to check assigned exams count
            Console.WriteLine($"Assigned Exams Count for {Name}: {AssignedExams.Count}");

            while (true)
            {
                Console.WriteLine("Student Menu:");
                Console.WriteLine("1. Take Exam");
                Console.WriteLine("2. View Results");
                Console.WriteLine("3. Logout");

                switch (Console.ReadLine())
                {
                    case "1":
                        TakeExam();
                        break;
                    case "2":
                        ViewResults();
                        break;
                    case "3":
                        Console.WriteLine("Logging out...");
                        Program.ShowLoginPage();
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public void AssignExam(Exam exam)
        {
            AssignedExams.Add(exam);
        }

        private void TakeExam()
        {
            Console.WriteLine("Available exams:");
            foreach (var exam in AssignedExams)
            {
                Console.WriteLine($"- {exam.ClassName}");
            }

            Console.Write("Enter the subject to take the exam: ");
            string className = Console.ReadLine();
            var selectedExam = AssignedExams.Find(e => e.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase));

            if (selectedExam != null)
            {
                int score = 0;
                foreach (var question in selectedExam.Questions)
                {
                    Console.WriteLine(question.QuestionText);
                    for (int i = 0; i < question.Options.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {question.Options[i]}");
                    }

                    Console.Write("Your answer: ");
                    int answer = int.Parse(Console.ReadLine()) - 1;
                    if (answer == question.CorrectAnswerIndex)
                    {
                        score++;
                    }
                }

                var examResult = new ExamResult(className, score, selectedExam.Questions.Count);
                selectedExam.Results.Add(examResult);
                Console.WriteLine($"You scored {score} out of {selectedExam.Questions.Count}.");
            }
            else
            {
                Console.WriteLine("Exam not found.");
            }
        }

        private void ViewResults()
        {
            Console.WriteLine("Exam results:");
            foreach (var exam in AssignedExams)
            {
                foreach (var result in exam.Results)
                {
                    Console.WriteLine($"{exam.ClassName}: {result.Score} out of {result.TotalQuestions}");
                }
            }
        }
    }
}
