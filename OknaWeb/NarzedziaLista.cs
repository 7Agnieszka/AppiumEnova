 
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class NarzedziaLista : AbstractWindow
    {
        private IWebElement OpcjeBttn => driver.FindElement(By.XPath("//div[text()=\"Opcje...\"]"));
        private IWebElement OdswiezOpcjeBttn => driver.FindElement(By.XPath("//div[text()=\"Odśwież opcje\"]"));
        private IWebElement OKBttn => driver.FindElement(By.XPath("//div[text()=\"OK\"]"));
        public NarzedziaLista(RemoteWebDriver driver) : base(driver)
        {
        }


        public OpcjeOkno PrzejdzDoOpcje()
        {
            OpcjeBttn.Click();
            return new OpcjeOkno(driver);

        }

        public StronaGlowna OdswiezOpcje()
        {
            OdswiezOpcjeBttn.Click();
            OKBttn.Click();
            return new StronaGlowna(driver);
        }

    }
}
