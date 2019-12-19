using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Narzedzia.Systemowe
{
    class OperatorOkno : AbstractWindow
    {
        private WindowsElement ZarzadzaPozostalymiOperatoramiCheckBox => driver.FindElement(By.XPath("//Pane[3]"));

        public OperatorOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public OperatorOkno PrzejdzDoZakladkiSystemowe()
        {
            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys("2");
            driver.Keyboard.SendKeys(Keys.Control);
            return this;
        }

        public bool CzyZazrzadzaPozostalymiOperatorami()
        {
            if (ZarzadzaPozostalymiOperatoramiCheckBox.Text == " Nie")
                return false;
            return true;
        }

        public void ZaznaczOdznaczZarzadzaPozostalymiOperatorami()
        {
            ZarzadzaPozostalymiOperatoramiCheckBox.Click();
        }
    }
}
