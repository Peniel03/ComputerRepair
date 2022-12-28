using ComputerRepair.DataAccess.DataContext;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Repositories.MsSql
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ComputerRepairContext _computerRepairContext;
        public ReviewRepository(ComputerRepairContext computerRepairContext)
        {
            _computerRepairContext = computerRepairContext;
        }
        public void Add(Review review)
        {
            _computerRepairContext.Add(review);
        }

        public void DeleteAsync(Review review)
        {
            _computerRepairContext.Remove(review);
        }

        public Task<List<Review>> GetAllAsync()
        {
            return _computerRepairContext.Reviews
                  .AsNoTracking()
                  .ToListAsync();
        }

        public Task<Review?> GetByIdAsync(int Id)
        {
            return _computerRepairContext.Reviews
              .Where(u => u.ReviewId == Id)
              .AsNoTracking()
              .FirstOrDefaultAsync();
        }

        public Task<Review?> GetByRate(int rate)
        {
            return _computerRepairContext.Reviews
                .Where(r => r.Rate == rate)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Task SavechangesAsync()
        {
            return _computerRepairContext.SaveChangesAsync();
        }

        public void UpdateAsync(Review review)
        {
            _computerRepairContext.Update(review);   
        }

 
    }
}
