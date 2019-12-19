using System;
 
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class OrganizujRaportyOkno : AbstractWindow
    {
        private IWebElement WiecejBttn => driver.FindElement(By.XPath("//*[@id=\"GeneralPage_scroll\"]/div[1]/div/div/div[2]/div[2]/div/div[1]/div/div[2]"));
        private IWebElement DefASPXBttn => driver.FindElement(By.XPath("//div[text()=\"Definicja raportu ASPX\"]"));
        private IWebElement NazwaPole => driver.FindElement(By.XPath("//*[@id=\"GeneralPage_scroll\"]/div[1]/div/div[1]/div[2]/div[1]/div/div[2]/input"));

        private IWebElement PlikBttn => driver.FindElement(By.XPath("//div[text()=\"Pliki\"]"));
        private IWebElement NowyBttn => driver.FindElement(By.Id("FilesList_New"));

        public OrganizujRaportyOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public OrganizujRaportyOkno NowyRaportASPX()
        {
            WiecejBttn.Click();
            DefASPXBttn.Click();
            return this;
        }

        public OrganizujRaportyOkno UzupelnijDefinicje(String Nazwa)
        {
            NazwaPole.SendKeys(Nazwa);
            return this;
        }

        public OrganizujRaportyOkno UstawNowyRaport()
        {
            PlikBttn.Click();
            NowyBttn.Click();
            return this;
        }

        public OrganizujRaportyOkno WpiszAdresRaportu(String Adres)
        {
            ThreadSleep(500);
            Actions actions = new Actions(driver);
            actions.SendKeys(Adres + Keys.Enter).Perform();
            return this;
        }
    }
}
