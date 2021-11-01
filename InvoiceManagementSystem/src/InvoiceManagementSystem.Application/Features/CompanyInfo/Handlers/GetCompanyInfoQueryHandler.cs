using InvoiceManagementSystem.Application.Features.CompanyInfo.Queries;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Handlers
{
    public class GetCompanyInfoQueryHandler : IRequestHandler<GetCompanyInfoQuery, Result<Domain.Entities.CompanyInfo>>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GetCompanyInfoQueryHandler> _logger;

        public GetCompanyInfoQueryHandler(ApplicationDbContext context,
            ILogger<GetCompanyInfoQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<Domain.Entities.CompanyInfo>> Handle(GetCompanyInfoQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetCompanyInfoQueryHandler.Handle - Retreiving company information");

            var information = await _context.CompanyInfo.FirstOrDefaultAsync(cancellationToken);

            _logger.LogInformation("GetCompanyInfoQueryHandler.Handle - Company information successfully returned.");
            return Result<Domain.Entities.CompanyInfo>.Success(information);
        }
    }
}
