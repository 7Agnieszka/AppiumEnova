using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace TestyInterfejsowe.OknaWeb
{
    class TowaryTabela : AbstractWindow
    {
        Actions action = new Actions(driver);
        private IWebElement DodajTowarBttn => driver.FindElement(By.Id("List_New"));
        private IWebElement Montaz => driver.FindElement(By.XPath("//div[text()=\"MONTAZ\"]"));
        private IWebElement But42 => driver.FindElement(By.XPath("//div[text()=\"BUT_NAR_42\"]"));
        private IWebElement But42xx => driver.FindElement(By.XPath("//div[text()=\"BUT_NAR_42xx\"]"));
        private IWebElement Bikini => driver.FindElement(By.XPath("//div[text()=\"BIKINI\"]"));
        private IWebElement DrukujBttn => driver.FindElement(By.XPath("//div[text()=\"Raporty\"]"));
        private IWebElement OKBttn => driver.FindElement(By.XPath("//div[text()=\"OK\"]"));
        private IWebElement TakBttn => driver.FindElement(By.XPath("//div[text()=\"Tak\"]"));
        private IWebElement TylkoZaznaczoneChcek => driver.FindElement(By.XPath("//div[text()=\"Tylko zaznaczone\"]"));
        private IWebElement ListaBttn => driver.FindElement(By.XPath("//div[text()=\"Lista\"]"));
        private IWebElement ZapiszBttn => driver.FindElement(By.XPath("//div[text()=\"Zapisz\"]"));
        private IWebElement EksportujBttn => driver.FindElement(By.XPath("//div[text()=\"Eksportuj...\"]"));
        private IWebElement ImportujBttn => driver.FindElement(By.XPath("//div[text()=\"Importuj...\"]"));
        private IWebElement WczytajDaneBttn => driver.FindElement(By.XPath("//div[text()=\"Wczytaj dane\"]"));
        private IWebElement ZaawansowaneBttn => driver.FindElement(By.XPath("//div[text()=\"Zaawansowane\"]"));
        private IWebElement OrganizujListeBttn => driver.FindElement(By.XPath("//div[text()=\"Organizuj listę\"]"));
        private IWebElement KoloryBttn => driver.FindElement(By.XPath("//div[text()=\"Kolory\"]"));
        private IWebElement DodajNowyZapisBttn => driver.FindElement(By.XPath("//div[text()=\"Dodaj nowy zapis\"]"));
        private IWebElement UsunBttn => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[2]/div/div/div/div"));
        private IWebElement ZaznaczWszytskoBttn => driver.FindElement(By.ClassName("check-close"));
        private IWebElement SalomonName => driver.FindElement(By.XPath("//div[text()=\"Salomon\"]"));
        private IWebElement WczytajDanePole => driver.FindElement(By.ClassName("fieldMemo"));
        private IWebElement AdresImportPole => driver.FindElement(By.XPath("//*[@id=\"dialog3_scroll\"]/div[1]/div/div/div[2]/div[2]/div/div/div[2]/input"));
        private IWebElement RozwinAdres => driver.FindElement(By.XPath("//*[@id=\"dialog3_scroll\"]/div[1]/div/div/div[2]/div[2]/div/div/div[2]/div"));
        private IWebElement TylkoZaznCheckBox => driver.FindElement(By.XPath("//*[@id=\"dialog3_scroll\"]/div[1]/div/div[1]/div[2]/div[2]/div/div[2]"));
        private IWebElement KolorPole => driver.FindElement(By.XPath("//div[@class=\"grid-canvas\"]/div[1]/div[2]"));
        private IWebElement KolorWarunek => driver.FindElement(By.XPath("//div[@class=\"grid-canvas\"]/div[1]/div[3]"));
        private IWebElement KolorCzcionki => driver.FindElement(By.XPath("//div[@class=\"grid-canvas\"]/div[1]/div[4]"));
        private IWebElement KolorCzcionkiPaleta => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[4]/div/div/div/div/div"));
        private IWebElement KolorTla => driver.FindElement(By.XPath("//div[@class=\"grid-canvas\"]/div[1]/div[5]"));
        private IWebElement KolorTlaPaleta => driver.FindElement(By.XPath("//*[@id=\"AppearancesPage_scroll\"]/div[1]/div/div/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[5]/div/div/div/div/div"));
        private IWebElement Czarny => driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div[1]/div[1]"));
        private IWebElement WierszFiltraBttn => driver.FindElement(By.CssSelector("div[data-icon=\"filter_row\"]"));
        private IWebElement CzynnosciBttn => driver.FindElement(By.Id("ActionsButton"));
        private IWebElement NonOptimalSearchLine => driver.FindElement(By.ClassName("nonoptimal"));
        private IWebElement KodNaglowek => driver.FindElement(By.CssSelector("#List_columns_cells > div:nth-child(2) > div.ghc-title > span"));
        private IWebElement NazwaNaglowek => driver.FindElement(By.CssSelector("#List_columns_cells > div:nth-child(4) > div.ghc-title > span"));
        private IWebElement Kodpoz1 => driver.FindElement(By.CssSelector("#List_canvas > div:nth-child(1) > div.gc.gc-so.gc-text > div.text"));
        private IWebElement Kodpoz2 => driver.FindElement(By.CssSelector("#List_canvas > div:nth-child(2) > div.gc.gc-so.gc-text > div.text"));
        private IWebElement Nazwapoz1 => driver.FindElement(By.CssSelector("#List_canvas > div:nth-child(1) > div:nth-child(4)"));
        private IWebElement Nazwapoz2 => driver.FindElement(By.CssSelector("#List_canvas > div:nth-child(2) > div:nth-child(4)"));



        //   private IWebElement ChcekBox => driver.FindElement(By.XPath("//*[@id=\"dialog3_scroll\"]/div[1]/div/div/div[2]/div/div/div[2]"));
        public TowaryTabela(RemoteWebDriver driver) : base(driver)
        {
        }


        public TowaryTabela TylkoZaznaczoneZaznaczChekBox()
        {
            if (TylkoZaznCheckBox.GetAttribute("Class") == "ch-content ch-right checked")
                TylkoZaznaczoneChcek.Click();

            return this;
        }


        public TowaryTabela Drukuj()
        {
            DrukujBttn.Click();
            return this;
        }

        public TowaryTabela Lista()
        {


            try
            {
                ListaBttn.Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                WaitForLoaderToDissapear();
                Lista();
            }
            return this;

        }

        public TowaryTabela Eksportuj()
        {
            EksportujBttn.Click();

            return this;
        }


        public TowaryTabela Importuj()
        {
            ImportujBttn.Click();
            RozwinAdres.Click();
            return this;
        }

        public TowaryTabela WpiszAdresPliku(String Adres)
        {
            // AdresImportPole.Click();
            RozwinAdres.Click();
            driver.Keyboard.SendKeys(Keys.Enter);
            driver.Keyboard.SendKeys(Adres);
            driver.Keyboard.SendKeys(Keys.Enter);

            return this;
        }

        public TowaryTabela TylkoZaznaczoneKlik()
        {
            TylkoZaznaczoneChcek.Click();
            return this;
        }
        public TowaryTabela WczytajDane()
        {
            WczytajDaneBttn.Click();
            return this;
        }

        public TowaryTabela Zaawansowane()
        {
            ZaawansowaneBttn.Click();
            return this;
        }

        public TowaryTabela OrganizujListe()
        {
            OrganizujListeBttn.Click();
            return this;
        }

        public TowaryTabela Kolory()
        {
            KoloryBttn.Click();
            return this;
        }
        public TowaryTabela DodajNowyZapis()
        {
            //  Thread.Sleep(500);
            DodajNowyZapisBttn.Click();
            return this;
        }

        public TowaryTabela UzupelnijPoleIWarunek(String Pole, String Warunek)
        {

            KolorPole.Click();
            //IWebElement KolorPoleText=
            KolorPole.FindElement(By.XPath("//input[@class=\"fieldInput\"]")).Click(); ;
              Thread.Sleep(500);
            action.SendKeys(Pole).Build().Perform();
            action = new Actions(driver);
            KolorWarunek.Click();
             Thread.Sleep(500);
            action.SendKeys(Warunek).Build().Perform();
            return this;
        }

        public TowaryTabela WybierzKolorCzionki()
        {


            KolorCzcionki.Click();
            KolorCzcionkiPaleta.Click();
            Czarny.Click();
            return this;
        }

        public TowaryTabela WybierzKolorTla()
        {

            //  KolorTla.Click();
            KolorTlaPaleta.Click();
            Czarny.Click();
            return this;
        }
        public RaportOkno OK()
        {
            OKBttn.Click();
            // Thread.Sleep(3000);
            return new RaportOkno(driver);
        }
        public TowaryTabela Zapisz()
        {
            ZapiszBttn.Click();
            return this;
        }

        public String WczytaneDane()
        {
            return WczytajDanePole.Text;
        }

        public TowaryTabela ZaznaczElementTabeliONazwie(String Text)
        {
            //driver.Mouse.MouseMove(driver.FindElement(By.XPath("//div[text()=\"" + Text + "\"]")), -10, 10);
            driver.FindElement(By.XPath("//*[@id=\"List_canvas\"]/div[" + Text + "]/div[1]/div")).Click();
            //        driver.Keyboard.ReleaseKey(Keys.Control);

            return this;

        }

        public String KolorSalomona()
        {
            return SalomonName.GetCssValue("color");
        }

        public TowaryTabela Odswiez()
        {
            driver.Navigate().Refresh();
            return this;
        }

        public TowaryTabela PosprzatajTest()
        {
            ZaznaczWszytskoBttn.Click();
            UsunBttn.Click();
            TakBttn.Click();
            return this;
        }

        public TowarOkno WybierzBut42()
        {
            But42.Click();
            return new TowarOkno(driver);
        }
        public TowarOkno WybierzBut42xx()
        {
            But42xx.Click();
            return new TowarOkno(driver);
        }
        public Boolean But42xxVisible()
        {
            return But42xx.Displayed;
        }
        public TowaryTabela KliknijNaglowekKod()
        {
            KodNaglowek.Click();
            return this;
        }
        public TowaryTabela KliknijNaglowekNazwa()
        {
            NazwaNaglowek.Click();
            return this;
        }
        public TowarOkno WybierzBIKINI()
        {
            Bikini.Click();
            return new TowarOkno(driver);
        }
        public TowarOkno DodajTowar()
        {
            DodajTowarBttn.Click();
            // Thread.Sleep(1000);
            return new TowarOkno(driver);
        }

        public String WymiaryPrzyciskuCzynnosci()
        {
            return CzynnosciBttn.Size.Height + " " + CzynnosciBttn.Size.Width;
        }

        public String LokalizacjaPrzyciskuCzynnosci()
        {
            return CzynnosciBttn.Location.X + " " + CzynnosciBttn.Location.Y;
        }

        internal void WlaczWierszFiltrowania()
        {
            WierszFiltraBttn.Click();
        }

        internal void WpiszTekstDoFiltraKolumny(string v1, string v2)
        {
            driver.FindElement(By.XPath("//div[@id='List_filters_cells']/div[" + v2 + "]/input")).SendKeys(v1);
        }

        internal double LiczbaWierszy()
        {
            ThreadSleep(14444);
            return driver.FindElements(By.XPath("//div[@id='List_canvas']/div")).Count - 1;
        }

        internal void WyczyscFiltrKolumny(string v)
        {
            //            driver.FindElementByXPath("//div[@id='List_filters_cells']/div[" + v + "]/input").Clear();
            driver.FindElement(By.XPath("//div[@id='List_filters_cells']/div[" + v + "]/input")).SendKeys(Keys.Backspace);
            driver.FindElement(By.XPath("//div[@id='List_filters_cells']/div[" + v + "]/input")).SendKeys(Keys.Backspace);
            driver.FindElement(By.XPath("//div[@id='List_filters_cells']/div[" + v + "]/input")).SendKeys(Keys.Backspace);
            driver.FindElement(By.XPath("//div[@id='List_filters_cells']/div[" + v + "]/input")).SendKeys(Keys.Backspace);
            driver.FindElement(By.XPath("//div[@id='List_filters_cells']/div[" + v + "]/input")).SendKeys(Keys.Enter);
            // Thread.Sleep(2000);
        }

        public void WlaczWyszukiwanieNieoptymalne()
        {
            NonOptimalSearchLine.Click();
        }

        public String TekstKomorkiKod1()
        {
            Thread.Sleep(500);
            return Kodpoz1.Text;
        }

        public String TekstKomorkiKod2()
        {
            return Kodpoz2.Text;
        }

        public String TekstKomorkiNazwa1()
        {
            Thread.Sleep(500);
            return Nazwapoz1.Text;
        }
        public String TekstKomorkiNazwa2()
        {
            return Nazwapoz2.Text;
        }
    }
}
