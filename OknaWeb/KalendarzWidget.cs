using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class KalendarzWidget : AbstractWindow
    {
        private IWebElement MiesiacBttn => driver.FindElement(By.ClassName("month"));
        private IWebElement StartDateDiv => driver.FindElement(By.ClassName("datepicker-start-date"));
        private IWebElement EndDateDiv => driver.FindElement(By.ClassName("datepicker-end-date"));
        private IWebElement OkienkoKalendarza => driver.FindElement(By.ClassName("datepicker-box-content"));
        private IWebElement OKBttn => driver.FindElement(By.CssSelector("div[data-icon=\"ok\"]"));
        Actions actions = new Actions(driver);

        public KalendarzWidget(RemoteWebDriver driver) : base(driver)
        {
        }


        public KalendarzWidget DataPoczatkowa()
        {

            StartDateDiv.Click();
            return this;
        }

        public KalendarzWidget DataKoncowa()
        {

            EndDateDiv.Click();
            return this;
        }

        public KalendarzWidget Miesiac()
        {

            MiesiacBttn.Click();
            return this;
        }


        public KalendarzWidget WybierzMiesiac(String miesiac)
        {

            switch (miesiac)
            {
                case "Styczeń":
                    driver.FindElementById("fn-0").Click();
                    return this;
                case "Luty":
                    driver.FindElementById("fn-1").Click();
                    return this;
                case "Marzec":
                    driver.FindElementById("fn-2").Click();
                    return this;
                case "Kwiecień":
                    driver.FindElementById("fn-3").Click();
                    return this;
                case "Maj":
                    driver.FindElementById("fn-4").Click();
                    return this;
                case "Czerwiec":
                    driver.FindElementById("fn-5").Click();
                    return this;
                case "Lipiec":
                    driver.FindElementById("fn-6").Click();
                    return this;
                case "Sierpień":
                    driver.FindElementById("fn-7").Click();
                    return this;
                case "Wrzesień":
                    driver.FindElementById("fn-8").Click();
                    return this;
                case "Październik":
                    driver.FindElementById("fn-9").Click();
                    return this;
                case "Listopad":
                    driver.FindElementById("fn-10").Click();
                    return this;
                case "Grudzień":
                    driver.FindElementById("fn-11").Click();
                    return this;
                default:
                    return this;


            }
        }


        public KalendarzWidget WybierzDzien(String dzien)
        {
            //   driver.FindElementByXPath("//div[@class='datepicker-day-button' and text()=" + dzien + "]").Click();

            //            driver.Mouse.MouseMove(driver.FindElementByXPath("//div[text()=" + dzien + "]").Location);
            ThreadSleep(2000);
            OkienkoKalendarza.Click();
            String xpath = "//div[contains(@class, 'datepicker-box-calendar')]/div[" + dzien + "]";

            //  actions.Click(driver.FindElementByXPath("//div[@class='datepicker-day-button' and text()=" + dzien + "]")).Perform();
            //  HighlightElement(driver.FindElementByXPath("//div[contains(@class, 'datepicker-box-calendar')]/div["+dzien+"]"));
            //  actions.Click(driver.FindElementByXPath("//div[text()=" + dzien + "]")).Build().Perform();


            for (int i = 0; i <= 5; i++)
            { try
                {
                    actions.Click(driver.FindElementByXPath(xpath)).Build().Perform();
                    break;
                }
                catch (StaleElementReferenceException e)
                {

                } }

            //    actions.MoveToElement("//div[@class='datepicker-box-calendar']/div[14]")

            // driver.FindElementByXPath("//div[text()=" + dzien + "]").Click();




            return this;
        }


        public void Zatwierdz()
        {

            ThreadSleep(1000);


            
            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    actions.Click(OKBttn).Build().Perform();
                    break;
                }
                catch (StaleElementReferenceException e)
                {

                }
            }

        }

    }
}
