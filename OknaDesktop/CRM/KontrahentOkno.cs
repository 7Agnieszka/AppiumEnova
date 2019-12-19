using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace TestyInterfejsowe.OknaDesktop.CRM
{
    class KontrahentOkno : AbstractWindow
    {
        private WindowsElement RozrachunkiElementDrzewa => driver.FindElementByName("Rozrachunki");
        private WindowsElement Rozrachunki => driver.FindElement(By.XPath("//TreeItem[@Name=\"Rozrachunki\"]/TreeItem[@Name=\"Rozrachunki\"]"));
        private WindowsElement Otworz => driver.FindElementByName("Otwórz");

        public KontrahentOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public void PrzejdzDoRozrachunki()
        {
            Actions action = new Actions(driver);
            action.MoveByOffset(20, 30);
            action.Click().Perform();
            FocusNaOkienko();
            RozrachunkiElementDrzewa.Click();
            Rozrachunki.Click();
        }

        public void PrzejdzDoRozrachunki1()
        {
            Actions action = new Actions(driver);

            action.ContextClick();
            action.MoveToElement(RozrachunkiElementDrzewa);
            action.Click(null);
            action.MoveByOffset(20, 30);
            action.Click(null).Perform();
        }

        public KontrahentOkno OtworzRekord()
        {
            Otworz.Click();
            return new KontrahentOkno(driver);
        }
    }
}
