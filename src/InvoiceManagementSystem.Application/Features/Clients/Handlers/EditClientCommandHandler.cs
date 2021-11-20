using AutoMapper;
using InvoiceManagementSystem.Application.Exceptions;
using InvoiceManagementSystem.Application.Features.Clients.Command;
using InvoiceManagementSystem.Application.Interfaces;
using InvoiceManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Clients.Handlers
{
    public class EditClientCommandHandler : IRequestHandler<EditClientCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EditClientCommandHandler> _logger;

        public EditClientCommandHandler(IApplicationDbContext context,
            IMapper mapper,
            ILogger<EditClientCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(EditClientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"EditClientCommandHandler.Handle - Editing client with Id={request.Id}.");

            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (client == null)
            {
                _logger.LogError($"EditClientCommandHandler.Handle - Client with Id={request.Id} couldn't be found.");
                throw new NotFoundException(nameof(Client), request.Id);
            }

            _mapper.Map(request, client);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError($"EditClientCommandHandler.Handle - Failed to update client with Id={request.Id}.");
                throw new Exception("Failed to update client");
            }

            _logger.LogInformation($"EditClientCommandHandler.Handle - Successfully updated client with Id={request.Id}.");
            return Unit.Value;
        }
    }
}
