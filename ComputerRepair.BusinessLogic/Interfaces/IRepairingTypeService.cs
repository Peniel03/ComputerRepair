using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Interfaces
{
    public interface IRepairingTypeService:IBaseService<RepairingType>
    {
        Task<RepairingType?> GetRepairingTypeByNameAsync(string RepairingTypeName);

    }
}
