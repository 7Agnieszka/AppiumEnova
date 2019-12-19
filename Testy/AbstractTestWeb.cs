using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;

namespace TestyInterfejsowe.Testy
{
    [TestFixture]
    public abstract class AbstractTestWeb
    {
        protected static RemoteWebDriver driver;
        ChromeOptions Options = new ChromeOptions();
        EdgeOptions OptionsE = new EdgeOptions();

        [SetUp]
        public void Setup()
        {
            Options.AddArgument("--disable-notifications");
            //  Options.AddArgument("--headless");



            driver = new ChromeDriver("resources", Options);
            // driver = new EdgeDriver();
            // driver = new EdgeDriver();
            driver.ResetInputState();
            driver.Navigate().GoToUrl("http://localhost/Login");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}