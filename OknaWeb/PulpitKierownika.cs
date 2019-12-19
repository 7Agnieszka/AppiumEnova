using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class PulpitKierownika : AbstractWindow
    {
        private IWebElement ListaPracownikowBttn => driver.FindElement(By.XPath("//div[text()=\"Lista pracowników\"]"));

        public PulpitKierownika(RemoteWebDriver driver) : base(driver)
        {
        }

    public ListaPracownikowTabela PrzejdzDoListaPracownikow()
        {
            ListaPracownikowBttn.Click();
            return new ListaPracownikowTabela(driver);
        }



    }
}
