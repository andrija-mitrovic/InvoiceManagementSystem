using InvoiceManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedDataAsync(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            CancellationToken cancellationToken,
            ILogger logger)
        {
            if (!userManager.Users.Any())
            {
                logger.LogInformation("ApplicationDbContextSeed.SeedDataAsync - Seeding data started.");

                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        UserName="admin",
                        Email="admin@gmail.com"
                    },
                    new ApplicationUser
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
