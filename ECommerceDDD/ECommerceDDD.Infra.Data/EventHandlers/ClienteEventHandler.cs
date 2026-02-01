using ECommerceDDD.Domain.Events;
using ECommerceDDD.Infra.Data.Mongo.Models;
using ECommerceDDD.Infra.Data.Mongo.Repositories;
using MediatR;

namespace ECommerceDDD.Infra.Data.EventHandlers
{
    public class ClienteEventHandler :
        INotificationHandler<ClienteRegistradoEvent>
    {
        private readonly ClienteReadRepository _clienteReadRepository;

        public ClienteEventHandler(ClienteReadRepository clienteReadRepository)
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
