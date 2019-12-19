using System;
using System.Collections.Generic;
using System.Text;
using TestyInterfejsowe.OknaDesktop.Handel;
using TestyInterfejsowe.OknaDesktop.Opcje;
using TestyInterfejsowe.OknaDesktop.Pomoc;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using TestyInterfejsowe.OknaDesktop.CRM;
using TestyInterfejsowe.OknaDesktop.KiP;
using TestyInterfejsowe.OknaDesktop.PodgladTabel;
using OpenQA.Selenium.Interactions;

namespace TestyInterfejsowe.OknaDesktop
{
    class StronaGlowna : AbstractWindow
    {
        public StronaGlowna(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        #region Menu Kontekstowe
        private WindowsElement NarzedziaElementMenu => driver.FindElement(By.Name("Narzędzia"));
        private WindowsElement OpcjeElementMenuNarzedzia => driver.FindElement(By.XPath("//MenuItem[@Name=\"Narzędzia\"]/MenuItem[@Name=\"Opcje...\"]"));
        private WindowsElement HandelElementDrzewa => driver.FindElement(By.Name("Handel"));
        private WindowsElement TowaryElementDrzewa => driver.FindElement(By.Name("Towary i usługi"));
        private WindowsElement SprzedazElementDrzewa => driver.FindElement(By.Name("Sprzedaż"));
        private WindowsElement FakturySprzedazyElementDrzewa => driver.FindElement(By.Name("Faktury sprzedaży"));
        private WindowsElement CRMElementDrzewa => driver.FindElement(By.Name("CRM"));
        private WindowsElement KontrahenciElementDrzewa => driver.FindElement(By.Name("Kontrahenci"));
        private WindowsElement KadryIPlaceElementDrzewa => driver.FindElement(By.Name("Kadry i płace"));
        private WindowsElement KadryElementDrzewa => driver.FindElement(By.Name("Kadry"));
        private WindowsElement PracownicyElementDrzewa => driver.FindElement(By.Name("Pracownicy"));
        private WindowsElement PodgladTabelElementDrzewa => driver.FindElement(By.Name("Podgląd tabel"));
        private WindowsElement BusinessPodgladTabelElementDrzewa => driver.FindElement(By.Name("Business"));
        private WindowsElement FeatureDefinitionBusinessPodgladTabelElementDrzewa => driver.FindElement(By.Name("FeatureDefinition"));
        private WindowsElement NowaFakturaBttn => driver.FindElement(By.Name("Nowy (FV - Faktura sprzedaży)"));
      

        #endregion




        public Drzewko PrzejdzDoOpcji()
        {


            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys(Keys.F9);
            driver.Keyboard.SendKeys(Keys.Control);

            return new Drzewko(driver);
        }

        public LicencjaDemonstracyjna PrzejdzDoLicencjeDemonstracyjne()
        {
            driver.Keyboard.SendKeys(Keys.Alt);
            driver.Keyboard.SendKeys("o");
            driver.Keyboard.SendKeys("i");
            driver.Keyboard.SendKeys(Keys.Alt);

            return new LicencjaDemonstracyjna(driver);
        }





        #region Drzewko Strony Głównej

        public TowaryTabela PrzejdzDoTowary()
        {
            HandelElementDrzewa.Click();
            TowaryElementDrzewa.Click();

            return new TowaryTabela(driver);
        }




        #region Faktura sprzedazy
        public FakturySprzedazyTabela PrzejdzDoFakturySprzedazy()
        {
            HandelElementDrzewa.Click();
            SprzedazElementDrzewa.Click();
            FakturySprzedazyElementDrzewa.Click();

            return new FakturySprzedazyTabela(driver);


        }


        public void NowaFaktura()
        {
            NowaFakturaBttn.Click();


        }




        #endregion


        public KontrahenciTabela PrzejdzDoKontrahenci()
        {
            CRMElementDrzewa.Click();
            KontrahenciElementDrzewa.Click();

            return new KontrahenciTabela(driver);
        }


        public PracownicyTabela PrzejdzDoPracownicy()
        {
            KadryIPlaceElementDrzewa.Click();
            KadryElementDrzewa.Click();
            PracownicyElementDrzewa.Click();

            return new PracownicyTabela(driver);
        }


        public FeatureDefinitionTabela PrzejdzDoTabeliCech()
        {

            PodgladTabelElementDrzewa.Click();
            BusinessPodgladTabelElementDrzewa.Click();
            FeatureDefinitionBusinessPodgladTabelElementDrzewa.Click();
            return new FeatureDefinitionTabela(driver);
        }

        #endregion

        public void DodajKadryIPlaceDoUlobionych()
        {
            driver.Mouse.MouseMove(driver.FindElementByName("Kadry i płace").Coordinates);
            driver.Mouse.ContextClick(null);

            Actions actions = new Actions(driver);

            actions.ContextClick(driver.FindElementByXPath("//TreeItem[@Name=\"Kadry i płace\"]")).SendKeys(Keys.ArrowDown)
                .SendKeys(Keys.Enter).Perform();

            driver.Mouse.Click(null);

        }


        public void PrzejdzDoUlubionych(string Baza)
        {
            driver.FindElementByName(Baza).Click();
            driver.FindElementByName("Ulubione").Click();
        }

        public void UsunKadryiPlaceZUlubionych()
        {
            Actions actions = new Actions(driver);
            actions.ContextClick(driver.FindElementByXPath("//*[@Name=\"Kadry i płace\"]")).SendKeys(Keys.ArrowUp)
                 .SendKeys(Keys.Enter).Perform();

            driver.FindElementByName("Foldery").Click();
        }

        public String ElementWUlubionych()
        {
            return driver.FindElementByName("Kadry i płace").Text;
        }


    }

}
