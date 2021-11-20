using AutoMapper;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
using InvoiceManagementSystem.Application.Interfaces;
using InvoiceManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateInvoiceCommandHandler> _logger;

        public CreateInvoiceCommandHandler(IApplicationDbContext context,
            IMapper mapper,
            ILogger<CreateInvoiceCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateInvoiceCommandHandler.Handle - Adding invoice.");

            var invoice = _mapper.Map<Invoice>(request);

            _context.Invoices.Add(invoice);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("CreateInvoiceCommandHandler.Handle - Failed to add invoice");
                throw new Exception("Failed to add invoice");
            }

            _logger.LogInformation("CreateInvoiceCommandHandler.Handle - Successfully added invoice.");
            return Unit.Value;
        }
    }
}
