﻿using Microsoft.Extensions.DependencyInjection;
using PizzaHub.Helpers;
using PizzaHub.Interfaces;
using PizzaHub.Services.Implementations;
using PizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.Configuration
{
    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<IFileHelper, FileHelper>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
