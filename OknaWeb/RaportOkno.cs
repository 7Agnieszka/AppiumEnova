using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class RaportOkno : AbstractWindow
    {
        private IWebElement ZamknijBtn => driver.FindElement(By.XPath("//div[text()=\"Zamknij\"]"));
        private IWebElement ZakladkaBtn => driver.FindElement(By.XPath("//*[@id=\"container\"]/div[1]/div[2]/div[2]/div[2]/div[1]/div"));
        private IWebElement WiecejBttn => driver.FindElement(By.XPath("//div[text()=\"Więcej...\"]"));
        private IWebElement PobierzPDFBttn => driver.FindElement(By.XPath("//div[text()=\"Pobierz PDF\"]"));
        private IWebElement ZalacznikPDFBttn => driver.FindElement(By.XPath("//div[text()=\"Załącznik PDF\"]"));
        private IWebElement PobierzHTMLBttn => driver.FindElement(By.XPath("//div[text()=\"Pobierz HTML\"]"));
        private IWebElement PobierzTXTBttn => driver.FindElement(By.XPath("//div[text()=\"Pobierz TXT\"]"));
        private IWebElement PobierzXLSBttn => driver.FindElement(By.XPath("//div[text()=\"Pobierz XLS\"]"));
        private IWebElement PobierzRTFBttn => driver.FindElement(By.XPath("//div[text()=\"Pobierz RTF\"]"));
        public RaportOkno(RemoteWebDriver driver) : base(driver)
        {
        }


        public String TekstZakladki()
        {
            return ZakladkaBtn.Text;
        }

        public RaportOkno KliknijWiecej()
        {
            WiecejBttn.Click();
            return this;
        }

        public RaportOkno KliknijPobierzPDFBttn()
        {
            PobierzPDFBttn.Click();
            return this;
        }
        public RaportOkno KliknijZalacznikPDFBttn()
        {
            ZalacznikPDFBttn.Click();
            return this;
        }

        public RaportOkno KliknijPobierzHTMLBttn()
        {
            PobierzHTMLBttn.Click();
            return this;
        }

        public RaportOkno KliknijPobierzTXTBttn()
        {
            PobierzTXTBttn.Click();
            return this;
        }

        public RaportOkno KliknijPobierzXLSBttn()
        {
            PobierzXLSBttn.Click();
            return this;
        }

        public RaportOkno KliknijPobierzRTFBttn()
        {
            PobierzRTFBttn.Click();
            return this;
        }


        public TowaryTabela Zamknij()
        {
            ZamknijBtn.Click();
            return new TowaryTabela(driver);
        }
    }
}
