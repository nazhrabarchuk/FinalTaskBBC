using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTaskBBC.pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//div[@id='orb-nav-links']//a[contains(text(),'News')]")]
        private IWebElement NewsPageButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        private IWebElement SearchInput { get; set; }    

        [FindsBy(How = How.XPath, Using = "//button[@id='orb-search-button']")]
        private IWebElement SearchButton { get; set; }

        public void ClickNewsPageButton() {
            NewsPageButton.Click();
        }

        public void PutKeywordToSearchInput(string keyword)
        {
            SearchInput.SendKeys(keyword);      
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }
    }
}
