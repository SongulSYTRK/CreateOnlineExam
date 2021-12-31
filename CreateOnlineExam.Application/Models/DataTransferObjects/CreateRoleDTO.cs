
using CreateOnlineExam.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Application.Models.DataTransferObjects
{
   public class CreateRoleDTO
    {
        public string RoleName { get; set; }

        public List<AppUser> Users { get; set; }
    }
}
