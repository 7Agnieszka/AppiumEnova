using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.Opcje.BI
{
    class ZestawyPrzedzialowDanych : AbstractWindow
    {
        private WindowsElement NowyDefinicja => driver.FindElement(By.Name("Nowy (Zestaw przedziałów liczb dziesiętnych)"));

        public ZestawyPrzedzialowDanych(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public void NowaDefinicjaZestawu()
        {
            NowyDefinicja.Click();
        }

    }
}
