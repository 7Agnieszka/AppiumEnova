using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TestyInterfejsowe.OknaWeb;
using TestyInterfejsowe.Testy;
using TestyInterfejsowe.Testy.KlasyPomocnicze;

namespace TestyInterfejsowe.Testy
{
    class RDModul : AbstractTestWeb
    {
        #region Stałe tekstowe

        String LOGIN_OPERATORA1 = "test";
        String HASLO1_OPERATORA1 = "2";
        String HASLO2_OPERATORA1 = "1";
        String LOGIN_PRACOWNIK = "Paweł Andrzejewski";
        String HASLO_PRACOWNIK = "HasloPawla";
        String LOGIN_KIEROWNIK = "Bartosz Kurek";
        String HASLO1_KIEROWNIK = "HasloBartka";
        String HASLO2_KIEROWNIK = "1";
        String LOGIN_KONTRAHENT = "Kontrahent";
        String HASLO_KONTRAHENT = "HasloKontrahenta";

        internal BazaDanych BAZA_PULPITY = new BazaDanych("TestRD", BazaDanych.Licencja.Zlota);
        internal BazaDanych BAZA_PULPITY_ANG = new BazaDanych("HTMLAng", BazaDanych.Licencja.Zlota, BazaDanych.Jezyk.Angielski);
        internal BazaDanych BAZA_PELNA = new BazaDanych("RDTestPelnaBaza", BazaDanych.Licencja.Zlota);

        #endregion


        #region  Testy grida i UI
        [TestCase]
        public void Locator()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            stronaGlowna.NavigateFolder("Handel", "Towary i usługi");
            var locator = driver.FindElementById("List_Locator");
            locator.SendKeys("W");
            Thread.Sleep(1000);
            var t = driver.FindElementsByXPath("//*[@id=\"List_canvas\"]/*").Count;
            t = driver.FindElementsByXPath("//*[@id=\"List_canvas\"]/*").Count - 1;
            Thread.Sleep(1000);

            Assert.AreEqual(8, t);
        }

        #endregion

        #region Logowanie na pulpity Test RD03 i RD04 

        [TestCase]
        public void PulpitPracownikaTest11534()
        {
            /*
             * Przed Testem trzeba przygotować 
             * Pracownik: "Paweł Andrzejewski"  z hasłem: "HasloPawla"
             * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe(LOGIN_PRACOWNIK, HASLO_PRACOWNIK);
            FolderGlowny folderGlowny = panelUzytkownika
                .PrzejdzDoGlownegoFolderu();

            Assert.AreEqual("Pulpit pracownika", folderGlowny.TytulFolder1());

            folderGlowny.KliknijPulpitPracownika();

            Assert.AreEqual("http://localhost/db/" + BAZA_PULPITY.NazwaBazyDanych + "#Folder/PulpitPracownika", folderGlowny.GetURL());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void PulpitKierownikaTest11534()
        {
            /*
             * Przed Testem trzeba przygotować w bazie:
             * Kierownik: "Bartosz Kurek" z hasłem: "HasloBartka"
             * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe(LOGIN_KIEROWNIK, HASLO1_KIEROWNIK);
            FolderGlowny folderGlowny = panelUzytkownika.PrzejdzDoGlownegoFolderu();

            Assert.AreEqual("Pulpit kierownika", folderGlowny.TytulFolder1());
            Assert.AreEqual("Pulpit pracownika", folderGlowny.TytulFolder2());

            folderGlowny.KliknijPulpitKierownika();

            Assert.AreEqual("http://localhost/db/" + BAZA_PULPITY.NazwaBazyDanych + "#Folder/PulpitKierownika", folderGlowny.GetURL());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void PulpitKontrahentaTest11534()
        {
            /*
             * Przed Testem trzeba przygotować w bazie:
             * Kontrahent z osobą kontaktową: "Kontrahent" z hasłem: "HasloKontrahenta"
             * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe(LOGIN_KONTRAHENT, HASLO_KONTRAHENT);
            FolderGlowny folderGlowny = panelUzytkownika.PrzejdzDoGlownegoFolderu();

            Assert.AreEqual("Pulpit kontrahenta", folderGlowny.TytulFolder0());

            folderGlowny.KliknijPulpitKontrahenta();

            Assert.AreEqual("http://localhost/db/" + BAZA_PULPITY.NazwaBazyDanych + "#Folder/PulpitKontrahenta", folderGlowny.GetURL());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void EmployeeDashboardTest11621()
        {
            /*
             * Przed Testem trzeba przygotować trzy osoby w bazie:
             * Pracownik: "Paweł Andrzejewski"  z hasłem: "HasloPawla"
             * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY_ANG);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe(LOGIN_PRACOWNIK, HASLO_PRACOWNIK);
            FolderGlowny folderGlowny = panelUzytkownika.PrzejdzDoGlownegoFolderuAng();

            Assert.AreEqual("Employee dashboard", folderGlowny.TytulFolder1());

            folderGlowny.ClickEmployeeDashboard();

            Assert.AreEqual("http://localhost/db/" + BAZA_PULPITY_ANG.NazwaBazyDanych + "#Folder/PulpitPracownika", folderGlowny.GetURL());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void ManagerDashboardTest11621()
        {
            /*
             * Przed Testem trzeba przygotować w bazie:
             * Kierownik: "Bartosz Kurek" z hasłem: "HasloBartka"
             * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY_ANG);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe(LOGIN_KIEROWNIK, HASLO1_KIEROWNIK);
            FolderGlowny folderGlowny = panelUzytkownika.PrzejdzDoGlownegoFolderuAng();

            Assert.AreEqual("Manager dashboard", folderGlowny.TytulFolder1());
            Assert.AreEqual("Employee dashboard", folderGlowny.TytulFolder2());

            folderGlowny.ClickManagerDashboard();

            Assert.AreEqual("http://localhost/db/" + BAZA_PULPITY_ANG.NazwaBazyDanych + "#Folder/PulpitKierownika", folderGlowny.GetURL());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void CustomerDashboardTest11621()
        {
            /*
             * Przed Testem trzeba przygotować w bazie:
             * Kontrahent z osobą kontaktową: "Kontrahent" z hasłem: "HasloKontrahenta"
             * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY_ANG);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe(LOGIN_KONTRAHENT, HASLO_KONTRAHENT);
            FolderGlowny folderGlowny = panelUzytkownika.PrzejdzDoGlownegoFolderuAng();

            Assert.AreEqual("Customer dashboard", folderGlowny.TytulFolder0());

            folderGlowny.ClickCustomerDashboard();

            Assert.AreEqual("http://localhost/db/" + BAZA_PULPITY_ANG.NazwaBazyDanych + "#Folder/PulpitKontrahenta", folderGlowny.GetURL());

            stronaLogowania.Wyloguj();
        }


        #endregion

        #region Zmiana hasła Test RD05 i RD06

        [TestCase]
        [Ignore ("Rozbity na dwa testy")]
        public void RD00005()
        {
            /*
             * Przed Testem trzeba przygotować dwie osoby w bazie:
             * operator: test z hasłem "2"
             * Kierownik: "Bartosz Kurek" z hasłem: "HasloBartka"
             * 
             * 
            * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe(LOGIN_OPERATORA1, HASLO1_OPERATORA1);

            Assert.IsTrue(stronaLogowania.Zalogowany());

            ZmianaHaslaDostepuOkno zmianaHaslaDostepuOkno = stronaLogowania
                .OperatorKliknij()
                .ZmianaHaslaKliknij();
            zmianaHaslaDostepuOkno
                .UstaWNoweHaslo(HASLO1_OPERATORA1, HASLO2_OPERATORA1)
                .ZapiszOkno();
            stronaLogowania.Wyloguj();
            stronaLogowania
                .ZalogujOsobe(LOGIN_OPERATORA1, HASLO2_OPERATORA1);

            Assert.IsTrue(stronaLogowania.Zalogowany());

            stronaLogowania.OperatorKliknij()
                .ZmianaHaslaKliknij();
            zmianaHaslaDostepuOkno
                .UstaWNoweHaslo(HASLO2_OPERATORA1, HASLO1_OPERATORA1)
                .ZapiszOkno();
            stronaLogowania.Wyloguj();
            panelUzytkownika = stronaLogowania
                .ZalogujOsobe(LOGIN_KIEROWNIK, HASLO1_KIEROWNIK);

            Assert.IsTrue(stronaLogowania.Zalogowany());

            zmianaHaslaDostepuOkno = stronaLogowania
                .OperatorKliknij()
                .ZmianaHaslaKliknij();
            zmianaHaslaDostepuOkno
                .UstaWNoweHaslo(HASLO1_KIEROWNIK, HASLO2_KIEROWNIK)
                .ZapiszOkno();
            stronaLogowania.Wyloguj();
            stronaLogowania//.ZalogujNaBaze()
                .ZalogujOsobe(LOGIN_KIEROWNIK, HASLO2_KIEROWNIK);

            Assert.IsTrue(stronaLogowania.Zalogowany());

            stronaLogowania
                .OperatorKliknij()
                .ZmianaHaslaKliknij();
            zmianaHaslaDostepuOkno
                .UstaWNoweHaslo(HASLO2_KIEROWNIK, HASLO1_KIEROWNIK)
                .ZapiszOkno();
            stronaLogowania.Wyloguj();
        }


        [TestCase]
        public void ZmianaHaslaOperatora11535()
        {
            /*
             * Przed Testem trzeba przygotować dwie osoby w bazie:
             * operator: test z hasłem "2"
             * Kierownik: "Bartosz Kurek" z hasłem: "HasloBartka"
            * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY);
            PanelUzytkownika panelUzytkownika = stronaLogowania

                .ZalogujOsobe(LOGIN_OPERATORA1, HASLO1_OPERATORA1);

            Assert.IsTrue(stronaLogowania.Zalogowany());

            ZmianaHaslaDostepuOkno zmianaHaslaDostepuOkno = stronaLogowania
                .OperatorKliknij()
                .ZmianaHaslaKliknij();
            zmianaHaslaDostepuOkno
                .UstaWNoweHaslo(HASLO1_OPERATORA1, HASLO2_OPERATORA1)
                .ZapiszOkno();
            stronaLogowania.Wyloguj();
            stronaLogowania
                .ZalogujOsobe(LOGIN_OPERATORA1, HASLO2_OPERATORA1);

            Assert.IsTrue(stronaLogowania.Zalogowany());

            stronaLogowania
                .OperatorKliknij()
                .ZmianaHaslaKliknij();
            zmianaHaslaDostepuOkno
                .UstaWNoweHaslo(HASLO2_OPERATORA1, HASLO1_OPERATORA1)
                .ZapiszOkno();
            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void ZmianHaslaKierownika11535()
        {
            /*
             * Przed Testem trzeba przygotować dwie osoby w bazie:
             * operator: test z hasłem "2"
             * Kierownik: "Bartosz Kurek" z hasłem: "HasloBartka"
            * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe(LOGIN_KIEROWNIK, HASLO1_KIEROWNIK);

            Assert.IsTrue(stronaLogowania.Zalogowany());

            ZmianaHaslaDostepuOkno zmianaHaslaDostepuOkno = stronaLogowania
                .OperatorKliknij()
                .ZmianaHaslaKliknij();
            zmianaHaslaDostepuOkno
                .UstaWNoweHaslo(HASLO1_KIEROWNIK, HASLO2_KIEROWNIK)
                .ZapiszOkno();
            stronaLogowania.Wyloguj();
            stronaLogowania
                .ZalogujOsobe(LOGIN_KIEROWNIK, HASLO2_KIEROWNIK);

            Assert.IsTrue(stronaLogowania.Zalogowany());

            stronaLogowania.OperatorKliknij()
                .ZmianaHaslaKliknij();
            zmianaHaslaDostepuOkno
                .UstaWNoweHaslo(HASLO2_KIEROWNIK, HASLO1_KIEROWNIK)
                .ZapiszOkno();
            stronaLogowania.Wyloguj();
        }


        #endregion
 
        [TestCase]
        public void ZmianaJezykaNaPolskiIAngielski()
        {
            /*
             * Przed Testem trzeba przygotować dwie osoby w bazie:
             * Kierownik: "Bartosz Kurek" z hasłem: "HasloBartka"
             * Powinien być na początku ustawiony na język angielski
             * 
            * */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY_ANG);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe("Bartosz Kurek", "HasloBartka");
            stronaLogowania
                .OperatorKliknij()
                .ZmienJezykNaPolski()
                .Wyloguj();
            stronaLogowania
                .ZalogujOsobe("Bartosz Kurek", "HasloBartka");

            Assert.IsTrue(panelUzytkownika.JestPolski());

            stronaLogowania
                .OperatorKliknij()
                .ZmienJezykNaAngielski()
                .Wyloguj();
            stronaLogowania
                .ZalogujOsobe("Bartosz Kurek", "HasloBartka");

            Assert.IsTrue(panelUzytkownika.JestAngielski());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void WydrukCennikaDlaWybranychPozycji()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            TowaryTabela towaryTabela = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoTowary();
            RaportOkno raportOkno = towaryTabela
                .Drukuj()
                .OK();

            Assert.AreEqual("Raport: Cennik", raportOkno.TekstZakladki());

            towaryTabela = raportOkno
                .Zamknij();
            towaryTabela.ZaznaczElementTabeliONazwie("1")
                .ZaznaczElementTabeliONazwie("5")
                .ZaznaczElementTabeliONazwie("7")
                .ZaznaczElementTabeliONazwie("11")
                .Drukuj()
                .TylkoZaznaczoneKlik()
                .OK();

            Assert.AreEqual("Raport: Cennik", raportOkno.TekstZakladki());

            raportOkno
                .Zamknij()
                .PrzejdzDoStronyGlownej();
            
            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void WydrukFakturyVat()
        {
            /*
             * Przygotowane przed testem:
             * Faktura Vat Sprzedazy
             * 
             */
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania

                .ZalogujAdministrator();
            FakturySprzedarzyTabela fakturySprzedarzyTabela = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoFakturySprzedarzy();
            fakturySprzedarzyTabela.NavigateGrid("List:Numer:1");
            RaportOkno raportOkno = fakturySprzedarzyTabela
                .Drukuj()
                .OK();
            raportOkno.KliknijWiecej()
                .KliknijPobierzHTMLBttn()
                .KliknijPobierzPDFBttn()
                .KliknijPobierzRTFBttn()
                .KliknijPobierzTXTBttn()
                .KliknijPobierzXLSBttn()
                .Zamknij();
            stronaLogowania.PrzejdzDoStronyGlownej();
            stronaLogowania.Wyloguj();

            //Brak Asserta sprawdzającego czy są wydruki. 
            //Trzeba albo sprawdzić adres na dysku, albo jkaims sposobem odbierac info ze strony że zostal wyslany plik (z headera ?)
        }

        [TestCase]
        [Ignore("Niestabilny")]
        public void RD00017()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            TowaryTabela towaryTabela = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoTowary();
            towaryTabela.Lista()
                .Eksportuj()
                .TylkoZaznaczoneZaznaczChekBox()
                .OK();
            towaryTabela.Lista()
                .Eksportuj()
                .WczytajDane();

            Assert.AreEqual("Kod Features.Producent Nazwa EAN Workers.StanMagazynu.StanRaz", towaryTabela.WczytaneDane().Remove(61));

            towaryTabela.OK();
            stronaLogowania.PrzejdzDoStronyGlownej();
            stronaLogowania.Wyloguj();
        }

        [TestCase]
        [Ignore("Helper")]
        public void RD00018()
        {

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania

                .ZalogujAdministrator();
            TowaryTabela towaryTabela = stronaGlowna.PrzejdDoHandel().PrzejdzDoTowary();
            towaryTabela.Lista().Importuj();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;


            // js.ExecuteScript("confirm(\"Otwórz enova365.helper\")");
            js.ExecuteScript("getElementById('Otwórz enova365.helper').click()");
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Enter);
            actions.Perform();
            //           ZOBttn.Click();

            //   driver.FindElementByName("Otwórz enova365.helper").Click();
            //   PopUp.SendKeys(Keys.Enter);
            //Problem z Helperem
        }

        [TestCase]
        public void KolorowanieListy()
        {
            /*
             * Widok Towary Zwiera kolumnę Producent
             */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania

                .ZalogujAdministrator();
            TowaryTabela towaryTabela = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoTowary();
            towaryTabela.Lista()
                .Zaawansowane()
                .OrganizujListe()
                .Kolory()

                .DodajNowyZapis()
                .UzupelnijPoleIWarunek("Producent {F", "[Nazwa] Like \"%but%\"");
            TowaryTabela towaryTabela2 = new TowaryTabela(driver);
                towaryTabela2
                .WybierzKolorCzionki()
                .WybierzKolorTla()
                .Zapisz();
            stronaLogowania.PrzejdzDoStronyGlownej();
            StronaGlowna stronaGlowna2 = new StronaGlowna(driver);
            stronaGlowna2
                .PrzejdDoHandel()
                .PrzejdzDoTowary();

            Assert.AreEqual("rgba(33, 33, 33, 1)", towaryTabela.KolorSalomona());

            towaryTabela.Lista()
                .Zaawansowane()
                .OrganizujListe()
                .Kolory()
                .PosprzatajTest()
                .Zapisz();
            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void KolorowanieListyKierownik()
        {
            /*
             * Kierownik ma dostęp do funkcji konfiguracyjnych
             */

            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY);
            PanelUzytkownika panelUzytkownika = stronaLogowania

                .ZalogujOsobe("Bartosz Kurek", "HasloBartka");
            FolderGlowny folderGlowny = panelUzytkownika
                .PrzejdzDoGlownegoFolderu();
            PulpitKierownika pulpitKierownika = folderGlowny
                .KliknijPulpitKierownika();
            ListaPracownikowTabela listaPracownikow = pulpitKierownika
                .PrzejdzDoListaPracownikow()
                .Lista()
                .Zaawansowane()
                .OrganizujListe()
                .Kolory()
                .DodajNowyZapis()
                .UzupelnijPoleIWarunek("Zatrudnienie {Workers.info.Historia.Etat}", "[Imie]Like\"%Jan%\"")
                .WybierzKolorCzionki()
                .WybierzKolorTla()
                .Zapisz();
            panelUzytkownika
                .PrzejdzDoGlownegoFolderu()
                .KliknijPulpitKierownika()
                .PrzejdzDoListaPracownikow();

            Assert.AreEqual("rgba(255, 255, 0, 1)", listaPracownikow.KolorJanaczcionka());
            Assert.AreEqual("rgba(33, 33, 33, 0.6)", listaPracownikow.KolorJanaTlo());

            pulpitKierownika
                .PrzejdzDoListaPracownikow()
                .Lista()
                .Zaawansowane()
                .OrganizujListe()
                .Kolory()
                .PosprzatajTest()
                .Zapisz();

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void DostepnoscPolWarunkowanychKalendarzem()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            PracownikOkno pracownikOkno = stronaGlowna
                .PrzejdzDoKadry()
                .PrzejdzDoPracownicy()
                .WybierzAndrzejewski()
                .WybierzZakladkeInformacjaPFRON();

            Assert.IsFalse(pracownikOkno.OkresOrzeczeniaJestDostepny());

            pracownikOkno
                .WybierzStopienNiepelnosprawnosci("Lekki")
                .WypelnijOkresOrzeczenia("12...20.08.2019");

            Assert.IsTrue(pracownikOkno.OkresOrzeczeniaJestDostepny());

            pracownikOkno
                .WybierzStopienNiepelnosprawnosci("Brak");

            Assert.IsFalse(pracownikOkno.OkresOrzeczeniaJestDostepny());

            pracownikOkno
                .KliknijZamknij()
                .KliknijNie()
                .PrzejdzDoStronyGlownej();
            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void ZalacznikPDFDoAsystenta()
        {
            /*
             * Przygotowane przed testem:
             * Faktura Vat Sprzedazy
             * 
             */
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            FakturySprzedarzyTabela fakturySprzedarzyTabela = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoFakturySprzedarzy();
            fakturySprzedarzyTabela
                .NavigateGrid("List:Numer:1");
            FakturySprzedarzyOkno fakturySprzedarzyOkno = fakturySprzedarzyTabela.Otworz();
            RaportOkno raportOkno = fakturySprzedarzyOkno
                .UstawAsystenta()
                .Raporty()
                .Duplikat()
                .OK();
            raportOkno.KliknijWiecej()
                .KliknijZalacznikPDFBttn()
                .Zamknij();
            fakturySprzedarzyOkno.PrzejdzDoZalacznikow();

            Assert.AreEqual("Dokument sprzedaży.pdf", fakturySprzedarzyOkno.NazwaPierwszegoZalacznika());

            fakturySprzedarzyOkno.PosprzatajTest();
            stronaLogowania.Wyloguj();
        }

        [TestCase]
        [Ignore("Helper")]
        public void RD00036()
        {
            /*
             * Przygotowane przed testem:
             * Faktura Vat Sprzedazy
             * 
             */
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania.ZalogujAdministrator();
            FakturySprzedarzyTabela fakturySprzedarzyTabela = stronaGlowna.PrzejdDoHandel().PrzejdzDoFakturySprzedarzy();
            FakturySprzedarzyOkno fakturySprzedarzyOkno = fakturySprzedarzyTabela.KliknijTabeliONazwie("FV/000001/19");
            fakturySprzedarzyOkno.UstawAsystenta();

            /*
             Problem z Helperem
             */


        }

        [TestCase]
        [Ignore("Helper")]
        public void RD00037()
        {


            /*
             Problem z Helperem
             */


        }


        [TestCase]
        public void OstrzezeniePolaKod()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            TowaryTabela towaryTabela = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoTowary();
            TowarOkno towarOkno = towaryTabela
                .WybierzBut42()
                .WyczyscKod();

            Assert.AreEqual("Wymagane jest wprowadzenie wartości pola 'Kod' (BUT_NAR_42 - Buty do nart Classic 42)", towarOkno.TekstOstrzezenia());
            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void OstrzezeniePolaEAN()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            TowaryTabela towaryTabela = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoTowary();
            TowarOkno towarOkno = towaryTabela
                .WybierzBut42()
                .ZmienKodKreskowy();

            Assert.AreEqual("Wprowadzony kod EAN nie jest poprawny", towarOkno.TekstOstrzezenia());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void OstrzezeniePoleNazwa()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            TowarOkno towarOkno = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoTowary()
                .DodajTowar();
            towarOkno.Zapisz();

            Assert.AreEqual("Wartość pola \"Nazwa\" jest wymagana", towarOkno.TekstOstrzezeniaOkna());

            towarOkno.ZrezygnujZZapisu();
            stronaLogowania.Wyloguj();
        }

        //[TestCase]
        //public void FakturaSprzedazy()
        //{
        //    /*
        //     * Przed testem 
        //     * Stan Magazynowy BIKINI niezerowy
        //     * (Wystawic dokumnet PZ2 - przyjęcie magazynowe na 2000szt)
        //     * */

        //    StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
        //    StronaGlowna stronaGlowna = stronaLogowania
        //        .ZalogujAdministrator();
        //    OpcjeOkno opcjeOkno = stronaGlowna
        //        .PrzejdDoNarzedzia()
        //        .PrzejdzDoOpcje();
        //    MagazynoweOpcje magazynoweOpcje = opcjeOkno
        //        .PrzejdzDoHandelOpcje()
        //        .PrzejdDoMagazynoweOpcje();
        //    magazynoweOpcje.WydanieWewnetrzeRozwinListe()
        //        .PrzejdzDoMagazyn()
        //        .UstawMomentOperacji("Na bieżąco, gdy dokument w buforze")
        //        .OK()
        //        .Zapisz();
        //    stronaGlowna.PrzejdzDoStronyGlownej();
        //    stronaGlowna.PrzejdDoNarzedzia()
        //        .OdswiezOpcje();
        //    FakturySprzedarzyOkno fakturySprzedarzyOkno = stronaGlowna
        //        .PrzejdDoHandel()
        //        .PrzejdzDoFakturySprzedarzy()
        //        .Nowy()
        //        .UzupelnijKontrahent("SENO");
        //    fakturySprzedarzyOkno
        //        .DodajTowar("BIKINI", "22", "2111,00 PLN")
        //        .Zatwierdz()
        //        .Zatwierdz()
        //        .Anuluj();
        //    fakturySprzedarzyOkno
        //        .KliknijDodanaFaktura();

        //    Assert.AreEqual("2 111,00 PLN", fakturySprzedarzyOkno.KwotaFaktury());
        //    //Nie wpisuje nadal tej kwoty 2111
        //    stronaLogowania.Wyloguj();

        //}


        [TestCase]
        public void RD00043()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            DokumentZOOkno dokumentZOOkno = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoWszystkieDokumenty()
                .UtworzZO();
            WszytskieDokumentyOkno wszytskieDokumentyOkno = dokumentZOOkno
                .WpiszKontrahenta("KURORT" + Keys.Enter)
                .DodajPozycje()
                .UzupelnijLinieBIKINI("22")
                .DodajPozycje()
                .UzupelnijLinieKombinezon("43")
                .DodajPozycje()
                .UzupelnijLinieNamiot("21")
                .ZatwierdzDokument();
            wszytskieDokumentyOkno
                .Czynnosci()
                .FakturaZaliczkowa();
            //A gdzie assert?
            stronaLogowania.Wyloguj();
        }

        [TestCase]
         [Ignore("Pobieranie z zewnatrz")]
        public void RD00050()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe("Bartosz Kurek", "HasloBartka");
            PulpitKierownika pulpitKierownika = panelUzytkownika
                .PrzejdzDoGlownegoFolderu()
                .KliknijPulpitKierownika();
            ListaPracownikowTabela listaPracownikowTabela = pulpitKierownika
                .PrzejdzDoListaPracownikow();
            OrganizujRaportyOkno organizujRaportyOkno = listaPracownikowTabela
                .Lista()
                .Zaawansowane()
                .OrganizujRaporty();
            organizujRaportyOkno.NowyRaportASPX()
                .UzupelnijDefinicje("wydruk listy pracowników o bardzo długiej nazwie do testów zerwocyh wersji html")
                .UstawNowyRaport()
                .WpiszAdresRaportu("E:\\pracownicy - lista pelna.aspx");
            stronaLogowania.Wyloguj();

            ///Assert!
        }

        [TestCase]
        public void WidocznoscZakladkiZCechami()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            TowaryTabela towaryTabela = stronaGlowna
                .PrzejdDoHandel()
                .PrzejdzDoTowary();
            TowarOkno towarOkno = towaryTabela
                .WybierzBIKINI()
                .Formularz()
                .ZaznaczWidzocznaZakladkaZCechami()
                .Zapisz();

            Assert.AreEqual("Cechy", towarOkno.TekstPozycji7naLiscie());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void WidocznoscZakladkiZCechamiKierownik()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PULPITY);
            PanelUzytkownika panelUzytkownika = stronaLogowania
                .ZalogujOsobe("Bartosz Kurek", "HasloBartka");
            PulpitKierownika pulpitKierownika = panelUzytkownika
                .PrzejdzDoGlownegoFolderu()
                .KliknijPulpitKierownika();
            ListaPracownikowTabela listaPracownikowTabela = pulpitKierownika
                .PrzejdzDoListaPracownikow();
            PracownikOkno pracownikOkno = listaPracownikowTabela
                .DorotaBujakOkno();
            pracownikOkno
                .Formularz()
                .ZaznaczWidzocznaZakladkaZCechami()
                .Zapisz();

            Assert.AreEqual("Cechy", pracownikOkno.TekstPozycji10naLiscie());

            stronaLogowania.Wyloguj();
        }

    }
}
