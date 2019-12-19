using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Opcje.BI
{
    class ZarzadzanieDashboardami : AbstractWindow
    {
        private WindowsElement ZakazDostepu => driver.FindElement(By.Name("Zakaz dostępu"));
        private WindowsElement TylkoOdczyt => driver.FindElement(By.Name("Tylko odczyt"));
        private WindowsElement PelnePrawo => driver.FindElement(By.Name("Pełne prawo"));
        private WindowsElement NieWybrano => driver.FindElement(By.Name("nie wybrano"));
        private WindowsElement WybierzWiele => driver.FindElement(By.Name("» Wybierz wiele «"));
        private WindowsElement KopjujLokalizacje => driver.FindElement(By.Name("Kopiuj lokalizacje na uprawnienie"));
        private WindowsElement LokalizacjaDashboarduPane => driver.FindElement(By.XPath("//Pane[@AutomationId=\"DataBar\"]/Pane[6]"));

        public ZarzadzanieDashboardami(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public ZarzadzanieDashboardami Znajdz(String SzukanyTekst)
        {
            driver.FindElementByName("Nazwa row 2").Click();
            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys("f");
            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys(SzukanyTekst);
            driver.FindElementByAccessibilityId("radioAllColumns").Click();
            driver.FindElementByName("Szukaj").Click();
            return this;
        }

        public ZarzadzanieDashboardami KopiujLokalizacjeNaUprawnienia()
        {
            KopjujLokalizacje.Click();
            return this;
        }

        public ZarzadzanieDashboardami KliknijPrawoDostepu()
        {
            ZakazDostepu.Click();
            return this;
        }

        public ZarzadzanieDashboardami KliknijZakazDostepu()
        {
            driver.Mouse.MouseMove(ZakazDostepu.Coordinates);
            driver.Mouse.Click(null);
            return this;
        }

        public ZarzadzanieDashboardami KliknijPelnePrawo()
        {
            driver.Mouse.MouseMove(PelnePrawo.Coordinates);
            driver.Mouse.Click(null);
            return this;
        }

        public ZarzadzanieDashboardami KliknijTylkoOdczyt()
        {
            driver.Mouse.MouseMove(TylkoOdczyt.Coordinates);
            driver.Mouse.Click(null);
            return this;
        }

        public ZarzadzanieDashboardami KliknijUprawnienia()
        {
            driver.Mouse.MouseMove(NieWybrano.Coordinates, 190, 7);
            driver.Mouse.Click(null);
            return this;
        }

        public ZarzadzanieDashboardami KliknijNaOsobe(String Osoba)
        {
            driver.Mouse.MouseMove(driver.FindElementByName(Osoba).Coordinates);
            driver.Mouse.Click(null);
            return this;
        }

        public ZarzadzanieDashboardami FiltrujHandel()
        {
            driver.FindElementByName("Nazwa row 2").Click();
            MaksymalizujOkno();
            LokalizacjaDashboarduPane.Click();
            driver.Keyboard.SendKeys("Handel/Towary");
            driver.Keyboard.SendKeys(Keys.Enter);
            return this;
        }
        public bool IsKopujLokalizacjeButtonVisible()
        {
            return IsVisible(KopjujLokalizacje);
        }
    }
}
