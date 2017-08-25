using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Tests.Automation.Entities
{
    public class ReportConfiguration : EntityBase
    {
        public string DocumentTitle { get; set; }
        public string ReportName { get; set; }
        public string ReportPath { get; set; }
        public string ScreenShotPath { get; set; }
    }
}
