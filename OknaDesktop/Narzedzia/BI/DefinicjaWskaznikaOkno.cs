using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Narzedzia.BI
{
    class DefinicjaWskaznikaOkno : AbstractWindow
    {
        private WindowsElement PoleNazwa => driver.FindElement(By.XPath("//Pane[4]"));
        private WindowsElement PoleDefinicja => driver.FindElement(By.XPath("//Pane[7]/ComboBox[1]"));
        private WindowsElement PoleDostepnaZrodla => driver.FindElement(By.Name("Wybrane źródła:"));
        private WindowsElement RozszerzButton => driver.FindElement(By.Name("Rozszerz"));
        private WindowsElement UsunRozszerzenieButton => driver.FindElement(By.Name("Usuń rozszerznie"));
        private WindowsElement PodgladZapytaniaButton => driver.FindElement(By.Name("Podgląd zapytania"));
        private WindowsElement PodgladZapytaniaOkno => driver.FindElement(By.XPath("//Window[@Name=\"Podgląd zapytania SQL\"]"));
        private WindowsElement KalkulatorModeluDanychOkno => driver.FindElement(By.XPath("//Window[@Name=\"Kalkulator modelu danych\"]"));
        private WindowsElement ObliczButton => driver.FindElement(By.Name("Oblicz"));
        private WindowsElement KomunikatText => driver.FindElement(By.Name("'Generuj widok' zakończone pomyślnie."));
        private WindowsElement GenerujWidokButton => driver.FindElement(By.Name("Generuj widok"));
        private WindowsElement DodatkoweZlaczenia => driver.FindElement(By.Name("Dodatkowe złączenia"));
        private WindowsElement DodatkowyWarunek => driver.FindElement(By.Name("Dodatkowy warunek"));
        private WindowsElement DodatkowePola => driver.FindElement(By.Name("Dodatkowe pola"));
        private WindowsElement Tabele => driver.FindElement(By.Name("Tabele"));
        private WindowsElement Dodaj => driver.FindElement(By.Name("&1. Dodaj >"));
        private String PoleNazwaText;

        public DefinicjaWskaznikaOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public void WpiszWPoleNazwa(string Nazwa)
        {
            PoleNazwa.Click();
            driver.Keyboard.SendKeys(Nazwa);
            PoleNazwaText = PoleNazwa.Text;
        }

        public void WpiszWPoleDefinicja(string Tekst)
        {
            PoleDefinicja.Click();
            driver.Keyboard.SendKeys(Tekst);
            KliknijOkienkoZTekstem(PoleNazwaText);
            KliknijOkienkoZTekstem(PoleNazwaText);
        }

        public string PobierzTekstZPolaDefinicj()
        {
            return PoleDefinicja.Text;
        }

        public void WpiszWPoleDostepneZrodla(String Tekst)
        {
            PoleDostepnaZrodla.Click();

            driver.Keyboard.SendKeys(Tekst);
            driver.Keyboard.SendKeys(Keys.Enter);
            driver.Keyboard.SendKeys(Keys.Enter);
        }

        public void PrzejdzDoZakladkiTabele()
        {
            Tabele.Click();
        }

        public void Rozszerz()
        {
            RozszerzButton.Click();
        }

        public void UsunRozszerzenie()
        {
            UsunRozszerzenieButton.Click();
        }

        public void PodgladZapytania()
        {
            PodgladZapytaniaButton.Click();
        }

        public void Oblicz()
        {
            ObliczButton.Click();
        }

        public void GenerujWidok()
        {
            GenerujWidokButton.Click();
        }

        public void DodajZDostepnychDoWybranych()
        {
            Dodaj.Click();
        }

        public void PrzejdzDoZakladkiPrawaDanych()
        {
            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys("7");
            driver.Keyboard.SendKeys(Keys.Control);
        }

        public bool IsDodatkoweZlaczeniaVisible()
        {
            try
            {
                return DodatkoweZlaczenia.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public bool IsDodatkowyWarunekVisible()
        {
            try
            {
                return DodatkowyWarunek.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public bool IsDodatkowePolaVisible()
        {
            try
            {
                return DodatkowePola.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public bool IsPodgladZapytaniaVisible()
        {
            try
            {
                return PodgladZapytaniaOkno.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public bool IsKalkulatorModeluDanychVisible()
        {
            try
            {
                return KalkulatorModeluDanychOkno.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public bool KomunikatZakonczonoPomyslnieVisible()
        {
            try
            {
                return KomunikatText.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }
        public bool IsRozszerzVisible()
        {
            try
            {
                return RozszerzButton.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }
        public bool IsPodgladZapytaniaButtonVisible()
        {
            try
            {
                return PodgladZapytaniaButton.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }
        public bool IsObliczVisible()
        {
            try
            {
                return ObliczButton.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }
        public bool IsGenerujWidokVisible()
        {
            try
            {
                return GenerujWidokButton.Displayed;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }
        public void WlaczKalkulatorModeluDanych()
        {
            try
            {
                KalkulatorModeluDanychOkno.Click();
            }
            catch
            {
                Thread.Sleep(500);
            }
        }
    }
}
