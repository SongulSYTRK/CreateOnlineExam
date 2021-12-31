using CreateOnlineExam.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Application.Models.DataTransferObjects
{
   public  class AssignedRoleToUserDTO
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> HasRole { get; set; }
        public IEnumerable<AppUser> HasNoRole { get; set; }
        public string RoleName { get; set; }

        
        public string[] AddIds { get; set; }
        public string[] DeleteIds { get; set; }
    }
}
