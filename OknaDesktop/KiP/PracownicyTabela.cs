using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.KiP
{
    class PracownicyTabela : AbstractWindow
    {
        private WindowsElement Otworz => driver.FindElementByName("Otwórz");

        public PracownicyTabela(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }
        public PracownikOkno OtworzRekord()
        {
            Otworz.Click();
            return new PracownikOkno(driver);
        }
    }
}
