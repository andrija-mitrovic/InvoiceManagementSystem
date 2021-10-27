using InvoiceManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedDataAsync(ApplicationDbContext context,
            UserManager<AppUser> userManager,
            CancellationToken cancellationToken,
            ILogger logger)
        {
            if (!userManager.Users.Any())
            {
                logger.LogInformation("ApplicationDbContextSeed.SeedDataAsync - Seeding data started.");

                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        UserName="admin",
                        Email="admin@gmail.com"
                    },
                    new AppUser
                    {
                        UserName="andrija",
                        Email="andrija@gmail.com"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Password123!");
                }

                await context.SaveChangesAsync(cancellationToken);

                logger.LogInformation("ApplicationDbContextSeed.SeedDataAsync - Seeding data finished.");
            }
        }
    }
}
