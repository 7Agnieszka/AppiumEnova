using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class UlubioneOkno :AbstractWindow
    {
        private IWebElement PozycjaUlubione1 => driver.FindElement(By.Id("nav-item0"));
        public UlubioneOkno(RemoteWebDriver driver) : base(driver)
        {
        }



        internal String NazwaPozycji()
        {
            return PozycjaUlubione1.Text;
        }
    }
}
