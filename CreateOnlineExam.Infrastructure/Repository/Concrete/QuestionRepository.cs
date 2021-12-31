﻿using CreateOnlineExam.Domain.Entities.Concrete;
using CreateOnlineExam.Domain.Repositories.EntityTypeRepo;
using CreateOnlineExam.Infrastructure.Context;
using CreateOnlineExam.Infrastructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Infrastructure.Repository.Concrete
{
    public class QuestionRepository:BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext appDbContext): base(appDbContext)
        {

        }
    }
}
