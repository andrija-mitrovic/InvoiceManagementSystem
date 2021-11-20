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
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteInvoiceCommandHandler> _logger;

        public DeleteInvoiceCommandHandler(IApplicationDbContext context, 
            IMapper mapper, 
            ILogger<DeleteInvoiceCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeleteInvoiceCommandHandler.Handle - Deleting invoice with Id={request.Id}");

            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (invoice == null)
            {
                _logger.LogError($"DeleteInvoiceCommandHandler.Handle - Invoice with Id={request.Id} couldn't be found.");
                throw new NotFoundException(nameof(Invoice), request.Id);
            }

            _context.Invoices.Remove(invoice);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError($"DeleteInvoiceCommandHandler.Handle - Failed to delete invoice with Id={request.Id}");
                throw new Exception("Failed to delete client");
            }

            _logger.LogInformation($"DeleteInvoiceCommandHandler.Handle - Successfully deleted invoice with Id={request.Id}");
            return Unit.Value;
        }
    }
}
