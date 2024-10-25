using System.Collections.Generic;

namespace ExamHub
{
    public class Exam
    {
        public string ClassName { get; set; }
        public List<Question> Questions { get; set; }
        public List<ExamResult> Results { get; set; } = new List<ExamResult>();

        public Exam(string className, List<Question> questions)
        {
            ClassName = className;
            Questions = questions;
        }

        internal List<Question> GetRandomQuestions(int v)
        {
            throw new NotImplementedException();
        }
    }
}
