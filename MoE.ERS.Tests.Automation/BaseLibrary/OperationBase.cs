using MoE.ERS.Tests.Automation.DataSource;
using MoE.ERS.Tests.Automation.Entities;
using OpenQA.Selenium;
using System.Linq;
using MoE.ERS.Tests.Automation.Utils.Reports;
using MoE.ERS.Tests.Automation.Utils;

namespace MoE.ERS.Tests.Automation.BaseLibrary
{
    public class OperationBase
    {
        private IWebDriver _webDriver = null;        
        private string _browser = string.Empty;
        private ExtentHtmlReportGenerator extentHtmlReportGenerator;

        public OperationBase()
        {
            LogIn logInData = RealTestData<LogIn>.GetTestData("ApplicationConfiguration").First();            
            Url = logInData.Url;
            UserName = logInData.UserName;
            Password = logInData.Password;
            Browser = logInData.Browser;
            extentHtmlReportGenerator = ExtentHtmlReportGenerator.GetReportInstance();
            if(!extentHtmlReportGenerator.IsReportConfigured)
               InitReport();
        }
        public bool IsReportConfigured
        {
            get; set;
        }
        public IWebDriver WebDriver
        {
            get { return _webDriver; }
        }
        public string Url{  get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Browser { get; set; }

        public string DataSheetPath { get; set; }

        public void InitiateDriver()
        {            
            _browser = Browser;
            this._webDriver = DriverFactory.Create(_browser);
        }
        public void NavigateToPage()
        {            
            if (!WebDriver.GetType().Name.ToUpper().Equals("INTERNETEXPLORERDRIVER"))
                WebDriver.Manage().Cookies.DeleteAllCookies();
            string driverType = WebDriver.GetType().ToString();           
            this._webDriver.Url = Url;
            this._webDriver.Manage().Window.Maximize();
        }    
        public void InitReport()
        {
            ReportConfiguration reportConfigData = RealTestData<ReportConfiguration>.GetTestData("ReportConfiguration").First();            
            extentHtmlReportGenerator.SetReportConfiguration(reportConfigData.DocumentTitle, reportConfigData.ReportName, reportConfigData.ReportPath);
            GetScreenShot.GetInstance().ScreenshotPath = reportConfigData.ScreenShotPath;            
        }
    }
}
