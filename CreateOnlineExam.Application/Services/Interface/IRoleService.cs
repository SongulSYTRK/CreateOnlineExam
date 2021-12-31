using CreateOnlineExam.Application.Models.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateOnlineExam.Application.Services.Interface
{
    public interface  IRoleService
    {
        Task Create(CreateRoleDTO model);
        Task Delete(string id);
        Task Update(UpdateRoleDTO model);
        Task<UpdateRoleDTO> GetById(string id);


      
        IQueryable<IdentityRole> GetRolesList();
        Task<bool> isPageExist(string roleName);
    }
}
