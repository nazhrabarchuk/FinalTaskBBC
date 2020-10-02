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
        private const string EXPECTED_HEADLINE_ARTICLE_TEXT = "Trump and Melania test positive for coronavirus";
        private const string EXPECTED_SEARCHED_FIRST_ARTICLE_TEXT = "US & Canada";
        private readonly List<string> SECONDARY_ARTICLE_TEXT = new List<string> {
            "Armenia 'ready' for Nagorno-Karabakh truce talks",
            "EU warns Turkey of sanctions over 'provocations'",
            "Lebanon seeks arrest of Beirut blast ship pair",
            "Nasa to launch new $23m toilet to space station",
            "Deaths at Saudi migrant detention centre - report"

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

            ClosePopupWindow();
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
            bool IsEquals = true;

            foreach(IWebElement elem in elementList)
            {
                if (!(SECONDARY_ARTICLE_TEXT.Contains(elem.Text)))
                {
                    IsEquals = false;
                }
            }
            Assert.IsTrue(IsEquals);
        }
       
        [Then(@"the title of the first article is equal to the searched value")]
        public void ThenTheSameArticleIsOpen()
        {
            Assert.AreEqual(NewsPage.FirstArticleSearchedSpan.Text, EXPECTED_SEARCHED_FIRST_ARTICLE_TEXT);
        }
    }
}





