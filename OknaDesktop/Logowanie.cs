using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using TestyInterfejsowe.OknaDesktop;
using TestyInterfejsowe.Testy.KlasyPomocnicze;

namespace TestyInterfejsowe.OknaDesktop
{
    class Logowanie : AbstractWindow
    {
        private WindowsElement PoleLogin => driver.FindElement(By.XPath("//ComboBox[@AutomationId=\"comboUser\"]/Edit[@ClassName=\"Edit\"]"));
        private WindowsElement ZalogujBttn => driver.FindElement(By.XPath("//Window[@AutomationId=\"LoginForm\"]/Button[@AutomationId=\"buttonOK\"]"));

        public Logowanie(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public StronaGlowna Zaloguj(BazaDanych Baza, string Login)
        {
            FocusNaOkienko();
            MaksymalizujOkno();
            driver.FindElementByName(Baza.NazwaBazyDanych).Click();
            PoleLogin.SendKeys(Login);
            ZalogujBttn.Click();

            if (Baza.LicencjaBazy == BazaDanych.Licencja.Demo)
            {
                FocusNaOkienko();
                driver.FindElementByName("Licencja demo - enova365");
                driver.FindElementByName("OK").Click();
            }
            return new StronaGlowna(driver);
        }

        public StronaGlowna ZalogujPonownie(BazaDanych Baza, string Login)
        {
            driver.FindElementByName("Wyloguj").Click();
            driver.FindElementByName(Baza.NazwaBazyDanych).Click();
            driver.Keyboard.SendKeys(Login);
            driver.Keyboard.SendKeys(Keys.Enter);
            driver.Keyboard.SendKeys(Keys.Enter);
            return new StronaGlowna(driver);
        }
    }
}
