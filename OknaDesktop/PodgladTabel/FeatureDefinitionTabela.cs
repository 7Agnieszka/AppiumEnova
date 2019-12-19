using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.PodgladTabel
{
    class FeatureDefinitionTabela : AbstractWindow
    {
        private WindowsElement NowaCechaBttn => driver.FindElementByName("Nowy (Definicja cechy)");

        public FeatureDefinitionTabela(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public DefinicjaCechyOkno NowaCecha()
        {
            NowaCechaBttn.Click();
            return new DefinicjaCechyOkno(driver);
        }
    }
}
