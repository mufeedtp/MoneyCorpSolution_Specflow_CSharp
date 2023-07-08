using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using MoneyCorp.Report;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace NopCommerce.TestBase
{
    public class ComponentGneric
    {
        private IWebDriver driver;
        private By ComponentLocator;
        private string ComponentName;
        private IWebElement SeleniumElement;
        double WaitInSecond = 20;

        public ComponentGneric(IWebDriver driver, By componentLocator,string componentName)
        {
            this.driver = driver;
            ComponentLocator = componentLocator;
            ComponentName = componentName;
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
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SeleniumElement);
                ExtentReport.LogInfo($"Clicked on the { ComponentName }.");
            }
            catch (Exception ex)
            {
                ExtentReport.LogError(ex.ToString());
            }

        }

        public void enterText(string input)
        {
            try
            {
                scrollToElement();
                SeleniumElement.Clear();
                SeleniumElement.SendKeys(input);
            }
            catch (Exception ex){
                throw ex;
            }

        }

        public bool isElementPresent()
        {
            try
            {
                scrollToElement();
                return (SeleniumElement.Displayed) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public void pressEnter()
        {
            try
            {
                scrollToElement();
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
                IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", SeleniumElement);
                ExtentReport.LogInfo($"Scorlled into the {ComponentName} elemnet to visible");
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
                scrollToElement();;
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