using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Handel
{
    class DashboardManagerOkno : AbstractWindow
    {
        private WindowsElement Dodaj => driver.FindElement(By.Name("&1. Dodaj >"));

        public DashboardManagerOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public DashboardManagerOkno KliknijDodaj()
        {
            Dodaj.Click();
            return this;
        }
    }
}
