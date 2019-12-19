using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Narzedzia.BI
{
    class DefinicjaStatycznaOkno : AbstractWindow
    {
        private WindowsElement Name => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[2]"));
        private WindowsElement Przedzial => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[last()]"));

        public DefinicjaStatycznaOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public DefinicjaStatycznaOkno WpiszNazwe(String Nazwa)
        {
            Name.Click();
            driver.Keyboard.SendKeys(Nazwa);
            return this;
        }

        public DefinicjaStatycznaOkno WpiszPrzedzial(String Nazwa)
        {
            Przedzial.Click();
            driver.Keyboard.SendKeys(Nazwa);
            driver.Keyboard.SendKeys(Keys.Enter);
            return this;
        }
    }
}
