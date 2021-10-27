using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            var logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                logger.LogInformation("Program.Main - migration started.");

                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                await context.Database.MigrateAsync();
                await ApplicationDbContextSeed.SeedDataAsync(context, userManager, CancellationToken.None, logger);

                logger.LogInformation("Program.Main - migration finished.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Program.Main - An error occured during migration.");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
