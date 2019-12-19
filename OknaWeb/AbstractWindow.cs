using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TestyInterfejsowe.OknaWeb
{
    public abstract class AbstractWindow
    {
        private IWebElement Overlay => driver.FindElement(By.ClassName("modal-overlay"));
        private IWebElement OverlayLoader => driver.FindElement(By.ClassName("overlay-screen-loader"));
        private IWebElement TakBttn => driver.FindElement(By.XPath("//div[text()=\"Tak\"]"));
        protected static RemoteWebDriver driver;
        protected static IJavaScriptExecutor js = driver;

        public AbstractWindow(RemoteWebDriver driver)
        {
            AbstractWindow.driver = driver;
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



        public void NavigatePage(String PageName)
        {

            driver.FindElementByXPath("//div[@class=\"nav-item\"]/div[text()=\"" + PageName + "\"]").Click();
        }


        public IWebElement FindElementBy(String NazwaStrony)
        {


            String[] t = NazwaStrony.Split(':');

            if (t[0] == "text")
            {
                return driver.FindElement(By.XPath("//div[text()=\"" + t[1] + "\"]"));
            }
            if (t[0] == "id")
            {
                return driver.FindElement(By.Id(t[1].ToString()));
            }
            if (t[0] == "name")
            {
                return driver.FindElement(By.Name(t[1]));
            }
            else
            {
                return driver.FindElementById(t[0]);
            }

        }
        public void KliknijTak()
        {
            TakBttn.Click();
        }

        public void CloseActiveTab()
        {
            Actions actions = new Actions(driver);

            actions.MoveByOffset(driver.FindElementByXPath("//*[@class=\"hb-bookmark active\"]/div[2]/div[1]").Location.X,
                driver.FindElementByXPath("//*[@class=\"hb-bookmark active\"]/div[2]/div[1]").Location.Y).Click().Perform();
        }

        public String GetTabName()
        {
            return driver.FindElementByXPath("//*[@class=\"hb-bookmark active\"]/div[1]/div[1]").Text;
        }


        //public void WaitForPageToBeReady()
        //{
        //    IJavaScriptExecutor jsScript = driver as IJavaScriptExecutor;
        //    while (!(Boolean)jsScript.ExecuteScript("return true "))
        //    {
        //        Thread.Sleep(200);
        //    }

        //}


        public IWebElement FindElementByText(String TekstElementu)
        {
            return driver.FindElement(By.XPath("//div[text()=\"" + TekstElementu + "\"]"));
        }

        public void NavigateFolder(String NazwaFolderu)
        {

            driver.FindElement(By.XPath("//div[text()=\"" + NazwaFolderu + "\"]")).Click();
        }

        public void NavigateFolders(String SciezkaDoFolderu)
        {
            String[] t = SciezkaDoFolderu.Split('/');

            for (int i = 0; i < t.Length; i++)
            {
                driver.FindElement(By.XPath("//div[text()=\"" + t[i] + "\"]")).Click();
            }
        }





        public void NavigateFolder(String NazwaFolderu1, String NazwaFolderu2)
        {

            driver.FindElement(By.XPath("//div[text()=\"" + NazwaFolderu1 + "\"]")).Click();
            driver.FindElement(By.XPath("//div[text()=\"" + NazwaFolderu2 + "\"]")).Click();
        }

        public void NavigateFolderURL(String Adres)
        {
            driver.Navigate().GoToUrl(driver.Url.TrimEnd('#') + "" + Adres);

        }
        public void Quit(String NazwaFolderu)
        {
            driver.Quit();
        }

        public void Close()
        {

            //WaitForPageToBeReady();
            //  driver.FindElementByXPath("//*[@id=\"HeaderBar\"]/div/div[2]/div[last()]").Click();
            driver.FindElementByXPath("//*[@id=\"HeaderBar\"]/div/div[2]/div[5]/div/div[2]").Click();

            if (driver.FindElementByXPath("//*[@id=\"container\"]/div[2]").GetAttribute("class").Equals("window-modal"))
            {
                //WaitForPageToBeReady();



                //Actions actions = new Actions(driver);
                //actions.MoveToElement(driver.FindElementByXPath("//*[@id=\"container\"]/div[2]/div/div/div[3]/div[2]/div")).Perform();

                //actions.Click(FindElementByText("Nie")).Perform();
                //actions.Click(null).Perform();
                driver.FindElementByXPath("//*[@id=\"container\"]/div[2]/div/div/div[3]/div[3]").Click();

            }
            // WaitForPageToBeReady();
        }


        public String GetURL()
        {
            return driver.Url;
        }

        public String GetPath()
        {

            return driver.Url.ToString().Substring('#');
        }

        public String GetLastPath()
        {
            return driver.Url.Substring(driver.Url.LastIndexOf('/') + 1);
        }

        public void PrzejdzDoStronyGlownej()
        {
            driver.FindElement(By.ClassName("hb-home")).Click();
        }




        public void HighlightElement(IWebElement element)
        {

            IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)driver;
            // jsDriver.ExecuteScript("alert('Hello')");
            string element_podrubiony = "arguments[0].style.border='10px solid yellow'";
            string element_zwykły = "arguments[0].style.border='0px solid white'";


            //(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"", ""background"" : ""yellow"" });";

            //string highlightJavascript = @"(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"", ""background"" : ""yellow"" });";
            jsDriver.ExecuteScript(element_podrubiony, element);
            ThreadSleep(3000);
            jsDriver.ExecuteScript(element_zwykły, element);


        }


        public void ThreadSleep()
        {

        }

        public void ThreadSleep(int i)
        {
            if (i == 14444)
                Thread.Sleep(1000);

        }


        public void WaitForLoaderToDissapear()
        {
            //int i = 0;
            //for (i = 0; i <= 15; i++)
            //    try
            //    {
            //        if (OverlayLoader.Displayed) ;

            //    }
            //    catch (Exception e)
            //    {
            //        break;
            //    }
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //wait.Until(ExpectedConditions.ElementExists(By.ClassName("overlay-screen-loader"))));

        }


    }
}
