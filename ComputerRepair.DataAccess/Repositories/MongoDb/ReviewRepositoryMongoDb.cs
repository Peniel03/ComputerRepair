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
    public class ReviewRepositoryMongoDb: IReviewRepository
    {
        private readonly MongoDbContext _mongoDbContext;
        public ReviewRepositoryMongoDb(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public void Add(Review review)
        {
            var reviewCollection = _mongoDbContext.ConnectToMongo<Review>("Reviews");
            reviewCollection.InsertOneAsync(review);
        }

        public void DeleteAsync(Review review)
        {
            var reviewCollection = _mongoDbContext.ConnectToMongo<Review>("Reviews");
            reviewCollection.DeleteOneAsync(c => c.ReviewId == review.ReviewId);
              
        }

        public async Task<List<Review>> GetAllAsync()
        {
            var reviewCollection = _mongoDbContext.ConnectToMongo<Review>("Reviews");
            var reviews = await reviewCollection.FindAsync(x => true);
            return reviews.ToList();
        }

        public async Task<Review?> GetByIdAsync(int Id)
        {
            var reviewCollection = _mongoDbContext.ConnectToMongo<Review>("Reviews");
            var review = await reviewCollection.FindAsync(u => u.ReviewId == Id);
            return (Review)review;
        }

        public async Task<Review?> GetByRate(int rate)
        {
            var reviewCollection = _mongoDbContext.ConnectToMongo<Review>("Reviews");
            var review = await reviewCollection.FindAsync(u => u.Rate == rate);
            return (Review)review;
        }

        public Task SavechangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Review review)
        {
            var reviewCollection = _mongoDbContext.ConnectToMongo<Review>("Users");
            var filter = Builders<Review>.Filter.Eq("_id", review.ReviewId);
            reviewCollection.ReplaceOneAsync(filter, review, new ReplaceOptions { IsUpsert = true });
        }
    }
}
