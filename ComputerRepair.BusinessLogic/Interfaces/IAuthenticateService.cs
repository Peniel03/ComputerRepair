using ComputerRepair.BusinessLogic.Accounts.Token;
using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Interfaces
{
    public interface IAuthenticateService
    {
        Task<Tokens> Authenticate(string email, string password);
        Task<User> ValidateUserAsync(string email, string password);
    }
}
