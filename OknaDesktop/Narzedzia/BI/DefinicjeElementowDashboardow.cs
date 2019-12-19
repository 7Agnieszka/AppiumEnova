using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Opcje.BI
{
    class DefinicjeElementowDashboardow : AbstractWindow
    {
        private WindowsElement NowyWskaznik => driver.FindElement(By.Name("Nowy (Wskaźnik)"));

        public DefinicjeElementowDashboardow(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public void NowyWskaznik1()
        {
            driver.Mouse.MouseMove(NowyWskaznik.Coordinates, 138, 15);
            driver.Mouse.Click(null);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.Enter);
        }

        public void NowyWskaznik2()
        {
            driver.Mouse.MouseMove(NowyWskaznik.Coordinates, 138, 15);
            driver.Mouse.Click(null);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.ArrowDown);
            driver.Keyboard.SendKeys(Keys.Enter);
        }
    }
}
