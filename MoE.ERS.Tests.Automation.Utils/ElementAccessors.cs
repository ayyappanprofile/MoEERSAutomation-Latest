using MoE.ERS.Tests.Automation.Utils.ElementIdentifiers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MoE.ERS.Tests.Automation.Utils
{
    public class ElementAccessors
    {
        //Generic method to locate the webelement
        public static By GetWebElementByLocator(IWebDriver driver, String locator, String elementIdentifier)
        {
            By element = null;
            try
            {
                switch (locator.ToLower())
                {
                    case "classname":
                        element = By.ClassName(elementIdentifier);
                        break;
                    case "id":
                        element = By.Id(elementIdentifier);
                        break;
                    case "xpath":
                        element = By.XPath(elementIdentifier);
                        break;
                    case "linktext":
                        element = By.LinkText(elementIdentifier);
                        break;
                    case "partiallinktext":
                        element = By.PartialLinkText(elementIdentifier);
                        break;
                    case "name":
                        element = By.Name(elementIdentifier);
                        break;
                    case "cssselector":
                        element = By.CssSelector(elementIdentifier);
                        break;
                    case "tagname":
                        element = By.TagName(elementIdentifier);
                        break;
                    default:
                        throw new InvalidLocatorException("Locator is invalid, please provide valid locator " + locator);
                }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
            }
            catch (InvalidLocatorException ex)
            {
            }
            catch (Exception ex)
            {
                //throw new Exception("Not able to find web element with locator<b> " + locator + " = " + elementIdentifier + "</b> after 60 seconds of wait on the web page", e);
            }
            return element;
        }

        // Method: Wait for element to visible
        private static void WaitForElementVisible(IWebDriver driver, By by, int timeOutInSeconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.Seconds);
            }
            finally
            {
                stopwatch.Stop();
            }
        }
        public static void Wait(int timeinseconds)
        {
            try
            {
                System.Threading.Thread.Sleep(timeinseconds * 1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message + e.InnerException.StackTrace);
                Console.ReadLine();
            }
        }

        public static void DoClick(IWebDriver driver,IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
        public static void ClearTextBox(IWebElement elementTextBox)
        {
            try
            {
                elementTextBox.Clear();
            }
            catch (Exception)
            { throw; }
        }

        public static void InputTextBox(string inputText, IWebElement elementTextBox)
        {
            try
            {
                ElementAccessors.ClearTextBox(elementTextBox);
                elementTextBox.SendKeys(inputText);
            }
            catch (Exception)
            { throw; }
        }

        //public static String GetElementIdentifierFromResource(String pageIdentifier, String keyValue)
        //{
        //    try
        //    {
        //        String elementidentifier = ElementIdentifiers.ElementIdentifiers
        //        return elementidentifier;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Not able to get element identifier from page " + pageIdentifier + " - <b>" + keyValue + "</b>", e);
        //    }
        //}

        //public static void ClickElement(IWebDriver driver, String locator, String keyValue, String pageIdentifier)
        //{
        //    String elementidentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);
        //    try
        //    {
        //        By ele = GetWebElementByLocator(driver, locator, elementidentifier);
        //        new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(ele));
        //        driver.FindElement(ele).Click();
        //        Console.WriteLine("Clicked on locator " + elementidentifier);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Not able to click on an element having " + locator + " - <b>" + elementidentifier + "</b>", e);
        //    }
        //}

        //public static IWebElement GetWebElementByReplacingValue(IWebDriver driver, String locator, String keyValue, String oldChar, String newChar, String pageIdentifier)
        //{
        //    String elementidentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);

        //    try
        //    {
        //        elementidentifier = elementidentifier.Replace(oldChar, newChar);
        //        By ele = GetWebElementByLocator(driver, locator, elementidentifier);
        //        Console.WriteLine("Element is displayed");
        //        return driver.FindElement(ele);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Not able to return web element " + locator + " - <b>" + elementidentifier + "</b>", e);
        //    }

        //}

        //public static IList<IWebElement> GetListOfWebElements(IWebDriver driver, String property, String keyValue, String pageIdentifier)
        //{
        //    String elementIdentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);
        //    try
        //    {

        //        By elements = GetWebElementByLocator(driver, property, elementIdentifier);
        //        new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(elements));
        //        IList<IWebElement> ele = driver.FindElements(elements);
        //        return ele;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Not able get list of elements " + elementIdentifier, e);
        //    }

        //}

        //public static string GetCSSValue(IWebDriver driver, String locator, String keyValue, String cssValue, String pageIdentifier)
        //{
        //    String elementidentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);
        //    try
        //    {

        //        By ele = GetWebElementByLocator(driver, locator, elementidentifier);
        //        String css = driver.FindElement(ele).GetCssValue(cssValue);
        //        return css;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Not able get CSS value " + elementidentifier, e);
        //    }

        //}

        //public static string GetAttribute(IWebDriver driver, String locator, String keyValue, String attribute, String pageIdentifier)
        //{
        //    String elementidentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);
        //    try
        //    {
        //        By ele = GetWebElementByLocator(driver, locator, elementidentifier);
        //        String attributeValue = driver.FindElement(ele).GetAttribute(attribute);
        //        return attributeValue;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Not able get Attribute value " + elementidentifier, e);
        //    }
        //}

        //public static void ClickElementAfterReplacingKeyValue(IWebDriver driver, String locator, String keyValue, String oldChar, String newChar, String pageIdentifier)
        //{
        //    String elementidentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);
        //    elementidentifier = elementidentifier.Replace(oldChar, newChar);
        //    By ele = GetWebElementByLocator(driver, locator, elementidentifier);
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(ele));
        //    if (driver.FindElement(ele).Displayed)
        //    {
        //        driver.FindElement(ele).Click();
        //    }
        //    else
        //    {
        //        throw new Exception("The element " + keyValue + " is not Displayed.");
        //    }
        //}

        //public static String GetText(IWebDriver driver, String locator, String keyValue, String pageIdentifier)
        //{
        //    String elementIdentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);
        //    By ele = GetWebElementByLocator(driver, locator, elementIdentifier);
        //    String gettext = "";
        //    try
        //    {
        //        gettext = driver.FindElement(ele).Text;
        //        return gettext;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Not able to get text from an element having xpath - <b>" + elementIdentifier + "</b>", e);
        //    }

        //}

        //public static void EnterText(IWebDriver driver, String locator, String keyValue, String data, String pageIdentifier)
        //{
        //    String elementidentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);
        //    By ele = GetWebElementByLocator(driver, locator, elementidentifier);
        //    try
        //    {
        //        driver.FindElement(ele).Click();
        //        driver.FindElement(ele).Clear();
        //        driver.FindElement(ele).SendKeys(data);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Not able to enter text in textbox in an element having xpath " + elementidentifier, e);
        //    }
        //}

        public static void ScrollDown(IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0,Math.max(document.documentElement.scrollHeight," + "document.body.scrollHeight,document.documentElement.clientHeight));");
            }
            catch (Exception e)
            {
                throw new Exception("Not able scroll", e);
            }

        }

        public static void ScrollToTop(IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0,0)");
            }
            catch (Exception e)
            {
                throw new Exception("Not able scroll", e);
            }

        }

        //public static void JavaScriptScrollToViewElement(IWebDriver driver, String locator, String keyValue, String pageIdentifier)
        //{
        //    String elementidentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);
        //    By ele = GetWebElementByLocator(driver, locator, elementidentifier);

        //    (new WebDriverWait(driver, TimeSpan.FromSeconds(30))).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(ele));
        //    try
        //    {
        //        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", ele);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Not able scroll to the element " + elementidentifier, e);
        //    }
        //}

        //public static void SelectComboBoxByText(IWebDriver driver, String locator, String keyValue, String selectValue, String pageIdentifier)
        //{
        //    String elementidentifier = GetElementIdentifierFromResource(pageIdentifier, keyValue);
        //    By ele = GetWebElementByLocator(driver, locator, elementidentifier);
        //    try
        //    {
        //        SelectElement obj = new SelectElement(driver.FindElement(ele));
        //        obj.SelectByText(selectValue);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Element is not present in the combobox with text having xpath - <b>" + elementidentifier + "</b>", e);
        //    }
        //}

    }

}
