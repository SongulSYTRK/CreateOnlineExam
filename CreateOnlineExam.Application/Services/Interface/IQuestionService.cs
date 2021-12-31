using CreateOnlineExam.Application.Models.DataTransferObjects;
using CreateOnlineExam.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreateOnlineExam.Application.Services.Interface
{
    public interface IQuestionService
    {
        Task Create(CreateQuestionDTO model);
        Task Update(UpdateQuestionDTO model);
        Task Delete(int id);

        Task<UpdateQuestionDTO> GetById(int id);
        Task<List<GetQuestionVM>> GetQuestions();

        //Task<GetQuestionVM> GetByExamId(int id);
    }
}
