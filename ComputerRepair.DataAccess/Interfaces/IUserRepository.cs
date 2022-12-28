using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string Email);
        Task<User?> GetByUserNameAsync(string Name);


    }
}
