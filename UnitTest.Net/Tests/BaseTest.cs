using NUnit.Framework;
using OpenQA.Selenium;
using FinalTaskBBC.pages;
using FinalTaskBBC.Pages;

namespace FinalTaskBBC.tests
{
    public class BaseTest
    {
        private const string BBC_URL = "https://www.bbc.com/";

        [SetUp]
        public void CreateDriver()
        {
            Driver.Start();
            Driver.MaximizeWindow();
            Driver.Navigate(BBC_URL);
        }
      
        public IWebDriver GetDriver()
        {
            return Driver.Instance;
        }

        public void ClosePopupWindow()
        {
            if (BasePage.SignInButton.Displayed)
            {
                BasePage.SignInButton.Click();
            }
        }

        public BasePage BasePage => new BasePage(Driver.Instance);
        public HomePage HomePage => new HomePage(Driver.Instance);
        public NewsPage NewsPage => new NewsPage(Driver.Instance);
        public CoronavirusPage CoronavirusPage => new CoronavirusPage(Driver.Instance);  
    }
}
