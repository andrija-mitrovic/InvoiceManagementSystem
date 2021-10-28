using FluentValidation;
using InvoiceManagementSystem.Application.Features.Invoices.Command;

namespace InvoiceManagementSystem.Application.Features.Invoices.Validators
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(x => x.Invoice).SetValidator(new InvoiceValidator());
        }
    }
}
