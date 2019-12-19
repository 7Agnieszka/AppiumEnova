using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Narzedzia.BI
{
    class UstawModeleDanychOkno : AbstractWindow
    {
        private WindowsElement ZakazDostepu => driver.FindElement(By.Name("Zakaz dostępu"));
        private WindowsElement TylkoOdczyt => driver.FindElement(By.Name("Tylko odczyt"));
        private WindowsElement PelnePrawo => driver.FindElement(By.Name("Pełne prawo"));
        private WindowsElement Administrator => driver.FindElement(By.Name("Administrator"));
        private WindowsElement WybierzWiele => driver.FindElement(By.Name("» Wybierz wiele «"));
        private WindowsElement DodajWszytkie => driver.FindElement(By.Name("Dodaj wszystkie >>>"));
        private WindowsElement ZamknijTak => driver.FindElement(By.XPath("//Pane[@Name=\"Zapytanie - Soneta\"]/Button[1]"));
        private WindowsElement OK => driver.FindElement(By.XPath("//Window[@Name=\"Wybierz zapisy\"]/Button[@Name=\"OK\"]"));

        public UstawModeleDanychOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public UstawModeleDanychOkno KliknijPrawoDostepu()
        {
            ZakazDostepu.Click();
            return this;
        }

        public UstawModeleDanychOkno KliknijZakazDostepu()
        {
            driver.Mouse.MouseMove(ZakazDostepu.Coordinates);
            driver.Mouse.Click(null);
            return this;
        }

        public UstawModeleDanychOkno KliknijPelnePrawo()
        {
            driver.Mouse.MouseMove(PelnePrawo.Coordinates);
            driver.Mouse.Click(null);
            return this;
        }

        public UstawModeleDanychOkno KliknijTylkoOdczyt()
        {
            driver.Mouse.MouseMove(TylkoOdczyt.Coordinates);
            driver.Mouse.Click(null);
            return this;
        }

        public UstawModeleDanychOkno KliknijUprawnienia()
        {
            driver.Mouse.MouseMove(Administrator.Coordinates, 190, 7);
            driver.Mouse.Click(null);

            return this;
        }

        public string PobierzTytulOkna()
        {
            return driver.FindElementByXPath("//Window[@Name=\"Opcje\"]/Window[1]").Text;
        }

        public UstawModeleDanychOkno KliknijWybierzWiele()
        {
            driver.Mouse.MouseMove(WybierzWiele.Coordinates);
            driver.Mouse.Click(null);
            return this;
        }

        public UstawModeleDanychOkno KliknijZamknijTak()
        {
            ZamknijTak.Click();
            return this;
        }

        public UstawModeleDanychOkno KliknijDodajWszystkie()
        {
            DodajWszytkie.Click();
            return this;
        }

        public UstawModeleDanychOkno ZatwierdzKliknijOK()
        {
            FocusNaOkienko();
            OK.Click();
            return this;
        }

        public UstawModeleDanychOkno ZatwierdzZmiany()
        {
            while (true)
            {
                try
                {
                    Kliknij_Tak();
                    break;
                }
                catch
                {
                    try
                    {
                        Kliknij_OK();
                        break;
                    }
                    catch
                    {
                        Thread.Sleep(500);
                        continue;
                    }
                }
            }
            return this;
        }
    }
}
