using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class MagazynoweOpcje : AbstractWindow
    {
        private IWebElement WydanieZewnetrzneLista => driver.FindElement(By.XPath("//*[@id=\"container\"]/div[3]/div[1]/div/div[1]/div[2]/div[2]/div/div/div[2]/div"));
        private IWebElement ZapiszBttn => driver.FindElement(By.XPath("//div[text()=\"Zapisz\"]"));
        public MagazynoweOpcje(RemoteWebDriver driver) : base(driver)
        {
        }

        public DefDokHanWZ WydanieWewnetrzeRozwinListe()
        {
            WydanieZewnetrzneLista.Click();
            return new DefDokHanWZ(driver);
        }
        public MagazynoweOpcje Zapisz() {
            ZapiszBttn.Click();
            return this;
        }
    }
}
