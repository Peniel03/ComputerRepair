using ComputerRepair.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;
using System.Threading.Tasks;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;

namespace ComputerRepair.DataAccess.Repositories.MongoDb
{
    public class RepairingTypeRepositoryMongoDb: IRepairingTypeRepository
    {
        private readonly MongoDbContext _mongoDbContext;
        public RepairingTypeRepositoryMongoDb(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public void Add(RepairingType repairingType)
        {
            var RepairingTypeCollection = _mongoDbContext.ConnectToMongo<RepairingType>("RepairingTypes");
            RepairingTypeCollection.InsertOneAsync(repairingType);
        }

        public void DeleteAsync(RepairingType repairingType)
        {
            var RepairingTypeCollection = _mongoDbContext.ConnectToMongo<RepairingType>("RepairingTypes");
            RepairingTypeCollection.DeleteOneAsync(c => c.RepairingTypeId == repairingType.RepairingTypeId);
        }

        public async Task<List<RepairingType>> GetAllAsync()
        {
            var RepairingTypeCollection = _mongoDbContext.ConnectToMongo<RepairingType>("RepairingTypes");
            var repairingTypes = await RepairingTypeCollection.FindAsync(x => true);
            return repairingTypes.ToList();
        }

        public async Task<RepairingType?> GetByIdAsync(int Id)
        {
            var RepairingTypeCollection = _mongoDbContext.ConnectToMongo<RepairingType>("RepairingTypes");
            var repairingType = await RepairingTypeCollection.FindAsync(u => u.RepairingTypeId == Id);
            return (RepairingType)repairingType;
        }

        public async Task<RepairingType?> GetRepairingTypeByNameAsync(string RepairingTypeName)
        {
            var RepairingTypeCollection = _mongoDbContext.ConnectToMongo<RepairingType>("RepairingTypes");
            var repairingType = await RepairingTypeCollection.FindAsync(u => u.RepairingTypeName == RepairingTypeName);
            return (RepairingType)repairingType;
        }

        public Task SavechangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(RepairingType repairingType)
        {
            var RepairingTypeCollection = _mongoDbContext.ConnectToMongo<RepairingType>("RepairingTypes");
            var filter = Builders<RepairingType>.Filter.Eq("_id", repairingType.RepairingTypeId);
            RepairingTypeCollection.ReplaceOneAsync(filter, repairingType, new ReplaceOptions { IsUpsert = true });
        }
    }
}
