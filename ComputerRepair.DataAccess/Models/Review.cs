using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewField { get; set; } = string.Empty;
        public int Rate { get; set; }
        //Relationship
        public Order? Order { get; set; }
        public int OrderId { get; set; }
    }
}
