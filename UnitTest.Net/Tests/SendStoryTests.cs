using NUnit.Framework;
using OpenQA.Selenium;
using UnitTest.Net.tests;

namespace UnitTest.Net.Tests
{
    [TestFixture]
    class SendStoryTests : BaseTest
    {
        [Test]
        public void CheckThatUserCanSubmitQuastions()
        {
            GoToSendCoronovirusStoryForm();

            GetCoronavirusPage().LogInKeys("Some story", " ", "e@m.ail", "333","Location");
            GetCoronavirusPage().LogInCheckboxCheck();
            GetCoronavirusPage().ClickSubmit();

            Assert.IsTrue(GetCoronavirusPage().IsErrorMessageExist());
        }

        [Test]
        public void CheckThatStoryNotSendWithEmptyFields()
        {
            GoToSendCoronovirusStoryForm();

            GetCoronavirusPage().LogInKeys("", "", "", "", "");
            GetCoronavirusPage().ClickSubmit();

            Assert.IsTrue(GetCoronavirusPage().IsErrorMessageExist());
        }

        [Test]
        public void CheckThatStoryNotSendWithInvalidEmail()
        {
            GoToSendCoronovirusStoryForm();
           
            GetCoronavirusPage().LogInKeys("Another story", "Name", "email", "111", "Location");
            GetCoronavirusPage().LogInCheckboxCheck();
            GetCoronavirusPage().ClickSubmit();

            Assert.IsTrue(GetCoronavirusPage().IsErrorMessageExist());
        }


        private void GoToSendCoronovirusStoryForm()
        {
            GetHomePage().ClickNewsPageButton();
            GetBasePage().WaitForPageLoadComplete();

            IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
            executor.ExecuteScript("arguments[0].click();", GetCoronavirusPage().GetCoronovirusButton());
            GetBasePage().WaitForPageLoadComplete();

            IJavaScriptExecutor executor2 = (IJavaScriptExecutor)GetDriver();
            executor2.ExecuteScript("arguments[0].click();", GetCoronavirusPage().GeYouCoronovirusStoriesButton());
            GetBasePage().WaitForPageLoadComplete();


            IJavaScriptExecutor executor3 = (IJavaScriptExecutor)GetDriver();
            executor3.ExecuteScript("arguments[0].click();", GetCoronavirusPage().GetHowToShareBBCNewsButton());
            GetBasePage().WaitForPageLoadComplete();

            if (GetBasePage().GetSignInButton().Displayed)
            {
                IJavaScriptExecutor executor4 = (IJavaScriptExecutor)GetDriver();
                executor4.ExecuteScript("arguments[0].click();", GetBasePage().GetSignInButton());
            }
            GetBasePage().WaitForPageLoadComplete();
        }
    }
}
