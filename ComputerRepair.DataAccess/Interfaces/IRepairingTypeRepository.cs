using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Interfaces
{
    public interface IRepairingTypeRepository: IBaseRepository<RepairingType>
    {
        Task<RepairingType?> GetRepairingTypeByNameAsync(string RepairingTypeName);


    }
}
