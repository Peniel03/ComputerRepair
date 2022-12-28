using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Interfaces
{
    public interface IRepairingServiceRepository:IBaseRepository<RepairingService>
    {
        Task<RepairingService?> GetRepairingServiceByNameAsync(string ServiceName);
        Task<RepairingService?> GetRepairingServiceByPriceAsync(decimal ServicePrice);


    }
}
