using InvoiceManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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
            CancellationToken cancellationToken)
        {
            if (!userManager.Users.Any())
            {
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
                        Email="andrija.mitrovic9@gmail.com"
                    }
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Password");
                }

                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
