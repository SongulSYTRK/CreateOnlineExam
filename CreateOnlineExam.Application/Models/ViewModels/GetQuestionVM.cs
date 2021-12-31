using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Application.Models.ViewModels
{
    public class GetQuestionVM
    {
        public int Id { get; set; }
        public string Title { get; set; }   //textttitle
        public string DescriptionText { get; set; }   //textdescription 
        public string Description { get; set; }  //for question
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }

        public string Answer { get; set; }

        
        public bool OnaylandiMi { get; set; }
        public string CorrectAnswer { get; set; }

        public int ExamPageId { get; set; }

        public List<GetExamPageVM> ExamPages { get; set; }

    }
}
