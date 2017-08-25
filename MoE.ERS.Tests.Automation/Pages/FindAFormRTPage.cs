using MoE.ERS.Tests.Automation.BaseLibrary;
using MoE.ERS.Tests.Automation.Utils;
using MoE.ERS.Tests.Automation.Utils.ElementIdentifiers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace MoE.ERS.Tests.Automation.Pages
{
    public class FindAFormRTPage : PageBase
    {
        IWebDriver driver;
        bool isPassed = false;
        public FindAFormRTPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.FORM_HEADER_LABEL)]
        public IWebElement FormHeaderLabel { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.ORG_HEADER_LABEL)]
        public IWebElement OrgHeaderLabel { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.ORG_TEXT)]
        public IWebElement OrganizationText { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.FT_HEADER_LABEL)]
        public IWebElement FundingTypeHeaderLabel { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.FT_DROPDOWN_ARROW)]
        public IWebElement FundingTypeDropdownArrow { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.FT_DROPDOWN)]
        public IWebElement FundingTypeDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.FT_DRP_ELEMENTS)]
        public IList<IWebElement> FundingTypeDropdownElements { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.FT_HELP_LINK)]
        public IWebElement FundingTypeHelpLink { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.FT_TEACHER_SEARCH_TEXT)]
        public IWebElement DropdownSearchTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.TEACHER_HEADER_LABEL)]
        public IWebElement TeacherHeaderLabel { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.TEACHER_DROPDOWN_ARROW)]
        public IWebElement TeacherDropdownArrow { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.TEACHER_DROPDOWN)]
        public IWebElement TeacherDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.TEACHER_DRP_ELEMENTS)]
        public IList<IWebElement> TeacherDropdownElements { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.TEACHER_HELP_LINK)]
        public IWebElement TeacherHelpLink { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.FORM_BUTTON)]
        public IWebElement CreateRequestButton { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.ORG_DRP_ELEMENTS)]
        public IList<IWebElement> OrgDropdownElements { get; set; }

        public string GetFormHeaderValue()
        {
            string formHeaderValue = string.Empty;
            try
            {
                formHeaderValue = FormHeaderLabel.Text;
            }
            catch (Exception)
            { throw; }
            return formHeaderValue;
        }
        public string GetOrgHeaderValue()
        {
            string orgHeaderValue = string.Empty;
            try
            {
                orgHeaderValue = OrgHeaderLabel.Text;
            }
            catch (Exception)
            { throw; }
            return orgHeaderValue;
        }
        public bool IsOrgTextBoxExists()
        {
            isPassed = false;
            try
            { isPassed = OrganizationText.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }
        public void InputOrganizationTextBox(string orgText)
        {
            try
            {
                ElementAccessors.InputTextBox(orgText, OrganizationText);
            }
            catch (Exception)
            { throw; }
        }

        public List<string> GetOrgDropdownElementsCaption()
        {
            List<string> lstDropdownElementsCaption = new List<string>();

            foreach (IWebElement webElement in OrgDropdownElements)
                lstDropdownElementsCaption.Add(webElement.GetAttribute("innerText"));

            return lstDropdownElementsCaption;
        }

        public void ClickOnOrganization(int elementIndex)
        {
            Random random = new Random();
            //int randomOrgIndx = random.Next(1, elementIndex);
            int randomOrgIndx = elementIndex;
            int idx = 1;
            foreach (IWebElement webElement in OrgDropdownElements)
            {
                if (idx == randomOrgIndx)
                    ElementAccessors.DoClick(this.driver, webElement);
                idx++;
            }
        }

        public string GetFTHeader()
        {
            string ftHeaderValue = string.Empty;
            try
            {
                ftHeaderValue = FundingTypeHeaderLabel.Text;
            }
            catch (Exception)
            { throw; }
            return ftHeaderValue;
        }
        public bool IsFTDropdownExists()
        {
            isPassed = false;
            try
            { isPassed = FundingTypeDropdown.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }
        public bool IsFTHelpLinkExists()
        {
            isPassed = false;
            try
            { isPassed = FundingTypeHelpLink.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }

        public string GetFTHelpLinkText()
        {
            string ftHelpLinkValue = string.Empty;
            try
            {
                ftHelpLinkValue = FundingTypeHelpLink.Text;
            }
            catch (Exception)
            { throw; }
            return ftHelpLinkValue;
        }

        public List<string> GetFTDropdownElementsCaption()
        {
            List<string> lstDropdownElementsCaption = new List<string>();

            foreach (IWebElement webElement in FundingTypeDropdownElements)
                lstDropdownElementsCaption.Add(webElement.GetAttribute("innerText"));

            return lstDropdownElementsCaption;
        }
        public void ClickOnFTDropdown()
        {
            try
            {
                FundingTypeDropdownArrow.Click();
            }
            catch (Exception)
            { throw; }
        }

        public void ClickOnFundingTypeOption(int elementIndex)
        {
            Random random = new Random();
            //int randomOrgIndx = random.Next(1, elementIndex);
            int randomOrgIndx = elementIndex;

            var selectElement = new SelectElement(FundingTypeDropdown);
            selectElement.SelectByIndex(elementIndex);
        }
        public void InputFundingTypeTextBox(string FTText)
        {
            try
            {
                ElementAccessors.InputTextBox(FTText, DropdownSearchTextBox);
            }
            catch (Exception)
            { throw; }
        }
        public string GetTeacherHeader()
        {
            string teacherHeaderValue = string.Empty;
            try
            {
                teacherHeaderValue = TeacherHeaderLabel.Text;
            }
            catch (Exception)
            { throw; }
            return teacherHeaderValue;
        }
        public bool IsTeacherDropdownxists()
        {
            isPassed = false;
            try
            { isPassed = TeacherDropdown.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }
        public bool IsTeacherHelpLinkExists()
        {
            isPassed = false;
            try
            { isPassed = TeacherHelpLink.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }

        public string GetTeacherHelpLinkText()
        {
            string ftHelpLinkValue = string.Empty;
            try
            {
                ftHelpLinkValue = TeacherHelpLink.Text;
            }
            catch (Exception)
            { throw; }
            return ftHelpLinkValue;
        }

        public List<string> GetTeacherDropdownElementsCaption()
        {
            List<string> lstDropdownElementsCaption = new List<string>();

            foreach (IWebElement webElement in TeacherDropdownElements)
                lstDropdownElementsCaption.Add(webElement.GetAttribute("innerText"));

            return lstDropdownElementsCaption;
        }
        public void ClickOnTeacherDropdown()
        {
            try
            {
                TeacherDropdownArrow.Click();
            }
            catch (Exception)
            { throw; }
        }

        public void ClickOnTeacherOption(int elementIndex)
        {
            Random random = new Random();
            //int randomOrgIndx = random.Next(1, elementIndex);
            int randomOrgIndx = elementIndex;

            var selectElement = new SelectElement(TeacherDropdown);
            selectElement.SelectByIndex(elementIndex);
        }
        public void InputTeacherTextBox(string FTText)
        {
            try
            {
                ElementAccessors.InputTextBox(FTText, DropdownSearchTextBox);
            }
            catch (Exception)
            { throw; }
        }

        public bool IsCreateRequestButtonExists()
        {
            isPassed = false;
            try
            { isPassed = CreateRequestButton.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }
        public bool IsCreateRequestButtonEnabled()
        {
            isPassed = false;
            try
            { isPassed = CreateRequestButton.Enabled; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }

        public string GetCreateRequestButtonCaption()
        {
            string createRequestButonCaption = string.Empty;
            try
            {
                createRequestButonCaption = CreateRequestButton.Text;
            }
            catch (Exception)
            { throw; }
            return createRequestButonCaption;
        }

        public void ClickOnCreateRequestButton()
        {
            try
            {
                ElementAccessors.DoClick(this.driver, CreateRequestButton);
            }
            catch (Exception)
            { throw; }
        }
        
    }
}
