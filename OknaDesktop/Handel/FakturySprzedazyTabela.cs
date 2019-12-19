using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Handel
{
    class FakturySprzedazyTabela : AbstractWindow
    {
        private WindowsElement NowaFakturaBttn => driver.FindElement(By.Name("Nowy (FV - Faktura sprzedaży)"));
        private WindowsElement OkresPole2 => driver.FindElementByXPath("//Text[@Name=\"Okres:\"]");
        private WindowsElement OkresPole => driver.FindElementByXPath("//Text[@Name=\"Okres:\"]/following-sibling::Pane/Pane/Edit");

        public FakturySprzedazyTabela(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public FakturaOkno NowaFaktura()
        {
            NowaFakturaBttn.Click();
            Thread.Sleep(200);
            return new FakturaOkno(driver);
        }

        public void UzupelnijOkres(String daty)
        {
            OkresPole.Click();
            OkresPole.SendKeys(daty + Keys.Enter);
        }
    }
}
