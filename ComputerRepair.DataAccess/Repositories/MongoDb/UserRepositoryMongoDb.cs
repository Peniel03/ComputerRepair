using ComputerRepair.DataAccess.DataContext;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Repositories.MongoDb
{
    public class UserRepositoryMongoDb : IUserRepository
    {
        private readonly MongoDbContext _mongoDbContext;
        public UserRepositoryMongoDb(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public void Add(User user)
        {
            var userCollection = _mongoDbContext.ConnectToMongo<User>("Users");
             userCollection.InsertOneAsync(user);
        }

        public void DeleteAsync(User user)
        {
            var userCollection = _mongoDbContext.ConnectToMongo<User>("Users"); 
            userCollection.DeleteOneAsync(c => c.UserId == user.UserId);
        }

        public async Task<List<User>> GetAllAsync()
        {
            var userCollection = _mongoDbContext.ConnectToMongo<User>("Users");
            var users = await userCollection.FindAsync(x => true);
            return users.ToList();
        }

        public async Task<User?> GetByIdAsync(int Id)
        {
            var userCollection = _mongoDbContext.ConnectToMongo<User>("Users");
            var user = await userCollection.FindAsync(u => u.UserId == Id);
            return   (User)user;
        }

        public async Task<User?> GetByUserNameAsync(string Name)
        {
            var userCollection = _mongoDbContext.ConnectToMongo<User>("Users");
            var user =  await userCollection.FindAsync(u => u.Name == Name);
            return (User)user;

        }

        public async Task<User?> GetUserByEmailAsync(string Email)
        {
            var userCollection = _mongoDbContext.ConnectToMongo<User>("Users");
            var user = await userCollection.FindAsync(u => u.Email == Email);
            return (User)user;
        }

        public Task SavechangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(User user)
        {
            var userCollection = _mongoDbContext.ConnectToMongo<User>("Users");
            var filter = Builders<User>.Filter.Eq("_id", user.UserId);
            userCollection.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });

        }
    }
}
