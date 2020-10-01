using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace FinalTaskBBC.pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        private readonly static int timetoWait = 30000;

        [FindsBy(How = How.XPath, Using = "//button[@class='sign_in-exit']")]
        public IWebElement SignInButton { get; private set; }
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timetoWait);
        }

        public void WaitForPageLoadComplete()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timetoWait));
            wait
                .Until(driver1 => 
                    ((IJavaScriptExecutor)driver)
                .ExecuteScript("return document.readyState")
                .Equals("complete"));
        }
    } 
}
