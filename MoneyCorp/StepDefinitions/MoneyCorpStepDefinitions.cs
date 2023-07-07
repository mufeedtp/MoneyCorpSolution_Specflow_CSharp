using MoneyCorp.Hooks;
using MoneyCorp.Pages;
using OpenQA.Selenium;
namespace MoneyCorp.StepDefinitions
{
    [Binding]
    public sealed class MoneyCorpStepDefinitions 
    {
        private IWebDriver driver;
        private MoneyCorpPage moneycorppage;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        public MoneyCorpStepDefinitions()
        {
            this.driver = DriverInstance.getDriver;
            moneycorppage = new MoneyCorpPage(driver);
        }

        [Given(@"MoneyCorp website opened")]
        public void GivenLaunchMoneyCorpWebsite()
        {
            driver.Url = "https://www.moneycorp.com/";
        }

        [When(@"Select the region and language ""([^""]*)""")]
        public void WhenSelectTheRegionAndLanguage(string region)
        {
            moneycorppage.selectRegion(region);
        }

        
        [Then(@"verify the selected region is displayed")]
        public void ThenVerifyTheSelectedRegionIsDisplayed()
        {
            moneycorppage.verifyRegionSelected();
        }

        [Then(@"click on find out more for Foreign exchange Solutions")]
        public void ThenClickOnFindOutMoreForForeignExchangeSolutions()
        {
            moneycorppage.clickOnFindOutMore();
        }

        [Then(@"verify Foreign exchange Solutions page arrived")]
        public void ThenVerifyForeignExchangeSolutionsPageArrived()
        {
            moneycorppage.verifyForeignExchangeSolutionsPageDisplayed();
        }

        [Then(@"Search ""([^""]*)""")]
        public void ThenSearch(string searchItem)
        {
            moneycorppage.seachItem(searchItem);
        }

        [Then(@"Verify search result page is arrived")]
        public void ThenVerifySearchResultPageIsArrived()
        {
            moneycorppage.verifySearchReultPageDisplayed();
        }

        [Then(@"click show more results until not available")]
        public void ThenClickShowMoreResultsUntilNotAvailable()
        {
            moneycorppage.clickShowMoreResultUntillNotAvailable();
        }

        [Then(@"verify all articles has link starting with")]
        public void ThenVerifyAllArticlesHasLinkStartingWith()
        {
            moneycorppage.verifyArticleLink();            
        }


    }
}