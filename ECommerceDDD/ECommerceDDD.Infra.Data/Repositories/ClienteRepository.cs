using ECommerceDDD.Domain.Entities;
using ECommerceDDD.Domain.Interfaces;
using ECommerceDDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDDD.Infra.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ECommerceDbContext context)
            : base(context)
        {
        }

        public async Task<Cliente> ObterPorEmailAsync(string email)
        {
            return await _dbSet
                .Include(c => c.Email)
                .FirstOrDefaultAsync(c => c.Email.Address == email);
        }
    }
}
