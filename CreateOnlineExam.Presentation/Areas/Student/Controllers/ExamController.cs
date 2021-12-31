using CreateOnlineExam.Application.Services.Interface;
using CreateOnlineExam.Domain.UnitofWork;
using CreateOnlineExam.Presentation.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateOnlineExam.Presentation.Areas.Student.Controllers
{
    [Area("Student")]
    public class ExamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionService _questionService;
        public ExamController(IUnitOfWork unitOfWork, IQuestionService questionService)
        {
            _unitOfWork = unitOfWork;
            _questionService = questionService;
        }
        public  IActionResult GetExam()
        {
            return RedirectToAction(nameof(QuestionController.List), "Question");
        }
        public IActionResult StartExam(int id)
        {
            var question = _questionService.GetById(id);
            if (question != null)
            {
               
            }
            return View(question);
            
          }
    }
}
