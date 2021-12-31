using AutoMapper;
using CreateOnlineExam.Application.Services.Concrete;
using CreateOnlineExam.Application.Services.Interface;
using CreateOnlineExam.Domain.UnitofWork;
using CreateOnlineExam.Infrastructure.Context;
using CreateOnlineExam.Infrastructure.UnitOfWork;
using CreateOnlinExam.UI.Data;
using MatBlazor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CreateOnlinExam.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], x => x.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
            });

           

            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlite("Data Source = OnlineExam.db");
            });


            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMatBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<IMapper>();
            //services.AddScoped<IExamPageService, ExamPageService>();
            //services.AddScoped<DbContext, AppContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
