using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class AbstractTableWindow : AbstractWindow
    {
        public AbstractTableWindow(RemoteWebDriver driver) : base(driver)
        {
        }


        public IWebElement NavigateGrid(String NazwaListyNazwaKolumnyNrWiersza)
        {
            String[] t = NazwaListyNazwaKolumnyNrWiersza.Split(':');

            int LiczbaKolumn = driver.FindElements(By.XPath("//*[@id=\"" + t[0] + "_columns_cells\"]/*")).Count;
            int NrKolumny = 0;

            for (int i = 2; i <= LiczbaKolumn; i++)
            {
                String TytulKolumny = driver.FindElement(By.XPath("//*[@id=\"" + t[0] + "_columns_cells\"]/div[" + i + "]/div[1]/span")).Text;

                if (t[1] == TytulKolumny)
                {
                    NrKolumny = i;
                    break;
                }
                else NrKolumny = 0;
            }

            return driver.FindElement(By.XPath("//*[@id=\"" + t[0] + "_canvas\"]/div[" + t[2] + "]/div[" + NrKolumny + "]"));
        }

    }
}
