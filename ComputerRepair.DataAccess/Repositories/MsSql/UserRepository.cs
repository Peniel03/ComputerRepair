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
    public class UserRepository : IUserRepository
    {
        private readonly ComputerRepairContext _computerRepairContext;
        public UserRepository(ComputerRepairContext computerRepairContext)
        {
            _computerRepairContext = computerRepairContext;
        }

        public void Add(User user)
        {
            _computerRepairContext.Add(user);
        }

        public void DeleteAsync(User user)
        {
            _computerRepairContext.Remove(user);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _computerRepairContext.Users
                   .AsNoTracking()
                   .ToListAsync();
        }

        public Task<User?> GetByIdAsync(int Id)
        {
            return _computerRepairContext.Users
                .Where(u => u.UserId == Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        }

        public Task<User?> GetByUserNameAsync(string Name)
        {
            return _computerRepairContext.Users
                .Where(u => u.Name == Name)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Task<User?> GetUserByEmailAsync(string Email)
        {
            return _computerRepairContext.Users
                .Where(u => u.Email == Email)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Task SavechangesAsync()
        {
            return _computerRepairContext.SaveChangesAsync();
        }

        public void UpdateAsync(User user)
        {
            _computerRepairContext.Update(user);

         }


    }
}
