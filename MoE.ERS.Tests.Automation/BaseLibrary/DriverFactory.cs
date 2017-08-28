using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Remote;

namespace MoE.ERS.Tests.Automation.BaseLibrary
{
    public class DriverFactory
    {
        public static IWebDriver Create(string browserType)
        {
            string driverPath = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf("Debug") + 5);
            switch (browserType.ToUpper())
            {
                case "CHROME":
                    return new ChromeDriver(driverPath);
                case "IE":                    
                    return new InternetExplorerDriver(driverPath, (InternetExplorerOptions)GetDriverOptions());               
                default:
                    return new InternetExplorerDriver();
            }
        }

        public static DriverOptions GetDriverOptions()
        {
            var options = new InternetExplorerOptions();
            options.EnsureCleanSession = true;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.IgnoreZoomLevel = true;            
            return options;
        }
    }
}
