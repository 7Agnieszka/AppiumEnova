using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaDesktop
{
    abstract class AbstractWindow
    {
        protected static WindowsDriver<WindowsElement> driver;

        public AbstractWindow(WindowsDriver<WindowsElement> driver)
        {
            AbstractWindow.driver = driver;
        }
        #region Tabele i Gridy
        public WindowsElement ElementNTabeliKolumny(int NrWiersza, String TytulKolumny)
        {
            return driver.FindElementByName(TytulKolumny + " row " + NrWiersza);
        }

        public int LiczbaWierszyOstatni()
        {
            string nazwa;
            driver.FindElementByName("Panel danych");
            nazwa = driver.FindElementByXPath("//Custom[@Name=\"Panel danych\"]/*[last()]").GetAttribute("Name");
            return Int32.Parse(Regex.Match(nazwa.ToString(), @"\d+").Value);
        }

        public int WezNumerWierszaOWartosciWKolumnie(string wartosc, string Kolumna)
        {
            var liczba = LiczbaWierszyOstatni();
            for (int i = 0; i < liczba; i++)
            {
                if (ElementNTabeliKolumny(i, Kolumna).Text == wartosc)
                {
                    return i;
                }
            }
            return -1;
        }

        public AbstractWindow KliknijKomorkeOPodanymTekscieIKolumnie(String Tekst, String TytulKolumny)
        {
            driver.FindElementByName(TytulKolumny + " row " + WezNumerWierszaOWartosciWKolumnie(Tekst, TytulKolumny)).Click();
            return this;
        }

        public AbstractWindow KliknijKomorkeOPodanymWierszuIKolumnie(String TytulKolumny, String NrWiersza)
        {
            driver.FindElementByName(TytulKolumny + " row " + NrWiersza).Click();
            return this;
        }

        public String TekstKomorkiNWKolumnie(int NumerWiersza, String TytulKolumny)
        {
            return driver.FindElementByName(TytulKolumny + " row " + NumerWiersza).Text;
        }

        public void WpiszTekstDoKomorkiNWKolumnie(String Tekst, int NumerWiersza, String TytulKolumny)
        {
            driver.FindElementByName(TytulKolumny + " row " + NumerWiersza).SendKeys(Tekst);
        }

        public void WpiszTekstDoFiltraKolumny(String Tekst, String TytulKolumny)
        {
            driver.FindElementByName(TytulKolumny + " filter row").Click();
            driver.FindElementByName(TytulKolumny + " filter row").SendKeys(Tekst);
        }

        public void WyczyscFiltr()
        {
            driver.FindElementByAccessibilityId("ClearFilterCheck").Click();
        }

        public WindowsElement KomorkaFiltraKolumny(String TytulKolumny)
        {
            return driver.FindElementByName(TytulKolumny + " filter row");
        }

        public WindowsElement KomorkaNWKolumnie(int NumerWiersza, String TytulKolumny)
        {
            return driver.FindElementByName(TytulKolumny + " row " + NumerWiersza);
        }

        public bool CzyMaFocus(WindowsElement element)
        {
            if (element.GetAttribute("HasKeyboardFocus").ToString() == "True")
                return true;
            else return false;

        }
        #endregion
        #region Zmien Wartosc komorki
        public void WlaczZamienWartoscPola()
        {
            Actions actions = new Actions(driver);
            actions.KeyDown(Keys.Control)
                .KeyDown(Keys.Shift)
                .SendKeys("h")
                .KeyUp(Keys.Shift)
                .KeyUp(Keys.Control)
                .Perform();
        }

        public void UzupelnijSzukanyTekst(String Tekst)
        {
            driver.FindElementByAccessibilityId("textSearch").SendKeys(Tekst);
        }
        public void UzupelnijZamienNaTekst(String Tekst)
        {
            driver.FindElementByAccessibilityId("textReplace").SendKeys(Tekst);
        }
        public void KliknijZamien()
        {
            driver.FindElementByAccessibilityId("button1").Click();
        }
        #endregion
        #region Obsluga okienek
        public AbstractWindow ZamknijOkno()
        {
            driver.Keyboard.SendKeys(Keys.Alt);
            driver.Keyboard.SendKeys(Keys.F4);
            driver.Keyboard.SendKeys(Keys.Alt);
            driver.Keyboard.SendKeys(Keys.F4);
            return this;
        }

        public AbstractWindow MaksymalizujOkno()
        {
            FocusNaOkienko();
            driver.Keyboard.SendKeys(Keys.Command);
            driver.Keyboard.SendKeys(Keys.ArrowUp);
            driver.Keyboard.SendKeys(Keys.Command);
            driver.Keyboard.SendKeys(Keys.ArrowUp);
            return this;
        }

        public AbstractWindow OdwrocMaksymalizacjeOkno()
        {
            FocusNaOkienko();
            driver.Keyboard.SendKeys(Keys.Command);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.Command);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            return this;
        }

        public AbstractWindow KliknijNie()
        {
            driver.FindElementByName("Nie").Click();
            return this;
        }

        public void Kliknij_Nie()
        {
            driver.FindElementByName("&Nie").Click();
        }

        public void KliknijTak()
        {
            driver.FindElementByName("Tak").Click();
        }

        public void Kliknij_Tak()
        {
            FocusNaOkienko();
            driver.FindElementByName("&Tak").Click();
        }

        public void KliknijOK()
        {
            driver.FindElementByName("OK").Click();
        }

        public void Kliknij_OK()
        {
            driver.FindElementByName("&OK").Click();
        }

        public void FocusNaOkienko()
        {
            var currentWindowHandle = driver.CurrentWindowHandle;
            var allWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(allWindowHandles[0]);
        }

        public AbstractWindow WyslijSkrotKlawiszowy(String Klawisz1, String Klawisz2)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Klawisz1 + Klawisz2).Build().Perform();
            actions.KeyUp(Klawisz1).Build().Perform();
            return this;
        }

        public AbstractWindow WyslijKlawisz(String Klawisz1)
        {
            //Zrobic enum może?
            Actions actions = new Actions(driver);
            actions.SendKeys(Klawisz1).Build().Perform();
            return this;
        }

        public AbstractWindow KliknijWObecnynMiejscu()
        {
            Actions actions = new Actions(driver);
            actions.Click().Build().Perform();
            return this;
        }

        public string PobierzTytulOkna()
        {
            FocusNaOkienko();
            return driver.FindElementByAccessibilityId("DataForm").GetAttribute("Name");
        }

        public void ZapiszBezZamykania()
        {
            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys("s");
            driver.Keyboard.SendKeys(Keys.Control);
        }

        public void ZapiszIZamknij()
        {
            driver.FindElement(By.Name("Zapisz i zamknij")).Click();
        }
        #endregion

        public void KliknijOkienkoZTekstem(String Text)
        {
            driver.FindElementByName(Text).Click();
        }

        public bool IsVisible(WindowsElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public void MenuKontekstowe()
        {
            Actions actions = new Actions(driver);
            actions.ContextClick().Perform();
        }
        #region Aststent
        public void KliknijWlaczWylaczAsystenta()
        {
            driver.FindElement(By.Name("Asystent")).Click();
        }
        public void ZakladkaZalaczniki()
        {
            driver.FindElement(By.Name("Załączniki")).Click();
        }
        public void DodajZalaczniki()
        {
            Actions actions = new Actions(driver);
            actions.Click(driver.FindElementByAccessibilityId("addLink")).Build().Perform();
        }
        public void ImportujPlik(String text)
        {
            Actions actions = new Actions(driver);
            actions.Click(driver.FindElementByXPath("//Edit[@Name=\"Nazwa pliku:\"]")).Build();
            actions.SendKeys(text).Build();
            actions.Click(driver.FindElementByName("Otwórz")).Build().Perform();
        }
        public String NazwaPlikuNaLiscie()
        {
            return driver.FindElementByXPath("//List[@Name=\"Załączniki:\"]/ListItem").GetAttribute("Name");

        }
        public void UsunZalacznikZListy()
        {
            Actions actions = new Actions(driver);
            actions.Click(driver.FindElementByXPath("//List[@Name=\"Załączniki:\"]/ListItem")).Build();
            actions.ContextClick().Build().Perform();
            actions.Click(driver.FindElementByXPath("//MenuItem[@Name=\"Usuń\"]")).Build().Perform();
        }
        #endregion
    }
}
