using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Opcje.BI
{
    class DefinicjaZastawowDanych : AbstractWindow
    {
        private WindowsElement PierwszyButtonToolbar => driver.FindElement(By.XPath("//ToolBar[@Name=\"Niestandardowa 1\"]/Button[1]"));
        private WindowsElement NowyDefinicja => driver.FindElement(By.Name("Nowy (Definicja zestawów danych)"));

        public DefinicjaZastawowDanych(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public void NowaDefinicjaZestawu()
        {
            NowyDefinicja.Click();
        }

        public string PobierzNazwePrzyciskuZToolbar()
        {
            return PierwszyButtonToolbar.Text;
        }
    }
}
