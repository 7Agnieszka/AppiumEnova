using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using TestyInterfejsowe.OknaWeb;
using TestyInterfejsowe.Testy.KlasyPomocnicze;

namespace TestyInterfejsowe.Testy
{
    class FunkcjeScriptera : AbstractTestWeb
    {
        internal BazaDanych BAZA_PULPITY = new BazaDanych("TestRD", BazaDanych.Licencja.Zlota);
        internal BazaDanych BAZA_PULPITY_ANG = new BazaDanych("TestRD", BazaDanych.Licencja.Zlota, BazaDanych.Jezyk.Angielski);
        internal BazaDanych BAZA_PELNA = new BazaDanych("RDTestPelnaBaza", BazaDanych.Licencja.Zlota);

        [TestCase]
        public void HTML_WinForm_Grid_IsFirst_IsLast()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna strona = stronaLogowania
                .ZalogujAdministrator();
            strona.NavigateFolders("Handel/Towary i usługi");
            String s = strona
                .NavigateGrid("List:Kod:1")
                .GetAttribute("Class");

            Assert.AreEqual("gc gc-so gc-active gc-text", s);

            Assert.AreEqual("r_1_aqzb", driver.FindElementByCssSelector(".focused").GetAttribute("id"));
        }

        [TestCase]
        public void HTML_WinForm_Grid_FocusedColumn()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna strona = stronaLogowania
                .ZalogujAdministrator();
            strona.NavigateFolders("Handel/Towary i usługi");
            strona.NavigateGrid("List:Nazwa:1")
                .Click();
            String s = strona.NavigateGrid("List:Nazwa:1")
                .GetAttribute("Class");

            Assert.AreEqual("gc gc-active gc-text", s);
            s = strona.NavigateGrid("List:Kod:1")
                .GetAttribute("Class");

            Assert.AreNotEqual("gc gc-active gc-text", s);
            strona.NavigateGrid("List:EAN:1").Click();
            s = strona.NavigateGrid("List:EAN:1")
                .GetAttribute("Class");

            Assert.AreEqual("gc gc-active gc-text", s);
            s = strona.NavigateGrid("List:Nazwa:1")
                .GetAttribute("Class");

            Assert.AreNotEqual("gc gc-active gc-text", s);
        }

        [TestCase]
        [Ignore("error")]
        public void HTML_WinForm_Grid_SelectedData()
        {
            Actions actions = new Actions(driver);
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna strona = stronaLogowania
                .ZalogujAdministrator();
            strona.NavigateFolders("Handel/Towary i usługi");
            actions.KeyDown(Keys.Control).Perform();
            strona.NavigateGrid("List:Nazwa:7")
                .Click();
            strona.NavigateGrid("List:Kod:1")
                .Click();
            strona.NavigateGrid("List:Nazwa:3")
                .Click();
            strona.NavigateGrid("List:Nazwa:6")
                .Click();
            actions.KeyUp(Keys.Control)
                .Perform();
            // strona.WaitForPageToBeReady();
            int LiczbaWybranych = driver.FindElementsByCssSelector(".check-open").Count;
            stronaLogowania.ThreadSleep(1000);

            Assert.AreEqual(4, LiczbaWybranych);

            actions.KeyDown(Keys.Control)
                .Perform();
            strona.NavigateGrid("List:Kod:7")
                .Click();
            actions.KeyUp(Keys.Control)
                .Perform();

            LiczbaWybranych = driver.FindElementsByCssSelector(".check-open")
                .Count;

            Assert.AreEqual(3, LiczbaWybranych);
        }

        [TestCase]
        public void HTML_WinForm_Grid_SelectedData_Set()
        {
            Actions actions = new Actions(driver);

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna strona = stronaLogowania
                .ZalogujAdministrator();
            strona.NavigateFolders("Handel/Towary i usługi");
            strona.NavigateGrid("List:Nazwa:3")
                .Click();
            actions.KeyDown(Keys.Shift)
                .Perform();
            strona.NavigateGrid("List:Nazwa:8")
                .Click();
            actions.KeyUp(Keys.Shift)
                .Perform();
            int LiczbaWybranych = driver.FindElementsByCssSelector(".check-open")
                .Count;

            Assert.AreEqual(6, LiczbaWybranych);

            actions.KeyDown(Keys.Control)
                .Perform();
            strona.NavigateGrid("List:Kod:7")
                .Click();
            actions.KeyUp(Keys.Control)
                .Perform();
            LiczbaWybranych = driver.FindElementsByCssSelector(".check-open")
                .Count;

            Assert.AreEqual(5, LiczbaWybranych);
        }

        [TestCase]
        public void HTML_GRID_SelectAll()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna strona = stronaLogowania
                .ZalogujAdministrator();
            strona.NavigateFolders("Handel/Towary i usługi");
            driver.FindElementByXPath("//*[@id=\"List_columns_cells\"]/div[1]")
                .Click();
            int LiczbaWybranych = driver.FindElementsByCssSelector(".check-open")
                .Count;
            Assert.AreEqual(51, LiczbaWybranych);
        }

        [TestCase]
        public void HTML_WinForm_Grid_Focused_AfterOpenForm()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna strona = stronaLogowania
                .ZalogujAdministrator();
            strona.NavigateFolders("Kontrahenci i urzędy/Kontrahenci");
            strona.NavigateGrid("List:Nazwa:2")
                .Click();
            strona.NavigateGrid("List:Nazwa:2")
                .Click();
            String s = strona.NavigateGrid("List:Nazwa:2")
                .GetAttribute("Class");

            Assert.AreEqual("gc gc-active gc-text", s);

            strona.NavigateGrid("List:Kod:2")
                .Click();
            strona.FindElementBy("id:Rozrachunki")
                .Click();
            strona.FindElementBy("text:Rozrachunki")
                .Click();
            strona.NavigatePage("Rozrachunki");
            strona.CloseActiveTab();
            s = strona.NavigateGrid("List:Nazwa:1")
                .GetAttribute("Class");

            Assert.AreEqual("gc gc-active gc-text", s);
        }

        [TestCase]
        public void NavigateTest()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            stronaGlowna.NavigateFolders("Handel/Towary i usługi");

            Assert.AreEqual("http://localhost/db/" + BAZA_PELNA.NazwaBazyDanych + "#Folder/Handel/Kartoteki/TowaryIUslugi", driver.Url);
        }

        [TestCase]
        public void CloseTest()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            stronaGlowna.NavigateFolders("Handel/Towary i usługi");
            stronaGlowna.NavigateGrid("List:Kod:3")
                .Click();
            stronaGlowna.Close();
            stronaGlowna.NavigateGrid("List:Kod:3")
                .Click();
            driver.FindElementByXPath("//*[@id=\"TowarPage_scroll\"]/div[1]/div/div[1]/div[2]/div[1]/div/div[2]/input").SendKeys("test");
            stronaGlowna.Close();
            stronaGlowna.FindElementBy("id:List_New").Click();
            stronaGlowna.Close();
        }

        [TestCase]
        public void LoadingKeepNextTest()
        {
            Actions actions = new Actions(driver);
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            stronaGlowna.NavigateFolder("Handel", "Towary i usługi");
            var LiczbaRekordow = driver.FindElementsByXPath("//*[@id=\"List_canvas\"]/*").Count;

            Assert.AreEqual(50, LiczbaRekordow);

            var TopValue = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;
            var Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.AreEqual(TopValue, Point);

            actions.SendKeys(Keys.PageDown).Perform();
            LiczbaRekordow = driver.FindElementsByXPath("//*[@id=\"List_canvas\"]/*").Count;

            Assert.AreEqual(50, LiczbaRekordow);

            Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.Less(0, Point);

            //list.postLoadMoreRowsNext(); // Wysłanie List:next
            // wygląda na funkcję wywoływaną z wnętrza (nie dostępna z poziomu Selenium
        }

        [TestCase]
        public void LoadingKeepNextTestDraft()
        {
            Actions actions = new Actions(driver);

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            stronaGlowna.NavigateFolder("Handel", "Towary i usługi");
            var TopValue = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;
            var Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.AreEqual(TopValue, Point);

            actions.SendKeys(Keys.PageDown);
            actions.Perform();
            Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.AreEqual(178, Point);
            Assert.Less(Point, TopValue);

            actions.SendKeys(Keys.PageDown)
                .Perform();
            Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.AreEqual(-686, Point);
            Assert.Less(Point, TopValue);
        }

        [TestCase]
        [Ignore(" nieskonczony")]
        public void GoToInner()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            stronaGlowna.NavigateFolder("Handel", "Towary i usługi");
        }

        [TestCase]
        public void LoadingNext()
        {
            Actions actions = new Actions(driver);

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania.ZalogujAdministrator();
            stronaGlowna.NavigateFolder("Handel", "Towary i usługi");
            var TopValue = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;
            var Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.AreEqual(Point, TopValue);

            actions.SendKeys(Keys.PageDown).Perform();
            Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.Less(Point, TopValue);

            actions.SendKeys(Keys.PageDown).Perform();
            Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.Less(Point, TopValue);

            actions.SendKeys(Keys.PageDown).Perform();
            Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.Less(Point, TopValue);

            actions.SendKeys(Keys.PageDown).Perform();
            Point = driver.FindElementByXPath("//*[@id=\"List_canvas\"]/div[1]").Location.Y;

            Assert.Less(Point, TopValue);
        }
    }
}
