using AutoMapper;
using InvoiceManagementSystem.Application.Features.Clients.Command;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Application.Interfaces;
using InvoiceManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Clients.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateClientCommandHandler> _logger;

        public CreateClientCommandHandler(IApplicationDbContext context,
            IMapper mapper,
            ILogger<CreateClientCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateClientCommandHandler.Handle - Adding client");

            var client = _mapper.Map<Client>(request);

            _context.Clients.Add(client);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("CreateClientCommandHandler.Handle - Failed to create client.");
                throw new Exception("Failed to create client.");
            }

            _logger.LogInformation("CreateClientCommandHandler.Handle - Client added successfully.");
            return Unit.Value;
        }
    }
}
