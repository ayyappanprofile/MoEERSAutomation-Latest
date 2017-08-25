using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;


namespace MoE.ERS.Tests.Automation.Utils.Reports
{
   public sealed class ExtentHtmlReportGenerator
    {
        private static ExtentHtmlReportGenerator instance = null;
        //public static ExtentReports extentReports;
        //public static ExtentHtmlReporter extentHtmlReporter;
        public ExtentReports extentReports;
        public ExtentHtmlReporter extentHtmlReporter;

        private ExtentHtmlReportGenerator()
        {}

        public bool IsReportConfigured
        {  get; set; }

        public void SetReportConfiguration(string documentTitle, string reportName, string reportPath)
        {
            extentReports = new ExtentReports();
            extentHtmlReporter = new ExtentHtmlReporter(reportPath + reportName +".html");
            extentHtmlReporter.Configuration().Theme = Theme.Dark;
            extentHtmlReporter.Configuration().DocumentTitle = documentTitle;
            extentHtmlReporter.Configuration().ReportName = reportName;
            extentReports.AttachReporter(extentHtmlReporter);
            IsReportConfigured = true;
        }
        public static ExtentHtmlReportGenerator GetReportInstance()
        {
            if (instance == null)
                instance = new ExtentHtmlReportGenerator();
            return instance;
        }
        public ExtentTest CreateTest(string testMessage)
        {
            return extentReports.CreateTest(testMessage);
        }
        public void RenderReport()
        {
            extentReports.Flush();
        }
    }
}
