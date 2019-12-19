using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TestyInterfejsowe.OknaDesktop;
using TestyInterfejsowe.OknaDesktop.CRM;
using TestyInterfejsowe.OknaDesktop.Handel;
using TestyInterfejsowe.OknaDesktop.KiP;
using TestyInterfejsowe.OknaDesktop.Opcje;
using TestyInterfejsowe.OknaDesktop.Opcje.BI;
using TestyInterfejsowe.OknaDesktop.PodgladTabel;
using TestyInterfejsowe.OknaDesktop.Pomoc;
using TestyInterfejsowe.Testy.KlasyPomocnicze;

namespace TestyInterfejsowe.Testy
{
    class SystemoweModul : AbstractTestDesktop
    {

        internal BazaDanych BAZA_NUNIT_UI = new BazaDanych("nunit:ui", BazaDanych.Licencja.Demo);
        internal BazaDanych BAZA_RD = new BazaDanych("RDTestPelnaBaza", BazaDanych.Licencja.Zlota);

        [TestCase]
        public void PrzechodzenieMiedzyStronami()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            PracownicyTabela pracownicyTabela = stronaGlowna.PrzejdzDoPracownicy();
            pracownicyTabela.KliknijKomorkeOPodanymTekscieIKolumnie("GAJDA", "Nazwisko");
            PracownikOkno pracownikOkno = pracownicyTabela.OtworzRekord();
            pracownikOkno.KliknijOkienko();
            pracownikOkno.KliknijStrzalkeWLewo();

            Assert.AreEqual("GŁĄB", pracownikOkno.NazwiskoWartosc());

            pracownikOkno.ZamknijOkno();
        }

        [TestCase]
        public void SkrotKlawiszowyShiftF4()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            FakturySprzedazyTabela fakturySprzedazyTabela = stronaGlowna.PrzejdzDoFakturySprzedazy();
            FakturaOkno fakturaOkno = fakturySprzedazyTabela.NowaFaktura();
            fakturaOkno.FocusNaOkienko();
            fakturaOkno.UzupelnijKontrahenta(Keys.Shift + Keys.F4);

            Thread.Sleep(2000);

            Assert.AreEqual("Kontrahent:  (?)", fakturaOkno.TytulOknaLookup());

            fakturaOkno.ZamknijOkno();
            fakturaOkno.KliknijNie();
            fakturaOkno.ZamknijOkno();
            fakturaOkno.KliknijNie();
        }

        [TestCase]
        public void SkrotKlawiszowyShiftF10()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            FakturySprzedazyTabela fakturySprzedazyTabela = stronaGlowna.PrzejdzDoFakturySprzedazy();
            FakturaOkno fakturaOkno = fakturySprzedazyTabela.NowaFaktura();
            fakturaOkno.FocusNaOkienko();
            fakturaOkno.UzupelnijKontrahenta(Keys.Shift + Keys.F10);
            fakturaOkno.WylaczContext();
            fakturaOkno.ZamknijOkno();
            fakturaOkno.FocusNaOkienko();
            fakturaOkno.KliknijNie();
        }

        [TestCase]
        public void SkrotKlawiszowyAltF3()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.KliknijKomorkeOPodanymWierszuIKolumnie("Kod", "3");
            towaryTabela.WyslijSkrotKlawiszowy(Keys.LeftAlt, Keys.F3);

            Assert.AreEqual(-1, towaryTabela.TekstKomorkiNWKolumnie(1, "Kod").CompareTo(towaryTabela.TekstKomorkiNWKolumnie(2, "Kod")));
            Assert.AreEqual(-1, towaryTabela.TekstKomorkiNWKolumnie(5, "Kod").CompareTo(towaryTabela.TekstKomorkiNWKolumnie(6, "Kod")));

            towaryTabela.KliknijKomorkeOPodanymWierszuIKolumnie("Nazwa", "3");
            towaryTabela.WyslijSkrotKlawiszowy(Keys.LeftAlt, Keys.F3);

            Assert.AreEqual(-1, towaryTabela.TekstKomorkiNWKolumnie(1, "Nazwa").CompareTo(towaryTabela.TekstKomorkiNWKolumnie(2, "Nazwa")));
            Assert.AreEqual(-1, towaryTabela.TekstKomorkiNWKolumnie(7, "Nazwa").CompareTo(towaryTabela.TekstKomorkiNWKolumnie(8, "Nazwa")));
        }

        [TestCase]
        public void DragAndDrop()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.WlaczOrganizatoraWidoku();
            towaryTabela.WlaczZakladkePole();
            towaryTabela.PrzeniesKolumne();

            Assert.IsTrue(towaryTabela.NaglowekLiczMagDisplayed());

            towaryTabela.PrzywrocStandardowyWidok();
        }

        [TestCase]
        public void FiltrowanieTest1()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.WlaczWierszFiltrowania();

            Assert.AreEqual(true, towaryTabela.CzyMaFocus(towaryTabela.KomorkaFiltraKolumny("Kod")));

            towaryTabela.WpiszTekstDoFiltraKolumny("nar", "Nazwa");

            Assert.AreEqual(10, towaryTabela.LiczbaWierszyOstatni());
        }

        [TestCase]
        public void FiltrowanieTest2()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.WlaczWierszFiltrowania();

            Assert.AreEqual(true, towaryTabela.CzyMaFocus(towaryTabela.KomorkaFiltraKolumny("Kod")));

            towaryTabela.WpiszTekstDoFiltraKolumny("* cm", "Nazwa");

            Assert.AreEqual(13, towaryTabela.LiczbaWierszyOstatni());
        }

        [TestCase]
        public void FiltrowanieTest3()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.WlaczWierszFiltrowania();
            towaryTabela.WpiszTekstDoFiltraKolumny("*88", "EAN");

            Assert.AreEqual(20, towaryTabela.LiczbaWierszyOstatni());

            towaryTabela.WyczyscFiltr();
            towaryTabela.WpiszTekstDoFiltraKolumny("*", "Stan razem");

            Assert.AreEqual(5, towaryTabela.LiczbaWierszyOstatni());

            towaryTabela.WyczyscFiltr();
            towaryTabela.WpiszTekstDoFiltraKolumny("?i", "Kod");

            Assert.AreEqual(8, towaryTabela.LiczbaWierszyOstatni());
        }

        [TestCase]
        public void Kalendarz()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            FakturySprzedazyTabela fakturySprzedazyTabela = stronaGlowna.PrzejdzDoFakturySprzedazy();
            fakturySprzedazyTabela.UzupelnijOkres("01.01.2018...31.12.2018");

            Assert.AreEqual(1, fakturySprzedazyTabela.LiczbaWierszyOstatni());

            fakturySprzedazyTabela.UzupelnijOkres("01.01.2019...31.12.2019");

            Assert.AreEqual(4, fakturySprzedazyTabela.LiczbaWierszyOstatni());

            fakturySprzedazyTabela.UzupelnijOkres("01...30.11.2019");

            Assert.AreEqual(3, fakturySprzedazyTabela.LiczbaWierszyOstatni());

            fakturySprzedazyTabela.UzupelnijOkres("22.11.2019");

            Assert.AreEqual(1, fakturySprzedazyTabela.LiczbaWierszyOstatni());
        }

        [TestCase]
        public void Cecha()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            FeatureDefinitionTabela featureDefinitionTabela = stronaGlowna.PrzejdzDoTabeliCech();
            DefinicjaCechyOkno definicjaCechyOkno = featureDefinitionTabela.NowaCecha();
            definicjaCechyOkno.UzupelnijTypDanychCechy("Kontrahenci");
            definicjaCechyOkno.KliknijOK();
            definicjaCechyOkno.UzupelnijNazweCechy("Nazwa");
            definicjaCechyOkno.CzyZaznaczHistoriaDanychWCzasie(true);
            definicjaCechyOkno.PrzejdzDoZaawansowaneZakladka();

            Assert.AreEqual("Cechy", definicjaCechyOkno.PiataZakladka());

            definicjaCechyOkno.Cecha6Wybierz();

            Assert.AreEqual("Algorytm", definicjaCechyOkno.PiataZakladka());

            definicjaCechyOkno.ZamknijOkno();
            definicjaCechyOkno.Kliknij_Nie();
        }

        [TestCase]
        public void RozmiarOkna()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.KliknijKomorkeOPodanymWierszuIKolumnie("Kod", "5");
            TowarOkno towarOkno = towaryTabela.OtworzRekord();
            towarOkno.FocusNaOkienko();
            String WymiarPoczatkowy = towarOkno.WymiaryOkienka();
            towarOkno.MaksymalizujOkno();

            Assert.AreEqual("1936 1056", towarOkno.WymiaryOkienka());

            towarOkno.OdwrocMaksymalizacjeOkno();

            Assert.AreEqual(WymiarPoczatkowy, towarOkno.WymiaryOkienka());

            towarOkno.ZamknijOkno();
        }

        [TestCase]
        public void RozmiarPola()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.KliknijKomorkeOPodanymWierszuIKolumnie("Kod", "5");
            TowarOkno towarOkno = towaryTabela.OtworzRekord();
            towarOkno.FocusNaOkienko();
            String WymiarPoczatkowy = towarOkno.WymiaryPolaKod();
            towarOkno.MaksymalizujOkno();

            Assert.AreEqual("1174 20", towarOkno.WymiaryPolaKod());

            towarOkno.OdwrocMaksymalizacjeOkno();

            Assert.AreEqual(WymiarPoczatkowy, towarOkno.WymiaryPolaKod());

            towarOkno.ZamknijOkno();
        }

        [Test]
        public void LokalizacjaPrzycisku()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            LicencjaDemonstracyjna licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaHandlowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczHandlowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_NUNIT_UI, "Administrator");
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
            Drzewko drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI();
            DefinicjaPrzedzialowCzasowych definicjaPrzedzialowCzasowych
                = drzewko.PrzejdzDoModeleDanychFolder().PrzejdzDoDefinicjaPrzedzialowCzasowych();

            Assert.AreEqual(197, definicjaPrzedzialowCzasowych.LewaWspolrzednaPrzyciskuOtworz() - drzewko.LewaWspolrzednaOknaOpcje());
            Assert.AreEqual(121, definicjaPrzedzialowCzasowych.TopWspolrzednaPrzyciskuOtworz() - drzewko.TopWspolrzednaOknaOpcje());

            drzewko.ZamknijOkno();
            licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaFirmowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczFirmowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_NUNIT_UI, "Administrator");
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
            stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI();
            definicjaPrzedzialowCzasowych
               = drzewko.PrzejdzDoModeleDanychFolder().PrzejdzDoDefinicjaPrzedzialowCzasowych();

            Assert.AreEqual(405, definicjaPrzedzialowCzasowych.LewaWspolrzednaPrzyciskuOtworz() - drzewko.LewaWspolrzednaOknaOpcje());
            Assert.AreEqual(121, definicjaPrzedzialowCzasowych.TopWspolrzednaPrzyciskuOtworz() - drzewko.TopWspolrzednaOknaOpcje());

            drzewko.ZamknijOkno();
            licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (licencjaDemonstracyjna.CzyLicencjaFirmowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczFirmowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
            }
            else if (licencjaDemonstracyjna.CzyLicencjaHandlowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczHandlowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
        }

        [TestCase]
        public void GridTest()
        {
            
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.ElementNTabeliKolumny(10, "Kod").Click();
            towaryTabela.WlaczZamienWartoscPola();
            towaryTabela.UzupelnijSzukanyTekst("KOM_NAR_T_X");
            towaryTabela.UzupelnijZamienNaTekst("KOM_NAR_T_X_1");
            towaryTabela.KliknijZamien();
            towaryTabela.Kliknij_Tak();
            towaryTabela.KliknijTak();
            TowarOkno towarOkno = towaryTabela.OtworzRekord();
            towarOkno.FocusNaOkienko();
            towarOkno.KliknijKodPole();

            Assert.AreEqual("KOM_NAR_T_X_1", towarOkno.TekstKodPole());

            towarOkno.WyczyscTekstKodPole();
            towarOkno.UzupelnijKodPole("KOM_NAR_T_X");
            towarOkno.ZapiszIZamknij();
            towaryTabela.KliknijTak();
            towaryTabela.FocusNaOkienko();

            Assert.AreEqual("KOM_NAR_T_X", towaryTabela.ElementNTabeliKolumny(10, "Kod").Text);
        }

        [TestCase]
        public void Sortowanie()
        {

            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.KliknijNaglowekKod();

            Assert.AreEqual("BIKINI", towaryTabela.TekstKomorkiNWKolumnie(0, "Kod"));
            Assert.AreEqual("BUT_NAR_42", towaryTabela.TekstKomorkiNWKolumnie(1, "Kod"));

            towaryTabela.KliknijNaglowekKod();

            Assert.AreEqual("ZES_Z190", towaryTabela.TekstKomorkiNWKolumnie(0, "Kod"));
            Assert.AreEqual("WRO_2SXC", towaryTabela.TekstKomorkiNWKolumnie(1, "Kod"));

            towaryTabela.KliknijNaglowekNazwa();

            Assert.AreEqual("Bikini - Strój kąpielowy damski", towaryTabela.TekstKomorkiNWKolumnie(0, "Nazwa"));
            Assert.AreEqual("Buty do nart Classic 42", towaryTabela.TekstKomorkiNWKolumnie(1, "Nazwa"));

            towaryTabela.KliknijNaglowekNazwa();

            Assert.AreEqual("Zestaw: narty, wiązania, kije, buty", towaryTabela.TekstKomorkiNWKolumnie(0, "Nazwa"));
            Assert.AreEqual("Wrotki zawodowe - 2 ślady Medium - czarne", towaryTabela.TekstKomorkiNWKolumnie(1, "Nazwa"));


        }

        [TestCase]
        public void DodajDoUlubionych()
        {
             
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_RD, "Administrator");
            stronaGlowna.DodajKadryIPlaceDoUlobionych();
            stronaGlowna.PrzejdzDoUlubionych(BAZA_RD.NazwaBazyDanych);

            Assert.AreEqual("Kadry i płace", stronaGlowna.ElementWUlubionych());

            stronaGlowna.UsunKadryiPlaceZUlubionych();
        }

        [TestCase]
        public void FakturaVat()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            FakturySprzedazyTabela fakturySprzedazyTabela = stronaGlowna.PrzejdzDoFakturySprzedazy();
            FakturaOkno fakturaOkno = fakturySprzedazyTabela.NowaFaktura();
            fakturaOkno.FocusNaOkienko();
            fakturaOkno.UzupelnijKontrahenta("ABC");
            fakturaOkno.UzupelnijLinieFaktury("BIKINI", "34");
            String Kwota = fakturaOkno.WartoscFaktury();

            Assert.AreEqual("1 656,07 PLN", Kwota);

            fakturaOkno.ZamknijOkno();
            fakturaOkno.FocusNaOkienko();
            fakturaOkno.KliknijBufor();
        }

        [TestCase]
        public void ImportowanieZapisu()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            towaryTabela.KliknijWlaczWylaczAsystenta();
            towaryTabela.ZakladkaZalaczniki();
            towaryTabela.DodajZalaczniki();
            towaryTabela.ImportujPlik("E:\\Test.txt");

            Assert.AreEqual("Test.txt", towaryTabela.NazwaPlikuNaLiscie());

            towaryTabela.UsunZalacznikZListy();
        }

        [TestCase]
        public void WinForm_Grid_AllData()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();

            Assert.AreEqual(40, towaryTabela.LiczbaWierszyOstatni());
        }

        [TestCase]
        public void WinForm_Grid_Focused_AfterOpenForm()
        {
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            KontrahenciTabela kontrahenciTabela = stronaGlowna.PrzejdzDoKontrahenci();
            Thread.Sleep(3000);
            kontrahenciTabela.KliknijKomorkeOPodanymWierszuIKolumnie("Kod", "1");
            string state1 = kontrahenciTabela.KomorkaNWKolumnie(1, "Kod").GetAttribute("HasKeyboardFocus").ToString();
            string state3 = kontrahenciTabela.KomorkaNWKolumnie(2, "Kod").GetAttribute("HasKeyboardFocus").ToString();

            Assert.AreEqual("True", state1);
            Assert.AreEqual("False", state3);

            KontrahentOkno kontrahentOkno = kontrahenciTabela.OtworzRekord();
            kontrahentOkno.PrzejdzDoRozrachunki();
            kontrahentOkno.KliknijKomorkeOPodanymWierszuIKolumnie("Numer", "1");
            kontrahentOkno.OtworzRekord();
            kontrahentOkno.ZamknijOkno();
            kontrahentOkno.ZamknijOkno();
            kontrahenciTabela.FocusNaOkienko();
            state1 = kontrahenciTabela.KomorkaNWKolumnie(1, "Kod").GetAttribute("HasKeyboardFocus").ToString();
            state3 = kontrahenciTabela.KomorkaNWKolumnie(2, "Kod").GetAttribute("HasKeyboardFocus").ToString();

            Assert.AreEqual("True", state1);
            Assert.AreEqual("False", state3);
        }
    }
}
