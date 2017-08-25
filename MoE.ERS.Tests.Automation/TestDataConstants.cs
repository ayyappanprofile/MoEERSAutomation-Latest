using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MoE.ERS.Tests.Automation
{
    public static class TestDataConstants
    {
        public static string USERNAME
        {
            get { return ConfigurationManager.AppSettings["UserName"].ToString(); }
        }
        public static string PASSWORD
        {
            get { return ConfigurationManager.AppSettings["Password"].ToString(); }
        }
        public static string DELETECOOKIES
        {
            get { return ConfigurationManager.AppSettings["DeleteCookiesInLogIn"].ToString(); }
        }
        //Welcome page constants.
        public const string MAKENEWREQUEST_BUTTON = "MAKE A NEW REQUEST";
        public const string VIEWALLREQUESTS_BUTTON = "VIEW ALL REQUESTS";

        //Find A form constants.        
        public const string FIND_FORM_HEADER = "New request";
        public const string FIND_FORM_ORG_HEADER = "Select organisation";
        public const string ORG_PLACEHOLDER = "Select organization";

        //Absence form constants.
        public const string ABS_SEC_HEADER = "Absence details";
        public const string ABS_DATEFROM_HEADER = "From";
        public const string ABS_DATETO_HEADER = "To";
        public const string ABS_DAYSDURINGABSENCE_HEADER = "Teacher only days during absence";
        public const string ABS_FROMDATE_VALUE = "08/02/2017";
        public const string ABS_TODATE_VALUE = "08/05/2017";
        public const string ABS_TEACHERDAYSDURINGABSENCE_VALUE = "03";
    }
}
