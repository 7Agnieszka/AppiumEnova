using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace TestyInterfejsowe.OknaDesktop.KiP
{
    class PracownikOkno : AbstractWindow
    {
        private WindowsElement StrzalkaPrawo => driver.FindElementByName("Następny zapis");
        private WindowsElement StrzalkaLewo => driver.FindElementByName("Poprzedni zapis");
        private WindowsElement Okienko => driver.FindElementById("DataForm");
        private WindowsElement NazwiskoPole => driver.FindElementByXPath("//Text[@Name=\"Nazwisko:\"]/following-sibling::Pane");

        public PracownikOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public void KliknijOkienko()
        {
            Actions actions = new Actions(driver);
            actions.MoveByOffset(200, 200).Build().Perform();
            Thread.Sleep(4000);
            actions.ContextClick().Build().Perform();
            FocusNaOkienko();
        }

        public PracownikOkno KliknijStrzalkeWLewo()
        {
            StrzalkaLewo.Click();
            return this;
        }

        public PracownikOkno KliknijStrzalkeWPrawo()
        {
            StrzalkaPrawo.Click();
            return this;
        }

        public String NazwiskoWartosc()
        {
            return NazwiskoPole.Text;
        }
    }
}
