using System;
using MoE.ERS.Tests.Automation.BaseLibrary;
using MoE.ERS.Tests.Automation.Utils.ElementIdentifiers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MoE.ERS.Tests.Automation.Entities;
using MoE.ERS.Tests.Automation.Utils;

namespace MoE.ERS.Tests.Automation.Pages
{
    //Login Page.
    public class LogInPage : PageBase
    {
        IWebDriver driver;
        public LogInPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }       

        [FindsBy(How = How.Id, Using = ElementIdentifiers.ANOTHERUSER_BUTTON)]
        public IWebElement AnotherUserLink { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.USERNAME_TEXT)]
        public IWebElement UserNameText { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.PASSWORD_TEXT)]
        public IWebElement PasswordText { get; set; }

        [FindsBy(How = How.Id, Using = ElementIdentifiers.SIGNIN_BUTTON)]
        public IWebElement SignInButton { get; set; }

        public void LogIn(string userName,string password)
        {
            try
            {                
                if (AnotherUserLink.Displayed)
                    ElementAccessors.DoClick(this.driver, AnotherUserLink);
            }
            catch (Exception)
            {  }
            finally
            {
                UserNameText.SendKeys(userName);
                PasswordText.SendKeys(password);
                ElementAccessors.Wait(4);
                ElementAccessors.DoClick(this.driver, SignInButton);
                ElementAccessors.Wait(4);
            }
        }
    }
}
