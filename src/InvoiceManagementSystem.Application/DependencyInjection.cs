using InvoiceManagementSystem.Application.Features.Invoices.Command;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Application.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<TokenService>();
            services.AddMediatR(typeof(CreateInvoiceCommand).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}
