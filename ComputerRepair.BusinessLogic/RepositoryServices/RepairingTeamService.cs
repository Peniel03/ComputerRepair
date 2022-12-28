using ComputerRepair.BusinessLogic.Exceptions;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.RepositoryServices
{
    public class RepairingTeamService: IRepairingTeamService
    {
        private readonly IRepairingTeamRepository _repairingTeamRepository;
        public RepairingTeamService(IRepairingTeamRepository repairingTeamRepository)
        {
            _repairingTeamRepository = repairingTeamRepository;
        }

        public async Task<RepairingTeam> AddAsync(RepairingTeam  repairingTeam)
        {
            var repairingTeamLooked = _repairingTeamRepository.GetRepairingTeamByNameAsync(repairingTeam.TeamName);

            if (repairingTeamLooked is not null)
            {
                throw new ExistException("This repairing team already exist");
            }

            _repairingTeamRepository.Add(repairingTeam);
            await _repairingTeamRepository.SavechangesAsync();

            return repairingTeam;
        }

        public async Task<RepairingTeam> DeleteAsync(RepairingTeam repairingTeam)
        {
            var repairingTeamLooked = await _repairingTeamRepository.GetByIdAsync(repairingTeam.RepairingTeamId);

            if (repairingTeamLooked is null)
            {
                throw new NotFoundException("This repairing team does not exist");
            }
            _repairingTeamRepository.DeleteAsync(repairingTeamLooked);
            await _repairingTeamRepository.SavechangesAsync();
            return repairingTeam;
        }

        public async Task<List<RepairingTeam>> GetAllAsync()
        {
            var repairingTeams = await _repairingTeamRepository.GetAllAsync();

            if (repairingTeams is null)
            {
                throw new NotFoundException("There are no repairing team yet");
            }
            return  repairingTeams;
        }

        public async Task<RepairingTeam?> GetByIdAsync(int Id)
        {
            var repairingTeam = await _repairingTeamRepository.GetByIdAsync(Id);
            if (repairingTeam is null)
            {
                throw new NotFoundException("The  repairing team does not exist");
            }
            return repairingTeam;
        }

        public async Task<RepairingTeam?> GetRepairingTeamByNameAsync(string RepairingTeamName)
        {
            var repairingTeam = await _repairingTeamRepository.GetRepairingTeamByNameAsync(RepairingTeamName);
            if (repairingTeam is null)
            {
                throw new NotFoundException("The  repairing team does not exist");
            }
            return  repairingTeam;

        }

        public Task SavechangesAsync()
        {
            return _repairingTeamRepository.SavechangesAsync();
         }

        public async Task<RepairingTeam> UpdateAsync(RepairingTeam repairingTeam)
        {
            var repairingTeamLooked = await _repairingTeamRepository.GetRepairingTeamByNameAsync(repairingTeam.TeamName);

            if (repairingTeamLooked is null)
            {
                throw new NotFoundException("The Repairing team does not exist");
            }

            repairingTeamLooked.TeamName = repairingTeam.TeamName;
            _repairingTeamRepository.UpdateAsync(repairingTeamLooked);
            await _repairingTeamRepository.SavechangesAsync();

            return repairingTeam;
        }
    }
}
