using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Models
{
    public  class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public int NumberOfUnits { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } 
        //Relationship
        public User? User { get; set; }
        public int UserId { get; set; }
        public ICollection <Review>? Reviews { get; set; }
        public Payement? Payement { get; set; }
        public RepairingType? RepairingType { get; set; }
        public int RepairingTypeId { get; set; }



    }
}
