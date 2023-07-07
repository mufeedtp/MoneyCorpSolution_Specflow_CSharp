using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace NopCommerce.TestBase
{
    public class ComponentGneric
    {
        //public IWebDriver driver { get; }
        private IWebDriver driver;
        private By ComponentLocator;
        private string ComponentName;
        private IWebElement SeleniumElement;
        double WaitInSecond = 20;

        public ComponentGneric(IWebDriver driver, By componentLocator,string componentName)
        {
            this.driver = driver;
            ComponentLocator = componentLocator;
            //SeleniumElement = (IWebElement)componentLocator;
            ComponentName = componentName;
            //PageFactory.InitElements(driver, this);
        }
        
        public void waitForElement(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitInSecond));
                SeleniumElement = wait.Until(ExpectedConditions.ElementToBeClickable(ComponentLocator));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Click()
        {
            try
            {
                scrollToElement();
                //SeleniumElement = driver.FindElement(ComponentLocator);
                //SeleniumElement = waitForElement(SeleniumElement);
                //if(SeleniumElement !=null )
                //{ 
                //SeleniumElement.Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SeleniumElement);
                //extent.SetStepStatusPass($"Clicked on the {ComponentName}.");
                //serilog.Log_Info($"Clicked on the {ComponentName}.");
                //}
            }
            catch (Exception ex)
            {
                //extent.SetStepStatusFail(ex);
                //serilog.Log_Error(ex.Message);
                throw ex;
            }

        }

        public void enterText(string input)
        {
            try
            {
                scrollToElement();
                //SeleniumElement = driver.FindElement(ComponentLocator);
                //SeleniumElement = waitForElement(SeleniumElement);
                //if (SeleniumElement != null )
                //{
                SeleniumElement.Clear();
                SeleniumElement.SendKeys(input);
                //extent.SetStepStatusPass($"Entered text [{input.ToString()}] in the {ComponentName}.");
                //serilog.Log_Info($"Entered text [{input.ToString()}] in the {ComponentName}.");
                //}
            }
            catch (Exception ex){

                //extent.SetStepStatusFail(ex);
                //serilog.Log_Error(ex.Message);
                throw ex;
            }

        }

        public bool isElementPresent()
        {
            try
            {
                //SeleniumElement = driver.FindElement(ComponentLocator);
                //SeleniumElement = waitForElement(SeleniumElement);
                scrollToElement();
                return (SeleniumElement.Displayed) ? true : false;
            }
            catch 
            {
                //BaseClass.extent.SetStepStatusFail(ex);
                //throw ex;
            }
            return false;
        }

        public void pressEnter()
        {
            try
            {
                scrollToElement();
                //SeleniumElement = driver.FindElement(ComponentLocator);
                //SeleniumElement = waitForElement(SeleniumElement);
                SeleniumElement.SendKeys(Keys.Enter);
                //extent.SetStepStatusPass($"Pressed Enter key in the {ComponentName}.");
                //serilog.Log_Info($"Pressed Enter key in the {ComponentName}.");
                
            }
            catch(Exception ex)
            {
                //extent.SetStepStatusFail(ex);
                //serilog.Log_Error(ex.Message);
                throw ex;
            }
        }

        public void scrollToElement()
        {
            try
            {
                waitForElement(SeleniumElement);
                //SeleniumElement = driver.FindElement(ComponentLocator);
                //if (SeleniumElement != null)
                //{
                IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", SeleniumElement);
                //serilog.Log_Info($"Found  {ComponentName} = {ComponentLocator}.");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void mouseHoverAndClick()
        {
            try
            {
                scrollToElement();
                //SeleniumElement = driver.FindElement(ComponentLocator);
                //SeleniumElement = waitForElement(SeleniumElement);
                Actions actions = new Actions(driver);
                actions.MoveToElement(SeleniumElement).Click().Perform();
                //extent.SetStepStatusPass($"Mouse overed on the {ComponentName} and clicked - {ComponentLocator}.");
                //serilog.Log_Info($"Mouse overed on the {ComponentName} and clicked - {ComponentLocator}.");

            }
            catch (Exception ex)
            {
                //extent.SetStepStatusFail(ex);
                //serilog.Log_Error(ex.Message);
                throw ex;
            }
        }

        public string GetText()
        {
            var text = "";
            try
            {
                scrollToElement();
                //SeleniumElement = driver.FindElement(ComponentLocator);
                //SeleniumElement = waitForElement(SeleniumElement);
                string elementText = SeleniumElement.Text;
                //extent.SetStepStatusPass($"Retrieved text from the {ComponentName} - {elementText}.");
                //serilog.Log_Info($"Retrieved text from the {ComponentName} - {elementText}.");
                return elementText;            
                
            }
            catch (Exception ex)
            {
                //extent.SetStepStatusFail(ex);
                //serilog.Log_Error(ex.Message);
                throw ex;
            }
            return text;
        }

    }
}