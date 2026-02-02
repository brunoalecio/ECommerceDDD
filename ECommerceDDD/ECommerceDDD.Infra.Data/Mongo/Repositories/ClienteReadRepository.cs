using ECommerceDDD.Application.Interfaces;
using ECommerceDDD.Application.ReadModels;
using ECommerceDDD.Infra.Data.Mongo;
using MongoDB.Driver;

namespace ECommerceDDD.Infra.Data.Mongo.Repositories
{
    public class ClienteReadRepository : IClienteReadRepository
    {
        private readonly IMongoCollection<ClienteReadModel> _collection;

        public ClienteReadRepository(MongoContext context)
        {
            _collection = context.GetCollection<ClienteReadModel>("clientes");
        }

        public async Task<IEnumerable<ClienteReadModel>> GetAllAsync()
        {
            return await _collection
                .Find(FilterDefinition<ClienteReadModel>.Empty)
                .ToListAsync();
        }

        public async Task<ClienteReadModel?> GetByIdAsync(Guid id)
        {
            return await _collection
                .Find(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(ClienteReadModel cliente)
        {
            await _collection.InsertOneAsync(cliente);
        }
    }
}