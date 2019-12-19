using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class DefDokHanWZ : AbstractWindow
    {
        private IWebElement MagazynBttn => driver.FindElement(By.XPath("//div[text()=\"Magazyn\"]"));
        private IWebElement MomentOperacjiLista => driver.FindElement(By.XPath("//*[@id=\"DefDokMagazynyPage_scroll\"]/div[1]/div/div/div[2]/div[5]/div/div/div[2]/div"));
        private IWebElement OKBttn => driver.FindElement(By.XPath("//div[text()=\"OK\"]"));
        private IWebElement MagazynoweBttn => driver.FindElement(By.XPath("//div[text()=\"Magazynowe\"]"));
        public DefDokHanWZ(RemoteWebDriver driver) : base(driver)
        {
        }


        public DefDokHanWZ PrzejdzDoMagazyn() {
            MagazynBttn.Click();
            return this;
        }
        public DefDokHanWZ UstawMomentOperacji(String Rodzaj) {
            MomentOperacjiLista.Click();
            driver.FindElement(By.XPath("//div[text()=\"" + Rodzaj + "\"]")).Click();
            return this;
        }
        public MagazynoweOpcje OK() {
            OKBttn.Click();
            return new MagazynoweOpcje(driver);
        }


    }
}
