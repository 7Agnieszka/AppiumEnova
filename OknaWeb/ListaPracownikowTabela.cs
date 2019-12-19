using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
  

namespace TestyInterfejsowe.OknaWeb
{
    class ListaPracownikowTabela :AbstractWindow
    {
        public ListaPracownikowTabela(RemoteWebDriver driver) : base(driver)
        {
        }
        Actions action = new Actions(driver);
        private IWebElement ListaBttn => driver.FindElement(By.XPath("//div[text()=\"Lista\"]"));
        private IWebElement TakBttn => driver.FindElement(By.XPath("//div[text()=\"Tak\"]"));
        private IWebElement ZaawansowaneBttn => driver.FindElement(By.XPath("//div[text()=\"Zaawansowane\"]"));
        private IWebElement OrganizujListeBttn => driver.FindElement(By.XPath("//div[text()=\"Organizuj listę\"]"));
        private IWebElement OrganizujRaportyBttn => driver.FindElement(By.XPath("//div[text()=\"Organizuj raporty\"]"));
        private IWebElement KoloryBttn => driver.FindElement(By.XPath("//div[text()=\"Kolory\"]"));
        private IWebElement DodajNowyZapisBttn => driver.FindElement(By.XPath("//div[text()=\"Dodaj nowy zapis\"]"));
        private IWebElement WczytajDanePole => driver.FindElement(By.ClassName("fieldMemo"));
        private IWebElement AdresImportPole => driver.FindElement(By.XPath("//*[@id=\"dialog3_scroll\"]/div[1]/div/div/div[2]/div[2]/div/div/div[2]/input"));
        private IWebElement RozwinAdres => driver.FindElement(By.XPath("//*[@id=\"dialog3_scroll\"]/div[1]/div/div/div[2]/div[2]/div/div/div[2]/div"));
        private IWebElement TylkoZaznCheckBox => driver.FindElement(By.XPath("//*[@id=\"dialog3_scroll\"]/div[1]/div/div[1]/div[2]/div[2]/div/div[2]"));
        private IWebElement ZapiszBttn => driver.FindElement(By.XPath("//div[text()=\"Zapisz\"]"));
        private IWebElement KolorPole => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[2]"));
        private IWebElement KolorWarunek => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[3]"));
        private IWebElement KolorCzcionki => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[4]"));
        private IWebElement KolorCzcionkiPaleta => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[4]/div/div/div/div/div"));
        private IWebElement KolorTla => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[5]"));
        private IWebElement KolorTlaPaleta => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[5]/div/div/div/div/div"));
        private IWebElement Czarny => driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div[1]/div[1]"));
        private IWebElement Zolty => driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[6]"));
        private IWebElement MechanikpojsamName => driver.FindElement(By.XPath("//*[@id=\"List_canvas\"]/div[4]/div[5]"));
        private IWebElement UsunBttn => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[2]/div/div/div/div"));
        private IWebElement ZaznaczWszytskoBttn => driver.FindElement(By.ClassName("check-close"));
        private IWebElement DorotaBujak => driver.FindElement(By.XPath("//div[text()=\"BUJAK\"]"));




        public ListaPracownikowTabela Lista()
        {
            ThreadSleep(500);
            ListaBttn.Click();
            return this;
        }
        public ListaPracownikowTabela Zaawansowane()
        {
            ZaawansowaneBttn.Click();
            return this;
        }
        public ListaPracownikowTabela Tak()
        {
            TakBttn.Click();
            return this;
        }
        public ListaPracownikowTabela OrganizujListe()
        {
            OrganizujListeBttn.Click();
            return this;
        }
        public OrganizujRaportyOkno OrganizujRaporty()
        {
          OrganizujRaportyBttn.Click();
            return new OrganizujRaportyOkno(driver);
        }


        public ListaPracownikowTabela Kolory()
        {
            KoloryBttn.Click();
            return this;
        }
        public ListaPracownikowTabela DodajNowyZapis()
        {
            ThreadSleep(500);
            DodajNowyZapisBttn.Click();
            return this;
        }

        public ListaPracownikowTabela UzupelnijPoleIWarunek(String Pole, String Warunek)
        {

            KolorPole.Click();
            ThreadSleep(500);
            action.SendKeys(Pole).Build().Perform();
            action = new Actions(driver);
            KolorWarunek.Click();
            ThreadSleep(500);
            action.SendKeys(Warunek).Build().Perform();
            return this;
        }

        public ListaPracownikowTabela WybierzKolorCzionki()
        {

            KolorCzcionki.Click();
            KolorCzcionkiPaleta.Click();
            Zolty.Click();
            return this;
        }

        public ListaPracownikowTabela WybierzKolorTla()
        {

            //  KolorTla.Click();
            KolorTlaPaleta.Click();
            Czarny.Click();
            return this;
        }
        public ListaPracownikowTabela Zapisz()
        {
            ZapiszBttn.Click();
            return this;
        }

        public String KolorJanaczcionka()
        {
            return MechanikpojsamName.GetCssValue("color");
        }
                public String KolorJanaTlo()
        {
            return MechanikpojsamName.GetCssValue("background-color");
        }

        public ListaPracownikowTabela PosprzatajTest()
        {
            ZaznaczWszytskoBttn.Click();
            UsunBttn.Click();
            TakBttn.Click();
            return this;
        }


        public PracownikOkno DorotaBujakOkno()
        {

            DorotaBujak.Click();
            return new PracownikOkno(driver);
        }
    }
}
