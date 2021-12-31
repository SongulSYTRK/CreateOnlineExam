using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Application.Models.ViewModels
{
   public class GetExamPageVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExamDate { get; set; }
        public int ExamTime { get; set; }
    }
}
