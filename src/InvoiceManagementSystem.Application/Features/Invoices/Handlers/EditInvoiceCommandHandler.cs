using AutoMapper;
using InvoiceManagementSystem.Application.Exceptions;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
using InvoiceManagementSystem.Application.Interfaces;
using InvoiceManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Invoices.Handlers
{
    public class EditInvoiceCommandHandler : IRequestHandler<EditInvoiceCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EditInvoiceCommandHandler> _logger;

        public EditInvoiceCommandHandler(IApplicationDbContext context, 
            IMapper mapper, 
            ILogger<EditInvoiceCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(EditInvoiceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"EditInvoiceCommandHandler.Handle - Editing client with Id={request.Id}.");

            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (invoice == null)
            {
                _logger.LogError($"EditInvoiceCommandHandler.Handle - Invoice with Id={request.Id} couldn't be found.");
                throw new NotFoundException(nameof(Invoice), request.Id);
            }

            _mapper.Map(request, invoice);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError($"EditInvoiceCommandHandler.Handle - Failed to update invoice with Id={request.Id}");
                throw new Exception("Failed to update invoice");
            }

            _logger.LogInformation($"EditInvoiceCommandHandler.Handle - Successfully updated invoice with Id={request.Id}");
            return Unit.Value;
        }
    }
}
