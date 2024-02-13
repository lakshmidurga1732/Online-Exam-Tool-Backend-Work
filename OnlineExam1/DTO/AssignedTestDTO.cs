namespace OnlineExam1.DTO
{
    public class AssignedTestDTO
    {
        public int AssignmentID { get; set; }
        public int TestID { get; set; }
        public string TestName { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime ScheduledDateTime { get; set; }
    }
}
