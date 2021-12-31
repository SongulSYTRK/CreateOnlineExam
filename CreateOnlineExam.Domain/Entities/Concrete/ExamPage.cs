using CreateOnlineExam.Domain.Entities.Interface;
using CreateOnlineExam.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Domain.Entities.Concrete
{
   public  class ExamPage:IBaseEntity
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public string  Description { get; set; }

        public DateTime ExamDate { get; set; }
        public int ExamTime { get; set; }

        public List<Question> Questions { get; set; }

      


        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }
    }
}
