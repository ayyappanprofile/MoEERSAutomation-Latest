using MoE.ERS.Tests.Automation.BaseLibrary;
using MoE.ERS.Tests.Automation.Utils;
using MoE.ERS.Tests.Automation.Utils.ElementIdentifiers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace MoE.ERS.Tests.Automation.Pages
{
    public class WelcomePage : PageBase
    {
        IWebDriver driver;
        bool isPassed = false;
        public WelcomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }


        [FindsBy(How = How.Id, Using = ElementIdentifiers.SIGNIN_BUTTON)]
        public IWebElement SignIn { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.MAKEANEWREQUEST_BUTTON)]
        public IWebElement MakeANewRequest { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.VIEWALLREQUEST_BUTTON)]
        public IWebElement ViewAllRequests { get; set; }

        [FindsBy(How = How.XPath, Using = ElementIdentifiers.CENTER_ALIGNED_CONTAINER)]
        public IWebElement ButtonsContainer { get; set; }


        public bool IsMakeANewRequestButtonDisplayed()
        {
            isPassed = false;
            try
            { isPassed = MakeANewRequest.Displayed; }
            catch(Exception)
            { isPassed = false; }
            return isPassed;          
        }
        public bool IsViewAllRequeststButtonDisplayed()
        {
            isPassed = false;
            try
            { isPassed = ViewAllRequests.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }
        public string GetMakeANewRequestCaption()
        {
            string makeANewRequestCap = string.Empty;            
            try
            {
                makeANewRequestCap = MakeANewRequest.Text;
            }
            catch(Exception)
            { throw; }
            return makeANewRequestCap;
        }
        public string GetViewAllRequestsCaption()
        {
            string viewAllRequestsCap = string.Empty;
            try
            {
                viewAllRequestsCap = ViewAllRequests.Text;
            }
            catch (Exception)
            { throw; }
            return viewAllRequestsCap;
        }
        public bool IsMakeANewRequestButtonEnabled()
        {
            isPassed = false;
            try
            { isPassed = MakeANewRequest.Enabled; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }
        public bool IsViewAllRequestsButtonEnabled()
        {
            isPassed = false;
            try
            { isPassed = ViewAllRequests.Enabled; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;
        }
        public bool AreRequestButtonsAlignedCenter()
        {
            isPassed = false;
            try
            { isPassed = ButtonsContainer.Displayed; }
            catch (Exception)
            { isPassed = false; }
            return isPassed;            
        }
        public void ClickOnMakeARequestButton()
        {            
            try
            {
                ElementAccessors.DoClick(this.driver, MakeANewRequest);
                ElementAccessors.Wait(2);                           
            }
            catch (Exception)
            { throw; }           
        }       
    }
}
