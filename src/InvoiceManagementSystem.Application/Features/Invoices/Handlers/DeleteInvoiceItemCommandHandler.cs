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
    public class DeleteInvoiceItemCommandHandler : IRequestHandler<DeleteInvoiceItemCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteInvoiceItemCommandHandler> _logger;

        public DeleteInvoiceItemCommandHandler(IApplicationDbContext context,
            IMapper mapper,
            ILogger<DeleteInvoiceItemCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeleteInvoiceItemCommandHandler.Handler - Deleting invoice item with invoice Id={request.InvoiceId} and item Id={request.InvoiceItemId}.");

            var invoice = await _context.Invoices
                .FirstOrDefaultAsync(x => x.Id == request.InvoiceId, cancellationToken);

            if (invoice == null)
            {
                _logger.LogError($"DeleteInvoiceItemCommandHandler.Handler - Invoice with Id={request.InvoiceId} couldn't be found.");
                throw new NotFoundException(nameof(Invoice), request.InvoiceId);
            }

            var invoiceItem = await _context.InvoiceItems
                .FirstOrDefaultAsync(x => x.Id == request.InvoiceItemId && x.Invoice.Id == invoice.Id, cancellationToken);

            if (invoiceItem == null)
            {
                _logger.LogError($"DeleteInvoiceItemCommandHandler.Handler - Invoice item with Id={request.InvoiceItemId} couldn't be found.");
                throw new NotFoundException(nameof(InvoiceItem), request.InvoiceItemId);
            }

            invoice.InvoiceItems.Remove(invoiceItem);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("DeleteInvoiceItemCommandHandler.Handle - Failed to delete invoice item.");
                throw new Exception("Failed to delete invoice item");
            }

            _logger.LogInformation("DeleteInvoiceItemCommandHandler.Handle - Successfully deleted invoice item.");
            return Unit.Value;
        }
    }
}
