using FluentValidation;
using InvoiceManagementSystem.Application.Features.Invoices.Command;

namespace InvoiceManagementSystem.Application.Features.Invoices.Validators
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(x => x.Invoice.AmountPaid).NotNull();
            RuleFor(x => x.Invoice.Date).NotNull();
            RuleFor(x => x.Invoice.From).NotNull();
            RuleFor(x => x.Invoice.To).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Invoice.InvoiceItems).SetValidator(new MustHaveInvoiceItemPropertyValidator());
        }
    }
}
