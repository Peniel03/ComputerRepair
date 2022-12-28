using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Dto
{
    public class ReviewCreateDto
    {
        public string ReviewField { get; set; } = string.Empty;
        public int Rate { get; set; }
    }
}
