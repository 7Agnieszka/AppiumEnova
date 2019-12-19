using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Narzedzia.Systemowe
{
    class Operatorzy : AbstractWindow
    {
        private WindowsElement DrugiButtonToolbar => driver.FindElement(By.XPath("//ToolBar[@Name=\"Niestandardowa 1\"]/Button[2]"));

        public Operatorzy(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public OperatorOkno OtworzOperatoraOKodzie(String KodOperatora)
        {
            KliknijKomorkeOPodanymTekscieIKolumnie(KodOperatora, "Kod");
            DrugiButtonToolbar.Click();
            return new OperatorOkno(driver);
        }
    }
}
