using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Tests.Automation.Entities
{
    public class FindFormRT : EntityBase
    {     
        public string FormHeaderExpected { get; set; }
        public string OrgHeaderExpected { get; set; }
        public string FTHeaderExpected { get; set; }
        public string FTHelpLinkExpected { get; set; }
        public string TeacherHeaderExpected { get; set; }
        public string TeacherHelpLinkExpected { get; set; }
        public string CreateRequestbuttonCaptionExpected { get; set; }
        public string OrgTextActual { get; set; }      
        public string OrgSelectionIndex { get; set; }
        public string FTTextActual { get; set; }
        public string FTSelectionIndex { get; set; }
        public string TeacherTextActual { get; set; }
        public string TeacherSelectionIndex { get; set; }
        public string NoResultsFoundCaptionExpected { get; set; }

    }
}
