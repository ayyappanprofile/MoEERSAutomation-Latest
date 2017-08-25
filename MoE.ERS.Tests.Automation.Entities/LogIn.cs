using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Tests.Automation.Entities
{
    public class LogIn :EntityBase
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Browser { get; set; }
    }
}
