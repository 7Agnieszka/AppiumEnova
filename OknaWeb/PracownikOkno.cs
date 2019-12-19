using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class PracownikOkno : AbstractWindow
    {
        private IWebElement ZakladkaPFRON => driver.FindElement(By.XPath("//div[text()=\"Informacje PFRON\"]"));
        private IWebElement NieBttn => driver.FindElement(By.XPath("//div[text()=\"Nie\"]"));
        private IWebElement ZamknijBttn => driver.FindElement(By.XPath("//div[text()=\"Zamknij\"]"));
        private IWebElement ZapiszBttn => driver.FindElement(By.XPath("//div[text()=\"Zapisz\"]"));    
        private IWebElement ListaStNiepelnosprawnosci => driver.FindElement(By.XPath("//*[@id=\"PracownikPFRONPage_scroll\"]/div[1]/div[1]/div[2]/div[2]/div[1]/div/div/div[2]/div"));
        private IWebElement OkresOrzeczeniaPoletxt => driver.FindElement(By.XPath("//*[@id=\"PracownikPFRONPage_scroll\"]/div[1]/div[1]/div[2]/div[2]/div[2]/div/div/div[2]/input"));
        private IWebElement OkresOrzeczeniaPoleDostepnosc => driver.FindElement(By.XPath("//*[@id=\"PracownikPFRONPage_scroll\"]/div[1]/div[1]/div[2]/div[2]/div[2]/div/div/div[1]"));
        private IWebElement FormularzBttn => driver.FindElement(By.XPath("//div[text()=\"Formularz\"]"));
        private IWebElement ZaawansowaneBttn => driver.FindElement(By.XPath("//div[text()=\"Zaawansowane\"]"));
        private IWebElement OrganizujFormularzBttn => driver.FindElement(By.XPath("//div[text()=\"Organizuj formularz\"]"));
        private IWebElement ZakladkaZCechamiBttn => driver.FindElement(By.XPath("//*[@id=\"FeaturesPage_scroll\"]/div[1]/div/div[3]/div[2]/div[1]/div/div[2]/div[1]"));
        private IWebElement Pozycja10 => driver.FindElement(By.XPath("//*[@id=\"nav-item10\"]/div"));
        private IWebElement OkienkoDialogoweZamknij => driver.FindElement(By.ClassName("question"));
        private IWebElement LewoStrzalka => driver.FindElement(By.CssSelector("div[data-icon=\"left\"]"));
        private IWebElement Prawostrzalka => driver.FindElement(By.CssSelector("div[data-icon=\"right\"]"));
        private IWebElement TytulRekordu => driver.FindElement(By.CssSelector("#HeaderBar > div > div.wb-header > div.wb-text.no-fav > span"));
        public PracownikOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public PracownikOkno KliknijNie()
        {
            ThreadSleep();
            NieBttn.Click();
            return this;
        }
        public PracownikOkno KliknijZamknij()
        {
            ZamknijBttn.Click();
            OkienkoDialogoweZamknij.GetType();
            return this;
        }
        public PracownikOkno WybierzZakladkeInformacjaPFRON()
        {
            
            ZakladkaPFRON.Click();

            return this;
        }

        public PracownikOkno WybierzStopienNiepelnosprawnosci(String Stopien)
        {
            
            ListaStNiepelnosprawnosci.Click();
            driver.FindElement(By.XPath("//div[text()=\""+Stopien+"\"]")).Click();
            return this;
        }

        public PracownikOkno WypelnijOkresOrzeczenia(String Okres)
        {
            OkresOrzeczeniaPoletxt.Clear();
            OkresOrzeczeniaPoletxt.SendKeys(Okres);
            OkresOrzeczeniaPoletxt.SendKeys(Keys.Enter);

            return this;
        }


        public bool OkresOrzeczeniaJestDostepny()
        {

            String Klasa = OkresOrzeczeniaPoleDostepnosc.GetAttribute("class");

            if(Klasa == "placeholder disabled")
            return false;

            return true;
        }
        public PracownikOkno Formularz()
        {
            FormularzBttn.Click();
            ZaawansowaneBttn.Click();
            OrganizujFormularzBttn.Click();
            return this;
        }
        public PracownikOkno ZaznaczWidzocznaZakladkaZCechami()
        {
            if (ZakladkaZCechamiBttn.Text == "Nie")
                ZakladkaZCechamiBttn.Click();

            return this;

        }

        public String TekstPozycji10naLiscie()
        {

            return Pozycja10.Text;
        }
        public PracownikOkno Zapisz()
        {
            ZapiszBttn.Click();
            return this;
        }

        public PracownikOkno PrzejdzWLewo()
        {
            LewoStrzalka.Click();
            Thread.Sleep(2000);
            return this;
        }
        public PracownikOkno PrzejdzWPrawo()
        {
            Prawostrzalka.Click();
            Thread.Sleep(2000);
            return this;
        }

        public String NazwiskoPracowinka()
        {
            
            return TytulRekordu.Text;
        }
    }
}
