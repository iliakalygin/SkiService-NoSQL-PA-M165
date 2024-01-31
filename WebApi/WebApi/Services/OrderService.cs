using WebApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApi.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _ordersCollection;

        public OrderService(
            IOptions<SkiServiceManagementDatabaseSettings> skiservicemanagementDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                skiservicemanagementDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                skiservicemanagementDatabaseSettings.Value.DatabaseName);

            _ordersCollection = mongoDatabase.GetCollection<Order>(
                skiservicemanagementDatabaseSettings.Value.OrdersCollectionName);
        }

        public async Task<List<Order>> GetAsync() =>
            await _ordersCollection.Find(_ => true).ToListAsync();

        public async Task<Order?> GetAsync(string id) =>
            await _ordersCollection.Find(x => x.OrderID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Order newOrder) =>
            await _ordersCollection.InsertOneAsync(newOrder);

        public async Task UpdateAsync(string id, Order updatedOrder) =>
            await _ordersCollection.ReplaceOneAsync(x => x.OrderID == id, updatedOrder);

        public async Task RemoveAsync(string id) =>
            await _ordersCollection.DeleteOneAsync(x => x.OrderID == id);
    }
}
