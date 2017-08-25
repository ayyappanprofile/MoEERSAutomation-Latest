using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Tests.Automation.Utils
{
    public class InvalidLocatorException : Exception
    {
        public InvalidLocatorException(string message):base(message)
        {

        }
    }
}
