using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.HelpersFunctions
{
    public static class PayementHelperFunctions
    {
        public static DateTime SetPayementDate()
        {
            var payementDate = DateTime.Now;
            return payementDate;

        }
        public static string SetPayementStatus()
        {
            var payementStatus = "Paid";
            return payementStatus;
        }
    }
}
