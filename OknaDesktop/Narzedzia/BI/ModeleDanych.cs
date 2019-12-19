using System;
using System.Collections.Generic;
using System.Text;
using TestyInterfejsowe.OknaDesktop.Narzedzia.BI;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Opcje.BI
{
    class ModeleDanych : AbstractWindow
    {
        private WindowsElement NowyDefinicja => driver.FindElement(By.Name("Nowy (Definicja wskaźnika)"));
        private WindowsElement UstawPrawoDoModeli => driver.FindElement(By.Name("Ustaw prawo do modeli"));
        private WindowsElement Czynnosci => driver.FindElement(By.Name("Czynności"));
        private WindowsElement CzynnosciMenuContx => driver.FindElement(By.XPath("//MenuItem[@Name=\"Czynności\"]"));
        private WindowsElement KopiujModeleDanych => driver.FindElement(By.Name("Kopiuj modele danych"));
        private WindowsElement DataBar => driver.FindElement(By.Id("DataBar"));
        private WindowsElement ObszarComboBox => driver.FindElement(By.XPath("//Pane[@AutomationId=\"DataBar\"]/Pane[6]"));
        private WindowsElement ZamknijTak => driver.FindElement(By.XPath("//Pane[@Name=\"Zapytanie - Soneta\"]/Button[1]"));
        private WindowsElement DrugiButtonToolbar => driver.FindElement(By.XPath("//ToolBar[@Name=\"Niestandardowa 1\"]/Button[2]"));


        public ModeleDanych(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public DefinicjaWskaznikaOkno NowaDefinicjaWskaznika1()
        {
            driver.Mouse.MouseMove(NowyDefinicja.Coordinates, 190, 15);
            driver.Mouse.Click(null);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.Enter);

            return new DefinicjaWskaznikaOkno(driver);
        }

        public DefinicjaWskaznikaOkno NowaDefinicjaWskaznika2()
        {
            driver.Mouse.MouseMove(NowyDefinicja.Coordinates, 190, 15);
            driver.Mouse.Click(null);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.Enter);

            return new DefinicjaWskaznikaOkno(driver);
        }

        public DefinicjaWskaznikaOkno NowaDefinicjaWskaznika3()
        {
            driver.Mouse.MouseMove(NowyDefinicja.Coordinates, 190, 15);
            driver.Mouse.Click(null);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.Enter);

            return new DefinicjaWskaznikaOkno(driver);
        }

        public DefinicjaWskaznikaOkno NowaDefinicjaWskaznika4()
        {
            driver.Mouse.MouseMove(NowyDefinicja.Coordinates, 190, 15);
            driver.Mouse.Click(null);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.Enter);

            return new DefinicjaWskaznikaOkno(driver);
        }

        public UstawModeleDanychOkno KliknijUstawPrawoDoModeli()
        {
            UstawPrawoDoModeli.Click();
            return new UstawModeleDanychOkno(driver);
        }

        public ModeleDanych KliknijZamknijTak()
        {
            ZamknijTak.Click();
            return this;
        }
        public ModeleDanych KliknijCzynnosci()
        {
            driver.Keyboard.SendKeys(Keys.Alt);
            driver.Keyboard.SendKeys("c");
            driver.Keyboard.SendKeys(Keys.Enter);
            driver.Keyboard.SendKeys(Keys.Alt);
            return this;
        }

        public ModeleDanych KliknijCzynnosciMenuCtx()
        {
            CzynnosciMenuContx.Click();
            return this;
        }
        public ModeleDanych KliknijKopjujModeleDanych()
        {
            driver.Keyboard.SendKeys(Keys.Alt);
            driver.Keyboard.SendKeys("c");
            driver.Keyboard.SendKeys(Keys.Enter);
            driver.Keyboard.SendKeys(Keys.Alt);
            driver.Keyboard.SendKeys(Keys.Enter);

            return this;
        }

        public DefinicjaWskaznikaOkno OtworzRekord()
        {
            DrugiButtonToolbar.Click();
            return new DefinicjaWskaznikaOkno(driver);
        }

        public ModeleDanych ZaznaczWszystko()
        {
            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys("a");
            driver.Keyboard.SendKeys(Keys.Control);

            return this;
        }

        public ModeleDanych KliknijListeObszar()
        {
            ObszarComboBox.Click();
            return this;
        }

        public ModeleDanych WybierzZListy(String PozycjaNaLiscie)
        {
            driver.Mouse.MouseMove(driver.FindElementByName(PozycjaNaLiscie).Coordinates);
            driver.Mouse.Click(null);

            return this;
        }
    }
}
