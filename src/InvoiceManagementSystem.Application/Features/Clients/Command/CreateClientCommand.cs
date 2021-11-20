using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Command
{
    public class CreateClientCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
