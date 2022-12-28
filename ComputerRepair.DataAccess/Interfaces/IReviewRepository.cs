﻿using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Interfaces
{
    public interface IReviewRepository: IBaseRepository<Review>
    {
        Task<Review?> GetByRate(int rate);

    }
}
