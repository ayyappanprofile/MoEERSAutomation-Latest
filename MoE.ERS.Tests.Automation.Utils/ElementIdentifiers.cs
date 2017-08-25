using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Tests.Automation.Utils.ElementIdentifiers
{
    public static class ElementIdentifiers
    {
        //LogIn page controls configuration.
        //public const string ANOTHERUSER_BUTTON = "//table[@id='use_another_account']";
        public const string ANOTHERUSER_BUTTON = "use_another_account_link";
        public const string USERNAME_TEXT = "cred_userid_inputtext";
        public const string PASSWORD_TEXT = "cred_password_inputtext";
        public const string SIGNIN_BUTTON = "cred_sign_in_button";

        //Welcome page controls configuration.
        public const string MAKEANEWREQUEST_BUTTON = "//a[contains(.,'MAKE A NEW REQUEST')]";
        public const string VIEWALLREQUEST_BUTTON = "//a[contains(.,'VIEW ALL REQUESTS')]";
        public const string CENTER_ALIGNED_CONTAINER = "//div[@class='container']/div[@class='col-xs-12 center']";

        //Find A Form Page controls configuration.
        public const string FORM_HEADER_LABEL = "//div[@class='organisation']//div[@class='row app-header']//h2";

        public const string ORG_HEADER_LABEL = "//div[@id='section_organisation']//label";
        public const string ORG_TEXT = "OrganisationName";        
        public const string ORG_DRP_ELEMENTS = "//li[@class='ui-menu-item']";


        public const string FT_HEADER_LABEL = "//div[@id='section_resource_type']//label";
        public const string FT_DROPDOWN_ARROW = "//div[@id='section_resource_type']//span[@class='select2-selection__arrow']";
        public const string FT_DROPDOWN = "//select[@id='select_resource']";
        public const string FT_DRP_ELEMENTS = "//li[@role='treeitem']";
        public const string FT_HELP_LINK = "//div[@id='section_resource_type']//a[@class='info-link']";

        public const string FT_TEACHER_SEARCH_TEXT = "//input[@class = 'select2-search__field']";

        public const string TEACHER_HEADER_LABEL = "//div[@id='section_teachers']//label";
        public const string TEACHER_DROPDOWN_ARROW = "//div[@id='section_teachers']//span[@class='select2-selection__arrow']";
        public const string TEACHER_DROPDOWN = "//select[@id='select_teacher']";
        public const string TEACHER_DRP_ELEMENTS = "//li[@role='treeitem']";     
        public const string TEACHER_HELP_LINK = "//div[@id='section_teachers']//a[@class='info-link']";

        public const string FORM_BUTTON = "create_request_button";




        //public const string ORGANISATIONTYPESEARCH_PLACEHOLDER = "//div[@id='section_organisation']//span[@class='select2-selection__rendered']";
        //public const string RESOURCETYPESEARCH_PLACEHOLDER = "//div[@id='section_resource_type']//span[@class='select2-selection__rendered']";
        //public const string TEACHERSEARCH_PLACEHOLDER = "//div[@id='section_teachers']//span[@class='select2-selection__rendered']";
        //public const string ORGANISATIONTYPE_DROPDOWN = "//div[@id='section_organisation']//span[@class='select2-selection select2-selection--single']";
        //public const string RESOURCETYPE_DROPDOWN = "//div[@id='section_resource_type']//span[@class='select2-selection select2-selection--single']";
        //public const string TEACHER_DROPDOWN = "//div[@id='section_teachers']//span[@class='select2-selection select2-selection--single']";        
        //public const string ORGANISATIONTYPE_DROPDOWN_OPTION = "//ul[@id='select2-select_organisation-results']/li[1]";
        //public const string RESOURCETYPE_DROPDOWN_OPTION = "//ul[@id='select2-select_resource-results']/li[1]";
        //public const string TEACHER_DROPDOWN_OPTION = "//ul[@id='select2-select_teacher-results']/li[1]";
        //public const string RESOURCETYPE_DROPDOWN_SEL_OPTION = "//div[@id='section_resource_type']//span[@class='select2-selection__rendered']";
        //public const string CREATEREQUEST_BUTTON = "create_request_button";


        //AbsenceForm controls configuration.
        public const string ABS_FORM_HEADER_TEXT = "//div[@class='col-xs-12']//h2";
        public const string ABS_SECTION_HEADER_TEXT = "form_heading";
        public const string ABS_FORM_DATEFROM_TEXT = "//label[@class='date-from required']";
        public const string ABS_FORM_DATETO_TEXT = "//label[@class='date-to required']";
        public const string ABS_FORM_DAYSDURINGABSENCE_TEXT = "//label[@for='teacher_days_absence']";
        public const string ABS_FORM_DATEFROM_FIELD = "date_from";
        public const string ABS_FORM_DATETO_FIELD = "date_to";
        public const string ABS_FORM_DAYSDURINGABSENCE_FIELD = "teacher_days_absence";
        public const string ABS_FORM_CONTINUE_BUTTON = "step_1_continue";

    }
}
