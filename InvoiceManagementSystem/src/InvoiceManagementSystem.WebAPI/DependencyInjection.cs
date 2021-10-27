﻿using FluentValidation.AspNetCore;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace InvoiceManagementSystem.WebAPI
{
    public static class DependencyInjection
    {
        public static void AddWebAPI(this IServiceCollection services)
        {
            ConfigureController(services);
            ConfigureSwagger(services);
            ConfigureCors(services);           
        }

        private static void ConfigureController(IServiceCollection services)
        {
            services.AddControllers(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            }).AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<CreateInvoiceCommand>();
            });
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InvoiceManagementSystem.WebAPI", Version = "v1" });
            });
        }

        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:3000");
                });
            });
        }
    }
}
