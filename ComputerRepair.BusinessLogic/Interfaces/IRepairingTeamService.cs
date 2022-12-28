using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Interfaces
{
    public interface IRepairingTeamService:IBaseService<RepairingTeam>
    {
        Task<RepairingTeam?> GetRepairingTeamByNameAsync(string RepairingTeamName);

    }
}
