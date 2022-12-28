using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Exceptions
{
    public class ActionAlreadyDone: Exception
    {
        public ActionAlreadyDone()
        {

        }
        public ActionAlreadyDone(string message) : base(message)
        {

        }

        public ActionAlreadyDone(string message, Exception ex) : base(message, ex)
        {


        }
    }
}
