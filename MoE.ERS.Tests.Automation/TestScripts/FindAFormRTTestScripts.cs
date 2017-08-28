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
    public class FindAFormRTTestScripts : OperationBase
    {
        private LogInPage logInPage = null;
        private WelcomePage welcomePage = null;
        private FindAFormRTPage findFormRTPage = null;
        private ExtentTest extentTest = null;
        private ExtentHtmlReportGenerator extentHtmlReportGenerator;
        private List<FindFormRT> findFormRTPageData = null;

        [OneTimeSetUp]
        public void InitReportInstance()
        {
            extentHtmlReportGenerator = ExtentHtmlReportGenerator.GetReportInstance();
            extentTest = extentHtmlReportGenerator.extentReports.CreateTest("FindFormRT Page");
        }
        #region Private Methods
        private void InitPages()
        {
            logInPage = new LogInPage(this.WebDriver);
            welcomePage = new WelcomePage(this.WebDriver);
            findFormRTPage = new FindAFormRTPage(this.WebDriver);
        }
        private void LoadFindFormRT()
        {
            InitiateDriver();
            NavigateToPage();
            InitPages();
            logInPage.LogIn(UserName, Password);
            welcomePage.ClickOnMakeARequestButton();
        }
        private void SelectOrganization(string orgTextActual, string orgSelectedIndex)
        {
            findFormRTPage.InputOrganizationTextBox(orgTextActual);
            ElementAccessors.Wait(2);
            findFormRTPage.ClickOnOrganization(int.Parse(orgSelectedIndex));
            ElementAccessors.Wait(2);
        }
        private void SelectFundingType(string ftSelectionIndex)
        {
            findFormRTPage.ClickOnFTDropdown();
            ElementAccessors.Wait(2);
            findFormRTPage.ClickOnFundingTypeOption(int.Parse(ftSelectionIndex));
            ElementAccessors.Wait(2);
        }
        #endregion Private Methods

        #region Organization-TestMethods
        [Test]
        public void ValidateFormHeaderCaption()
        {            
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
               Assert.AreEqual(findFormRT.FormHeaderExpected, findFormRTPage.GetFormHeaderValue());
        }
        [Test]
        public void ValidateOrgHeaderCaption()
        {  
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
                Assert.AreEqual(findFormRT.OrgHeaderExpected.Trim(), findFormRTPage.GetOrgHeaderValue());
        }
        [Test]
        public void ValidateOrgTextBoxExistence()
        {            
            LoadFindFormRT();
            bool isPassed = findFormRTPage.IsOrgTextBoxExists();
            Assert.AreEqual(true, isPassed);         
        }

        [Test]
        public void ValidateOrgSearchResults()
        {
            List<string> lstDropdownElementsCaption;            
            LoadFindFormRT();

            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "OrgTextActual", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                findFormRTPage.InputOrganizationTextBox(findFormRT.OrgTextActual.Trim());
                ElementAccessors.Wait(2);
                lstDropdownElementsCaption = findFormRTPage.GetOrgDropdownElementsCaption();
                bool validationResult = ((lstDropdownElementsCaption.FindAll(caption => caption.ToUpper().Contains(findFormRT.OrgTextActual.Trim().ToUpper())).Count
                                                == lstDropdownElementsCaption.Count)
                                          || lstDropdownElementsCaption.Contains(findFormRT.NoResultsFoundCaptionExpected.Trim()));
                Assert.AreEqual(true, validationResult);                
            }
        }
        [Test]
        public void SelectOrganizationFromDropdown()
        {           
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "OrgTextActual,OrgSelectionIndex", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
              SelectOrganization(findFormRT.OrgTextActual, findFormRT.OrgSelectionIndex);
        }

        #endregion Organization-TestMethods

        #region FundingType-TestMethods
        [Test]
        public void ValidateFTHeaderCaption()
        {            
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                SelectOrganization(findFormRT.OrgTextActual, findFormRT.OrgSelectionIndex);
                Assert.AreEqual(findFormRT.FormHeaderExpected, findFormRTPage.GetFTHeader());                
            }
        }
        [Test]
        public void ValidateFTDropdownExistence()
        {           
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                SelectOrganization(findFormRT.OrgTextActual, findFormRT.OrgSelectionIndex);
                bool isPassed = findFormRTPage.IsFTDropdownExists();
                Assert.AreEqual(true, isPassed);
            }                     
        }

        [Test]
        public void ValidateFTHelpLinkExistence()
        { 
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                SelectOrganization(findFormRT.OrgTextActual, findFormRT.OrgSelectionIndex);
                bool isPassed = findFormRTPage.IsFTHelpLinkExists();
                Assert.AreEqual(true, isPassed);
            }                            
        }

        [Test]
        public void ValidateFTHelpLinkText()
        {         
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                SelectOrganization(findFormRT.OrgTextActual, findFormRT.OrgSelectionIndex);
                Assert.AreEqual(findFormRT.FTHelpLinkExpected, findFormRTPage.GetFTHelpLinkText());
            }
        }

        [Test]
        public void ValidateFTResultsOnLoad()
        {
            List<string> lstDropdownElementsCaption;            
            LoadFindFormRT();
            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                SelectOrganization(findFormRT.OrgTextActual, findFormRT.OrgSelectionIndex);
                lstDropdownElementsCaption = findFormRTPage.GetFTDropdownElementsCaption();                
                Assert.AreEqual(true, lstDropdownElementsCaption.Count > 0);
            }
        }
        [Test]
        public void ValidateFTSearchResults()
        {
            List<string> lstDropdownElementsCaption;            
            LoadFindFormRT();        

            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");

            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                SelectOrganization(findFormRT.OrgTextActual, findFormRT.OrgSelectionIndex);
                findFormRTPage.ClickOnFTDropdown();
                ElementAccessors.Wait(2);
                findFormRTPage.InputFundingTypeTextBox(findFormRT.FTTextActual);
                ElementAccessors.Wait(2);
                lstDropdownElementsCaption = findFormRTPage.GetFTDropdownElementsCaption();
                findFormRTPage.ClickOnFTDropdown();
                bool validationResult = ((lstDropdownElementsCaption.FindAll(caption => caption.ToUpper().Contains(findFormRT.FTTextActual.Trim().ToUpper())).Count
                                                == lstDropdownElementsCaption.Count)
                                          || lstDropdownElementsCaption.Contains(findFormRT.NoResultsFoundCaptionExpected.Trim()));
                Assert.AreEqual(true, validationResult);             
            }
        }
        [Test]
        public void SelectFundingTypeFromDropdown()
        {            
            LoadFindFormRT();  
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                SelectOrganization(findFormRT.OrgTextActual, findFormRT.OrgSelectionIndex);
                SelectFundingType(findFormRT.FTSelectionIndex);
            }                   
        }
        #endregion FundingType-TestMethods

        #region Teacher-TestMethods
        [Test]
        public void ValidateTeacherHeader()
        {           
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            foreach (FindFormRT findFormRT in findFormRTPageData)
               Assert.AreEqual(findFormRT.TeacherHeaderExpected, findFormRTPage.GetTeacherHeader());
        }
        [Test]
        public void ValidateTeacherDropdownExistence()
        {           
            LoadFindFormRT();
            bool isPassed = findFormRTPage.IsTeacherDropdownxists();
            Assert.AreEqual(true, isPassed);          
        }
        [Test]
        public void ValidateTeacherHelpLinkExistence()
        {            
            LoadFindFormRT();
            bool isPassed = findFormRTPage.IsTeacherHelpLinkExists();
            Assert.AreEqual(true, isPassed);            
        }
        [Test]
        public void ValidateTeacherHelpLinkText()
        {            
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            string teacherHelpLinkText = findFormRTPage.GetTeacherHelpLinkText();
            foreach (FindFormRT findFormRT in findFormRTPageData)
               Assert.AreEqual(findFormRT.TeacherHelpLinkExpected, teacherHelpLinkText);
        }

        [Test]
        public void ValidateTeacherResultsOnLoad()
        {
            List<string> lstDropdownElementsCaption;            
            LoadFindFormRT();

            lstDropdownElementsCaption = findFormRTPage.GetTeacherDropdownElementsCaption();
            bool validationResult = lstDropdownElementsCaption.Count > 0;
            Assert.AreEqual(true, validationResult);           
        }
        [Test]
        public void ValidateTeacherSearchResults()
        {
            List<string> lstDropdownElementsCaption;
            LoadFindFormRT();          

            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "TeacherTextActual", "TestName='" + new StackFrame(0).GetMethod().Name + "'");

            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                findFormRTPage.ClickOnTeacherDropdown();
                ElementAccessors.Wait(2);
                findFormRTPage.InputTeacherTextBox(findFormRT.TeacherTextActual);
                ElementAccessors.Wait(2);
                lstDropdownElementsCaption = findFormRTPage.GetTeacherDropdownElementsCaption();
                findFormRTPage.ClickOnTeacherDropdown();
                bool validationResult = ((lstDropdownElementsCaption.FindAll(caption => caption.ToUpper().Contains(findFormRT.TeacherTextActual.Trim().ToUpper())).Count
                                                == lstDropdownElementsCaption.Count)
                                          || lstDropdownElementsCaption.Contains(findFormRTPageData[0].NoResultsFoundCaptionExpected.Trim()));
                Assert.AreEqual(true, validationResult);                
            }
        }
        [Test]
        public void SelectTeacherFromDropdown()
        {          
            LoadFindFormRT();            

            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            findFormRTPage.ClickOnTeacherDropdown();
            ElementAccessors.Wait(5);
            foreach (FindFormRT findFormRT in findFormRTPageData)
            {
                SelectOrganization(findFormRT.OrgTextActual, findFormRT.OrgSelectionIndex);
                SelectFundingType(findFormRT.FTSelectionIndex);
                findFormRTPage.ClickOnTeacherOption(int.Parse(findFormRT.TeacherSelectionIndex));
            }                           
        }
        #endregion Teacher-TestMethods

        #region CreateRequest-TestMethods
        [Test]
        public void ValidateCreateRequestButtonExistence()
        {           
            LoadFindFormRT();
            bool isPassed = findFormRTPage.IsCreateRequestButtonExists();
            Assert.AreEqual(true, isPassed);            
        }
        [Test]
        public void ValidateCreateRequestButtonText()
        {           
            LoadFindFormRT();
            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "*", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            string createRequestButtonText = findFormRTPage.GetCreateRequestButtonCaption();
            foreach (FindFormRT findFormRT in findFormRTPageData)           
                Assert.AreEqual(findFormRT.CreateRequestbuttonCaptionExpected, createRequestButtonText);
        }
        [Test]
        public void ValidateCreateRequestButtonDisabledOnFormLoad()
        {            
            LoadFindFormRT();
            bool isPassed = findFormRTPage.IsCreateRequestButtonEnabled();
            Assert.AreEqual(false, isPassed);          
        }
        [Test]
        public void ValidateCreateRequestButtonEnabledAfterLoad()
        {           
            LoadFindFormRT();
            bool isPassed = findFormRTPage.IsCreateRequestButtonEnabled();
            Assert.AreEqual(true, isPassed);            
        }

        [Test]
        public void CreateRequest()
        {            
            LoadFindFormRT();            

            findFormRTPageData = RealTestData<FindFormRT>.GetTestData("FindFormRT", "TeacherSelectionIndex", "TestName='" + new StackFrame(0).GetMethod().Name + "'");
            findFormRTPage.ClickOnTeacherDropdown();
            ElementAccessors.Wait(5);
            findFormRTPage.ClickOnTeacherOption(int.Parse(findFormRTPageData[0].TeacherSelectionIndex));
            ElementAccessors.Wait(2);
            findFormRTPage.ClickOnCreateRequestButton();            
        }
        #endregion CreateRequest-TestMethods
        [TearDown]
        public void TearDown()
        {
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus == TestStatus.Passed)
                extentTest.Log(Status.Pass, "<pre>" + TestContext.CurrentContext.Test.Name + " Passed</pre>");
            else
            if (testStatus == TestStatus.Failed)
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
