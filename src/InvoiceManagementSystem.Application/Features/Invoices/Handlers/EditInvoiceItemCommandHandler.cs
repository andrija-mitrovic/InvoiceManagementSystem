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
    public class EditInvoiceItemCommandHandler : IRequestHandler<EditInvoiceItemCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EditInvoiceItemCommandHandler> _logger;

        public EditInvoiceItemCommandHandler(IApplicationDbContext context, 
            IMapper mapper, 
            ILogger<EditInvoiceItemCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(EditInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"EditInvoiceItemCommandHandler.Handler - Editing invoice item in invoice with Id={request.InvoiceId} and item Id={request.InvoiceItemId}.");

            var invoice = await _context.Invoices
                .Include(x => x.InvoiceItems)
                .FirstOrDefaultAsync(x => x.Id == request.InvoiceId, cancellationToken);

            if (invoice == null)
            {
                _logger.LogError($"EditInvoiceItemCommandHandler.Handler - Invoice with Id={request.InvoiceId} couldn't be found.");
                throw new NotFoundException(nameof(Invoice), request.InvoiceId);
            }

            var invoiceItem = await _context.InvoiceItems
                .FirstOrDefaultAsync(x => x.Id == request.InvoiceItemId && x.Invoice.Id == invoice.Id, cancellationToken);

            if (invoiceItem == null)
            {
                _logger.LogError($"EditInvoiceItemCommandHandler.Handler - Invoice with item Id={request.InvoiceItemId} couldn't be found.");
                throw new NotFoundException(nameof(Invoice), request.InvoiceItemId);
            }

            _mapper.Map(request, invoiceItem);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("EditInvoiceItemCommandHandler.Handle - Failed to add invoice item.");
                throw new Exception("Failed to add invoice");
            }

            _logger.LogInformation("EditInvoiceItemCommandHandler.Handle - Successfully added invoice item.");
            return Unit.Value;
        }
    }
}
