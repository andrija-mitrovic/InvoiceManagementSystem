using AutoMapper;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Features.Invoices.Queries;
using InvoiceManagementSystem.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Invoices.Handlers
{
    public class GetUserInvoiceListQueryHandler : IRequestHandler<GetUserInvoiceListQuery, List<InvoiceDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserInvoiceListQueryHandler> _logger;

        public GetUserInvoiceListQueryHandler(ApplicationDbContext context,
            IMapper mapper,
            ILogger<GetUserInvoiceListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<InvoiceDto>> Handle(GetUserInvoiceListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetUserInvoiceListQueryHandler.Handle - Retrieving invoices.");

            var invoices = await _context.Invoices
                .Include(x => x.InvoiceItems)
                .Where(x => x.CreatedBy == request.User)
                .ToListAsync(cancellationToken);

            if (invoices == null)
            {
                _logger.LogError($"GetUserInvoiceListQueryHandler.Handle - No inovices created by {request.User}.");
                return null;
            }

            _logger.LogInformation("GetUserInvoiceListQueryHandler.Handle - Successfully returned invoices.");
            return _mapper.Map<List<InvoiceDto>>(invoices);
        }
    }
}
