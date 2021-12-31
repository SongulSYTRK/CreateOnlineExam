
using AutoMapper;
using CreateOnlineExam.Application.Models.DataTransferObjects;
using CreateOnlineExam.Application.Models.ViewModels;
using CreateOnlineExam.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Application.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<RegisterDTO, AppUser>().ReverseMap();
            CreateMap<AppUser, UpdateProfileDTO>().ReverseMap();
            CreateMap<UpdateProfileDTO, GetAppUserVM>().ReverseMap();

            CreateMap<IdentityRole, CreateRoleDTO>().ReverseMap();
            CreateMap<IdentityRole, UpdateRoleDTO>().ReverseMap();
            CreateMap<UpdateRoleDTO, IdentityRole>().ReverseMap();
            CreateMap<AssignedRoleToUserDTO, IdentityRole>().ReverseMap();

           
            CreateMap<Question, CreateQuestionDTO>().ReverseMap();
            CreateMap<Question, UpdateQuestionDTO>().ReverseMap();
            CreateMap<UpdateQuestionDTO, GetQuestionVM>().ReverseMap();
            CreateMap<GetQuestionVM, UpdateQuestionDTO>().ReverseMap();

            CreateMap<ExamPage, CreateExamPageDTO>().ReverseMap();
            CreateMap<ExamPage, UpdateExamPageDTO>().ReverseMap();
            CreateMap<UpdateExamPageDTO, GetExamPageVM>().ReverseMap();
            CreateMap<GetExamPageVM, UpdateExamPageDTO>().ReverseMap();

        }
    }
}
