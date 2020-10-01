using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using FinalTaskBBC.tests;

namespace FinalTaskBBC.Steps
{
    [Binding]
    public class BBCSendStorySteps : BaseTest
    {
        [Given(@"I go to News")]
        public void GivenIGoToNews()
        {
            HomePage.ClickNewsPageButton();
            BasePage.WaitForPageLoadComplete();

            ClosePopupWindow();
        }

        [Given(@"click on Coronavirus tab")]
        public void GivenClickOnCoronavirusTab()
        {
            CoronavirusPage.ClickCoronovirusButton();
            BasePage.WaitForPageLoadComplete();
        }

        [Given(@"click on Your Coronavirus Stories tab")]
        public void GivenClickOnYourCoronavirusStoriesTab()
        {
            CoronavirusPage.ClickYouCoronovirusStoriesButton();
            BasePage.WaitForPageLoadComplete();
        }

        [Given(@"go to “How to share with BBC news”")]
        public void GivenGoToHowToShareWithBBCNews()
        {
            CoronavirusPage.ClickHowToShareBBCNewsButton(); 
        }

        [When(@"fill in the information on the bottom")]
        public void WhenFillInTheInformationOnTheBottom(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            CoronavirusPage.LogInKeys(
                (string)data.Story,
                (string)data.Name,
                (string)data.EmailAddress,
                Convert.ToString(data.ContactNumber),
                (string)data.Location);
        }

        [When(@"i click checkbox input in the form")]
        public void WhenICheckLogInCheckboxField()
        {
            CoronavirusPage.LogInCheckboxCheck();
        }

        [When(@"click Submit")]
        public void WhenClickSubmit()
        {
            CoronavirusPage.ClickSubmit();
            BasePage.ImplicitWait();
        }

        [Then(@"the error message is exist")]
        public void ThenTheStoryIsNotSent()
        {
            Assert.IsTrue(CoronavirusPage.IsErrorMessageExist());
        }
    }
}
