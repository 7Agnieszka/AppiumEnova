using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace TestyInterfejsowe.OknaDesktop.Handel
{
    class TowaryTabela : AbstractWindow
    {
        private WindowsElement Czynosci => driver.FindElement(By.Name("Czynności"));
        private WindowsElement ZarzadzajPanelemBIPozycja => driver.FindElement(By.Name("Zarządzaj panelem BI"));
        private WindowsElement PanelBI => driver.FindElement(By.Name("BI"));
        private WindowsElement WartoscFakturSprzedazyText => driver.FindElement(By.Name("Wartość faktur sprzedaży (kraj)"));
        private WindowsElement Otworz => driver.FindElementByName("Otwórz");
        private WindowsElement NaglowekStanZamowien => driver.FindElementByXPath("//Header[@Name=\"Stan zamówień\"]");
        private WindowsElement NaglowekLiczMagazyn => driver.FindElementByXPath("//Header[@Name=\"Licz magazyn\"]");
        private WindowsElement NaglowekNazwa => driver.FindElementByXPath("//Header[@Name=\"Nazwa\"]");
        private WindowsElement NaglowekKod => driver.FindElementByXPath("//Header[@Name=\"Kod\"]");
        private WindowsElement OrganizujWidok => driver.FindElementByName("Organizuj widok");
        private WindowsElement PolaZakladka => driver.FindElementByName("Pola");
        private WindowsElement ZapisZakladka => driver.FindElementByName("Zapis");
        private WindowsElement PrzywrocStandardowe => driver.FindElementByName("Przywróć standardowe ustawienia");
        private WindowsElement LiczMagazynPoz => driver.FindElementByName("LiczMagazyn");
        private WindowsElement WierszFiltraBttn => driver.FindElementByAccessibilityId("ToggleFilterRowCheck");

        public TowaryTabela(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public DashboardManagerOkno ZarzadzajPanelemBI()
        {
            Czynosci.Click();
            driver.Mouse.MouseMove(ZarzadzajPanelemBIPozycja.Coordinates);
            driver.Mouse.Click(null);

            return new DashboardManagerOkno(driver);
        }

        public bool CzyPanelBI()
        {
            return IsVisible(PanelBI);
        }

        public bool CzyWartoscFakturSprzedazyText()
        {
            return IsVisible(WartoscFakturSprzedazyText);
        }

        public TowarOkno OtworzRekord()
        {
            Otworz.Click();
            return new TowarOkno(driver);
        }

        public void WlaczOrganizatoraWidoku()

        {
            OrganizujWidok.Click();
        }

        public void WlaczZakladkePole()
        {
            PolaZakladka.Click();
        }

        public void PrzeniesKolumne()
        {
            Actions actions = new Actions(driver);
            actions.DragAndDrop(LiczMagazynPoz, NaglowekStanZamowien).Build().Perform();
            actions.Click();
        }

        public void PrzywrocStandardowyWidok()
        {
            ZapisZakladka.Click();
            PrzywrocStandardowe.Click();
            Kliknij_OK();
            OrganizujWidok.Click();
        }

        public bool NaglowekLiczMagDisplayed()
        {
            return NaglowekLiczMagazyn.Displayed;
        }
        public void KliknijNaglowekKod()
        {
            NaglowekKod.Click();
        }
        public void KliknijNaglowekNazwa()
        {
            NaglowekNazwa.Click();
        }

        public void WlaczWierszFiltrowania()
        {
            WierszFiltraBttn.Click();
        }
    }
}
