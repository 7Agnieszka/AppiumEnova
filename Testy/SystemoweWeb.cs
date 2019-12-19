using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestyInterfejsowe.OknaWeb;
using TestyInterfejsowe.Testy.KlasyPomocnicze;

namespace TestyInterfejsowe.Testy
{
    class SystemoweWeb : AbstractTestWeb
    {

        internal BazaDanych BAZA_PULPITY = new BazaDanych("TestRD", BazaDanych.Licencja.Zlota);
        internal BazaDanych BAZA_PULPITY_ANG = new BazaDanych("TestRD", BazaDanych.Licencja.Zlota, BazaDanych.Jezyk.Angielski);
        internal BazaDanych BAZA_PELNA = new BazaDanych("RDTestPelnaBaza", BazaDanych.Licencja.Zlota);

        [TestCase]
        public void FakturaSprzedaży()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            HandelOkno handelOkno = stronaGlowna.PrzejdDoHandel();
            FakturySprzedarzyTabela fakturySprzedarzyTabela = handelOkno.PrzejdzDoFakturySprzedarzy();
            FakturySprzedarzyOkno fakturySprzedarzyOknoNowy = fakturySprzedarzyTabela.Nowy()
                 .UzupelnijKontrahent("ABC")
                .DodajTowar("Bikini", "1", "1");
            fakturySprzedarzyOknoNowy.ThreadSleep(14444);

            Assert.AreEqual("535,79 PLN", fakturySprzedarzyOknoNowy.SumaFaktury());

            FakturySprzedarzyTabela DodanaFaktura = fakturySprzedarzyOknoNowy.Zapisz_2();
        }

        [TestCase]
        public void DodajDoUlubionych()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            HandelOkno handelOkno = stronaGlowna.PrzejdDoHandel();
            handelOkno.DodajDoUlubionych();
            stronaGlowna.PrzejdzDoUlubionych();

            Assert.AreEqual("Handel", stronaGlowna.NazwaPozycji());

            stronaGlowna.PrzejdDoHandel();
            handelOkno.UsunZUlubionych();
            stronaLogowania.Wyloguj();

        }

        [TestCase]
        public void PrzechodzenieMiedzyStronami()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            PracownicyTabela pracownicyTabela = stronaGlowna.PrzejdzDoKadry().PrzejdzDoPracownicy();
            PracownikOkno pracownikOkno = pracownicyTabela.WybierzAndrzejewski();

            pracownikOkno.PrzejdzWPrawo();

            Assert.AreEqual("Pracownik: BEDNAREK DAMIAN (007), (wszystko)", pracownikOkno.NazwiskoPracowinka());
            pracownikOkno.PrzejdzWLewo().PrzejdzWPrawo();
            Assert.AreEqual("Pracownik: BEDNAREK DAMIAN (007), (wszystko)", pracownikOkno.NazwiskoPracowinka());

        }

        [Test]
        public void WymiarPrzycisku()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            HandelOkno handelOkno = stronaGlowna.PrzejdDoHandel();
            TowaryTabela towaryTabela = handelOkno.PrzejdzDoTowary();

            Assert.AreEqual("30 100", towaryTabela.WymiaryPrzyciskuCzynnosci());

            stronaLogowania.Wyloguj();
        }

        [Test]
        public void ZmianaNazwyRekordu()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            HandelOkno handelOkno = stronaGlowna.PrzejdDoHandel();
            TowaryTabela towaryTabela=handelOkno.PrzejdzDoTowary();
            TowarOkno towarOkno = towaryTabela.WybierzBut42();
            towarOkno.WpiszKod("xx")
                .Zapisz()
                .KliknijTak();

            Assert.IsTrue(towaryTabela.But42xxVisible());

            towaryTabela.WybierzBut42xx()
                .WrocNazwe("BUT_NAR_42")
                .Zapisz()
                .KliknijTak();
            stronaLogowania.Wyloguj();


        }

        [Test]
        public void Sortowanie()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            HandelOkno handelOkno = stronaGlowna.PrzejdDoHandel();
            TowaryTabela towaryTabela = handelOkno.PrzejdzDoTowary();
            towaryTabela.KliknijNaglowekKod();

            Assert.AreEqual("BIKINI", towaryTabela.TekstKomorkiKod1());
            Assert.AreEqual("BUT_NAR_42", towaryTabela.TekstKomorkiKod2());

            towaryTabela.KliknijNaglowekKod();

            Assert.AreEqual("ZES_Z190", towaryTabela.TekstKomorkiKod1());
            Assert.AreEqual("WRO_2SXC", towaryTabela.TekstKomorkiKod2());

            towaryTabela.KliknijNaglowekNazwa();

            Assert.AreEqual("Bikini - Strój kąpielowy damski", towaryTabela.TekstKomorkiNazwa1());
            Assert.AreEqual("Buty do nart Classic 42", towaryTabela.TekstKomorkiNazwa2());

            towaryTabela.KliknijNaglowekNazwa();

            Assert.AreEqual("Zestaw: narty, wiązania, kije, buty", towaryTabela.TekstKomorkiNazwa1());
            Assert.AreEqual("Wrotki zawodowe - 2 ślady Medium - czarne", towaryTabela.TekstKomorkiNazwa2());

            stronaLogowania.Wyloguj();
        }

        [Test]
        public void Kalendarz()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            HandelOkno handelOkno = stronaGlowna.PrzejdDoHandel();

            FakturySprzedarzyTabela fakturySprzedarzyTabela = handelOkno.PrzejdzDoFakturySprzedarzy();

            KalendarzWidget kalendarzWidget = fakturySprzedarzyTabela.Kalendarz();

            kalendarzWidget.WybierzDzien("5");
            kalendarzWidget.DataPoczatkowa().Miesiac().WybierzMiesiac("Lipiec").WybierzDzien("18")
                .DataKoncowa().Miesiac().WybierzMiesiac("Październik").WybierzDzien("28").Zatwierdz();

            //assert
           
        }

        [Test]
        public void Lokalizacja()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            HandelOkno handelOkno = stronaGlowna.PrzejdDoHandel();
            TowaryTabela towaryTabela = handelOkno.PrzejdzDoTowary();

            Assert.AreEqual("1490 46", towaryTabela.LokalizacjaPrzyciskuCzynnosci());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void FiltrowanieTest2()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            HandelOkno handelOkno = stronaGlowna.PrzejdDoHandel();
            TowaryTabela towaryTabela = handelOkno.PrzejdzDoTowary();
            towaryTabela.WlaczWierszFiltrowania();
            towaryTabela.WpiszTekstDoFiltraKolumny("* cm", "4");

            Assert.AreEqual(13.0d, towaryTabela.LiczbaWierszy());

            stronaLogowania.Wyloguj();
        }

        [TestCase]
        public void FiltrowanieTest3()
        {
            StronaLogowania stronaLogowania = new StronaLogowania(driver, BAZA_PELNA);
            StronaGlowna stronaGlowna = stronaLogowania
                .ZalogujAdministrator();
            HandelOkno handelOkno = stronaGlowna.PrzejdDoHandel();
            TowaryTabela towaryTabela = handelOkno.PrzejdzDoTowary();
            towaryTabela.WlaczWierszFiltrowania();
            towaryTabela.WpiszTekstDoFiltraKolumny("*88", "5");

            Assert.AreEqual(1.0d, towaryTabela.LiczbaWierszy());

            towaryTabela.WyczyscFiltrKolumny("5");

            Assert.AreEqual(49.0d, towaryTabela.LiczbaWierszy());

            towaryTabela.WpiszTekstDoFiltraKolumny("*", "6");


            towaryTabela.WlaczWyszukiwanieNieoptymalne();

            Assert.AreEqual(1.0d, towaryTabela.LiczbaWierszy());

            stronaLogowania.Wyloguj();
        }
    }
}
