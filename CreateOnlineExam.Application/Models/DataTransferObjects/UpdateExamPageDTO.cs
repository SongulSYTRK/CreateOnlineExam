using CreateOnlineExam.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Application.Models.DataTransferObjects
{
    public class UpdateExamPageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExamDate { get; set; }
        public int ExamTime { get; set; }
        public DateTime Update => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
