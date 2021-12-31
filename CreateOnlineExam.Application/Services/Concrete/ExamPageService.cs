using AutoMapper;
using CreateOnlineExam.Application.Models.DataTransferObjects;
using CreateOnlineExam.Application.Models.ViewModels;
using CreateOnlineExam.Application.Services.Interface;
using CreateOnlineExam.Domain.Entities.Concrete;
using CreateOnlineExam.Domain.Enums;
using CreateOnlineExam.Domain.UnitofWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreateOnlineExam.Application.Services.Concrete
{
    public class ExamPageService:IExamPageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExamPageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(CreateExamPageDTO model)
        {
            var textPage = _mapper.Map<ExamPage>(model);
            await _unitOfWork.ExamPageRepository.Add(textPage);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            var exam = await _unitOfWork.ExamPageRepository.GetById(id);
            exam.Status = Status.Passive;
            exam.DeleteDate = DateTime.Now;
            await _unitOfWork.Commit();
        }

        public async Task<UpdateExamPageDTO> GetById(int id)
        {
            var TextPage = await _unitOfWork.ExamPageRepository.GetFilteredFirstOrDefault(
              selector: x => new GetExamPageVM
              {
                  Id = x.Id,
                  Title = x.Title,
                  Description = x.Description,
                  ExamDate=x.ExamDate,
                  ExamTime=x.ExamTime,
                  
              },
              expression: x => x.Id == id && x.Status != Status.Passive);

            var updatedTextPage = _mapper.Map<UpdateExamPageDTO>(TextPage);

            return updatedTextPage;
        }

        public async Task<List<GetExamPageVM>> GetTextPages()
        {
            var TextPageList = await _unitOfWork.ExamPageRepository.GetFilteredList(
                selector: x => new GetExamPageVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ExamDate = x.ExamDate,
                    ExamTime = x.ExamTime,

                },
                expression: x => x.Status != Status.Passive);

            return TextPageList;
        }

        public async Task Update(UpdateExamPageDTO model)
        {
            var textPage = _mapper.Map<ExamPage>(model);

            _unitOfWork.ExamPageRepository.Update(textPage);

            await _unitOfWork.Commit();
        }
    }
}
