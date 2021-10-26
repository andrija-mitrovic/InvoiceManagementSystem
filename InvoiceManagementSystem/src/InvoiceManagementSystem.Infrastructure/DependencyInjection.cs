using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Infrastructure.Data;
using InvoiceManagementSystem.Infrastructure.Interfaces;
using InvoiceManagementSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentityCore<AppUser>(opt =>
            //{
            //    opt.Password.RequireNonAlphanumeric = false;
            //})
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddSignInManager<SignInManager<AppUser>>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
