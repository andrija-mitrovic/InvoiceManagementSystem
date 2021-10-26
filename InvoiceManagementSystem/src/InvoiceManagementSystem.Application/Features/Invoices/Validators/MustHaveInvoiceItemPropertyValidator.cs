using FluentValidation.Validators;
using InvoiceManagementSystem.Application.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManagementSystem.Application.Features.Invoices.Validators
{
    public class MustHaveInvoiceItemPropertyValidator : PropertyValidator
    {
        public MustHaveInvoiceItemPropertyValidator()
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IList<InvoiceItemDto>;
            return list != null && list.Any();
        }
    }
}
