using FluentValidation;
using InvoiceManagementSystem.Application.DTOs;

namespace InvoiceManagementSystem.Application.Features.Invoices.Validators
{
    public class InvoiceValidator : AbstractValidator<InvoiceDto>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x.InvoiceNumber).NotNull();
            RuleFor(x => x.AmountPaid).NotNull();
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.From).NotNull();
            RuleFor(x => x.To).NotEmpty().MinimumLength(3);
            RuleFor(x => x.InvoiceItems).SetValidator(new MustHaveInvoiceItemPropertyValidator());
        }
    }
}
