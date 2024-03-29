﻿using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Interfaces
{
    public interface IUserService: IBaseService<User>
    {
        Task<User?> GetUserByEmailAsync(string Email);
        Task<User?> GetByUserNameAsync(string Name);
    }
}
