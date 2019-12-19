using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class KadryIPlaceOkno : AbstractWindow
    {
        private IWebElement PracownicyBttn => driver.FindElement(By.XPath("//div[text()=\"Pracownicy\"]"));
        public KadryIPlaceOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public PracownicyTabela PrzejdzDoPracownicy()
        {
            PracownicyBttn.Click();
            return new PracownicyTabela(driver);
        }
    }
}
