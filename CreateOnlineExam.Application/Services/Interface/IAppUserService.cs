
using CreateOnlineExam.Application.Models.DataTransferObjects;
using CreateOnlineExam.Application.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreateOnlineExam.Application.Services.Interface
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO model);
        Task<SignInResult> Login(LoginDTO model);
        Task LogOut();
        Task UpdateUser(UpdateProfileDTO model);
        Task<UpdateProfileDTO> GetById(string id);
        Task<GetAppUserVM> GetByUser(string id);
        Task<int> UserIdFromName(string userName);
        Task GetById(object p);
    }
}
