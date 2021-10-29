using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Command
{
    public class DeleteClientCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
