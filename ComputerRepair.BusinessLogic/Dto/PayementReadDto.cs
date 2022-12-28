using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Dto
{
    public class PayementReadDto
    {
        public DateTime PayementDate { get; set; }
        public string PayementStatus { get; set; } = string.Empty;
        public decimal Amount { get; set; }

    }
}
