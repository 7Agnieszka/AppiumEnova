using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Narzedzia.BI
{
    class DefinicjaDynamicznaOkno : AbstractWindow
    {
        private WindowsElement Name => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[2]"));
        private WindowsElement OdTekst => driver.FindElement(By.Name("Od:"));
        private WindowsElement DoTekst => driver.FindElement(By.Name("Do:"));
        private WindowsElement TekstPodglad => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Text[2]"));
        #region parametry
        private WindowsElement Od1Pole1 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[4]"));
        private WindowsElement Od1Pole2 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[5]"));
        private WindowsElement Od1Pole3 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[6]"));
        private WindowsElement Od2Pole1 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[7]"));
        private WindowsElement Od2Pole2 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[8]"));
        private WindowsElement Od2Pole3 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[9]"));
        private WindowsElement Do1Pole1 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[10]"));
        private WindowsElement Do1Pole2 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[11]"));
        private WindowsElement Do1Pole3 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[12]"));
        private WindowsElement Do2Pole1 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[13]"));
        private WindowsElement Do2Pole2 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[14]"));
        private WindowsElement Do2Pole3 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[15]"));
        private WindowsElement Do3Pole1 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[16]"));
        private WindowsElement Do3Pole2 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[17]"));
        private WindowsElement Do3Pole3 => driver.FindElement(By.XPath("//Pane[@AutomationId=\"TimeSpanDefinitionOgolnePage\"]/Pane[18]"));
        #endregion

        public DefinicjaDynamicznaOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public DefinicjaDynamicznaOkno WpiszNazwe(String Nazwa)
        {
            Name.Click();
            driver.Keyboard.SendKeys(Nazwa);
            return this;
        }

        public DefinicjaDynamicznaOkno OdPlus()
        {
            driver.Mouse.MouseMove(OdTekst.Coordinates, 45, 10);
            driver.Mouse.Click(null);
            return this;
        }

        public DefinicjaDynamicznaOkno DoPlus()
        {
            driver.Mouse.MouseMove(DoTekst.Coordinates, 45, 10);
            driver.Mouse.Click(null);
            return this;
        }

        public String PodgladText()
        {
            return TekstPodglad.GetAttribute("Name");
        }

        #region Obsluga Parametrow
        public void WpiszDoPola(WindowsElement element, String tekst)
        {
            element.Click();
            driver.Keyboard.SendKeys(tekst);
            driver.Keyboard.SendKeys(Keys.Enter);
        }

        public DefinicjaDynamicznaOkno WpiszOd1Pole1(String tekst)
        {
            WpiszDoPola(Od1Pole1, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszOd1Pole2(String tekst)
        {
            WpiszDoPola(Od1Pole2, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszOd1Pole3(String tekst)
        {
            WpiszDoPola(Od1Pole3, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszOd2Pole1(String tekst)
        {
            WpiszDoPola(Od2Pole1, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszOd2Pole2(String tekst)
        {
            WpiszDoPola(Od2Pole2, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszOd2Pole3(String tekst)
        {
            WpiszDoPola(Od2Pole3, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszDo1Pole1(String tekst)
        {
            WpiszDoPola(Do1Pole1, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszDo1Pole2(String tekst)
        {
            WpiszDoPola(Do1Pole2, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszDo1Pole3(String tekst)
        {
            WpiszDoPola(Do1Pole3, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszDo2Pole1(String tekst)
        {
            WpiszDoPola(Do2Pole1, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszDo2Pole2(String tekst)
        {
            WpiszDoPola(Do2Pole2, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszDo2Pole3(String tekst)
        {
            WpiszDoPola(Do2Pole3, tekst);
            return this;
        }

        public DefinicjaDynamicznaOkno WpiszDo3Pole1(String tekst)
        {
            WpiszDoPola(Do3Pole1, tekst);
            return this;
        }
        public DefinicjaDynamicznaOkno WpiszDo3Pole2(String tekst)
        {
            WpiszDoPola(Do3Pole2, tekst);
            return this;
        }
        public DefinicjaDynamicznaOkno WpiszDo3Pole3(String tekst)
        {
            WpiszDoPola(Do3Pole3, tekst);
            return this;
        }
        #endregion
    }
}
