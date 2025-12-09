using ECommerceDDD.Domain.Entities;

namespace ECommerceDDD.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterPorEmailAsync(string email);
    }
}
