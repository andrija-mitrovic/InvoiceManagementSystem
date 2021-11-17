using AutoMapper;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Handlers
{
    public class EditCompanyInfoCommandHandler : IRequestHandler<EditCompanyInfoCommand, Result<Unit>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EditCompanyInfoCommandHandler> _logger;

        public EditCompanyInfoCommandHandler(IApplicationDbContext context,
            IMapper mapper,
            ILogger<EditCompanyInfoCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(EditCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"EditCompanyInfoCommandHandler.Handle - Editing company information with Id={request.Id}");

            var companyInfo = await _context.CompanyInfo.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (companyInfo == null)
            {
                _logger.LogError("EditCompanyInfoCommand.Handle - Company information couldn't be found.");
                return Result<Unit>.Failure("No company information");
            }

            _mapper.Map(request, companyInfo);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("EditCompanyInfoCommand.Handle - Failed to update company information.");
                return Result<Unit>.Failure("Failed to update company information");
            }

            _logger.LogInformation("EditCompanyInfoCommand.Handle - Successfully update company information.");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
