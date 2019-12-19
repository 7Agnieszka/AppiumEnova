using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class OpcjeOkno : AbstractWindow
    {
        private IWebElement HandelBttn => driver.FindElement(By.CssSelector("div.tile-content > div:nth-of-type(16) .title"));
        public OpcjeOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public HandelOpcje PrzejdzDoHandelOpcje()
        {

            HandelBttn.Click();
            return new HandelOpcje(driver);
        }

    }
}
