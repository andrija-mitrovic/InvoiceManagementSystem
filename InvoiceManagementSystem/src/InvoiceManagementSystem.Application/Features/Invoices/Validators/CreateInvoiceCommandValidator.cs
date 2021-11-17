using FluentValidation;
using InvoiceManagementSystem.Application.Features.Invoices.Command;

namespace InvoiceManagementSystem.Application.Features.Invoices.Validators
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
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
