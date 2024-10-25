namespace ExamHub
{
    public class ExamResult
    {
        private int correct;
        private int wrong;
        private int empty;

        public string ClassName { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }

        public ExamResult(string className, int score, int totalQuestions)
        {
            ClassName = className;
            Score = score;
            TotalQuestions = totalQuestions;
        }

        public ExamResult(int correct, int wrong, int empty)
        {
            this.correct = correct;
            this.wrong = wrong;
            this.empty = empty;
        }
    }
}
