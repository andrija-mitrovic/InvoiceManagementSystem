﻿using AutoMapper;
using InvoiceManagementSystem.Application.Features.Clients.Command;
using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Clients.Handlers
{
    public class EditClientCommandHandler : IRequestHandler<EditClientCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EditClientCommandHandler> _logger;

        public EditClientCommandHandler(ApplicationDbContext context,
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

            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (client == null)
            {
                _logger.LogError($"DeleteClientCommandHandler.Handle - Client with Id={request.Id} couldn't be found.");
                return Unit.Value;
            }

            _mapper.Map(request.Client, client);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError($"DeleteClientCommandHandler.Handle - Failed to update client with Id={request.Id}");
                return Unit.Value;
            }

            _logger.LogInformation($"DeleteClientCommandHandler.Handle - Successfully updated client with Id={request.Id}");
            return Unit.Value;
        }
    }
}