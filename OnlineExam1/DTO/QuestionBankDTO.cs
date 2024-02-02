namespace OnlineExam1.DTO
{
    public class QuestionBankDTO
    {
        public int QuestionID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string QuestionText { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }

        public string Answer { get; set; }
    }
}
