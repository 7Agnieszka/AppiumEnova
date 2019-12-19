using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Pomoc
{
    class LicencjaDemonstracyjna : AbstractWindow
    {
        private WindowsElement PlaceComboBox => driver.FindElement(By.XPath("//Pane[@AutomationId=\"UIDefinePage\"]/Pane[@AutomationId=\"LicencjaDemoPage\"]/Pane[5]"));
        private WindowsElement FirmowyCheckBox => driver.FindElementByXPath("//Text[@Name=\"Firmowy:\"]/following-sibling::Pane");
        private WindowsElement HandlowyCheckBox => driver.FindElementByXPath("//Text[@Name=\"Obszar Handlowy:\"]/following-sibling::Pane");
        private WindowsElement ZapiszIZamknijButton => driver.FindElement(By.Name("Zapisz i zamknij"));

        public LicencjaDemonstracyjna(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public bool CzyLicencjaFirmowaZaznaczona()
        {
            MaksymalizujOkno();
            if (FirmowyCheckBox.Text == " Nie")
                return false;

            return true;
        }

        public bool CzyLicencjaHandlowaZaznaczona()
        {
            MaksymalizujOkno();
            if (HandlowyCheckBox.Text == " Nie")
                return false;

            return true;
        }

        public void ZaznaczOdznaczFirmowaLicencja()
        {
            FirmowyCheckBox.Click();
        }

        public void ZaznaczOdznaczHandlowaLicencja()
        {
            HandlowyCheckBox.Click();
        }

        public StronaGlowna ZapiszIZamknij()
        {
            ZapiszIZamknijButton.Click();
            return new StronaGlowna(driver);
        }
    }
}
