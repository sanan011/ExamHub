using System;
using System.Collections.Generic;

namespace ExamHub
{
    public class Admin : UserBase
    {
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public Admin(string username, string password) : base(username, password) { }

        public override void Login()
        {
            Console.WriteLine($"Admin {Username} logged in.");
            ShowAdminMenu();
        }

        private void ShowAdminMenu()
        {
            while (true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Add Questions");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Assign Exams");
                Console.WriteLine("4. Logout");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddQuestions();
                        break;
                    case "2":
                        ViewStudents();
                        break;
                    case "3":
                        AssignExams();
                        break;
                    case "4":
                        Console.WriteLine("Logging out...");
                        Program.ShowLoginPage();
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void AddQuestions()
        {
            Console.WriteLine("Select a subject to add questions: 1. Math, 2. Chemistry, 3. Physics, 4. Programming, 5. System Administration");
            string className = GetClassName(Console.ReadLine());

            if (className != null)
            {
                List<Question> newQuestions = new List<Question>();
                Console.WriteLine($"Adding questions for {className}");
                while (true)
                {
                    Console.Write("Enter question text (or 'exit' to finish): ");
                    string questionText = Console.ReadLine();
                    if (questionText.ToLower() == "exit") break;

                    string[] options = new string[4];
                    for (int i = 0; i < 4; i++)
                    {
                        Console.Write($"Enter option {i + 1}: ");
                        options[i] = Console.ReadLine();
                    }

                    Console.Write("Enter the index of the correct option (1-4): ");
                    int correctAnswerIndex = int.Parse(Console.ReadLine()) - 1;

                    Question question = new Question(newQuestions.Count + 1, questionText, options, correctAnswerIndex);
                    newQuestions.Add(question);
                }

                Exam exam = Exams.Find(e => e.ClassName == className);
                if (exam == null)
                {
                    exam = new Exam(className, newQuestions);
                    Exams.Add(exam);
                }
                else
                {
                    exam.Questions.AddRange(newQuestions);
                }
                Console.WriteLine("Questions added successfully.");
            }
        }

        private string GetClassName(string choice)
        {
            return choice switch
            {
                "1" => "Math",
                "2" => "Chemistry",
                "3" => "Physics",
                "4" => "Programming",
                "5" => "System Administration",
                _ => null
            };
        }

        private void ViewStudents()
        {
            Console.WriteLine("List of students:");
            foreach (var student in Program.Students)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name} {student.Surname}");
            }
        }

        private void AssignExams()
        {
            Console.Write("Enter student ID to assign exams: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var student = Program.Students.Find(s => s.ID == studentId);

                if (student != null)
                {
                    Console.WriteLine("Select a subject to assign exams: 1. Math, 2. Chemistry, 3. Physics, 4. Programming, 5. System Administration");
                    string className = GetClassName(Console.ReadLine());

                    var exam = Exams.Find(e => e.ClassName == className);
                    if (exam != null)
                    {
                        student.AssignExam(exam);
                        Console.WriteLine($"{className} exam assigned to {student.Name}.");
                        // Debug line to check if exam was added
                        Console.WriteLine($"Assigned Exams Count for {student.Name}: {student.AssignedExams.Count}");
                    }
                    else
                    {
                        Console.WriteLine("Exam not found for the chosen class.");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
        }
    }
}
