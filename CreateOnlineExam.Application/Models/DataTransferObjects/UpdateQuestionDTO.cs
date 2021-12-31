using CreateOnlineExam.Application.Models.ViewModels;
using CreateOnlineExam.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Application.Models.DataTransferObjects
{
    public class UpdateQuestionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionText { get; set; }
        public string Description { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }

        public string Answer { get; set; }

        public string CorrectAnswer { get; set; }
        public int ExamPageId { get; set; }

        public List<GetExamPageVM> ExamPages { get; set; }

     
        public DateTime Update => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
