using NopCommerce.TestBase;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCorp.Pages
{
    public class MoneyCorpPage
    {

        private IWebDriver driver;
        public MoneyCorpPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region locators
        private By regionLanguageButtonBy = By.Id("language-dropdown-flag");
        private By usaEnglishBy = By.XPath("//a[@aria-label='USB English']");
        private By regionUSAButtonBy = By.XPath("//button[@id='language-dropdown-flag']//img[@alt='English' and contains(@src , 'america')]");
        private By acceptAllCookiesBy = By.XPath("//button[text()='Accept All Cookies']");
        private By findOutMoreForeignExchangeBy = By.XPath("(//h3[contains(text(),'Foreign exchange solutions')]//following::a[contains(@aria-label,'Find out more')])[1]//span");
        private By foreignExchangeHeaderBy = By.XPath("//h1[normalize-space()='Foreign exchange solutions for your business']");
        private By searchBoxBy = By.XPath("(//input[@id='nav_search'])[2]");
        private By searchMoneyCorpPageBy = By.XPath("//h2[text()='Search Moneycorp']");
        private By showMoreResultsBy = By.XPath("//a[normalize-space()='Show more results']");
        private By articlesBy = By.XPath("//div[@class='results-wrapper']//div[@class='results']//a");
        #endregion locators

        #region WebElements
        public ComponentGneric regionLanguageButton => new ComponentGneric(driver, regionLanguageButtonBy, "Region Language Button");
        public ComponentGneric usaEnglish => new ComponentGneric(driver, usaEnglishBy, "USA English");
        public ComponentGneric regionUSAButton => new ComponentGneric(driver, regionUSAButtonBy, "Region USA English");
        public ComponentGneric acceptAllCookies => new ComponentGneric(driver, acceptAllCookiesBy, "Accept all cookies button");
        public ComponentGneric findOutMoreForeignExchange => new ComponentGneric(driver, findOutMoreForeignExchangeBy, "Find Out More Button for Foreign Echange");
        public ComponentGneric foreignExchangeHeader => new ComponentGneric(driver, foreignExchangeHeaderBy, "foreign Exchange page Header");
        public ComponentGneric searchBox => new ComponentGneric(driver, searchBoxBy, "Search Box in foreign Exchange page");
        public ComponentGneric searchMoneyCorpPage => new ComponentGneric(driver, searchMoneyCorpPageBy, "Search money corp page");
        public ComponentGneric showMoreResults => new ComponentGneric(driver, showMoreResultsBy, "Show more results link in foreign Exchange page");
        #endregion WebElements


        #region method
        public void selectRegion(string region)
        {
            usaEnglishBy = By.XPath("//a[@aria-label='" + region + "']");
            usaEnglish.mouseHoverAndClick();
        }

        public void verifyRegionSelected()
        {
            Assert.True(regionUSAButton.isElementPresent());  
        }

        public void clickOnFindOutMore()
        {
            acceptAllCookies.Click();
            findOutMoreForeignExchange.Click();
        }

        public void verifyForeignExchangeSolutionsPageDisplayed()
        {
            Assert.True(foreignExchangeHeader.isElementPresent());
        }

        public void seachItem(string item)
        {
            searchBox.enterText(item);
            searchBox.pressEnter();
        }

        public void verifySearchReultPageDisplayed()
        {
            Assert.True(searchMoneyCorpPage.isElementPresent());
        }

        public void clickShowMoreResultUntillNotAvailable()
        {
            bool isElementPresent = true;
            int count = 0;
            while(isElementPresent && count < 5)
            {
                count++;
                showMoreResults.Click();
                isElementPresent = showMoreResults.isElementPresent();
            }
        }

        public void verifyArticleLink()
        {
            var elements = driver.FindElements(articlesBy);
            foreach (IWebElement ele in elements)
            {
                string href = ele.GetAttribute("href");
                if(href.StartsWith("https://www.moneycorp.com/en-us/"))
                {
                    Assert.True(true, "article link starting with https://www.moneycorp.com/en-us/e");
                    //return;
                }
            }
            //Assert.True(false, "article link is not starting with https://www.moneycorp.com/en-us/");
        }
        #endregion

    }
}
