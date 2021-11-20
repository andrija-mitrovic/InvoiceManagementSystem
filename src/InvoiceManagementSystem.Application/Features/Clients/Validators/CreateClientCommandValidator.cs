using FluentValidation;
using InvoiceManagementSystem.Application.Features.Clients.Command;
using InvoiceManagementSystem.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Clients.Validators
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateClientCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified name already exists.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(255).WithMessage("Address must not exceed 255 characters.");
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(50).WithMessage("Phone must not exceed 50 characters.");
            RuleFor(x => x.Email)
                .MaximumLength(40).WithMessage("Email must not exceed 40 characters.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.CompanyInfo.AllAsync(x => x.Name != name);
        }
    }
}
