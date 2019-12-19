using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Opcje.BI
{
    class BIOgolne : AbstractWindow
    {
        private WindowsElement PrawaModeliDanychCheckBox => driver.FindElement(By.XPath("//Pane[2]/CheckBox[1]"));

        public BIOgolne(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public bool CzyPrawaModeliDanych()
        {
            if (PrawaModeliDanychCheckBox.Text == " Nie")
                return false;
            return true;
        }

        public void ZaznaczOdznaczPrawaModeliDanychCheckBox()
        {
            PrawaModeliDanychCheckBox.Click();
        }
    }
}
