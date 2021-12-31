using CreateOnlineExam.Application.Models.DataTransferObjects;
using CreateOnlineExam.Application.Services.Interface;
using CreateOnlineExam.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateOnlineExam.Presentation.Areas.Admin.Controllers
{
   // [Authorize(Roles = "Admin, Student")]
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _QuestionService;
        private readonly IExamPageService _textPageService;
        public QuestionController(IQuestionService QuestionService, IExamPageService textPageService)
        {
            _QuestionService = QuestionService;
            _textPageService = textPageService;
        }

        #region Create ExamPage
        public async Task<IActionResult> Create() => View(new CreateQuestionDTO() { ExamPages = await _textPageService.GetTextPages() });
       
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionDTO model)
        {
            if (ModelState.IsValid)
            {
                 TempData["Success"] = "The Question has been added..!";
                await _QuestionService.Create(model);
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "The question hasn't been added..!";
                model.ExamPages = await _textPageService.GetTextPages();
                return View(model);
            }
        }
        #endregion
        public async Task<IActionResult> List() => View(await _QuestionService.GetQuestions());

        #region Update
        public async Task<IActionResult> Update(int id) => View(await _QuestionService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Update(UpdateQuestionDTO model)
        {
            if (ModelState.IsValid)
            {
                 TempData["Success"] = "The qustion has been updated..!";
                await _QuestionService.Update(model);
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "The question hasn't been updated..!";
                return View(model);
            }
        }
        #endregion
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            TempData["Warning"] = "The question has been deleted..!";
            await _QuestionService.Delete(id);
            // return RedirectToAction("List");
            return Json(" ");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var question = await _QuestionService.GetById(id);
            return View(question);

        }
    }
}
