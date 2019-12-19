using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class FolderGlowny : AbstractWindow
    {
        //        private IWebElement Folder1 => driver.FindElement(By.Name("folder_1"));
        private IWebElement Folder0 => driver.FindElement(By.XPath("//*[@id=\"folder_0\"]/div[1]/div[2]"));
        private IWebElement Folder1 => driver.FindElement(By.XPath("//*[@id=\"folder_1\"]/div[1]/div[2]"));
        private IWebElement Folder2 => driver.FindElement(By.XPath("//*[@id=\"folder_2\"]/div[1]/div[2]"));
        private IWebElement Folder3 => driver.FindElement(By.XPath("//*[@id=\"folder_3\"]/div[1]/div[2]"));
        private IWebElement PulpitPracownikaBttn => driver.FindElement(By.XPath("//div[text()=\"Pulpit pracownika\"]"));
        private IWebElement EmployeeDashboardBttn => driver.FindElement(By.XPath("//div[text()=\"Employee dashboard\"]"));
        private IWebElement PulpitKierownikaBttn => driver.FindElement(By.XPath("//div[text()=\"Pulpit kierownika\"]"));
        private IWebElement ManagerDashboardBttn => driver.FindElement(By.XPath("//div[text()=\"Manager dashboard\"]"));
        private IWebElement PulpitKontrahentaBttn => driver.FindElement(By.XPath("//div[text()=\"Pulpit kontrahenta\"]"));
        private IWebElement CustomerDashboardBttn => driver.FindElement(By.XPath("//div[text()=\"Customer dashboard\"]"));
        public FolderGlowny(RemoteWebDriver driver) : base(driver)
        {
        }


        public void KliknijPulpitPracownika()
        {
            PulpitPracownikaBttn.Click();
            Folder2.GetType();

        }
        public PulpitKierownika KliknijPulpitKierownika()
        {
            PulpitKierownikaBttn.Click();
            Folder2.GetType();
            return new PulpitKierownika(driver);
        }

        public PulpitKierownika ClickEmployeeDashboard()
        {
            EmployeeDashboardBttn.Click();
            Folder2.GetType();
            return new PulpitKierownika(driver);
        }

        public PulpitKierownika ClickManagerDashboard()
        {
            ManagerDashboardBttn.Click();
            Folder2.GetType();
            return new PulpitKierownika(driver);
        }

        public void KliknijPulpitKontrahenta()
        {
            PulpitKontrahentaBttn.Click();
            Folder2.GetType();
        }




        public void ClickCustomerDashboard()
        {
            CustomerDashboardBttn.Click();
            Folder2.GetType();
        }

        public String TytulFolder0()
        {
            return Folder0.Text;
        }
        public String TytulFolder1()
        {
            return Folder1.Text;
        }
        public String TytulFolder2()
        {
            return Folder2.Text;
        }
    }
}
