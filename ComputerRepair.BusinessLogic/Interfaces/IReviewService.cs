using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Interfaces
{
    public interface IReviewService:IBaseService<Review>
    {
        Task<Review?> GetByRate(int rate);

    }
}
