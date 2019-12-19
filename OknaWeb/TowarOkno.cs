using System;
using System.Collections.Generic;
using System.Text;
 
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class TowarOkno : AbstractWindow
    {
        private IWebElement KodPole => driver.FindElement(By.XPath("//*[@id=\"TowarPage_scroll\"]/div[1]/div/div[1]/div[2]/div[1]/div/div[2]/input"));
        private IWebElement KodKreskowyPole => driver.FindElement(By.XPath("//*[@id=\"TowarPage_scroll\"]/div[1]/div/div[1]/div[2]/div[4]/div/div[2]/input"));
        private IWebElement OstrzezenieOknoTekst => driver.FindElement(By.XPath("//*[@id=\"container\"]/div[2]/div/div/div[2]/div[1]/div/div[2]/div/div/div[2]"));
        private IWebElement Ostrzezenie => driver.FindElement(By.ClassName("verifier-title"));
        private IWebElement ZapiszBttn => driver.FindElement(By.XPath("//div[text()=\"Zapisz\"]"));
        private IWebElement FormularzBttn => driver.FindElement(By.XPath("//div[text()=\"Formularz\"]"));
        private IWebElement ZaawansowaneBttn => driver.FindElement(By.XPath("//div[text()=\"Zaawansowane\"]"));
        private IWebElement OrganizujFormularzBttn => driver.FindElement(By.XPath("//div[text()=\"Organizuj formularz\"]"));
        private IWebElement ZakladkaZCechamiBttn => driver.FindElement(By.XPath("//*[@id=\"FeaturesPage_scroll\"]/div[1]/div/div[3]/div[2]/div[1]/div/div[2]/div[1]"));
        private IWebElement Pozycjasiodma => driver.FindElement(By.XPath("//*[@id=\"nav-item7\"]/div"));
        private IWebElement ZrezygnujBttn => driver.FindElement(By.XPath("//div[text()=\"Zrezygnuj\"]"));
        public TowarOkno(RemoteWebDriver driver) : base(driver)
        {
        }


        public TowarOkno WyczyscKod()
        {
            KodPole.Click();
            for (int i = 0; i < 10; i++)
            { KodPole.SendKeys(Keys.Backspace); }
            KodPole.SendKeys(Keys.Enter);
            return this;
        }

        public TowarOkno WpiszKod(String Kod)
        {
            KodPole.Click();
            KodPole.SendKeys(Kod);
            return this;
        }

        public TowarOkno WrocNazwe(String Kod)
        {
            KodPole.Click();
            KodPole.SendKeys(Keys.Backspace);
            KodPole.SendKeys(Keys.Backspace);
            return this;
        }

        public TowarOkno ZmienKodKreskowy()
        {
            KodKreskowyPole.Clear();
            KodKreskowyPole.SendKeys("abc");
            KodPole.SendKeys(Keys.Enter);
            return this;
        }

        public TowarOkno Formularz()
        {
            FormularzBttn.Click();
            ZaawansowaneBttn.Click();
            OrganizujFormularzBttn.Click();
            return this;
        }

        public TowarOkno Zapisz()
        {
            ZapiszBttn.Click();
            return this;
        }
        public String TekstOstrzezenia()
        {
           // Thread.Sleep(500);
            return Ostrzezenie.Text;
        }
        public void ZrezygnujZZapisu()
        {
            ZrezygnujBttn.Click();
        }
        public String TekstOstrzezeniaOkna()
        {
           // Thread.Sleep(500);
            return OstrzezenieOknoTekst.Text;
        }

        public TowarOkno ZaznaczWidzocznaZakladkaZCechami()
        {
            if (ZakladkaZCechamiBttn.Text == "Nie")
                ZakladkaZCechamiBttn.Click();

            return this;

        }

        public String TekstPozycji7naLiscie()
        {

            return Pozycjasiodma.Text;
        }

    }
}
