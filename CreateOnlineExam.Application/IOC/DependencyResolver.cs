
using Autofac;
using AutoMapper;
using CreateOnlineExam.Application.AutoMapper;
using CreateOnlineExam.Application.Models.DataTransferObjects;
using CreateOnlineExam.Application.Services.Concrete;
using CreateOnlineExam.Application.Services.Interface;
using CreateOnlineExam.Application.Validation.FluentValidation;
using CreateOnlineExam.Domain.UnitofWork;
using CreateOnlineExam.Infrastructure.UnitOfWork;
using FluentValidation;


using System;
using System.Collections.Generic;

using System.Text;

namespace CreateOnlineExam.Application.IOC
{
    public class DependencyResolver:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();


            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<ExamPageService>().As<IExamPageService>().InstancePerLifetimeScope();

            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();


            builder.RegisterType<LoginDTOValidation>().As<IValidator<LoginDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterDTOValidation>().As<IValidator<RegisterDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateProfileDTOValidation>().As<IValidator<UpdateProfileDTO>>().InstancePerLifetimeScope();
            //builder.RegisterType<CreateExamValidaiton>().As<CreateExamDTO>().InstancePerLifetimeScope();
            //builder.RegisterType<UpdateExamValidation>().As<UpdateExamDTO>().InstancePerLifetimeScope();


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<Mapping>();
            }
           )).AsSelf().SingleInstance();


            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
