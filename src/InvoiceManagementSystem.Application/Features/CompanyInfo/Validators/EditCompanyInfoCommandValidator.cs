using FluentValidation;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Validators
{
    public class EditCompanyInfoCommandValidator : AbstractValidator<EditCompanyInfoCommand>
    {
        private readonly IApplicationDbContext _context;

        public EditCompanyInfoCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters")
                .MustAsync(BeUniqueName).WithMessage("The specified name already exists.");
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20).WithMessage("Phone number must not exceed 255 characters.");
            RuleFor(x => x.Email)
                .MaximumLength(40).WithMessage("Email must not exceed 40 characters.");
            RuleFor(x => x.BankAccount)
                .NotEmpty().WithMessage("Bank account is required.")
                .MaximumLength(255).WithMessage("Bank account must not exceed 255 characters.")
                .MustAsync(BeUniqueBankAccount).WithMessage("The specified bank account already exists.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(50).WithMessage("Address must not exceed 50 characters.");
            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("Zip code is required.")
                .MaximumLength(20).WithMessage("Zip code must not exceed 20 characters.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("city must not exceed 50 characters.");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.CompanyInfo.AllAsync(x => x.Name != name);
        }

        public async Task<bool> BeUniqueBankAccount(string bankAccount, CancellationToken cancellationToken)
        {
            return await _context.CompanyInfo.AllAsync(x => x.BankAccount != bankAccount);
        }
    }
}
