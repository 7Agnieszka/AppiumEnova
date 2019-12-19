using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TestyInterfejsowe.Testy.KlasyPomocnicze;

namespace TestyInterfejsowe.OknaWeb
{
    class StronaLogowania : AbstractWindow
    {
        private IWebElement PoleLogin => driver.FindElement(By.Id("userName"));
        private IWebElement PoleHaslo => driver.FindElement(By.Id("userPassword"));
        private IWebElement LoginBttn => driver.FindElement(By.Id("btnLogin"));
        private IWebElement ListaJezykow => driver.FindElement(By.CssSelector("div[data-icon=\"lista\"]"));
        private IWebElement JezykPolski => driver.FindElement(By.XPath("//div[text()=\"polski\"]"));
        private IWebElement JezykAngielski => driver.FindElement(By.XPath("//div[text()=\"English\"]"));
        private IWebElement LogoutBttn => driver.FindElement(By.Id("LogoutCommand"));
        private IWebElement OperatorBttn => driver.FindElement(By.Id("UserCommand"));
        private IWebElement ZmianaJezykaPole => driver.FindElement(By.Id("CultureUIField"));
        private IWebElement ZmianaHaslaDostepuBttn => driver.FindElement(By.XPath("//div[text()=\"Zmiana hasła dostępu\"]"));
        private IWebElement TakBttn => driver.FindElement(By.XPath("//div[text()=\"Tak\"]"));
        private IWebElement YesBttn => driver.FindElement(By.XPath("//div[text()=\"Yes\"]"));
        private IWebElement OkBttn => driver.FindElement(By.XPath("//div[text()=\"OK\"]"));
        private IWebElement Opacity => driver.FindElement(By.ClassName("modal-overlay"));
        private IWebElement AktywnaZakladka => driver.FindElement(By.XPath("//div[@class=\"hb-bookmark active\"]/div/div"));
        BazaDanych bazaDanych { get; set; }

        public StronaLogowania(RemoteWebDriver driver, BazaDanych bazaDanychUzytkownika) : base(driver)
        {
            bazaDanych = bazaDanychUzytkownika;

            driver.Navigate().GoToUrl("http://localhost/Login/" + bazaDanych.NazwaBazyDanych);
        }


        public StronaLogowania WpiszLoginIHaslo(String Login, String Haslo)
        {
            PoleLogin.Clear();
            PoleLogin.SendKeys(Login);
            PoleHaslo.Clear();
            PoleHaslo.SendKeys(Haslo);

            return this;
        }

        public StronaLogowania KliknijZaloguj()
        {
            LoginBttn.Click();

            //if(AktywnaZakladka.Text== "Pobrane licencje")
            //{
            //    PobraneLicencjeOkno pobraneLicencjeOkno = new PobraneLicencjeOkno(driver);
            //    pobraneLicencjeOkno.WylogujWszystkichZalogowanych();
            //}

            return this;
        }



        public StronaGlowna ZalogujAdministrator()
        {
            WpiszLoginIHaslo("Administrator", "").KliknijZaloguj();
            if (bazaDanych.LicencjaBazy == BazaDanych.Licencja.Demo)
            { OkBttn.Click(); }

            return new StronaGlowna(driver);
        }

        public PanelUzytkownika ZalogujOsobe(String Login, String Haslo)
        {
            WpiszLoginIHaslo(Login, Haslo).KliknijZaloguj();


            if (bazaDanych.LicencjaBazy == BazaDanych.Licencja.Demo)
            { OkBttn.Click(); }

            return new PanelUzytkownika(driver);
        }

        public void Wyloguj()
        {
            try
            {
                LogoutBttn.Click();
            }
            catch (Exception e)
            {
                Wyloguj();
            }
            if (bazaDanych.JezykBazy == BazaDanych.Jezyk.Polski)
                TakBttn.Click();
            else if (bazaDanych.JezykBazy == BazaDanych.Jezyk.Angielski)
                YesBttn.Click();

        }






        public StronaLogowania OperatorKliknij()
        {
            OperatorBttn.Click();
            return this;
        }

        public ZmianaHaslaDostepuOkno ZmianaHaslaKliknij()
        {
            ZmianaHaslaDostepuBttn.Click();
            return new ZmianaHaslaDostepuOkno(driver);
        }

        public bool Zalogowany()
        {
            try
            {

                return LogoutBttn.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public StronaLogowania ZmienJezykNaAngielski()
        {
            ZmianaJezykaPole.Click();
            ListaJezykow.Click();
            JezykAngielski.Click();
            OkBttn.Click();
            bazaDanych.JezykBazy = BazaDanych.Jezyk.Angielski;
            return this;
        }
        public StronaLogowania ZmienJezykNaPolski()
        {
            ZmianaJezykaPole.Click();
            ListaJezykow.Click();
            JezykPolski.Click();
            OkBttn.Click();
            bazaDanych.JezykBazy = BazaDanych.Jezyk.Polski;
            return this;
        }

    }
}
