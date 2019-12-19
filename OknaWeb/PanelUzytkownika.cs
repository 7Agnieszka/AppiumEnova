using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class PanelUzytkownika : AbstractWindow
    {
        private IWebElement PierwszyElementOkruszkow => driver.FindElement(By.XPath("//*[@id=\"HeaderBar\"]/div[2]/div/div[1]"));
        private IWebElement PierwszyElementOkruszkowAng => driver.FindElement(By.XPath("//*[@id=\"HeaderBar\"]/div[2]/div/div[1]/div/div[1]"));
        #region Weryfikacja Angielskiego

        private IWebElement EmployeePanel => driver.FindElement(By.XPath("//div[text()=\"Employee\"]"));
        private IWebElement VacationLeavePanel => driver.FindElement(By.XPath("//div[text()=\"Vacation leave\"]"));
        private IWebElement PracownikPanel => driver.FindElement(By.XPath("//div[text()=\"Pracownik\"]"));
        private IWebElement UrlopWypoczynkowyPanel => driver.FindElement(By.XPath("//div[text()=\"Urlop wypoczynkowy\"]"));


        #endregion


        public PanelUzytkownika(RemoteWebDriver driver) : base(driver)
        {
        }

        public FolderGlowny PrzejdzDoGlownegoFolderu()
        {
            PierwszyElementOkruszkow.Click();
            return new FolderGlowny(driver);
        }

        public FolderGlowny PrzejdzDoGlownegoFolderuAng()
        {
            PierwszyElementOkruszkowAng.Click();
            return new FolderGlowny(driver);
        }

        public bool JestAngielski()
        {
            try {
                EmployeePanel.GetType();
                VacationLeavePanel.GetType();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool JestPolski()
        {
            try
            {
                PracownikPanel.GetType();
                UrlopWypoczynkowyPanel.GetType();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
