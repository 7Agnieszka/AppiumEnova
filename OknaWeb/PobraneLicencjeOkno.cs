using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class PobraneLicencjeOkno : AbstractWindow
    {
        private IWebElement ZalogowaniOperatorzy => driver.FindElement(By.XPath("//div[text()=\"Zalogowani operatorzy\"]"));
        private IWebElement WylogujBttn => driver.FindElement(By.XPath("//div[text()=\"Wyloguj\"]"));
        private IWebElement ZaznaczWszytskichCheckBox => driver.FindElement(By.ClassName("check-close"));
        private IWebElement ZapiszBttn => driver.FindElement(By.XPath("//div[data-icon=\"zapisz\"]"));
        private IWebElement TakBttn => driver.FindElement(By.XPath("//div[text()=\"Tak\"]"));

        public PobraneLicencjeOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public void WylogujWszystkichZalogowanych()
        {
            ZalogowaniOperatorzy.Click();
            ZaznaczWszytskichCheckBox.Click();
            WylogujBttn.Click();
            TakBttn.Click();
            ZapiszBttn.Click();
        }
    }
}
