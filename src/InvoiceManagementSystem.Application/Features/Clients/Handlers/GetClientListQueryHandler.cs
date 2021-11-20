using AutoMapper;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Features.Clients.Queries;
using InvoiceManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Clients.Handlers
{
    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, List<ClientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetClientListQueryHandler> _logger;

        public GetClientListQueryHandler(IApplicationDbContext context,
            IMapper mapper,
            ILogger<GetClientListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ClientDto>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetClientListQueryHandler.Handle - Retrieving clients.");

            var clients = await _context.Clients.ToListAsync(cancellationToken);

            _logger.LogInformation("GetClientListQueryHandler.Handle - Successfully returned clients.");
            return _mapper.Map<List<ClientDto>>(clients);
        }
    }
}
