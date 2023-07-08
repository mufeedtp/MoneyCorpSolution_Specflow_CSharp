using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using MoneyCorp.Helper;
using MoneyCorp.Report;
using AventStack.ExtentReports.Gherkin.Model;

namespace MoneyCorp.Hooks
{
    [Binding]
    public class Hooks : ExtentReport
    {
        public IWebDriver driver;

        [BeforeTestRun]
        public static void beforeTestRun()
        {
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void afterTestRun()
        {
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void beforeFeature(FeatureContext featureContext)
        {
            _feature = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
        }

        [AfterFeature]
        public static void afterFeature(FeatureContext featureContext)
        {
            

        }

        [BeforeScenario]
        public void BeforeScenarios(ScenarioContext scenarioContext)
        {
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
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

        [BeforeStep]
        public void beforeStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            if(stepType == "Given")
            {
                _step = _scenario.CreateNode<Given>(stepName); 
            }
            else if (stepType == "When")
            {
                _step = _scenario.CreateNode<When>(stepName);
            }
            else if (stepType == "Then")
            {
                _step = _scenario.CreateNode<Then>(stepName);
            }
            else if (stepType == "And")
            {
                _step = _scenario.CreateNode<And>(stepName);
            }
        }

        [AfterStep]
        public void afterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            //string stepName = scenarioContext.StepContext.StepInfo.Text;

           if(scenarioContext.TestError != null)
            {
                if(stepType == "Given")
                {
                    ExtentFailStep(scenarioContext);
                }
                else if (stepType == "When")
                {
                    ExtentFailStep(scenarioContext);
                }
                else if (stepType == "Then")
                {
                    ExtentFailStep(scenarioContext);
                }
                else if (stepType == "And")
                {
                    ExtentFailStep(scenarioContext);
                }
            }
        }
    }
}
