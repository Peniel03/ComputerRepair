using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Models
{
    public class RepairingType
    {
        public int RepairingTypeId { get; set; }
        public string RepairingTypeName { get; set; } = string.Empty;
        
        //Relationship
        public ICollection<Order>? Orders { get; set; }
        public ICollection<RepairingTeam>? RepairingTeams { get; set; }

    }
}
