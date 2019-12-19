using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using TestyInterfejsowe.OknaDesktop.Narzedzia.BI;

namespace TestyInterfejsowe.OknaDesktop.Opcje.BI
{
    class DefinicjaPrzedzialowCzasowych : AbstractWindow
    {
        private WindowsElement PierwszyButtonToolbar => driver.FindElement(By.XPath("//ToolBar[@Name=\"Niestandardowa 1\"]/Button[1]"));
        private WindowsElement Usun => driver.FindElement(By.Name("Usuń"));
        private WindowsElement NowyDefinicja => driver.FindElement(By.Name("Nowy (Definicja dynamiczna)"));
        private WindowsElement OtworzBttn => driver.FindElement(By.Name("Otwórz"));

        public DefinicjaPrzedzialowCzasowych(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }
        public DefinicjaDynamicznaOkno NowaDefinicja()
        {
            NowyDefinicja.Click();
            return new DefinicjaDynamicznaOkno(driver);
        }

        public DefinicjaStatycznaOkno NowaDefinicjaStatyczna()
        {
            driver.Mouse.MouseMove(NowyDefinicja.Coordinates, 205, 15);
            driver.Mouse.Click(null);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.Enter);
            return new DefinicjaStatycznaOkno(driver);
        }

        public string PobierzNazwePrzyciskuZToolbar()
        {
            return PierwszyButtonToolbar.Text;
        }

        public DefinicjaPrzedzialowCzasowych UsunRekord()
        {
            Usun.Click();
            Kliknij_Tak();
            Thread.Sleep(500);
            return this;
        }

        public int LewaWspolrzednaPrzyciskuOtworz()
        {
            String WordLeft = "Left:";
            String Zwrot;
            String Left;
            Zwrot = OtworzBttn.GetAttribute("BoundingRectangle");
            Left = Zwrot.Substring(Zwrot.IndexOf(WordLeft) + WordLeft.Length, Zwrot.IndexOf(" ", Zwrot.IndexOf(WordLeft) + 1) - Zwrot.IndexOf(WordLeft) - WordLeft.Length);

            return Int32.Parse(Left);
        }

        public int TopWspolrzednaPrzyciskuOtworz()
        {
            String WordTop = "Top:";
            String Zwrot;
            String Top;

            Zwrot = OtworzBttn.GetAttribute("BoundingRectangle");
            Top = Zwrot.Substring(Zwrot.IndexOf(WordTop) + WordTop.Length, Zwrot.IndexOf(" ", Zwrot.IndexOf(WordTop) + 1) - Zwrot.IndexOf(WordTop) - WordTop.Length);

            return Int32.Parse(Top);
        }
    }
}
