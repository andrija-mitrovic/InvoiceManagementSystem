using AutoMapper;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Handlers
{
    public class CreateCompanyInfoCommandHanlder : IRequestHandler<CreateCompanyInfoCommand, Result<Unit>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCompanyInfoCommandHanlder> _logger;

        public CreateCompanyInfoCommandHanlder(IApplicationDbContext context,
            IMapper mapper,
            ILogger<CreateCompanyInfoCommandHanlder> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(CreateCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateCompanyInfoCommandHanlder.Handle - Adding company information.");

            var company = _mapper.Map<Domain.Entities.CompanyInfo>(request);

            _context.CompanyInfo.Add(company);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("CreateCompanyInfoCommandHanlder.Handle - Failed to add company information.");
                return Result<Unit>.Failure("Failed to add company information");
            }

            _logger.LogInformation("CreateCompanyInfoCommandHanlder.Handle - Successfully added company information.");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
