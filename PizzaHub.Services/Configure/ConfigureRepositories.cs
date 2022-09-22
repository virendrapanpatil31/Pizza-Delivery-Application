using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaHub.Entities;
using PizzaHub.Repositories;
using PizzaHub.Repositories.Implementation;
using PizzaHub.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Services.Configure
{
    public class ConfigureRepositories
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((options) =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"))
            );
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.AddScoped<DbContext, AppDbContext>();

            services.AddTransient<IRepository<Item>, Repository<Item>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<ItemType>, Repository<ItemType>>();
        }
    }
}
