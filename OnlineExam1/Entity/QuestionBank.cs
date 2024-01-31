using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam1.Entity
{
    public class QuestionBank
    {
        [Key]
        public int QuestionID { get; set; }

        [Required]
        public int SubjectID { get; set; }

        [ForeignKey(nameof(SubjectID))]
        public Subject Subject { get; set; }

        [Required]
        [MaxLength]
        public string QuestionText { get; set; }
        [Required]
        [MaxLength]
        public string Option1 { get; set; }
        [Required]
        [MaxLength]
        public string Option2 { get; set; }
        [Required]
        [MaxLength]
        public string Option3 { get; set; }
        [Required]
        [MaxLength]
        public string Option4 { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Answer { get; set; }
    }
}
