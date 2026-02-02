using MediatR;
using ECommerceDDD.Application.Interfaces;
using ECommerceDDD.Application.ReadModels;

namespace ECommerceDDD.Application.Queries.Cliente
{
    public class GetAllClientesQueryHandler
        : IRequestHandler<GetAllClientesQuery, IEnumerable<ClienteReadModel>>
    {
        private readonly IClienteReadRepository _clienteReadRepository;

        public GetAllClientesQueryHandler(IClienteReadRepository clienteReadRepository)
        {
            _clienteReadRepository = clienteReadRepository;
        }

        public async Task<IEnumerable<ClienteReadModel>> Handle(
            GetAllClientesQuery request,
            CancellationToken cancellationToken)
        {
            return await _clienteReadRepository.GetAllAsync();
        }
    }
}