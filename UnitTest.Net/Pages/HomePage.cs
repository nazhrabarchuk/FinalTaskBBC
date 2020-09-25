using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTest.Net.pages
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

        public void SearchByKeyWord(string keyword)
        {
            SearchInput.SendKeys(keyword);
        }

        public IWebElement GetSearchButton()
        {
            return SearchButton;
        }

    }
}
