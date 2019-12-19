using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TestyInterfejsowe.OknaDesktop;
using TestyInterfejsowe.Testy.KlasyPomocnicze;

namespace TestyInterfejsowe.Testy
{
    [TestFixture]
    class CRMModul : AbstractTestDesktop
    {
        internal BazaDanych BAZA_NUNIT_UI = new BazaDanych("nunit:ui", BazaDanych.Licencja.Demo);

        [TestCase]
        public void TC009()
        {          
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            stronaGlowna.PrzejdzDoOpcji().PrzejdzDoKontrahenciIUrzedyFolder().PrzejdzDoKontrahenciIUrzedyOgolne();
        }

        [TestCase]
        public void TC0009()
        {      
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            CRMMetody cRMMetody = new CRMMetody(driver);
            stronaGlowna.PrzejdzDoOpcji();
            driver.FindElementByName("Kontrahenci i urzędy").Click();
            driver.FindElementByName("Kategorie").Click();
            driver.FindElementByName("Nowy (Definicja kategorii kontrahentów)").Click();

            driver.FindElementByXPath("//Pane[@AutomationId=\"DefKategKthPage\"]/Pane[2]").Click();
            driver.Keyboard.SendKeys("Kategoria folder");
            driver.FindElementByXPath("//Pane[@AutomationId=\"DefKategKthPage\"]/Pane[3]").Click();
            driver.FindElementByName("OK").Click();
            driver.FindElementByName("Nowy (Definicja kategorii kontrahentów)").Click();

            driver.FindElementByXPath("//Pane[@AutomationId=\"DefKategKthPage\"]/Pane[2]").Click();
            driver.Keyboard.SendKeys("Kategoria");
            driver.FindElementByName("OK").Click();

            driver.FindElementByName("Zapisz i zamknij").Click();

            driver.FindElementByName("CRM").Click();
            driver.FindElementByName("Kontrahenci wg kategorii").Click();

            Assert.IsTrue(driver.FindElementByName("Kategoria folder").Displayed);

            driver.FindElementByName("Kontrahenci").Click();
            driver.Mouse.MouseMove(driver.FindElementByName("190600 - Soneta").Coordinates, 600, 400);
            driver.Mouse.Click(null);
            driver.Mouse.Click(null);
            driver.FindElementByName("Kontrahenci").Click();
            cRMMetody.FocusNaOkienko();
            // driver.FindElementByName("Grupuj wg cechy").Click();

            driver.FindElementByName("Kod row 1").Click();
            driver.Keyboard.SendKeys(Keys.Shift);
            driver.FindElementByName("Kod row 6").Click();
            driver.Keyboard.SendKeys(Keys.Shift);

            driver.FindElementByName("Czynności").Click();

            driver.Mouse.MouseMove(driver.FindElementByName("Przypisz kontrahentów do kategorii...").Coordinates);
            driver.Mouse.Click(null);

            driver.Keyboard.SendKeys("Kategoria");

            driver.FindElementByName("OK").Click();
            driver.FindElementByName("&OK").Click();


            driver.FindElementByName("Kod row 9").Click();
            driver.Keyboard.SendKeys(Keys.Shift);
            driver.FindElementByName("Kod row 13").Click();
            driver.Keyboard.SendKeys(Keys.Shift);

            driver.FindElementByName("Czynności").Click();

            driver.Mouse.MouseMove(driver.FindElementByName("Przypisz kontrahentów do kategorii...").Coordinates);
            driver.Mouse.Click(null);

            driver.Keyboard.SendKeys("Kategoria folder");

            driver.FindElementByName("OK").Click();
            driver.FindElementByName("&OK").Click();

            //  for (int i = 0; i <= 15; i++) driver.Keyboard.SendKeys(Keys.ArrowUp);

            driver.FindElementByName("Kod row 6").Click();
            driver.Keyboard.SendKeys(Keys.Return);

            cRMMetody.FocusNaOkienko();

            driver.Mouse.MouseMove(driver.FindElementByName("Kategorie i branże").Coordinates);
            driver.Mouse.Click(null);


            Assert.AreEqual("Zaznaczony", driver.FindElementByName("Przypisana row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Kategoria", "Kategoria")).Text);

            driver.FindElementByName("Zapisz i zamknij").Click();

            cRMMetody.FocusNaOkienko();

            // driver.FindElementByName("CRM").Click();
            driver.FindElementByName("Kontrahenci wg kategorii").Click();
            driver.FindElementByName("Kategoria folder").Click();

            Assert.AreEqual(5, cRMMetody.LiczbaWierszyOstatni());

            driver.FindElementByName("Kontrahenci").Click();
            driver.FindElementByName("Rozwiń dodatkowe filtry").Click();

            driver.Mouse.MouseMove(driver.FindElementByName("Kategoria:").Coordinates, 75, 10);
            driver.Mouse.Click(null);

            driver.Keyboard.SendKeys("Kategoria");
            driver.Keyboard.SendKeys(Keys.Enter);


            Assert.AreEqual(6, cRMMetody.LiczbaWierszyOstatni());

            driver.Mouse.MouseMove(driver.FindElementByName("Kategoria:").Coordinates, 75, 10);
            driver.Mouse.Click(null);

            driver.Keyboard.SendKeys(Keys.Backspace);
            driver.Keyboard.SendKeys(Keys.Enter);
            driver.FindElementByName("Grupuj wg cechy").Click();

            driver.FindElementByName("Nazwa row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Rolmap", "Kod")).Click();

            driver.FindElementByName("Otwórz").Click();
            Thread.Sleep(500);

            cRMMetody.FocusNaOkienko();

            driver.Mouse.MouseMove(driver.FindElementByName("Kategorie i branże").Coordinates);
            driver.Mouse.Click(null);

            driver.FindElementByName("Przypisana row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Komornik Sądowy", "Kategoria")).Click();
            driver.FindElementByName("Przypisana row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Organizacja Pożytku Publicznego", "Kategoria")).Click();

            driver.FindElementByName("Zapisz i zamknij").Click();

            cRMMetody.FocusNaOkienko();

            driver.FindElementByName("Kontrahenci wg kategorii").Click();
            driver.FindElementByName("Komornik Sądowy").Click();

            Assert.AreEqual(1, cRMMetody.LiczbaWierszyOstatni());

            driver.FindElementByName("Kontrahenci wg kategorii").Click();
            driver.FindElementByName("Organizacja Pożytku Publicznego").Click();

            Assert.AreEqual(1, cRMMetody.LiczbaWierszyOstatni());

            driver.FindElementByName("Nowy (Kontrahent)").Click();
            Thread.Sleep(500);
            cRMMetody.FocusNaOkienko();

            driver.Mouse.MouseMove(driver.FindElementByName("Kategorie i branże").Coordinates);
            driver.Mouse.Click(null);

            Assert.AreEqual("Zaznaczony", driver.FindElementByName("Przypisana row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Organizacja Pożytku Publicznego", "Kategoria")).Text);

            // driver.FindElementByName("Zamknij").Click();
            cRMMetody.ZamknijOkno();
            driver.FindElementByName("Nie").Click();
        }

        [TestCase]
        public void pomocniczy()
        {    
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            CRMMetody cRMMetody = new CRMMetody(driver);

            driver.FindElementByName("CRM").Click();

            driver.FindElementByName("Kontrahenci").Click();

            driver.Mouse.MouseMove(driver.FindElementByName("BITest - Soneta").Coordinates, 600, 400);
            driver.Mouse.Click(null);
            driver.FindElementByName("Kontrahenci").Click();

            driver.FindElementByName("Kod row 6").Click();
            driver.Keyboard.SendKeys(Keys.Return);

            driver.Mouse.MouseMove(driver.FindElementByName("Kategorie i branże").Coordinates);
            driver.Mouse.Click(null);
        }

        [TestCase]
        public void TC0013()
        {
   
            Logowanie logowanie = new Logowanie(driver);

            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");


            CRMMetody cRMMetody = new CRMMetody(driver);

            stronaGlowna.PrzejdzDoOpcji();

            driver.FindElementByName("Systemowe").Click();
            driver.FindElementByName("Operatorzy [Ctrl+O]").Click();

            driver.FindElementByName("Kod row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Administrator", "Kod")).Click();
            driver.Keyboard.SendKeys(Keys.Return);

            cRMMetody.FocusNaOkienko();
            cRMMetody.MaksymalizujOkno();
            driver.FindElementByName("Systemowe").Click();
            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys("2");
            driver.Keyboard.SendKeys(Keys.Control);
            String s = driver.FindElementByXPath("//Pane[@AutomationId=\"OperatorSystemowePage\"]/Pane[5]/CheckBox[1]").GetAttribute("Name");
            if (s != " Tak")
            { driver.FindElementByXPath("//Pane[@AutomationId=\"OperatorSystemowePage\"]/Pane[5]/CheckBox[1]").Click(); }

            driver.FindElementByName("OK").Click();
            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys("s");
            driver.Keyboard.SendKeys(Keys.Control);
            driver.FindElementByName("Ogólne").Click();
            driver.FindElementByName("Ochrona danych osobowych").Click();
            driver.FindElementByName("Definicje zakresów").Click();

            driver.FindElementByName("Nazwa row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Anonimizacja kontrahentów", "Nazwa")).Click();
            driver.Keyboard.SendKeys(Keys.Return);
            driver.FindElementByName("Prawa danych").Click();

            Assert.AreEqual("Zaznaczony", driver.FindElementByName("Pełne prawo row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Pełne prawo", "Prawo")).Text);

            driver.FindElementByName("OK").Click();


            driver.FindElementByName("Nazwa row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Pseudonimizacja kontrahentów", "Nazwa")).Click();
            driver.Keyboard.SendKeys(Keys.Return);
            driver.FindElementByName("Prawa danych").Click();

            Assert.AreEqual("Zaznaczony", driver.FindElementByName("Pełne prawo row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Pełne prawo", "Prawo")).Text);

            driver.FindElementByName("OK").Click();

            driver.FindElementByName("Kontrahenci i urzędy").Click();
            driver.Mouse.MouseMove(driver.FindElementByName("Kontrahenci i urzędy").Coordinates, 30, 20);
            driver.Mouse.Click(null);

            if (driver.FindElementByXPath("//Pane[@AutomationId=\"OgolnePage\"]/Pane[20]").GetAttribute("Name") != " Tak")
            { driver.FindElementByXPath("//Pane[@AutomationId=\"OgolnePage\"]/Pane[20]").Click(); }

            driver.FindElementByName("Zapisz i zamknij").Click();
            driver.FindElementByName("CRM").Click();
            driver.FindElementByName("Kontrahenci").Click();
            driver.Mouse.MouseMove(driver.FindElementByName("190600 - Soneta").Coordinates, 600, 400);
            driver.Mouse.Click(null);
            cRMMetody.FocusNaOkienko();

            driver.FindElementByName("Kontrahenci").Click();
            driver.FindElementByName("Panel danych").Click();
            driver.FindElementByName("Kod row " + cRMMetody.ZnajdzPozycjeNaLiscieZKolumny("Zefir", "Kod")).Click();
            driver.FindElementByName("Otwórz").Click();

            driver.Keyboard.SendKeys(Keys.Control);
            driver.Keyboard.SendKeys("2");
            driver.Keyboard.SendKeys(Keys.Control);

            if (driver.FindElementByXPath("//Pane[@AutomationId=\"KontrahentBlokadaPage\"]/Pane[4]/CheckBox[1]").GetAttribute("Name") != " Tak")
            { driver.FindElementByXPath("//Pane[@AutomationId=\"KontrahentBlokadaPage\"]/ Pane[4]/CheckBox[1]").Click(); }
        }
    }
}
