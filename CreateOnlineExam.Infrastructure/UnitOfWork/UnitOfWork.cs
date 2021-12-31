
using CreateOnlineExam.Domain.Repositories.EntityTypeRepo;
using CreateOnlineExam.Domain.UnitofWork;
using CreateOnlineExam.Infrastructure.Context;
using CreateOnlineExam.Infrastructure.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreateOnlineExam.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }


        private IAppUserRepository _appUserRepository;
        public IAppUserRepository AppUserRepository
        {
            get
            {
                if (_appUserRepository == null)
                {
                    _appUserRepository = new AppUserRepository(_db);
                }
                return _appUserRepository;
            }
        }

        private IAppUserRoleRepository _appUserRoleRepository;
        public IAppUserRoleRepository AppUserRoleRepository
        {
            get
            {
                if (_appUserRoleRepository==null)
                {
                    _appUserRoleRepository = new AppUserRoleRepository(_db);
                }
                return _appUserRoleRepository;
            }
        }
        
        private IQuestionRepository _questionRepository;
        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository == null)
                {
                    _questionRepository = new QuestionRepository(_db);
                }
                return _questionRepository;
            }
        }
        private IExamPageRepository _examPageRepository;
        public IExamPageRepository ExamPageRepository
        {
            get
            {
                if (_examPageRepository == null)
                {
                    _examPageRepository = new ExamPageRepository(_db);
                }
                return _examPageRepository;
            }
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }


        private bool isDispose = false;
        public async ValueTask DisposeAsync()
        {
            if (!isDispose)
            {
                isDispose = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);
            }
        }

        private async Task DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _db.DisposeAsync();
            }
        }
    }
}
