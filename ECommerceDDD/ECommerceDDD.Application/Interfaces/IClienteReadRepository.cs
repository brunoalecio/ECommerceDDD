using ECommerceDDD.Application.ReadModels;

namespace ECommerceDDD.Application.Interfaces
{
    public interface IClienteReadRepository
    {
        Task<IEnumerable<ClienteReadModel>> GetAllAsync();
        Task<ClienteReadModel?> GetByIdAsync(Guid id);
        Task AddAsync(ClienteReadModel cliente);
    }
}