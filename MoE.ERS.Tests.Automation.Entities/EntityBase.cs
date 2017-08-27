using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Tests.Automation.Entities
{
    public class EntityBase
    {
        public string TestContainerName { get; set; }
        public string TestName { get; set; }

        public string CanExecute { get; set; }
    }
}
