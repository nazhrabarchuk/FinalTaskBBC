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
        private readonly string[] SECONDARY_ARTICLE_TEXT = { 
            "Greece moves migrants to new camp after fire",
            "Navalny's aides say poison found on water bottle",
            "Why fires in Siberia threaten us all",
            "Protesters topple conquistador statue in Colombia",
            "Police 'requested heat ray' for White House protest"
        };

        [Given(@"the BBC Home page is open")]
        public void GivenTheBBCHomePageIsOpen()
        {
            CreateDriver();
        }

        [When(@"I go to News page")]
        public void WhenIGoToNewsPage()
        {
            HomePage.ClickNewsPageButton();
            BasePage.WaitForPageLoadComplete();
        }

        [When(@"i put copied name to search input")]
        public void WhenIPutCopiedNameToSearchInput()
        {
            HomePage.PutKeywordToSearchInput(NewsPage.CategoryLinkOfHeadlineArticleSpan.Text);
        }

        [When(@"i click search")]
        public void WhenIClickSearch()
        {
            HomePage.ClickSearchButton();
            BasePage.WaitForPageLoadComplete();
        }

        [Then(@"the headline article name loaded succesfully")]
        public void ThenTheHeadlineArticleNameLoadedSuccesfully()
        {
            Assert.AreEqual(NewsPage.HeadlineArticleH3.Text, EXPECTED_HEADLINE_ARTICLE_TEXT);
        }

        [Then(@"the seconady articles name loaded succesfully")]
        public void ThenTheSeconadyArticlesNameLoadedSuccesfully()
        {
            IList<IWebElement> elementList = NewsPage.SecondaryArticleH3List;

            for (int i = 0; i < elementList.Count; i++)
            {
                for (int j = 0; j < SECONDARY_ARTICLE_TEXT.Length; j++)
                {
                    Assert.AreEqual(elementList[i].Text, SECONDARY_ARTICLE_TEXT[i]);
                }
            }
        }
       
        [Then(@"the title of the first article is equal to the searched value")]
        public void ThenTheSameArticleIsOpen()
        {
            Assert.AreEqual(NewsPage.FirstArticleSearchedSpan.Text, EXPECTED_SEARCHED_FIRST_ARTICLE_TEXT);
        }
    }
}





