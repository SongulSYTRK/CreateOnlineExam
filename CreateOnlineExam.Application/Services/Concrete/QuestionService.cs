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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Create(CreateQuestionDTO model)
        {
            var examPage = _mapper.Map<Question>(model);
            await _unitOfWork.QuestionRepository.Add(examPage);
             await  _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            var examPage = await _unitOfWork.QuestionRepository.GetById( id);
            examPage.Status = Status.Passive;
            examPage.DeleteDate = DateTime.Now;
            await _unitOfWork.Commit();
        }

        public async Task<UpdateQuestionDTO> GetById(int id)
        {
            var examPage = await _unitOfWork.QuestionRepository.GetFilteredFirstOrDefault(
              selector: x => new GetQuestionVM
              {
                  Id = x.Id,
                 
                  Description = x.Description,
                  A = x.A,
                  B = x.B,
                  C = x.C,
                  D = x.D,
                  CorrectAnswer = x.CorrectAnswer,
                  ExamPageId=x.ExamPageId,
                  Title=x.ExamPage.Title,
                 DescriptionText=x.ExamPage.Description,
              },
              expression: x => x.Id == id && x.Status != Status.Passive) ;

            var updatedExamPage = _mapper.Map<UpdateQuestionDTO>(examPage);

            return updatedExamPage;
        }

        public async Task<List<GetQuestionVM>> GetQuestions()
        {
            var QuestionList = await _unitOfWork.QuestionRepository.GetFilteredList(
                selector: x => new GetQuestionVM
                {
                    Id = x.Id,
                    
                    Description = x.Description,
                    A = x.A,
                    B = x.B,
                    C = x.C,
                    D = x.D,
                    Answer=x.Answer,
                    CorrectAnswer = x.CorrectAnswer,
                    Title = x.ExamPage.Title,
                    ExamPageId = x.ExamPageId,
                    DescriptionText = x.ExamPage.Description,
                },
                expression: x => x.Status != Status.Passive);

            return QuestionList;
        }

        public async Task Update(UpdateQuestionDTO model)
        {
            var examPage = _mapper.Map<Question>(model);

            _unitOfWork.QuestionRepository.Update(examPage);

            await _unitOfWork.Commit();
        }



        //public async Task<GetQuestionVM> GetByExamId(int id)
        //{
        //    var Exam = await _unitOfWork.QuestionRepository.GetFilteredFirstOrDefault(
        //     selector: x => new GetQuestionVM
        //     {
        //         Id = x.Id,

        //         Description = x.Description,
        //         A = x.A,
        //         B = x.B,
        //         C = x.C,
        //         D = x.D,
        //         CorrectAnswer = x.CorrectAnswer,
        //         ExamPageId = x.ExamPageId,
        //         Title = x.ExamPage.Title,
        //         DescriptionText = x.ExamPage.Description,
        //     },
        //     expression: x => x.Id == id && x.Status != Status.Passive);
        //    if (Exam.Answer==Exam.CorrectAnswer)
        //    {
               
        //    }
        //    else
        //    {

        //    }

        //    await _unitOfWork.Commit();
        //}

    }
}
