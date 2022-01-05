using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateOnlinExam.UI.Data
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FK_Question_Document_DocumentId")]
        public int DocumentId { get; set; }
        public string QuestionText { get; set; }
     
        public virtual List<Answer> Answers { get; set; }
    }
}