using CreateOnlineExam.Application.Models.DataTransferObjects;
using CreateOnlineExam.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateOnlineExam.Presentation.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ExamPageController : Controller
    {
        private readonly IExamPageService _examPageService;
        public ExamPageController(IExamPageService examPageService) => _examPageService = examPageService;

        #region Create ExamPage
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateExamPageDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "The TextPage has been added..!";
                await _examPageService.Create(model);
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "The TextPage hasn't been added..!";
                return View(model);
            }
        }
        #endregion
        public async Task<IActionResult> List() => View(await _examPageService.GetTextPages());

        #region Update
        public async Task<IActionResult> Update(int id) => View(await _examPageService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Update(UpdateExamPageDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "The TextPage has been updated..!";
                await _examPageService.Update(model);
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "The TextPage hasn't been updated..!";
                return View(model);
            }
        }
        #endregion
        public async Task<IActionResult> Delete(int id)
        {
            await _examPageService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
