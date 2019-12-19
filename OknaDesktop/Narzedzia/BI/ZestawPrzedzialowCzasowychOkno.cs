using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Narzedzia.BI
{
    class ZestawPrzedzialowCzasowychOkno : AbstractWindow
    {
        private WindowsElement Name => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanSetOgolnePage\"]/Pane[3]"));
        private WindowsElement NowyElement => driver.FindElement(By.Name("Nowy (Element zestawu przedziału czasowego)"));
        private WindowsElement DefinicjaPrzedzialuWybierz => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanItemOgolnePage\"]/Pane[3]"));

        public ZestawPrzedzialowCzasowychOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public ZestawPrzedzialowCzasowychOkno WpiszName(String Nazwa)
        {
            Name.Click();
            driver.Keyboard.SendKeys(Nazwa);
            return this;
        }

        public ZestawPrzedzialowCzasowychOkno KLiknijNowyElementZestawu()
        {
            NowyElement.Click();
            return this;
        }

        public ZestawPrzedzialowCzasowychOkno WybierzDefinicjaPrzdzialu(String Text)
        {
            DefinicjaPrzedzialuWybierz.Click();
            driver.Keyboard.SendKeys(Text);
            driver.Keyboard.SendKeys(Keys.Enter);
            return this;
        }

        public ZestawPrzedzialowCzasowychOkno Zatwierdz()
        {
            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys(Keys.Return);
            driver.Keyboard.ReleaseKey(Keys.Control);
            driver.Keyboard.ReleaseKey(Keys.Return);

            return this;
        }
    }
}
