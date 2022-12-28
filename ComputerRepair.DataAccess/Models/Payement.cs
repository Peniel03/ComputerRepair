using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Models
{
    public class Payement
    {
        [ForeignKey("Order")]
        [Key]
        public int PayementId { get; set; }
        public DateTime PayementDate { get; set; }
        public string PayementStatus { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        //Relationship
        public Order? Order { get; set; }


 
    }
}
