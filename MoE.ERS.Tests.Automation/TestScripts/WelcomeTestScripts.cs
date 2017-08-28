using AventStack.ExtentReports;
using MoE.ERS.Tests.Automation.BaseLibrary;
using MoE.ERS.Tests.Automation.DataSource;
using MoE.ERS.Tests.Automation.Entities;
using MoE.ERS.Tests.Automation.Pages;
using MoE.ERS.Tests.Automation.Utils;
using MoE.ERS.Tests.Automation.Utils.Reports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace MoE.ERS.Tests.Automation.TestScripts
{
    [TestFixture]
    public class WelcomeTestScripts : OperationBase
    {
        private LogInPage logInPage = null;
        private WelcomePage welcomePage = null;
        private ExtentTest extentTest = null;
        private ExtentHtmlReportGenerator extentHtmlReportGenerator;
        private List<Welcome> welcomePageData = null;


        #region Private Methods
        private void InitPages()
        {
            logInPage = new LogInPage(this.WebDriver);
            welcomePage = new WelcomePage(this.WebDriver);
        }
        private void LoadWelcomePage()
        {
            InitiateDriver();
            NavigateToPage();
            InitPages();
        }
        #endregion Private Methods

        [OneTimeSetUp]
        public void InitReportInstance()
        {
            extentHtmlReportGenerator = ExtentHtmlReportGenerator.GetReportInstance();            
            extentTest = extentHtmlReportGenerator.CreateTest("Welcome Page");            
        }
        [Test]
        public void ValidateMakeANewRequestButtonExistence()
        {
            LoadWelcomePage();
            logInPage.LogIn(UserName, Password);
            bool isPassed = welcomePage.IsMakeANewRequestButtonDisplayed();
            Assert.AreEqual(true, isPassed);           
        }
        [Test]
        public void ValidateViewAllRequestsButtonExistence()
        {
            LoadWelcomePage();
            logInPage.LogIn(UserName, Password);
            bool isPassed = welcomePage.IsViewAllRequeststButtonDisplayed();
            Assert.AreEqual(true, isPassed);           
        }
        public void ValidateMakeANewRequestButtonEnabled()
        {
            LoadWelcomePage();
            logInPage.LogIn(UserName, Password);
            bool isPassed = welcomePage.IsMakeANewRequestButtonEnabled();
            Assert.AreEqual(true, isPassed);          
        }
        [Test]
        public void ValidateViewAllRequestsButtonEnabled()
        {
            LoadWelcomePage();
            logInPage.LogIn(UserName, Password);
            bool isPassed = welcomePage.IsViewAllRequestsButtonEnabled();
            Assert.AreEqual(true, isPassed);            
        }
        [Test]
        public void ValidateMakeANewRequestButtonCaption()
        {
            LoadWelcomePage();
            logInPage.LogIn(UserName, Password);
            string actual = welcomePage.GetMakeANewRequestCaption();
            welcomePageData = RealTestData<Welcome>.GetTestData("Welcome", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (Welcome welcome in welcomePageData)
                Assert.AreEqual(welcome.Caption, welcomePage.GetMakeANewRequestCaption());           
        }
        [Test]
        public void ValidateViewAllRequestsButtonCaption()
        {
            LoadWelcomePage();
            logInPage.LogIn(UserName, Password);
            string actual = welcomePage.GetMakeANewRequestCaption();
            welcomePageData = RealTestData<Welcome>.GetTestData("Welcome", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (Welcome welcome in welcomePageData)
                Assert.AreEqual(welcome.Caption, welcomePage.GetViewAllRequestsCaption());           
        }
        [Test]
        public void ValidateRequestButtonsAlignment()
        {
            LoadWelcomePage();
            logInPage.LogIn(UserName, Password);
            bool isPassed = welcomePage.AreRequestButtonsAlignedCenter();
            Assert.AreEqual(true, isPassed);       
        }
        [Test]
        public void MakeANewRequest()
        {
            LoadWelcomePage();
            logInPage.LogIn(UserName, Password);
            welcomePage.ClickOnMakeARequestButton();           
        }
        [TearDown]
        public void TearDown()
        {
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus == TestStatus.Passed)
                extentTest.Log(Status.Pass, "<pre>" + TestContext.CurrentContext.Test.Name + " Passed</pre>");
            else if (testStatus == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                GetScreenShot.GetInstance().Capture(this.WebDriver, TestContext.CurrentContext.Test.Name);
                extentTest.AddScreenCaptureFromPath(GetScreenShot.GetInstance().ScreenshotPath + TestContext.CurrentContext.Test.Name + ".png");
                extentTest.Log(Status.Fail, stackTrace + errorMessage);
            }
            ElementAccessors.Wait(1);
            this.WebDriver.Quit();
        }
        [OneTimeTearDown]
        public void GenerateReport()
        {           
            extentHtmlReportGenerator.extentReports.Flush();
            this.WebDriver.Quit();
        }       
    }
}

