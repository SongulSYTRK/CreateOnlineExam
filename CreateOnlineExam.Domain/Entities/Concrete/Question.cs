using CreateOnlineExam.Domain.Entities.Interface;
using CreateOnlineExam.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Domain.Entities.Concrete
{
   public class Question:IBaseEntity
    {
        public int Id { get; set; }
        
        public string  Description { get; set; }
        public string  A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        
        public string Answer { get; set; }


        public int ExamPageId { get; set; }

        public ExamPage ExamPage { get; set; }


      

        public bool OnaylandiMi { get; set; }
        public string  CorrectAnswer { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }
    }
}
