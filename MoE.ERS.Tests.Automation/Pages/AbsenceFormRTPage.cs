using MoE.ERS.Tests.Automation.BaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MoE.ERS.Tests.Automation.DataSource;
using MoE.ERS.Tests.Automation.Entities;
using System.Linq.Expressions;
using MoE.ERS.Tests.Automation.Utils;
using MoE.ERS.Tests.Automation.Utils.Exceptions;
using MoE.ERS.Tests.Automation.Utils.ElementIdentifiers;
using Xunit;
using System.Diagnostics;

namespace MoE.ERS.Tests.Automation.Pages
{
    public class AbsenceFormRTPage : PageBase
    {
        IWebDriver driver;
        bool isPassed = false;
        public AbsenceFormRTPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        [FindsBy(How = How.XPath, Using = ElementIdentifiers.ABS_FORM_HEADER_TEXT)]
        public IWebElement FormHeaderText { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.ABS_SECTION_HEADER_TEXT)]
        public IWebElement SectionHeaderText { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.ABS_FORM_DATEFROM_TEXT)]
        public IWebElement DateFromFieldText { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.ABS_FORM_DATETO_TEXT)]
        public IWebElement DateToFieldText { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.ABS_FORM_DAYSDURINGABSENCE_TEXT)]
        public IWebElement DaysDuringAbsenceFieldText { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.ABS_FORM_DATEFROM_FIELD)]
        public IWebElement DateFromField { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.ABS_FORM_DATETO_FIELD)]
        public IWebElement DateToField { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.ABS_FORM_DAYSDURINGABSENCE_FIELD)]
        public IWebElement DaysDuringAbsenceField { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.ABS_FORM_CONTINUE_BUTTON)]
        public IWebElement ContinueButton { get; set; }


        public string GetFormHeader()
        {
            string formHeaderValue = string.Empty;
            try
            {
                formHeaderValue = FormHeaderText.Text;
            }
            catch (Exception)
            { }
            return formHeaderValue;
        }
        public string GetSectionHeader()
        {
            string sectionHeaderValue = string.Empty;
            try
            {
                sectionHeaderValue = SectionHeaderText.Text;
            }
            catch (Exception)
            { }
            return sectionHeaderValue;           
        }

        public bool IsDateFromCaptionExists()
        {
            isPassed = false;
            try
            { isPassed = DateFromField.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }

        public bool IsDateToCaptionExists()
        {
            isPassed = false;
            try
            { isPassed = DateToField.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }

        public bool IsDaysDuringAbsenceCaptionExists()
        {
            isPassed = false;
            try
            { isPassed = DaysDuringAbsenceField.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }
        //public void KeyInFormFields(String fromDate, String toDate, String noOfDaysDuringAbsence)
        //{
        //    try
        //    {
        //        //Enter value in FromDate field.
        //        DateFromField.SendKeys(fromDate);
        //        //Enter value in ToDate field.
        //        DateToField.SendKeys(toDate);
        //        //Enter value in Teacher only days during Absence field.
        //        DaysDuringAbsenceField.Clear();
        //        DaysDuringAbsenceField.SendKeys(noOfDaysDuringAbsence);
        //        ElementAccessors.Wait(2);
        //    }
        //    catch (Exception)
        //    { }
        //}







        //public bool EnterDataIntoAbsenceFormRTFields(String fromDate, String toDate, String noOfDaysDuringAbsence)
        //{
        //    isPassed = false;
        //    try
        //    {
        //        // Enter value in From date
        //        DateFromField.SendKeys(fromDate);
        //        Logger.LogMessage("Entered value in Date From field.\n");
        //        // Enter value in To Date
        //        DateToField.SendKeys(toDate);
        //        Logger.LogMessage("Entered value in To Date field.\n");
        //        // Enter value in Teacher only days during absence
        //        DaysDuringAbsenceField.Clear();
        //        DaysDuringAbsenceField.SendKeys(noOfDaysDuringAbsence);
        //        Logger.LogMessage("Entered value in Teacher only days during absence field.\n");
        //        ElementAccessors.Wait(2);
        //        isPassed = true;
        //    }
        //    catch (Exception)
        //    { Logger.LogError("FAILED-Unable to enter data into the fields.\n"); }
        //    return isPassed;            
        //}








        //public bool IsFormHeaderExists(string selectedResourceType)
        //{
        //    isPassed = false;
        //    try
        //    {
        //        Assert.Equal(selectedResourceType,FormHeaderText.Text);
        //        isPassed = true;
        //        Logger.LogMessage("SUCCESS-Form header exists.\n");
        //    }
        //    catch (Exception)
        //    { throw; }
        //    return isPassed;
        //}

        //public bool IsSectionHeaderExists(string sectionHeader)
        //{
        //    isPassed = false;
        //    try
        //    {
        //        Assert.Equal(sectionHeader, SectionHeaderText.Text);
        //        isPassed = true;
        //        Logger.LogMessage("SUCCESS-Form header exists.\n");
        //    }
        //    catch (Exception)
        //    { throw; }
        //    return isPassed;
        //}

        //public bool IsDateFromExists(string dateFromHeader)
        //{
        //    isPassed = false;
        //    try
        //    {
        //        Assert.True(DateFromField.Displayed);
        //        Assert.Equal(dateFromHeader, DateFromFieldText.Text);
        //        isPassed = true;
        //        Logger.LogMessage("SUCCESS-Form's Date From field and header exists.\n");
        //    }
        //    catch (Exception)
        //    { throw; }
        //    return isPassed;
        //}

        //public bool IsDateToExists(String dateTo)
        //{
        //    isPassed = false;
        //    try
        //    {
        //        Assert.True(DateToField.Displayed);
        //        Assert.Equal(dateTo, DateToFieldText.Text);
        //        isPassed = true;
        //        Logger.LogMessage("SUCCESS-Form's Date to field and header exists.\n");
        //    }
        //    catch (Exception)
        //    { throw; }
        //    return isPassed;
        //}

        //public bool IsDaysDuringAbsenceExists(String daysDuringAbsence)
        //{
        //    isPassed = false;
        //    try
        //    {
        //        Assert.True(DaysDuringAbsenceField.Displayed);
        //        Assert.Equal(daysDuringAbsence, DaysDuringAbsenceFieldText.Text);
        //        isPassed = true;
        //        Logger.LogMessage("SUCCESS-Form's 'Teacher only days during absence' field and header exists.\n");
        //    }
        //    catch (Exception)
        //    { throw; }
        //    return isPassed;
        //}

        //public bool EnterDataIntoAbsenceFormRTFields(String fromDate, String toDate, String noOfDaysDuringAbsence)
        //{
        //    isPassed = false;
        //    try
        //    {
        //        // Enter value in From date
        //        DateFromField.SendKeys(fromDate);
        //        Logger.LogMessage("Entered value in Date From field.\n");
        //        // Enter value in To Date
        //        DateToField.SendKeys(toDate);
        //        Logger.LogMessage("Entered value in To Date field.\n");
        //        // Enter value in Teacher only days during absence
        //        DaysDuringAbsenceField.Clear();
        //        DaysDuringAbsenceField.SendKeys(noOfDaysDuringAbsence);
        //        Logger.LogMessage("Entered value in Teacher only days during absence field.\n");
        //        ElementAccessors.Wait(2);
        //        isPassed = true;
        //    }
        //    catch (Exception)
        //    { Logger.LogError("FAILED-Unable to enter data into the fields.\n"); }
        //    return isPassed;            
        //}

        //public bool ClickOnContinueButton()
        //{
        //    isPassed = false;
        //    try
        //    {
        //        ContinueButton.Click();
        //        ElementAccessors.Wait(5);
        //        isPassed = true;
        //        Logger.LogMessage("SUCCESS-Clicked Continue button.\n");
        //    }
        //    catch (Exception)
        //    { Logger.LogError("FAILED-Unable to click on Continue button.\n"); }
        //    return isPassed;
        //}
    }
}
