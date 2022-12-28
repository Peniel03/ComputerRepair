using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.Exceptions
{
    public class ExistException:Exception
    {
        public ExistException()
        {

        }
        public ExistException(string message) : base(message)
        {

        }

        public ExistException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
