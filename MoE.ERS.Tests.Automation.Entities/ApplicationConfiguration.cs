using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Tests.Automation.Entities
{
    public class ApplicationConfiguration : EntityBase
    {
        public string TestDataContainer { get; set; }
        public string ExecutableContainer { get; set; }  
        public string ProviderName { get; set; }
    }
}
