using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace PizzaNCS
{
    public class BaseTests
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
        }

        public void LaunchPizzaNCSSite()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://d1zgi04j6ht6lv.cloudfront.net/#/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void QuitBrowser()
        {
            driver.Quit();
        }
    }
}