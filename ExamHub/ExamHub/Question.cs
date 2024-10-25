namespace ExamHub
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string[] Options { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public Question(int id, string questionText, string[] options, int correctAnswerIndex)
        {
            Id = id;
            QuestionText = questionText;
            Options = options;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}
