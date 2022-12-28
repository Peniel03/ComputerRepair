using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Models
{
    public class RepairingTeam
    {
        public int RepairingTeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;

        //Relationship
        public RepairingType? RepairingType { get; set; }
        public int RepairingTypeId { get; set; }
        public ICollection<RepairingService>? RepairingServices { get; set; }


    }
}
