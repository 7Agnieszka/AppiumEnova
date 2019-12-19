using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class DokumentZOOkno : AbstractWindow
    {
        private IWebElement KontrahentPole => driver.FindElement(By.XPath("//*[@id=\"DokumentOgolnePage_scroll\"]/div[1]/div[1]/div[1]/div[2]/div[4]/div/div/div[2]/input"));

        private IWebElement DodajNowaPozycjeBttn => driver.FindElement(By.XPath("//div[@class='grid-row new']/div[@class='text']"));
        private IWebElement TowarPole1 => driver.FindElement(By.XPath("//div[@class='editor-text focused']//input[@class='fieldInput']"));
        private IWebElement IloscPole1 => driver.FindElement(By.XPath("//div[.='1 szt']"));
        private IWebElement IloscPole1Input => driver.FindElement(By.XPath("//input[@value='1 szt']"));
        private IWebElement TowarLista1 => driver.FindElement(By.XPath("//*[@id=\"DokumentOgolnePage_scroll\"]/div[1]/div[1]/div[5]/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[3]/div/div/div/div/div"));
        private IWebElement TowarLista2 => driver.FindElement(By.XPath("//*[@id=\"DokumentOgolnePage_scroll\"]/div[1]/div[1]/div[5]/div[2]/div[1]/div/div[2]/div/div[1]/div[2]/div[3]/div/div/div/div/div"));
        private IWebElement TowarLista3 => driver.FindElement(By.XPath("//*[@id=\"DokumentOgolnePage_scroll\"]/div[1]/div[1]/div[5]/div[2]/div[1]/div/div[2]/div/div[1]/div[3]/div[3]/div/div/div/div/div"));
        private IWebElement BIKINIBttn => driver.FindElement(By.XPath("//div[text()=\"BIKINI\"]"));
        private IWebElement KombinezonBttn => driver.FindElement(By.XPath("//div[text()=\"KOM_NAR_S_C\"]"));
        private IWebElement NamiotBttn => driver.FindElement(By.XPath("//div[text()=\"NAM_HOME2\"]"));
        private IWebElement ZatwierdzBttn => driver.FindElement(By.XPath("//div[text()=\"Zatwierdź\"]"));

        public DokumentZOOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public DokumentZOOkno WpiszKontrahenta(String text)
        {
            ThreadSleep(250);
            KontrahentPole.SendKeys(text);
            return this;
        }

        public DokumentZOOkno DodajPozycje()
        {
             ThreadSleep(250);
            DodajNowaPozycjeBttn.Click();
            return this;
        }

        public DokumentZOOkno UzupelnijLinieBIKINI(String Ilosc)
        {
            TowarLista1.Click();
            BIKINIBttn.Click();
            IloscPole1.Click();
            IloscPole1Input.SendKeys(Ilosc);

            return this;
        }
        public DokumentZOOkno UzupelnijLinieKombinezon(String Ilosc)
        {
            TowarLista2.Click();
            KombinezonBttn.Click();
            IloscPole1.Click();
            IloscPole1Input.SendKeys(Ilosc);

            return this;
        }
        public DokumentZOOkno UzupelnijLinieNamiot(String Ilosc)
        {
            TowarLista3.Click();
            NamiotBttn.Click();
            IloscPole1.Click();
            ThreadSleep(200);
            IloscPole1Input.SendKeys(Ilosc);

            return this;
        }

        public WszytskieDokumentyOkno ZatwierdzDokument()
        {
            ZatwierdzBttn.Click();
            return new WszytskieDokumentyOkno(driver);
        }

    }
}
