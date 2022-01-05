using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateOnlinExam.UI.Data
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FK_Answer_Question_QuestionId")]
        public int QuestionId { get; set; }
        public string AnswerTextForA { get; set; }
        public string AnswerTextForB { get; set; }
        public string AnswerTextForC { get; set; }
        public string AnswerTextForD { get; set; }
    }
}