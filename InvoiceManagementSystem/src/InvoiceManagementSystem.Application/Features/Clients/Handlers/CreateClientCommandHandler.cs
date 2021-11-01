using AutoMapper;
using InvoiceManagementSystem.Application.Features.Clients.Command;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Clients.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result<Unit>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateClientCommandHandler> _logger;

        public CreateClientCommandHandler(ApplicationDbContext context,
            IMapper mapper,
            ILogger<CreateClientCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateClientCommandHandler.Handle - Adding client");

            var client = _mapper.Map<Client>(request.Client);

            _context.Clients.Add(client);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("CreateClientCommandHandler.Handle - Failed to create client.");
                return Result<Unit>.Failure("Failed to create client.");
            }

            _logger.LogInformation("CreateClientCommandHandler.Handle - Client added successfully.");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
