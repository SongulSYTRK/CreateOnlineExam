
using CreateOnlineExam.Domain.Entities.Interface;
using CreateOnlineExam.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;


namespace CreateOnlineExam.Domain.Entities.Concrete
{
    public class AppUser : IdentityUser, IBaseEntity
    {

        public string FullName { get; set; }
        public string Imagepath { get; set; } = "/images/users/default.jpg";
        //public string  Password { get; set; }
        //public string ConfirmPassword { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }
        int IBaseEntity.Id { get; set; }
    }
}

