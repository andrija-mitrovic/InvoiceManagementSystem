using AutoMapper;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Exceptions;
using InvoiceManagementSystem.Application.Features.Invoices.Queries;
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
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetInvoiceByIdQueryHandler> _logger;

        public GetInvoiceByIdQueryHandler(IApplicationDbContext context,
            IMapper mapper,
            ILogger<GetInvoiceByIdQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InvoiceDto> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetInvoiceByIdQueryHandler.Handle - Retrieved invoice with Id={request.Id}");

            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (invoice == null)
            {
                _logger.LogError($"GetInvoiceByIdQueryHandler.Handle - Invoice with Id={request.Id} couldn't be found.");
                throw new NotFoundException(nameof(Invoice), request.Id);
            }

            _logger.LogInformation($"GetInvoiceByIdQueryHandler.Handle - Successfully returned invoice with Id={request.Id}");
            return _mapper.Map<InvoiceDto>(invoice);
        }
    }
}
