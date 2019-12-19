using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class HandelOkno : AbstractWindow
    {
        private IWebElement TowaryIUslugiBttn => driver.FindElement(By.XPath("//div[text()=\"Towary i usługi\"]"));
        private IWebElement FakturySprzedazyBttn => driver.FindElement(By.XPath("//div[text()=\"Faktury sprzedaży\"]"));
        private IWebElement WszystkiedokBttn => driver.FindElement(By.XPath("//div[text()=\"Wszystkie dokumenty\"]"));
        private IWebElement DodajDoUlubionychBttn => driver.FindElement(By.ClassName("pb-icon"));
        private IWebElement DodajDoUlubionychBttn2 => driver.FindElement(By.XPath("//div[text()=\"Dodaj do ulubionych\"]"));
        private IWebElement UsunZUlubionychBttn => driver.FindElement(By.XPath("//div[text()=\"Usuń z ulubionych\"]"));
      
 

        public HandelOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public TowaryTabela PrzejdzDoTowary()
        {
            driver.FindElement(By.XPath("//div[text()=\"Towary i usługi\"]")).Click();
            return new TowaryTabela(driver);
        }

        public FakturySprzedarzyTabela PrzejdzDoFakturySprzedarzy()
        {
            FakturySprzedazyBttn.Click();
            return new FakturySprzedarzyTabela(driver);
        }
        public WszytskieDokumentyOkno PrzejdzDoWszystkieDokumenty()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(WszystkiedokBttn);
            actions.Perform();
            WszystkiedokBttn.Click();
            return new WszytskieDokumentyOkno(driver);
        }

        internal void DodajDoUlubionych()
        {
            DodajDoUlubionychBttn.Click();
            DodajDoUlubionychBttn2.Click();
        }

        internal void UsunZUlubionych()
        {
            DodajDoUlubionychBttn.Click();
            UsunZUlubionychBttn.Click();
        }
    }
}
