using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.CRM
{
    class KontrahenciTabela : AbstractWindow
    {
        private WindowsElement Otworz => driver.FindElementByName("Otwórz");

        public KontrahenciTabela(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public KontrahentOkno OtworzRekord()
        {
            Otworz.Click();
            return new KontrahentOkno(driver);
        }

    }
}
