using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using TestyInterfejsowe.OknaDesktop.Narzedzia.BI;

namespace TestyInterfejsowe.OknaDesktop.Opcje.BI
{
    class DefinicjaZestawowPrzedzialowCzasowych : AbstractWindow
    {
        private WindowsElement PierwszyButtonToolbar => driver.FindElement(By.XPath("//ToolBar[@Name=\"Niestandardowa 1\"]/Button[1]"));
        private WindowsElement NowyDefinicja => driver.FindElement(By.Name("Nowy (Zestaw przedziałów czasowych)"));
        private WindowsElement Otworz => driver.FindElement(By.Name("Otwórz"));

        public DefinicjaZestawowPrzedzialowCzasowych(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public ZestawPrzedzialowCzasowychOkno NowaDefinicjaZestawu()
        {
            NowyDefinicja.Click();
            return new ZestawPrzedzialowCzasowychOkno(driver);
        }

        public DefinicjaZestawowPrzedzialowCzasowych OtworzRekord()
        {
            Otworz.Click();
            return this;
        }

        public string PobierzNazwePrzyciskuZToolbar()
        {
            return PierwszyButtonToolbar.Text;
        }
    }
}
