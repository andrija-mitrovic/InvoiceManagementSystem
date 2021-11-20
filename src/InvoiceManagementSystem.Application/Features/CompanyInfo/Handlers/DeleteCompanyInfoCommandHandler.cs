using InvoiceManagementSystem.Application.Exceptions;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Handlers
{
    public class DeleteCompanyInfoCommandHandler : IRequestHandler<DeleteCompanyInfoCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<DeleteCompanyInfoCommandHandler> _logger;

        public DeleteCompanyInfoCommandHandler(IApplicationDbContext context,
            ILogger<DeleteCompanyInfoCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DeleteCompanyInfoCommandHandler.Handle - Deleting company information.");

            var companyInfo = await _context.CompanyInfo.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (companyInfo == null)
            {
                _logger.LogError("DeleteCompanyInfoCommandHandler.Handle - Couldn't be found company information.");
                throw new NotFoundException(nameof(Domain.Entities.CompanyInfo), request.Id);
            }

            _context.CompanyInfo.Remove(companyInfo);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("DeleteCompanyInfoCommandHandler.Handle - Failed to delete company information.");
                throw new Exception("Failed to delete company information");
            }

            _logger.LogInformation("DeleteCompanyInfoCommandHandler.Handle - Successfully deleted company information.");
            return Unit.Value;
        }
    }
}
