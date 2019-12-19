using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class WszytskieDokumentyOkno : AbstractWindow
    {
        private IWebElement NowyDokStrzalkaBttn => driver.FindElement(By.XPath("//div[@id='List_New']//div[@class='s-icon']"));
        private IWebElement ZOBttn => driver.FindElement(By.XPath("//div[27]/div[@class='nav-item-cap no-animate']"));
        private IWebElement CzynnosciBttn => driver.FindElement(By.XPath("//div[text()=\"Czynności\"]"));
        private IWebElement FakturaBttn => driver.FindElement(By.XPath("//div[text()=\"Faktura\"]"));
        private IWebElement FakturaZalBttn => driver.FindElement(By.XPath("//div[text()=\"nowy (FZAL - Faktura zaliczkowa)\"]"));

        public WszytskieDokumentyOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public DokumentZOOkno UtworzZO()
        {
            NowyDokStrzalkaBttn.Click();
            Actions actions = new Actions(driver);
            actions.MoveToElement(ZOBttn);
            actions.Perform();
            ZOBttn.Click();

            return new DokumentZOOkno(driver);
        }

        public WszytskieDokumentyOkno Czynnosci()
        {
            //  Thread.Sleep(500);

            CzynnosciBttn.Click();


            return this;
        }

        public FakturaZaliczkowaOkno FakturaZaliczkowa()
        {
            FakturaBttn.Click();
            FakturaZalBttn.Click();
            return new FakturaZaliczkowaOkno(driver);
        }

    }
}
