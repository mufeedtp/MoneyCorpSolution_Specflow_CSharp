using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using MoneyCorp.Helper;

namespace MoneyCorp.Hooks
{
    [Binding]
    public class Hooks
    {
        public IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenarios()
        {
            Tools.KillProcess("chromedriver");
            driver = DriverInstance.getDriver;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [AfterScenario]
        public void AfterScenarios()
        {
            DriverInstance.QuitDriver();
        }

    }
}
