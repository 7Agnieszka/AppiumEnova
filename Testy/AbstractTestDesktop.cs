using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace TestyInterfejsowe.Testy
{
    abstract class AbstractTestDesktop
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";
        private const string AppId = @"C:\Program Files (x86)\Soneta\enova365\SonetaExplorer.exe";
        protected static WindowsDriver<WindowsElement> driver;

        [SetUp]
        public void UstawienieSterownikow()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", AppId);
            appCapabilities.SetCapability("ms:waitForAppLaunch", "25");
            appCapabilities.SetCapability("ms:experimental-webdriver", true);
            //appCapabilities.SetCapability("app", "Root");
            driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            var allWindowHandles = driver.WindowHandles;
            Thread.Sleep(4500);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TearDown]
        public void TearDown()
        {
            var allWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(allWindowHandles[0]);
            driver.CloseApp();
            //driver.FindElementByName("&Tak").Click();
        }
    }
}
