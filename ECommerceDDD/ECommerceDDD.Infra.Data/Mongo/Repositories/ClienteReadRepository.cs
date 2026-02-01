using ECommerceDDD.Infra.Data.Mongo.Models;
using MongoDB.Driver;

namespace ECommerceDDD.Infra.Data.Mongo.Repositories
{
    public class ClienteReadRepository
    {
        private readonly IMongoCollection<ClienteReadModel> _collection;

        public ClienteReadRepository(MongoContext context)
        {
            _collection = context.GetCollection<ClienteReadModel>("clientes");
        }

        public async Task AddAsync(ClienteReadModel cliente)
        {
            await _collection.InsertOneAsync(cliente);
        }

        public async Task UpdateAsync(ClienteReadModel cliente)
        {
            await _collection.ReplaceOneAsync(
                c => c.Id == cliente.Id,
                cliente,
                new ReplaceOptions { IsUpsert = true }
            );
        }

        public async Task<ClienteReadModel> GetByIdAsync(Guid id)
        {
            return await _collection
                .Find(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ClienteReadModel>> GetAllAsync()
        {
            return await _collection
                .Find(_ => true)
                .ToListAsync();
        }
    }
}
