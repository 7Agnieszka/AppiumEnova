using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class FakturySprzedarzyOkno : AbstractWindow
    {
        private IWebElement FormularzBttn => driver.FindElement(By.XPath("//div[text()=\"Formularz\"]"));
        private IWebElement ZawansowaneBttn => driver.FindElement(By.XPath("//div[text()=\"Zaawansowane\"]"));
        private IWebElement ZapiszBttn => driver.FindElement(By.XPath("//div[text()=\"Zapisz\"]"));
        private IWebElement ZatwierdzBttn => driver.FindElement(By.XPath("//div[text()=\"Zatwierdź\"]"));
        private IWebElement OKBttn => driver.FindElement(By.XPath("//div[text()=\"OK\"]"));
        private IWebElement TakBttn => driver.FindElement(By.XPath("//div[text()=\"Tak\"]"));
        private IWebElement AnulujBttn => driver.FindElement(By.XPath("//div[text()=\"Anuluj\"]"));
        private IWebElement ZalacznikiBttn => driver.FindElement(By.XPath("//div[text()=\"Załączniki\"]"));
        private IWebElement AsystentBttn => driver.FindElement(By.Id("Asystent"));
        private IWebElement UsunzListy => driver.FindElement(By.Id("AttachmentList_Remove"));
        private IWebElement RaportyBttn => driver.FindElement(By.XPath("//div[text()=\"Raporty\"]"));
        private IWebElement ZalacznikPozycja => driver.FindElement(By.XPath("//*[@id=\"AttachmentList_canvas\"]/div[1]/div[2]"));
        private IWebElement DuplikatBttn => driver.FindElement(By.XPath("//div[text()=\"Duplikat\"]"));
        private IWebElement OrganizujFormularzBttn => driver.FindElement(By.XPath("//div[text()=\"Organizuj formularz\"]"));
        private IWebElement ZaznaczonyAsystentBttn => driver.FindElement(By.XPath("//*[@id=\"FeaturesPage_scroll\"]/div[1]/div/div[2]/div[2]/div/div/div[2]/div[1]"));
        private IWebElement KontrahentPole => driver.FindElement(By.CssSelector("#DokumentOgolnePage_scroll > div.window.form > div.stack > div:nth-child(1) > div.group-content > div:nth-child(4) > div > div > div.content > input"));  
//        private IWebElement KontrahentPole => driver.FindElement(By.XPath("//*[@id=\"DokumentOgolnePage_scroll\"]/div[1]/div[1]/div[1]/div[2]/div[4]/div/div/div[2]/input"));  
        private IWebElement DodajNowyTowarBttn => driver.FindElement(By.XPath("//div[text()=\"Dodaj nowy zapis\"]"));
        //private IWebElement BIKINIBttn => driver.FindElement(By.XPath("//div[text()=\"BIKINI\"]"));
        private IWebElement BIKINIBttn => driver.FindElement(By.CssSelector("div[data-rowid='1'] .text"));
     //   private IWebElement TowarPole => driver.FindElement(By.XPath("//div[@class='grid-row odd focused']/div[3]"));
      //  private IWebElement TowarPole => driver.FindElement(By.CssSelector("#DokumentOgolnePage_scroll > div.window.form > div.stack > div:nth-child(2) > div.group-content > div.grid > div > div.grid-viewport > div > div.grid-canvas > div.grid-row.odd.focused > div:nth-child(3)"));
        private IWebElement TowarPole => driver.FindElement(By.CssSelector("div.grid-row.odd.focused > div:nth-child(3)"));
      //  private IWebElement TowarIlosc => driver.FindElement(By.XPath("//*[@id=\"DokumentOgolnePage_scroll\"]/div[1]/div/div[2]/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[4]"));
        private IWebElement TowarIlosc => driver.FindElement(By.CssSelector("div.grid-row.odd.focused > div:nth-child(4)"));
        private IWebElement TowarIloscInput => driver.FindElement(By.CssSelector("input[value='1 szt']"));
        private IWebElement TowarCena => driver.FindElement(By.XPath("//div[@class='grid-row odd focused']/div[5]"));
        private IWebElement TowarCena2 => driver.FindElement(By.XPath("//*[@id=\"DokumentOgolnePage_scroll\"]/div[1]/div/div[2]/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[5]"));
        private IWebElement TowarCenaInput => driver.FindElement(By.XPath("//div[@class='editor-text input-textRight focused']//input[@class='fieldInput']"));
        private IWebElement TowarTablica => driver.FindElement(By.XPath("//div[@class='grid-canvas']"));
        private IWebElement TowarLista => driver.FindElement(By.CssSelector("#DokumentOgolnePage_scroll > div.window.form > div.stack > div:nth-child(2) > div.group-content > div.grid > div > div.grid-viewport > div > div.grid-canvas > div.grid-row.odd.focused > div.gc.gc-active.gc-text > div > div > div > div > div"));
       // private IWebElement TowarLista => driver.FindElement(By.XPath("//*[@id=\"DokumentOgolnePage_scroll\"]/div[1]/div[1]/div[2]/div[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[3]/div/div/div/div/div"));
        private IWebElement NrDokumentuWeb => driver.FindElement(By.XPath("//div[@class='wb-text no-fav']"));
        //private IWebElement WartoscFiled => driver.FindElement(By.XPath("//div[@class='stack']/div[3]/div[5]/input"));
        private IWebElement WartoscFiled => driver.FindElement(By.XPath("//*[@id=\"DokumentOgolnePage_scroll\"]/div[1]/div/div[3]/div[2]/div[7]/div/div[2]/input"));
      //  private IWebElement WartoscFiled => driver.FindElement(By.CssSelector("div.stack div:nth-of-type(7) .fieldInput"));
        private IWebElement ZatwierdźBttn => driver.FindElement(By.Id("ApproveButton"));
        private IWebElement ZapiszBttn2 => driver.FindElement(By.Id("Save2Button"));

        String NrDokumentu = "";

        public FakturySprzedarzyOkno(RemoteWebDriver driver) : base(driver)
        {
        }

        public FakturySprzedarzyOkno UstawAsystenta()
        {
            FormularzBttn.Click();
            ZawansowaneBttn.Click();
            OrganizujFormularzBttn.Click();
            if (ZaznaczonyAsystentBttn.Text == "Nie") ZaznaczonyAsystentBttn.Click();

            ZapiszBttn.Click();
            return this;
        }

        public FakturySprzedarzyOkno Raporty()
        {
            RaportyBttn.Click();
            return this;
        }


        public FakturySprzedarzyOkno Duplikat()
        {
            DuplikatBttn.Click();
            return this;
        }

        public RaportOkno OK()
        {
            OKBttn.Click();
            return new RaportOkno(driver);
        }

        public FakturySprzedarzyOkno PrzejdzDoZalacznikow()
        {
            AsystentBttn.Click();
            ZalacznikiBttn.Click();
            return this;
        }

        public String NazwaPierwszegoZalacznika()
        {
            return ZalacznikPozycja.Text;
        }

        public FakturySprzedarzyOkno PosprzatajTest()
        {
            ZalacznikPozycja.Click();
            UsunzListy.Click();
            TakBttn.Click();
            ZapiszBttn.Click();
            return this;
        }

        public FakturySprzedarzyOkno UzupelnijKontrahent(String Kontrahent)
        {
            KontrahentPole.Click();
            KontrahentPole.Clear();
            KontrahentPole.SendKeys(Kontrahent);
            return this;
        }

        public FakturySprzedarzyOkno DodajTowar(String Towar, String Ilosc, String Cena)
        {
            DodajNowyTowarBttn.Click();
            TowarPole.Click();
            TowarLista.Click();
            BIKINIBttn.Click();
            TowarIlosc.Click();
            TowarIlosc.Click();
            TowarIloscInput.SendKeys(Ilosc + Keys.Enter);
            TowarCena.Click();
           // TowarCenaInput.Clear();
           // TowarCenaInput.SendKeys(Cena);
           // TowarCenaInput.SendKeys(Keys.Enter);
 
            int i = 0;


            NrDokumentu = NrDokumentuWeb.Text.Substring(19, 12);
            return this;

        }
        public FakturySprzedarzyOkno Zatwierdz()
        {
            ZatwierdzBttn.Click();
            return this;

        }
        public FakturySprzedarzyOkno Anuluj()
        {
            AnulujBttn.Click();
            return this;

        }

        public String KwotaFaktury()
        {
            return TowarCena2.Text;
        }
        public void SumaFakturyHI()
        {
            HighlightElement(WartoscFiled);

        }


        public String SumaFaktury()
        {
            return WartoscFiled.GetAttribute("value");
        }

        public FakturySprzedarzyOkno KliknijDodanaFaktura()
        {
            driver.FindElement(By.XPath("//div[text()=\"" + NrDokumentu + "\"]")).Click();
            return this;
        }
 

        public FakturySprzedarzyTabela Zapisz_2()
        {
            ZapiszBttn2.Click();
            return new FakturySprzedarzyTabela(driver);
        }
 
    }
}
