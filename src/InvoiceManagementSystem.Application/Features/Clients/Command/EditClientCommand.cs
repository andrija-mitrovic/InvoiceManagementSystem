using InvoiceManagementSystem.Application.Helpers;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Command
{
    public class EditClientCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
