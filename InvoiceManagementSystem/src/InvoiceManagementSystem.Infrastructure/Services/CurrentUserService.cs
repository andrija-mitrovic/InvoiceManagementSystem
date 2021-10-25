using InvoiceManagementSystem.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InvoiceManagementSystem.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService()
        {
        }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; set; }
    }
}
