using CreateOnlineExam.Application.Extensions;
using CreateOnlineExam.Application.Models.DataTransferObjects;
using CreateOnlineExam.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateOnlineExam.Presentation.Controllers
{
    [Authorize, AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AccountController(IAppUserService appUserService)
        {
            this._appUserService = appUserService;
        }
        #region Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View();
        }
        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Register(model);

                if (result.Succeeded)  //if register successed, Homapage open authtomiticially
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError(string.Empty, item.Description);
                }
            }
            return View(model);
        }
        #endregion
        #region Login

        [AllowAnonymous]

        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Login(LoginDTO model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Login(model);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);   //kaldığımız page 'e geri dönüş yapacak
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt..!");

            }
            return View(model);

        }
        
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        #endregion
        #region LogOut
        public async Task<IActionResult> LogOut()
        {
            await _appUserService.LogOut();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion
        #region Edit
        public async Task<IActionResult> Edit(string userName)
        {
            if (userName == User.Identity.Name)
            {
                var user = await _appUserService.GetById(User.GetUserId()); 

                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProfileDTO model)
        {
            if (ModelState.IsValid)
            {
                await _appUserService.UpdateUser(model);
                TempData["Success"] = "Your has been profile updated..!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                TempData["Error"] = "Your profile hasn't been updated..!";
                return View(model);
            }
        }


        #endregion
        #region Detail 
        public async Task<IActionResult> ProfileDetail(string userName)
        {
            if (userName == User.Identity.Name)
            {
                var user = await _appUserService.GetByUser(User.GetUserId());
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        #endregion

    }
}
