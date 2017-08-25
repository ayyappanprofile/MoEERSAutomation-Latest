using AventStack.ExtentReports;
using MoE.ERS.Tests.Automation.BaseLibrary;
using MoE.ERS.Tests.Automation.DataSource;
using MoE.ERS.Tests.Automation.Entities;
using MoE.ERS.Tests.Automation.Pages;
using MoE.ERS.Tests.Automation.Utils;
using MoE.ERS.Tests.Automation.Utils.Reports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace MoE.ERS.Tests.Automation.TestScripts
{
    public class AbsenceFormRTTestScripts : OperationBase
    {
        private LogInPage logInPage = null;
        private WelcomePage welcomePage = null;
        private ExtentTest extentTest = null;
        private ExtentHtmlReportGenerator extentHtmlReportGenerator;        

        [OneTimeSetUp]
        public void InitReportInstance()
        {
            extentHtmlReportGenerator = ExtentHtmlReportGenerator.GetReportInstance();
            extentTest = extentHtmlReportGenerator.CreateTest("AbsenceFormRT Testing...");
        }
        private void InitPages()
        {
            logInPage = new LogInPage(this.WebDriver);
            welcomePage = new WelcomePage(this.WebDriver);
        }

        //public AbsenceFormRTTestScripts()
        //{
        //    htmlReporter = HtmlReporter.GetInstance();
        //    InitiateDriver();
        //    logInPage = new LogInPage(this.WebDriver);
        //    welcomePage = new WelcomePage(this.WebDriver);
        //    findAForm = new FindAFormRTPage(this.WebDriver);
        //    absenceForm = new AbsenceFormRTPage(this.WebDriver);
        //}

        //private void LoadAbsenceForm()
        //{
        //    try
        //    {
        //        Logger.LogMessage("START-LoadAbsenceForm");
        //        NavigateToPage();
        //        //Logging on to ERS site.    
        //        logInPage.LogIn();
        //        welcomePage.ClickOnMakeARequestButton();
        //        if (findAForm.IsOrganisationSearchDropdownDisplays())
        //            findAForm.SelectOptionInOrganizationDropdown();
        //        if (findAForm.IsResourceTypeSearchDropdownDisplays())
        //        {
        //            findAForm.SelectOptionInResourceTypeDropdown();
        //            resourceTypeSelOption = findAForm.GetSelectedResourceType();
        //        }
        //        if (findAForm.IsTeacherSearchDropdownDisplays())
        //            findAForm.SelectOptionInTeacherDropdown();
        //        findAForm.ClickOnCreateRequestButton();
        //    }
        //    catch (Exception ex)
        //    { Logger.LogMessage("FAILED-ErrorLoading Absence Form." + ex.Message + ex.StackTrace); }
        //    finally
        //    { Logger.LogMessage("END-LoadAbsenceForm"); }
        //}

        //private void UpdateAbsenceFormAndSubmit()
        //{
        //    try
        //    {
        //        Logger.LogMessage("START-UpdateAbsenceFormAndSubmit");
        //        absenceForm.EnterDataIntoAbsenceFormRTFields(TestDataConstants.ABS_FROMDATE_VALUE, TestDataConstants.ABS_TODATE_VALUE, TestDataConstants.ABS_TEACHERDAYSDURINGABSENCE_VALUE);
        //        absenceForm.ClickOnContinueButton();
        //    }
        //    catch (Exception ex)
        //    { Logger.LogMessage("FAILED-Error Submitting Absence Form." + ex.Message + ex.StackTrace); }
        //    finally
        //    { Logger.LogMessage("END-UpdateAbsenceFormAndSubmit"); }

        //}
        //public void ValidateFormHeader()
        //{            
        //    try
        //    {
        //        startTime = DateTime.Now.ToShortTimeString();              
        //        Logger.LogMessage("START-TestScript-AbsenceFormRT-ValidateFormHeader");
        //        LoadAbsenceForm();
        //        isPassed = absenceForm.IsFormHeaderExists(resourceTypeSelOption);
        //        actual = absenceForm.FormHeaderText.Text;
        //        expected = resourceTypeSelOption;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Source.ToUpper().Equals("XUNIT.ASSERT"))
        //        {
        //            actual = absenceForm.FormHeaderText.Text;
        //            expected = resourceTypeSelOption;
        //        }
        //        isPassed = false;
        //        Logger.LogError("FAILED-" + ex.Message + ex.StackTrace);
        //    }
        //    finally
        //    {
        //        endTime = DateTime.Now.ToShortTimeString();
        //        if (!isPassed) GetScreenShot.Capture(this.WebDriver, "ABS-" + new StackFrame(0).GetMethod().Name);
        //        htmlReporter.AddResultToReport("AbsenceFormRT-ValidateFormHeader", actual, expected
        //           , isPassed ? "PASS" : "FAIL", "ABS-" + new StackFrame(0).GetMethod().Name + ".png", startTime, endTime, "ShowDetails");
        //        Logger.LogMessage("END-TestScript-AbsenceFormRT-ValidateFormHeader");
        //        this.WebDriver.Quit();
        //    }
        //}
        //public void ValidateSectionHeader()
        //{
        //    try
        //    {
        //        startTime = DateTime.Now.ToShortTimeString();
        //        Logger.LogMessage("START-TestScript-AbsenceFormRT-ValidateSectionHeader");
        //        LoadAbsenceForm();
        //        isPassed = absenceForm.IsSectionHeaderExists(TestDataConstants.ABS_SEC_HEADER);
        //        actual = absenceForm.SectionHeaderText.Text;
        //        expected = TestDataConstants.ABS_SEC_HEADER;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Source.ToUpper().Equals("XUNIT.ASSERT"))
        //        {
        //            actual = absenceForm.SectionHeaderText.Text;
        //            expected = TestDataConstants.ABS_SEC_HEADER;
        //        }
        //        isPassed = false;
        //        Logger.LogError("FAILED-" + ex.Message + ex.StackTrace);
        //    }
        //    finally
        //    {
        //        endTime = DateTime.Now.ToShortTimeString();
        //        if (!isPassed) GetScreenShot.Capture(this.WebDriver, "ABS-" + new StackFrame(0).GetMethod().Name);
        //        htmlReporter.AddResultToReport("AbsenceFormRT-ValidateFormHeader", actual, expected
        //           , isPassed ? "PASS" : "FAIL", "ABS-" + new StackFrame(0).GetMethod().Name + ".png", startTime, endTime, "ShowDetails");
        //        Logger.LogMessage("END-TestScript-AbsenceFormRT-ValidateSectionHeader");
        //        this.WebDriver.Quit();
        //    }
        //}
        //public void ValidateFromDateField()
        //{
        //    try
        //    {
        //        startTime = DateTime.Now.ToShortTimeString();
        //        Logger.LogMessage("START-TestScript-AbsenceFormRT-ValidateFromDateField");
        //        LoadAbsenceForm();
        //        isPassed = absenceForm.IsDateFromExists(TestDataConstants.ABS_DATEFROM_HEADER);
        //        actual = absenceForm.DateFromFieldText.Text;
        //        expected = TestDataConstants.ABS_DATEFROM_HEADER;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Source.ToUpper().Equals("XUNIT.ASSERT"))
        //        {
        //            actual = absenceForm.DateFromFieldText.Text;
        //            expected = TestDataConstants.ABS_DATEFROM_HEADER;
        //        }
        //        isPassed = false;
        //        Logger.LogError("FAILED-" + ex.Message + ex.StackTrace);
        //    }
        //    finally
        //    {
        //        endTime = DateTime.Now.ToShortTimeString();
        //        if (!isPassed) GetScreenShot.Capture(this.WebDriver, "ABS-" + new StackFrame(0).GetMethod().Name);
        //        htmlReporter.AddResultToReport("AbsenceFormRT-ValidateFromDateField", actual, expected
        //           , isPassed ? "PASS" : "FAIL", "ABS-" + new StackFrame(0).GetMethod().Name + ".png", startTime, endTime, "ShowDetails");
        //        Logger.LogMessage("END-TestScript-AbsenceFormRT-ValidateFromDateField");
        //        this.WebDriver.Quit();
        //    }
        //}

        //public void ValidateToDateField()
        //{
        //    try
        //    {
        //        startTime = DateTime.Now.ToShortTimeString();
        //        Logger.LogMessage("START-TestScript-AbsenceFormRT-ValidateToDateField");
        //        LoadAbsenceForm();
        //        isPassed = absenceForm.IsDateToExists(TestDataConstants.ABS_DATETO_HEADER);
        //        actual = absenceForm.DateToFieldText.Text;
        //        expected = TestDataConstants.ABS_DATETO_HEADER;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Source.ToUpper().Equals("XUNIT.ASSERT"))
        //        {
        //            actual = absenceForm.DateToFieldText.Text;
        //            expected = TestDataConstants.ABS_DATETO_HEADER;
        //        }
        //        isPassed = false;
        //        Logger.LogError("FAILED-" + ex.Message + ex.StackTrace);
        //    }
        //    finally
        //    {
        //        endTime = DateTime.Now.ToShortTimeString();
        //        if (!isPassed) GetScreenShot.Capture(this.WebDriver, "ABS-" + new StackFrame(0).GetMethod().Name);
        //        htmlReporter.AddResultToReport("AbsenceFormRT-ValidateToDateField", actual, expected
        //           , isPassed ? "PASS" : "FAIL", "ABS-" + new StackFrame(0).GetMethod().Name + ".png", startTime, endTime, "ShowDetails");
        //        Logger.LogMessage("END-TestScript-AbsenceFormRT-ValidateToDateField");
        //        this.WebDriver.Quit();
        //    }
        //}

        //public void ValidateDaysDuringAbsenceField()
        //{
        //    try
        //    {
        //        startTime = DateTime.Now.ToShortTimeString();
        //        Logger.LogMessage("START-TestScript-AbsenceFormRT-ValidateDaysDuringAbsenceField");
        //        LoadAbsenceForm();
        //        isPassed = absenceForm.IsDaysDuringAbsenceExists(TestDataConstants.ABS_DAYSDURINGABSENCE_HEADER);
        //        actual = absenceForm.DaysDuringAbsenceFieldText.Text;
        //        expected = TestDataConstants.ABS_DAYSDURINGABSENCE_HEADER;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Source.ToUpper().Equals("XUNIT.ASSERT"))
        //        {
        //            actual = absenceForm.DaysDuringAbsenceFieldText.Text;
        //            expected = TestDataConstants.ABS_DAYSDURINGABSENCE_HEADER;
        //        }
        //        isPassed = false;
        //        Logger.LogError("FAILED-" + ex.Message + ex.StackTrace);
        //    }
        //    finally
        //    {
        //        endTime = DateTime.Now.ToShortTimeString();
        //        if (!isPassed) GetScreenShot.Capture(this.WebDriver, "ABS-" + new StackFrame(0).GetMethod().Name);
        //        htmlReporter.AddResultToReport("AbsenceFormRT-ValidateDaysDuringAbsenceField", actual, expected
        //           , isPassed ? "PASS" : "FAIL", "ABS-" + new StackFrame(0).GetMethod().Name + ".png", startTime, endTime, "ShowDetails");
        //        Logger.LogMessage("END-TestScript-AbsenceFormRT-ValidateDaysDuringAbsenceField");
        //        this.WebDriver.Quit();
        //    }
        //}

        //public void UpdateAbsenceRTFormAndContinue()
        //{
        //    try
        //    {
        //        startTime = DateTime.Now.ToShortTimeString();
        //        Logger.LogMessage("START-TestScript-AbsenceFormRT-UpdateAbsenceRTFormAndContinue");
        //        LoadAbsenceForm();
        //        UpdateAbsenceFormAndSubmit();
        //        isPassed = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Source.ToUpper().Equals("XUNIT.ASSERT"))
        //        {

        //        }
        //        isPassed = false;
        //        Logger.LogError("FAILED-" + ex.Message + ex.StackTrace);
        //    }
        //    finally
        //    {
        //        endTime = DateTime.Now.ToShortTimeString();
        //        if (!isPassed) GetScreenShot.Capture(this.WebDriver, "ABS-" + new StackFrame(0).GetMethod().Name);
        //        htmlReporter.AddResultToReport("AbsenceFormRT-UpdateAbsenceRTFormAndContinue", actual, expected
        //           , isPassed ? "PASS" : "FAIL", "ABS-" + new StackFrame(0).GetMethod().Name + ".png", startTime, endTime, "ShowDetails");
        //        Logger.LogMessage("END-TestScript-AbsenceFormRT-UpdateAbsenceRTFormAndContinue");
        //        this.WebDriver.Quit();
        //    }
        //}
    }
}
