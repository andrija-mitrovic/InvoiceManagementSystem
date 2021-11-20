using FluentValidation;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
using InvoiceManagementSystem.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Features.Invoices.Validators
{
    public class EditInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        private readonly IApplicationDbContext _context;

        public EditInvoiceCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.InvoiceNumber)
                .NotEmpty().WithMessage("Invoice number is required.")
                .MaximumLength(100).WithMessage("Invoice number must not exceed 200 characters.")
                .MustAsync(BeUniqueInvoiceNumber).WithMessage("The specified invoice number already exists.");
            RuleFor(x => x.AmountPaid);
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");
            RuleFor(x => x.From)
                .NotEmpty().WithMessage("From is required.");
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("To is required");
            RuleFor(x => x.InvoiceItems).SetValidator(new MustHaveInvoiceItemPropertyValidator());
        }

        public async Task<bool> BeUniqueInvoiceNumber(string invoiceNumber, CancellationToken cancellationToken)
        {
            return await _context.Invoices.AllAsync(x => x.InvoiceNumber != invoiceNumber, cancellationToken);
        }
    }
}
