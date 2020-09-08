using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTest.Net
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();  // Creates a new Chrome instance and opens the browser
            driver.Navigate().GoToUrl("https://www.bbc.com");  // Navigates to a page by address

        }
    }
}
