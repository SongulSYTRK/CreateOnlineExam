using CreateOnlineExam.Application.Models.DataTransferObjects;
using CreateOnlineExam.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreateOnlineExam.Application.Services.Interface
{
   public interface IExamPageService
    {
        Task Create(CreateExamPageDTO model);
        Task Update(UpdateExamPageDTO model);
        Task Delete(int id);

        Task<UpdateExamPageDTO> GetById(int id);
        Task<List<GetExamPageVM>> GetTextPages();
    }
}
