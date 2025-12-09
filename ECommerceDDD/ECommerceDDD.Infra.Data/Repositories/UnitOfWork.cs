using ECommerceDDD.Domain.Interfaces;
using ECommerceDDD.Infra.Data.Context;

namespace ECommerceDDD.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;

        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
