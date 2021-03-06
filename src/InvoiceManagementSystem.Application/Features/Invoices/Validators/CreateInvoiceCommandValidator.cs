using FluentValidation;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
using InvoiceManagementSystem.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Invoices.Validators
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateInvoiceCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.InvoiceNumber)
                .NotEmpty().WithMessage("Invoice number is required.")
                .MaximumLength(255).WithMessage("Invoice number must not exceed 255 characters.")
                .MustAsync(BeUniqueInvoiceNumber).WithMessage("The specified invoice number already exists.");
            RuleFor(x => x.Logo)
                .MaximumLength(255).WithMessage("Logo must not exceed 255 characters.");
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");
            RuleFor(x => x.From)
                .NotEmpty().WithMessage("From is required.")
                .MaximumLength(50).WithMessage("Logo must not exceed 50 characters.");
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("To is required")
                .MaximumLength(50).WithMessage("Logo must not exceed 50 characters.");
            RuleFor(x => x.InvoiceItems).SetValidator(new MustHaveInvoiceItemPropertyValidator());
        }

        public async Task<bool> BeUniqueInvoiceNumber(string invoiceNumber, CancellationToken cancellationToken)
        {
            return await _context.Invoices.AllAsync(x => x.InvoiceNumber != invoiceNumber, cancellationToken);
        }
    }
}
