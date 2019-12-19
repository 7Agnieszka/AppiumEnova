using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class PracownicyTabela : AbstractWindow
    {
        private IWebElement Andrzejewski => driver.FindElement(By.XPath("//div[text()=\"ANDRZEJEWSKI\"]"));
        private IWebElement OtworzBttn => driver.FindElement(By.Id("List_Open"));

        public PracownicyTabela(RemoteWebDriver driver) : base(driver)
        {
        }

        public PracownikOkno WybierzAndrzejewski()
        {
            Andrzejewski.Click();

            return new PracownikOkno(driver);
        }

    }
}
