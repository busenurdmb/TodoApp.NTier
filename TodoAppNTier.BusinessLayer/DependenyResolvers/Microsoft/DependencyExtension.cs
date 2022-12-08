using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.BusinessLayer.Interfaces;
using TodoAppNTier.BusinessLayer.Mapping.AuutoMapper;
using TodoAppNTier.BusinessLayer.Services;
using TodoAppNTier.BusinessLayer.ValidationRules;
using TodoAppNTier.DataAccesLayer.Context;
using TodoAppNTier.DataAccesLayer.UnitofWork;
using TodoAppNTier.DtosLayer.WorkDtos;

namespace TodoAppNTier.BusinessLayer.DependenyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {

            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=DESKTOP-493DFJA\\SQLEXPRESS;database=TodoDB;integrated security=true");
                opt.LogTo(Console.WriteLine, LogLevel.Information);


            });
            var configuration = new MapperConfiguration(opt =>
             {
                 opt.AddProfile(new WorkProfile());
             });
            var mapper = configuration.CreateMapper();
           //bu mapper'ı Depency Injection la ele alabileyim 
           // aynı şekilde siz birşeyi doğrudan addsingleton,addscoped,addtranseit ile
           // //geçerseniz ilgili şeyi dependency ınjection  aracılığıyla ele alabilirsiniz
            services.AddSingleton(mapper);
            //artık ben mapper'ı gördüğüm zaman IMapperla hareket et diyebilicem
           
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();
           
            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();
        }
    }
}
