using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using UnitTest.Net.pages;

namespace UnitTest.Net.tests
{
    
  
    [TestFixture]
    class NewsArticleTests : BaseTest
    {
        private const string EXPECTED_HEADLINE_ARTICLE_TEXT = "WHO warns of 'very serious situation' in Europe";
        private const string EXPECTED_SEARCHED_FIRST_ARTICLE_TEXT = "World's End: World's End";
        private readonly string[] SECONDARY_ARTICLE_TEXT = {"Greece moves migrants to new camp after fire", "Navalny's aides say poison found on water bottle", "Why fires in Siberia threaten us all", "Protesters topple conquistador statue in Colombia", "Police 'requested heat ray' for White House protest" };
       
        [Test]
        public void CheckTheNameOfTheHeadlineArticle()
        {
            GetHomePage().ClickNewsPageButton();
            GetBasePage().WaitForPageLoadComplete();

            Assert.AreEqual(GetNewsPage().GetHeadlineArticleH3().Text, EXPECTED_HEADLINE_ARTICLE_TEXT);
        }
        
        [Test]
        public void CheckSecondaryArticleTitles()
        {
            IList<IWebElement> elementList = GetNewsPage().GetSecondaryArticleH3List();

            GetHomePage().ClickNewsPageButton();
            GetBasePage().WaitForPageLoadComplete();
         
            for(int i = 0; i < elementList.Count; i++)
            {
                for(int j = 0; j < SECONDARY_ARTICLE_TEXT.Length; j++)
                {
                    Assert.AreEqual(elementList[i].Text, SECONDARY_ARTICLE_TEXT[i]);
                }
            }          
        }

        [Test]
        public void SendStoresCategoryTextToSearchBarAndCheckTheNameOfTheFirstArticleAgainstASpecifiedValue()
        {
            GetHomePage().ClickNewsPageButton();
            GetBasePage().WaitForPageLoadComplete();
            GetHomePage().SearchByKeyWord(GetNewsPage().GetCategoryLinkOfHeadlineArticleSpan().Text);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
            executor.ExecuteScript("arguments[0].click();", GetHomePage().GetSearchButton());
            GetBasePage().WaitForPageLoadComplete();

            Assert.AreEqual(GetNewsPage().GetFirstArticleSearchedSpanText(), EXPECTED_SEARCHED_FIRST_ARTICLE_TEXT);
        }
    }
}
