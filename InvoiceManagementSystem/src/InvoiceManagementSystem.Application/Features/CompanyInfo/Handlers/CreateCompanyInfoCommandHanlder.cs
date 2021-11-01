﻿using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Handlers
{
    public class CreateCompanyInfoCommandHanlder : IRequestHandler<CreateCompanyInfoCommand, Result<Unit>>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CreateCompanyInfoCommandHanlder> _logger;

        public CreateCompanyInfoCommandHanlder(ApplicationDbContext context,
            ILogger<CreateCompanyInfoCommandHanlder> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(CreateCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateCompanyInfoCommandHanlder.Handle - Adding company information.");

            _context.CompanyInfo.Add(request.CompanyInfo);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                _logger.LogError("CreateCompanyInfoCommandHanlder.Handle - Failed to add company information.");
                return Result<Unit>.Failure("Failed to add company information");
            }

            _logger.LogInformation("CreateCompanyInfoCommandHanlder.Handle - Successfully added company information.");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
