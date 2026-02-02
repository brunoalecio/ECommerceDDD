using ECommerceDDD.Domain.Events;
using ECommerceDDD.Application.Interfaces;
using ECommerceDDD.Application.ReadModels;
using MediatR;

namespace ECommerceDDD.Infra.Data.EventHandlers
{
    public class ClienteEventHandler :
        INotificationHandler<ClienteRegistradoEvent>
    {
        private readonly IClienteReadRepository _clienteReadRepository;

        public ClienteEventHandler(IClienteReadRepository clienteReadRepository)
        {
            _clienteReadRepository = clienteReadRepository;
        }

        public async Task Handle(
            ClienteRegistradoEvent notification,
            CancellationToken cancellationToken)
        {
            var clienteReadModel = new ClienteReadModel
            {
                Id = notification.Id,
                Nome = notification.Nome,
                Email = notification.Email,
                DataNascimento = notification.DataNascimento
            };

            await _clienteReadRepository.AddAsync(clienteReadModel);
        }
    }
}