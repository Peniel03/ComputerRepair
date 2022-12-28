using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using ComputerRepair.DataAccess.DataContext;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;

namespace ComputerRepair.DataAccess.Repositories.MongoDb
{
    public class OrderRepositoryMongoDb: IOrderRepository
    {
        private readonly MongoDbContext _mongoDbContext;
        public OrderRepositoryMongoDb(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public void Add(Order order)
        {
            var OrderCollection = _mongoDbContext.ConnectToMongo<Order>("Orders");
            OrderCollection.InsertOneAsync(order);
        }

        public void DeleteAsync(Order order)
        {
            var OrderCollection = _mongoDbContext.ConnectToMongo<Order>("Orders");
            OrderCollection.DeleteOneAsync(c => c.OrderId == order.OrderId);

        }
        public async Task<List<Order>> GetAllAsync()
        {
            var OrderCollection = _mongoDbContext.ConnectToMongo<Order>("Orders");
            var orders = await OrderCollection.FindAsync(x => true);
            return orders.ToList();
        }

        public async Task<Order?> GetByIdAsync(int Id)
        {
            var OrderCollection = _mongoDbContext.ConnectToMongo<Order>("Orders");
            var order = await OrderCollection.FindAsync(u => u.OrderId == Id);
            return (Order)order;
        }

        public async Task<Order?> GetOrderByNameAsync(string OrderName)
        {
            var OrderCollection = _mongoDbContext.ConnectToMongo<Order>("Orders");
            var order = await OrderCollection.FindAsync(u => u.OrderName == OrderName);
            return (Order)order;
        }

        public Task SavechangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Order order)
        {
            var OrderCollection = _mongoDbContext.ConnectToMongo<Order>("Orders");
            var filter = Builders<Order>.Filter.Eq("_id", order.OrderId);
            OrderCollection.ReplaceOneAsync(filter, order, new ReplaceOptions { IsUpsert = true });

        }
    }
}
