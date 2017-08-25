using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.IO;

namespace MoE.ERS.Tests.Automation.Utils
{
    public sealed class GetScreenShot
    {
        private static GetScreenShot instance = null;

        private GetScreenShot()
        { }

        public static GetScreenShot GetInstance()
        {
            if (instance == null)
                instance = new GetScreenShot();
            return instance;
        }
        public string ScreenshotPath
        { get; set; }       
        
        public void Capture(IWebDriver webDriver, string screenShotName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)webDriver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();          
            string finalPath = ScreenshotPath + screenShotName + ".png";
            string localPath = new Uri(finalPath).LocalPath;

            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
        }
    }
}
