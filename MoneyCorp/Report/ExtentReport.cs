using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MoneyCorp.Report
{
    public class ExtentReport
    {
        public static ExtentReports extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;
        public static ExtentTest _step;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        public static string testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Reprot";
            htmlReporter.Config.DocumentTitle = "Automation status Report";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();

            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
            extentReports.AddSystemInfo("Application", "Youtube");
            extentReports.AddSystemInfo("Browser", "chrome");
            extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            extentReports.Flush();
        }

        public static void LogInfo(string stepDescription)
        {
            _step.Log(Status.Info, stepDescription);
        }

        public static void LogError(string stepDescription)
        {
            _step.Log(Status.Error, stepDescription);
        }
        public static void ExtentFailStep(ScenarioContext scenarioContext)
        {
            string exceptionMessage = scenarioContext.TestError.Message;
            string exceptionInfo = scenarioContext.TestError.ToString();
            var exceptionSummary = string.Format(exceptionMessage + "<br>" + "<details>" + "<summary>" + "<i>" + "<font color=" + "red>" +
                "Click here to see more details" + "</font>" + "</i>" + "</summary>" + exceptionInfo.Replace(" at ", "<br> &nbsp&nbsp at ") + "</details>");
            _step.Fail(exceptionSummary);
        }
    }
}