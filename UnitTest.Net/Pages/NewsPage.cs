using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace FinalTaskBBC.pages
{
   public class NewsPage : BasePage
    {
        public NewsPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#1']//h3")]
        public IWebElement HeadlineArticleH3 { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='gel-wrap gs-u-pt+']//div[contains(@class,'nw-c-top-stories__secondary-item')]//h3")]
        public IList<IWebElement> SecondaryArticleH3List { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#1']//div[contains(@class,'gs-c-promo-body')]//ul//li[@class='nw-c-promo-meta']/a/span")]
        public IWebElement CategoryLinkOfHeadlineArticleSpan { get; private set; }

        [FindsBy(How = How.XPath, Using = "//main[@id='main-content']//ul[@role='list']/li[1]//div[contains(.//dt,'Section')]//span[@type='category']/span")]
        public IWebElement FirstArticleSearchedSpan { get; private set; }
    }
}
