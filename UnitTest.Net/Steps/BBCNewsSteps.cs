using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using FinalTaskBBC.tests;

namespace FinalTaskBBC.Steps
{
    [Binding]
     public class BBCNewsSteps : BaseTest
    {
        private const string EXPECTED_HEADLINE_ARTICLE_TEXT = "WHO warns of 'very serious situation' in Europe";
        private const string EXPECTED_SEARCHED_FIRST_ARTICLE_TEXT = "World's End: World's End";
        private readonly string[] SECONDARY_ARTICLE_TEXT = { "Greece moves migrants to new camp after fire", "Navalny's aides say poison found on water bottle", "Why fires in Siberia threaten us all", "Protesters topple conquistador statue in Colombia", "Police 'requested heat ray' for White House protest" };

        [Given(@"the BBC Home page is open")]
        public void GivenTheBBCHomePageIsOpen()
        {
            CreateDriver();
            GetBasePage().WaitForPageLoadComplete();
        }

        [When(@"I go to News page")]
        public void WhenIGoToNewsPage()
        {
            GetHomePage().ClickNewsPageButton();
            GetBasePage().WaitForPageLoadComplete();
        }

        [When(@"i put copied name to search input")]
        public void WhenIPutCopiedNameToSearchInput()
        {
            GetHomePage().SearchByKeyWord(GetNewsPage().GetCategoryLinkOfHeadlineArticleSpan().Text);
        }

        [When(@"i click search")]
        public void WhenIClickSearch()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
            executor.ExecuteScript("arguments[0].click();", GetHomePage().GetSearchButton());
            GetBasePage().WaitForPageLoadComplete();
        }

        [Then(@"the headline article name loaded succesfully")]
        public void ThenTheHeadlineArticleNameLoadedSuccesfully()
        {
            Assert.AreEqual(GetNewsPage().GetHeadlineArticleH3().Text, EXPECTED_HEADLINE_ARTICLE_TEXT);
        }

        [Then(@"the seconady articles name loaded succesfully")]
        public void ThenTheSeconadyArticlesNameLoadedSuccesfully()
        {
            IList<IWebElement> elementList = GetNewsPage().GetSecondaryArticleH3List();

            for (int i = 0; i < elementList.Count; i++)
            {
                for (int j = 0; j < SECONDARY_ARTICLE_TEXT.Length; j++)
                {
                    Assert.AreEqual(elementList[i].Text, SECONDARY_ARTICLE_TEXT[i]);
                }
            }
        }
       
        [Then(@"the name of the first article against a specified value")]
        public void ThenTheSameArticleIsOpen()
        {
            Assert.AreEqual(GetNewsPage().GetFirstArticleSearchedSpanText(), EXPECTED_SEARCHED_FIRST_ARTICLE_TEXT);
        }


    }
}





