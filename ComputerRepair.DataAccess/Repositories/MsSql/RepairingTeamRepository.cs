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
    public class RepairingTeamRepository : IRepairingTeamRepository
    {

        private readonly ComputerRepairContext _computerRepairContext;
        public RepairingTeamRepository(ComputerRepairContext computerRepairContext)
        {
            _computerRepairContext = computerRepairContext;
        }
        public void Add(RepairingTeam repairingTeam)
        {
            _computerRepairContext.Add(repairingTeam);
        }

        public void DeleteAsync(RepairingTeam repairingTeam)
        {
            _computerRepairContext.Remove(repairingTeam);

        }

        public Task<List<RepairingTeam>> GetAllAsync()
        {
            return _computerRepairContext.RepairingTeams
                 .AsNoTracking()
                 .ToListAsync();
        }

        public Task<RepairingTeam?> GetByIdAsync(int Id)
        {
            return _computerRepairContext.RepairingTeams
                .Where(p => p.RepairingTeamId == Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Task<RepairingTeam?> GetRepairingTeamByNameAsync(string RepairingTeamName)
        {
            return _computerRepairContext.RepairingTeams
                          .Where(u => u.TeamName == RepairingTeamName)
                          .AsNoTracking()
                          .FirstOrDefaultAsync();
        }

        public Task SavechangesAsync()
        {
            return _computerRepairContext.SaveChangesAsync();
        }

        public void UpdateAsync(RepairingTeam repairingTeam)
        {
            _computerRepairContext.Update(repairingTeam);
        }


    }
}
