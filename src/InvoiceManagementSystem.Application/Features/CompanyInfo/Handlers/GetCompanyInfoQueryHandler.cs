using InvoiceManagementSystem.Application.Exceptions;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Queries;
using InvoiceManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Handlers
{
    public class GetCompanyInfoQueryHandler : IRequestHandler<GetCompanyInfoQuery, Domain.Entities.CompanyInfo>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetCompanyInfoQueryHandler> _logger;

        public GetCompanyInfoQueryHandler(IApplicationDbContext context,
            ILogger<GetCompanyInfoQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Domain.Entities.CompanyInfo> Handle(GetCompanyInfoQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetCompanyInfoQueryHandler.Handle - Retreiving company information.");

            var companyInfo = await _context.CompanyInfo.FirstOrDefaultAsync(cancellationToken);

            if (companyInfo == null)
            {
                _logger.LogError($"GetCompanyInfoQueryHandler.Handle - Company information couldn't be found.");
                throw new NotFoundException(nameof(Domain.Entities.CompanyInfo));
            }

            _logger.LogInformation($"GetCompanyInfoQueryHandler.Handle - Successfully returned company information.");
            return companyInfo;
        }
    }
}
