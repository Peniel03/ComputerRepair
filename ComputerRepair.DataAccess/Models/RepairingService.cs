using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Models
{
    public class RepairingService
    {
        public int RepairingServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public decimal ServicePrice { get; set; }

        //RelationShip
        public RepairingTeam? RepairingTeam { get; set; }
        public int RepairingTeamId { get; set; }


    }
}
