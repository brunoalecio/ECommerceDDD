using ECommerceDDD.Application.ReadModels;
using MediatR;

namespace ECommerceDDD.Application.Queries.Cliente
{
    public class GetAllClientesQuery : IRequest<IEnumerable<ClienteReadModel>>
    {
    }
}