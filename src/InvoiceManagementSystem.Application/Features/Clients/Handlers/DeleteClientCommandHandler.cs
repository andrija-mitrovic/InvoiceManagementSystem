using InvoiceManagementSystem.Application.Features.Clients.Command;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Clients.Handlers
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Result<Unit>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<DeleteClientCommandHandler> _logger;

        public DeleteClientCommandHandler(IApplicationDbContext context,
            ILogger<DeleteClientCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeleteClientCommandHandler.Handle - Deleting client with Id={request.Id}");

            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (client == null)
            {
                _logger.LogError($"DeleteClientCommandHandler.Handle - Client with Id={request.Id} couldn't be found.");
                return Result<Unit>.Failure($"No client");
            }

            _context.Clients.Remove(client);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError($"DeleteClientCommandHandler.Handle - Failed to delete client with Id={request.Id}");
                return Result<Unit>.Failure("Failed to delete client");
            }

            _logger.LogInformation($"DeleteClientCommandHandler.Handle - Successfully deleted client with Id={request.Id}");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
