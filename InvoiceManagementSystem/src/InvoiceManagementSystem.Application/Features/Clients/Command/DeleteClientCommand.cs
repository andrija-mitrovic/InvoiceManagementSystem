using InvoiceManagementSystem.Application.Helpers;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Command
{
    public class DeleteClientCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}
