using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Dto
{
    public class RepairingServiceCreateDto
    {
        public string ServiceName { get; set; } = string.Empty;
        public decimal ServicePrice { get; set; }
    }
}
