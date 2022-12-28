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
    public class PayementRepositoryMongoDb: IPayementRepository
    {
        private readonly MongoDbContext _mongoDbContext;
        public PayementRepositoryMongoDb(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public void Add(Payement payement)
        {
            var PayementCollection = _mongoDbContext.ConnectToMongo<Payement>("Payements");
            PayementCollection.InsertOneAsync(payement);
        }

        public void DeleteAsync(Payement payement)
        {
            var PayementCollection = _mongoDbContext.ConnectToMongo<Payement>("Payements");
            PayementCollection.DeleteOneAsync(c => c.PayementId == payement.PayementId);

        }

        public async Task<List<Payement>> GetAllAsync()
        {
            var PayementCollection = _mongoDbContext.ConnectToMongo<Payement>("Payements");
            var payements = await PayementCollection.FindAsync(x => true);
            return payements.ToList();
        }

        public async Task<Payement?> GetByIdAsync(int Id)
        {
            var PayementCollection = _mongoDbContext.ConnectToMongo<Payement>("Payements");
            var payement = await PayementCollection.FindAsync(u => u.PayementId == Id);
            return (Payement)payement;
        }

        public Task SavechangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Payement payement)
        {
            var PayementCollection = _mongoDbContext.ConnectToMongo<Payement>("Payements");
            var filter = Builders<Payement>.Filter.Eq("_id", payement.PayementId);
            PayementCollection.ReplaceOneAsync(filter, payement, new ReplaceOptions { IsUpsert = true });
        }
    }
}
