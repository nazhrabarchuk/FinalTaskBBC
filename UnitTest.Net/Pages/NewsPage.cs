using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace UnitTest.Net.pages
{

   public class NewsPage : BasePage
    {
        public NewsPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#1']//div[contains(@class,'gs-u-display-inline-block@m')]//h3")]
        private IWebElement HeadlineArticleH3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='gel-wrap gs-u-pt+']//div[contains(@class,'nw-c-top-stories__secondary-item')]//h3")]
        private IList<IWebElement> SecondaryArticleH3List { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#1']//div[contains(@class,'gs-u-display-inline-block@m')]//li[@class='nw-c-promo-meta']/a/span")]
        private IWebElement CategoryLinkOfHeadlineArticleSpan { get; set; }

        [FindsBy(How = How.XPath, Using = "//main[@id='main-content']//ul[@role='list']/li[1]//a/span")]
        private IWebElement FirstArticleSearchedSpan { get; set; }
       
        public IWebElement GetHeadlineArticleH3()
        {
            return HeadlineArticleH3;
        }

        public IList<IWebElement> GetSecondaryArticleH3List()
        {
            return SecondaryArticleH3List;
        }

        public IWebElement GetCategoryLinkOfHeadlineArticleSpan()
        {
            return CategoryLinkOfHeadlineArticleSpan;
        }

        public string GetFirstArticleSearchedSpanText()
        {
            return FirstArticleSearchedSpan.Text;
        }
    }
}
