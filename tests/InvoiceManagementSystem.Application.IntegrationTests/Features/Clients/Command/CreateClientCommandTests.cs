using InvoiceManagementSystem.Application.Features.Clients.Command;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.IntegrationTests.Features.Clients.Command
{
    public class CreateClientCommandTests
    {
        private static IServiceScopeFactory _scopeFactory;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [Test]
        public async Task ShouldCreateClient()
        {
            var command = new CreateClientCommand
            {
                Name = "Microsoft",
                Address = "",
                PhoneNumber = "",
                Email = ""
            };

            var response = await SendAsync(command);
        }


        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<ISender>();

            return await mediator.Send(request);
        }

    }
}
