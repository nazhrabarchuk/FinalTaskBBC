using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UnitTest.Net.tests;

namespace UnitTest.Net.Steps
{
    [Binding]
    public class BBCSendStorySteps : BaseTest
    {
        [Given(@"I go to News")]
        public void GivenIGoToNews()
        {
            GetHomePage().ClickNewsPageButton();
            GetBasePage().WaitForPageLoadComplete();
        }

        [Given(@"click on Coronavirus tab")]
        public void GivenClickOnCoronavirusTab()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
            executor.ExecuteScript("arguments[0].click();", GetCoronavirusPage().GetCoronovirusButton());
            GetBasePage().WaitForPageLoadComplete();
        }

        [Given(@"click on Your Coronavirus Stories tab")]
        public void GivenClickOnYourCoronavirusStoriesTab()
        {
            IJavaScriptExecutor executor2 = (IJavaScriptExecutor)GetDriver();
            executor2.ExecuteScript("arguments[0].click();", GetCoronavirusPage().GeYouCoronovirusStoriesButton());
            GetBasePage().WaitForPageLoadComplete();
        }

        [Given(@"go to “How to share with BBC news”")]
        public void GivenGoToHowToShareWithBBCNews()
        {
            IJavaScriptExecutor executor3 = (IJavaScriptExecutor)GetDriver();
            executor3.ExecuteScript("arguments[0].click();", GetCoronavirusPage().GetHowToShareBBCNewsButton());
            GetBasePage().WaitForPageLoadComplete();

            if (GetBasePage().GetSignInButton().Displayed)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
                executor.ExecuteScript("arguments[0].click();", GetBasePage().GetSignInButton());
            }
        }

        [When(@"fill in the information on the bottom")]
        public void WhenFillInTheInformationOnTheBottom(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            GetCoronavirusPage().LogInKeys((string)data.Story, (string)data.Name, (string)data.EmailAddress, (int)data.ContactNumber, (string)data.Location);
        }

        [When(@"i check logIn checkbox field")]
        public void WhenICheckLogInCheckboxField()
        {
            GetCoronavirusPage().LogInCheckboxCheck();
        }

        [When(@"click Submit")]
        public void WhenClickSubmit()
        {
            GetCoronavirusPage().ClickSubmit();
            GetBasePage().ImplicitWait();
        }

        [Then(@"the story is not sent")]
        public void ThenTheStoryIsNotSent()
        {
            Assert.IsTrue(GetCoronavirusPage().IsErrorMessageExist());
        }
    }
}
