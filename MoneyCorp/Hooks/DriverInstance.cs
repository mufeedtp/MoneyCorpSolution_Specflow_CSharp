using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCorp.Hooks
{
    public class DriverInstance
    {
        private static IWebDriver _driver;
        private static readonly object _lockObject = new object();

        private DriverInstance()
        {
            InitializeWebDriver();
        }

        public static IWebDriver getDriver
        {
            get
            {
                if (_driver == null)
                {
                    lock (_lockObject)
                    {
                        if (_driver == null)
                        {
                            new DriverInstance();
                        }
                    }
                }
                return _driver;
            }
        }

        private void InitializeWebDriver()
        {
            _driver = new ChromeDriver(); 
        }

        public static void QuitDriver()
        {
            lock (_lockObject)
            {
                if (_driver != null)
                {
                    _driver.Quit();
                    _driver = null;
                }
            }
        }

    }
}
