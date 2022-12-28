using ComputerRepair.DataAccess.DataContext;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Repositories.MongoDb
{
    public class RepairingTeamRepositoryMongoDb: IRepairingTeamRepository
    {
        private readonly MongoDbContext _mongoDbContext;
        public RepairingTeamRepositoryMongoDb(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public void Add(RepairingTeam repairingTeam)
        {
            var RepairingTeamCollection = _mongoDbContext.ConnectToMongo<RepairingTeam>("RepairingTeams");
            RepairingTeamCollection.InsertOneAsync(repairingTeam);
        }

        public void DeleteAsync(RepairingTeam repairingTeam)
        {
            var RepairingTeamCollection = _mongoDbContext.ConnectToMongo<RepairingTeam>("RepairingTeams");
            RepairingTeamCollection.DeleteOneAsync(c => c.RepairingTeamId == repairingTeam.RepairingTeamId);

        }

        public async Task<List<RepairingTeam>> GetAllAsync()
        {
            var RepairingTeamCollection = _mongoDbContext.ConnectToMongo<RepairingTeam>("RepairingTeams");
            var repairingTeams = await RepairingTeamCollection.FindAsync(x => true);
            return repairingTeams.ToList();

        }

        public async Task<RepairingTeam?> GetByIdAsync(int Id)
        {
            var RepairingTeamCollection = _mongoDbContext.ConnectToMongo<RepairingTeam>("RepairingTeams");
            var RepairingTeam = await RepairingTeamCollection.FindAsync(u => u.RepairingTeamId == Id);
            return (RepairingTeam)RepairingTeam;
        }

        public async Task<RepairingTeam?> GetRepairingTeamByNameAsync(string RepairingTeamName)
        {
            var RepairingTeamCollection = _mongoDbContext.ConnectToMongo<RepairingTeam>("RepairingTeams");
            var RepairingTeam = await RepairingTeamCollection.FindAsync(u => u.TeamName == RepairingTeamName);
            return (RepairingTeam)RepairingTeam;
        }

        public Task SavechangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(RepairingTeam repairingTeam)
        {
            var RepairingTypeCollection = _mongoDbContext.ConnectToMongo<RepairingTeam>("RepairingTeams");
            var filter = Builders<RepairingTeam>.Filter.Eq("_id", repairingTeam.RepairingTeamId);
            RepairingTypeCollection.ReplaceOneAsync(filter, repairingTeam, new ReplaceOptions { IsUpsert = true });
        }
    }
}
