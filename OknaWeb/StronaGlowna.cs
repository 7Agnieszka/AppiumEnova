using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class StronaGlowna : AbstractWindow
    {
        private IWebElement HandelBttn => driver.FindElement(By.XPath("//div[text()=\"Handel\"]"));
        private IWebElement KadryBttn => driver.FindElement(By.XPath("//div[text()=\"Kadry i płace\"]"));
        private IWebElement NarzedziaBttn => driver.FindElement(By.Id("SettingsCommand"));
        private IWebElement StronaGlownaBttn => driver.FindElement(By.ClassName("logo"));
        private IWebElement GwiazdkaBttn => driver.FindElement(By.CssSelector("div[data-icon=\"gwiazda\"]"));
        private IWebElement PozycjaUlubione1 => driver.FindElement(By.Id("nav-item0"));
        public StronaGlowna(RemoteWebDriver driver) : base(driver)
        {
        }

        public HandelOkno PrzejdDoHandel()
        {


           // HandelBttn.Click();
          //  driver.FindElement(By.XPath("//div[text()=\"Handel\"]")).Click();
            driver.FindElement(By.CssSelector("#FolderMenuList_scroll > div.window.main-menu > div > div:nth-child(1) > div:nth-child(8) > div.content > div.title.left")).Click();
          //  driver.FindElement(By.CssSelector("div:contains(\"Handel\")")).Click();
            return new HandelOkno(driver);

        }

        public KadryIPlaceOkno PrzejdzDoKadry()
        {

            KadryBttn.Click();
            return new KadryIPlaceOkno(driver);
        }

        public NarzedziaLista PrzejdDoNarzedzia()
        {
            NarzedziaBttn.Click();
            return new NarzedziaLista(driver);
        }

        internal void PrzejdzDoUlubionych()
        {
            driver.FindElement(By.CssSelector("#container > div.hb > div.hb-main.hb-main-menu > div.hb-home")).Click();
            GwiazdkaBttn.Click();

 
        }
 


        internal String NazwaPozycji()
        {
            return PozycjaUlubione1.Text;
        }


    }
}
