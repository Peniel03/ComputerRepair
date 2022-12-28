using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.HelpersFunctions
{
    public static class OrderHelperFunctions
    {
        public static DateTime SetOrderDateOnUpdate()
        {
            var OrderDate = DateTime.Now;
            return OrderDate;
        }

    }
}
