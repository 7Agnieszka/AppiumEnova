using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class FakturySprzedarzyTabela : AbstractWindow
    {
        private IWebElement DrukujBttn => driver.FindElement(By.XPath("//div[text()=\"Raporty\"]"));
        private IWebElement OKBttn => driver.FindElement(By.XPath("//div[text()=\"OK\"]"));
        private IWebElement KalendarzBttn => driver.FindElement(By.CssSelector("div[data-icon=\"kalendarz\"]"));
        private IWebElement NowyElementListyBttn => driver.FindElement(By.Id("List_New"));
        private IWebElement OtworzBttn => driver.FindElement(By.Id("List_Open"));

        public FakturySprzedarzyTabela(RemoteWebDriver driver) : base(driver)
        {
        }

        public FakturySprzedarzyTabela Drukuj()
        {
            ThreadSleep(2100);
            DrukujBttn.Click();
            return this;
        }

        public RaportOkno OK()
        {
            OKBttn.Click();
            return new RaportOkno(driver);
        }
        public KalendarzWidget Kalendarz()
        {
            KalendarzBttn.Click();
            return new KalendarzWidget(driver);

        }
        public FakturySprzedarzyOkno KliknijTabeliONazwie(String Text)
        {
            driver.FindElement(By.XPath("//div[text()=\"" + Text + "\"]")).Click();
            ThreadSleep(2000);
            return new FakturySprzedarzyOkno(driver);

        }

        public FakturySprzedarzyOkno Nowy()
        {
            NowyElementListyBttn.Click();
            return new FakturySprzedarzyOkno(driver);
        }

        public FakturySprzedarzyOkno Otworz()
        {
            OtworzBttn.Click();
            return new FakturySprzedarzyOkno(driver);
        }
    }
}
