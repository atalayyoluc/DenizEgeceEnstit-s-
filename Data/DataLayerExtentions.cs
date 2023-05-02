using Data.Context;
using Data.Repository.Abstractions;
using Data.Repository.Concretes;
using Data.UnitOfWork.Abstractions;
using Data.UnitOfWork.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DataLayerExtentions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services,IConfiguration config)
        {
          
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
                services.AddScoped<IUnitOfWork, UnitOfWork.Concretes.UnitOfWork>();
                return services;


          
        }
    }
}
