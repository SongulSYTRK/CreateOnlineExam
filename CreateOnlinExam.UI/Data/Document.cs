using CreateOnlineExam.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreateOnlinExam.UI.Data
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime ExamDate { get; set; }
        public int ExamTime { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
