using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace TestyInterfejsowe.OknaDesktop.Handel
{
    class FakturaOkno : AbstractWindow
    {
        private WindowsElement KontrahentPole => driver.FindElementByXPath("//Pane[@AutomationId=\"DokumentHandlowyDokumentOgolnePage\"]/Pane[7]/ComboBox[1]/Edit[2]");
        private WindowsElement GridControl => driver.FindElementByAccessibilityId("GridControl");
        private WindowsElement TowarNazwaPole => driver.FindElementByXPath("//Table[@AutomationId=\"GridControl\"]/ComboBox[1]/Edit[1]");
        private WindowsElement TowarIloscPole => driver.FindElementByName("Ilość row 0");
        private WindowsElement ElementMenu2 => driver.FindElementByName("Zaznacz wszystko");
        private WindowsElement BuforBttn => driver.FindElementByName("Bufor");
        private WindowsElement AnulujBttn => driver.FindElementByName("Anuluj");
        private WindowsElement SumaFakturyPole => driver.FindElementByXPath("//Pane[@AutomationId=\"DokumentHandlowyDokumentOgolnePage\"]/Pane[15]");
        private WindowsElement OknoLookUp => driver.FindElementByXPath("//Window[@AutomationId=\"DataForm\"]");

        public FakturaOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public void UzupelnijKontrahenta(String kontrahent)
        {
            KontrahentPole.Click();
            KontrahentPole.SendKeys(kontrahent);
        }

        public String MenuKontekst()
        {
            return ElementMenu2.GetAttribute("HasKeyboardFocus");
        }

        public void MenuKontekstWylacz()
        {
            ElementMenu2.Click();
        }

        public void KliknijKontrahenta()
        {
            KontrahentPole.Click();
        }

        public String TytulOknaLookup()
        {
            return OknoLookUp.GetAttribute("Name");
        }

        public void UzupelnijLinieFaktury(String towar, String Ilosc)
        {
            GridControl.Click();
            TowarNazwaPole.SendKeys(towar);
            TowarIloscPole.Click();
            TowarIloscPole.SendKeys(Ilosc);
            GridControl.Click();
        }

        public String WartoscFaktury()
        {
            return SumaFakturyPole.GetAttribute("Name");
        }

        public void KliknijBufor()
        {
            BuforBttn.Click();
        }

        public void KliknijAnuluj()
        {
            AnulujBttn.Click();
        }

        public void WylaczContext()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.ArrowUp).Build();
            actions.SendKeys(Keys.Enter).Build().Perform();
        }
    }
}
