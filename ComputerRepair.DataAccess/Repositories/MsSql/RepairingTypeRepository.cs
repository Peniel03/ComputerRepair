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
    public class RepairingTypeRepository : IRepairingTypeRepository
    {

        private readonly ComputerRepairContext _computerRepairContext;
        public RepairingTypeRepository(ComputerRepairContext computerRepairContext)
        {
            _computerRepairContext = computerRepairContext;
        }
        public void Add(RepairingType repairingType)
        {
            _computerRepairContext.Add(repairingType);
        }

        public void DeleteAsync(RepairingType repairingType)
        {
            _computerRepairContext.Remove(repairingType);
        }

        public Task<List<RepairingType>> GetAllAsync()
        {
             return _computerRepairContext.RepairingTypes
                  .AsNoTracking()
                  .ToListAsync();
        }

        public Task<RepairingType?> GetByIdAsync(int Id)
        {
            return _computerRepairContext.RepairingTypes
                .Where(p => p.RepairingTypeId == Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Task<RepairingType?> GetRepairingTypeByNameAsync(string RepairingTypeName)
        {
            return _computerRepairContext.RepairingTypes
                            .Where(u => u.RepairingTypeName == RepairingTypeName)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
        }

        public Task SavechangesAsync()
        {
            return _computerRepairContext.SaveChangesAsync();
        }

        public void UpdateAsync(RepairingType repairingType)
        {
            _computerRepairContext.Update(repairingType);

        }
    }
}
