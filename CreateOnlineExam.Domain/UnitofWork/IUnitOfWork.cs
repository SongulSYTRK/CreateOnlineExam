
using CreateOnlineExam.Domain.Repositories.EntityTypeRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreateOnlineExam.Domain.UnitofWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAppUserRepository AppUserRepository { get; }
        IAppUserRoleRepository AppUserRoleRepository { get; }
       
        

        IQuestionRepository QuestionRepository { get; }

        IExamPageRepository ExamPageRepository { get; }
        Task Commit();

    }
}
