using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class HandelOpcje : AbstractWindow
    {
        private IWebElement MagazynoweBttn => driver.FindElement(By.XPath("//div[text()=\"Magazynowe\"]"));
        public HandelOpcje(RemoteWebDriver driver) : base(driver)
        {
        }



        public MagazynoweOpcje PrzejdDoMagazynoweOpcje()
        {
            MagazynoweBttn.Click();
            return new MagazynoweOpcje(driver);
        }
    }
}
