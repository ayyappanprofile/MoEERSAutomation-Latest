using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MoE.ERS.Tests.Automation.Entities;
using MoE.ERS.Tests.Automation.DataSource;


namespace MoE.ERS.Tests.Automation.BaseLibrary
{
    public abstract class PageBase
    {
       
        internal PageBase(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
       
        internal void TestLogin()
        { }
    }
}
