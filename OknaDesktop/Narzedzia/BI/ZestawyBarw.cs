using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Opcje.BI
{
    class ZestawyBarw : AbstractWindow
    {
        private WindowsElement NowyDefinicja => driver.FindElement(By.Name("Nowy (Zestaw barw)"));

        public ZestawyBarw(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public void NowaDefinicjaZestawu()
        {
            NowyDefinicja.Click();
        }
    }
}
