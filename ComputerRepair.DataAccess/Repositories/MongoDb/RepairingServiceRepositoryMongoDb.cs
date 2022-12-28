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
    public class RepairingServiceRepositoryMongoDb: IRepairingServiceRepository
    {
        private readonly MongoDbContext _mongoDbContext;
        public RepairingServiceRepositoryMongoDb(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }
        public void Add(RepairingService repairingService)
        {
            var RepairingServiceCollection = _mongoDbContext.ConnectToMongo<RepairingService>("RepairingServices");
            RepairingServiceCollection.InsertOneAsync(repairingService);
        }

        public void DeleteAsync(RepairingService repairingService)
        {
            var RepairingServiceCollection = _mongoDbContext.ConnectToMongo<RepairingService>("RepairingServices");
            RepairingServiceCollection.DeleteOneAsync(c => c.RepairingServiceId == repairingService.RepairingServiceId);
        }

        public async Task<List<RepairingService>> GetAllAsync()
        {
            var RepairingServiceCollection = _mongoDbContext.ConnectToMongo<RepairingService>("RepairingServices");
            var repairingServices = await RepairingServiceCollection.FindAsync(x => true);
            return repairingServices.ToList();
        }

        public async Task<RepairingService?> GetByIdAsync(int Id)
        {
            var RepairingServiceCollection = _mongoDbContext.ConnectToMongo<RepairingService>("RepairingServices");
            var repairingService = await RepairingServiceCollection.FindAsync(u => u.RepairingServiceId == Id);
            return (RepairingService)repairingService;
        }

        public async Task<RepairingService?> GetRepairingServiceByNameAsync(string ServiceName)
        {
            var RepairingServiceCollection = _mongoDbContext.ConnectToMongo<RepairingService>("RepairingServices");
             var repairingService = await RepairingServiceCollection.FindAsync(u => u.ServiceName == ServiceName);
            return (RepairingService)repairingService;
        }

        public async Task<RepairingService?> GetRepairingServiceByPriceAsync(decimal ServicePrice)
        {
            var RepairingServiceCollection = _mongoDbContext.ConnectToMongo<RepairingService>("RepairingServices");
             var repairingService = await RepairingServiceCollection.FindAsync(u => u.ServicePrice == ServicePrice);
            return (RepairingService)repairingService;
        }

        public Task SavechangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(RepairingService repairingService)
        {
            var RepairingServiceCollection = _mongoDbContext.ConnectToMongo<RepairingService>("RepairingServices");
            var filter = Builders<RepairingService>.Filter.Eq("_id", repairingService.RepairingServiceId);
            RepairingServiceCollection.ReplaceOneAsync(filter, repairingService, new ReplaceOptions { IsUpsert = true });
        }
    }
}
