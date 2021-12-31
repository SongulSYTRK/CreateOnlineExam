
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CreateOnlineExam.Application.Models.DataTransferObjects
{
    public class UpdateProfileDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ImagePath { get => "/images/users/default.jpg"; }



        [NotMapped]
     
        public IFormFile Image { get; set; }
    }
}
