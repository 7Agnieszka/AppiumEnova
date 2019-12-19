using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Handel
{
    class TowarOkno : AbstractWindow
    {
        private WindowsElement Okno => driver.FindElementByXPath("/Window[@AutomationId=\"DataForm\"]");
        private WindowsElement KodPole => driver.FindElementByXPath("//Text[@Name=\"Kod:\"]/following-sibling::Pane");
        private WindowsElement KodPoleTekstowe => driver.FindElementByXPath("//Text[@Name=\"Kod:\"]/following-sibling::Pane/Edit[1]");
        private WindowsElement ZapisziZamknij => driver.FindElementByName("Zapisz i zamknij");

        public TowarOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public void KliknijKodPole()
        {
            KodPole.Click();
        }

        public void UzupelnijKodPole(String Text)
        {
            KodPoleTekstowe.SendKeys(Text);
        }

        public String TekstKodPole()
        {
            return KodPole.Text;
        }

        public void WyczyscTekstKodPole()
        {
            KodPoleTekstowe.Clear();
        }

        public void KliknijZapisziZamknij()
        {
            ZapisziZamknij.Click();
        }

        public String WymiaryOkienka()
        {
            String WordWidth = "Width:";
            String WordHeight = "Height:";
            String WymiarWidth;
            String WymiarHeight;
            String Zwrot; ;

            Okno.Click();
            Zwrot = Okno.GetAttribute("BoundingRectangle");
            WymiarWidth = Zwrot.Substring(Zwrot.IndexOf(WordWidth) + WordWidth.Length, Zwrot.IndexOf(" ", Zwrot.IndexOf(WordWidth) + 1) - Zwrot.IndexOf(WordWidth) - WordWidth.Length);
            WymiarHeight = Zwrot.Substring(Zwrot.IndexOf(WordHeight) + WordHeight.Length);

            return WymiarWidth + " " + WymiarHeight;
        }

        public String WymiaryPolaKod()
        {
            String WordWidth = "Width:";
            String WordHeight = "Height:";
            String WymiarWidth;
            String WymiarHeight;
            String Zwrot; ;

            Okno.Click();
            Zwrot = KodPole.GetAttribute("BoundingRectangle");
            WymiarWidth = Zwrot.Substring(Zwrot.IndexOf(WordWidth) + WordWidth.Length, Zwrot.IndexOf(" ", Zwrot.IndexOf(WordWidth) + 1) - Zwrot.IndexOf(WordWidth) - WordWidth.Length);
            WymiarHeight = Zwrot.Substring(Zwrot.IndexOf(WordHeight) + WordHeight.Length);

            return WymiarWidth + " " + WymiarHeight;
        }
    }
}
