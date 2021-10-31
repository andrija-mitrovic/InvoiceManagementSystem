using AutoMapper;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Handlers
{
    public class EditCompanyInfoCommandHandler : IRequestHandler<EditCompanyInfoCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EditCompanyInfoCommandHandler> _logger;

        public EditCompanyInfoCommandHandler(ApplicationDbContext context,
            IMapper mapper,
            ILogger<EditCompanyInfoCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(EditCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"EditCompanyInfoCommandHandler.Handle - Editing company information with Id={request.Id}");

            var companyInfo = await _context.CompanyInfo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (companyInfo == null)
            {
                _logger.LogError("EditCompanyInfoCommand.Handle - Company information couldn't be found.");
                return Unit.Value;
            }

            _mapper.Map(request.CompanyInfo, companyInfo);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("EditCompanyInfoCommand.Handle - Failed to update company information.");
                return Unit.Value;
            }

            _logger.LogInformation("EditCompanyInfoCommand.Handle - Successfully update company information.");
            return Unit.Value;
        }
    }
}
