using AutoMapper;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Result<Unit>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateInvoiceCommandHandler> _logger;

        public CreateInvoiceCommandHandler(ApplicationDbContext context,
            IMapper mapper,
            ILogger<CreateInvoiceCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateInvoiceCommandHandler.Handle - Adding invoice.");

            var invoice = _mapper.Map<Invoice>(request.Invoice);

            _context.Invoices.Add(invoice);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("CreateInvoiceCommandHandler.Handle - Failed to add invoice");
                return Result<Unit>.Failure("Failed to add invoice");
            }

            _logger.LogInformation("CreateInvoiceCommandHandler.Handle - Successfully added invoice.");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
