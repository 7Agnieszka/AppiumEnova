using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class ZmianaHaslaDostepuOkno : AbstractWindow
    {
        private IWebElement PoprzednieHaslo => driver.FindElement(By.XPath("//*[@id=\"OgolnePage_scroll\"]/div[1]/div/div[1]/div[2]/div[2]/div/div[2]/input"));
        private IWebElement NoweHaslo => driver.FindElement(By.XPath("//*[@id=\"OgolnePage_scroll\"]/div[1]/div/div[2]/div[2]/div[2]/div/div[2]/input"));
        private IWebElement NoweHasloPowtorz => driver.FindElement(By.XPath("//*[@id=\"OgolnePage_scroll\"]/div[1]/div/div[2]/div[2]/div[3]/div/div[2]/input"));
        private IWebElement ZapiszBttn => driver.FindElement(By.XPath("//div[text()=\"Zapisz\"]"));

        public ZmianaHaslaDostepuOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public ZmianaHaslaDostepuOkno UstaWNoweHaslo(String StareHaslo, String TwojeNoweHaslo)
        {
            PoprzednieHaslo.Clear();
            PoprzednieHaslo.SendKeys(StareHaslo);
            NoweHaslo.Clear();
            NoweHaslo.SendKeys(TwojeNoweHaslo);
            NoweHasloPowtorz.Clear();
            NoweHasloPowtorz.SendKeys(TwojeNoweHaslo);
            return this;
        }

        public void ZapiszOkno()
        {
            ZapiszBttn.Click();
        }
    }
}
