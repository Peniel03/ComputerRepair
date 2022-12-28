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
    public class RepairingServiceRepository : IRepairingServiceRepository
    {

        private readonly ComputerRepairContext _computerRepairContext;
        public RepairingServiceRepository(ComputerRepairContext computerRepairContext)
        {
            _computerRepairContext = computerRepairContext;
        }
        public void Add(RepairingService repairingService)
        {
            _computerRepairContext.Add(repairingService);
        }

        public void DeleteAsync(RepairingService repairingService)
        {
            _computerRepairContext.Remove(repairingService);
        }

        public Task<List<RepairingService>> GetAllAsync()
        {
            return _computerRepairContext.RepairingServices
                  .AsNoTracking()
                  .ToListAsync();
        }

        public Task<RepairingService?> GetByIdAsync(int Id)
        {
            return _computerRepairContext.RepairingServices
                .Where(p => p.RepairingServiceId == Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Task<RepairingService?> GetRepairingServiceByNameAsync(string ServiceName)
        {
            return _computerRepairContext.RepairingServices
                                        .Where(u => u.ServiceName == ServiceName)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        }

        public Task<RepairingService?> GetRepairingServiceByPriceAsync(decimal ServicePrice)
        {
            return _computerRepairContext.RepairingServices
                                        .Where(u => u.ServicePrice == ServicePrice)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        }

        public Task SavechangesAsync()
        {
            return _computerRepairContext.SaveChangesAsync();
        }

        public void UpdateAsync(RepairingService repairingService)
        {
            _computerRepairContext.Update(repairingService);   
        
        }

 
    }
}
