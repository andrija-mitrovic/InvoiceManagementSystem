using AutoMapper;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Exceptions;
using InvoiceManagementSystem.Application.Features.Clients.Queries;
using InvoiceManagementSystem.Application.Interfaces;
using InvoiceManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Clients.Handlers
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetClientByIdQueryHandler> _logger;

        public GetClientByIdQueryHandler(IApplicationDbContext context,
            IMapper mapper,
            ILogger<GetClientByIdQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetClientByIdQueryHandler.Handle - Retrieved client with Id={request.Id}.");

            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if(client == null)
            {
                _logger.LogError($"GetClientByIdQueryHandler.Handle - Client with Id={request.Id} couldn't be found.");
                throw new NotFoundException(nameof(Client), request.Id);
            }

            _logger.LogInformation($"GetClientByIdQueryHandler.Handle - Successfully returned client with Id={request.Id}.");
            return _mapper.Map<ClientDto>(client);
        }
    }
}
