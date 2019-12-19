using NUnit.Framework;
using TestyInterfejsowe.OknaDesktop;
using TestyInterfejsowe.OknaDesktop.Opcje;
using TestyInterfejsowe.OknaDesktop.Pomoc;
using TestyInterfejsowe.OknaDesktop.Opcje.BI;
using TestyInterfejsowe.OknaDesktop.Narzedzia.BI;
using TestyInterfejsowe.OknaDesktop.Narzedzia.Systemowe;
using TestyInterfejsowe.OknaDesktop.Handel;
using System;
using TestyInterfejsowe.Testy.KlasyPomocnicze;

namespace TestyInterfejsowe.Testy
{

    [TestFixture]
    class BIModul : AbstractTestDesktop
    {

        internal BazaDanych BAZA_NUNIT_UI = new BazaDanych("nunit:ui", BazaDanych.Licencja.Demo);
        internal BazaDanych BAZA_BI_TEST = new BazaDanych("BITest", BazaDanych.Licencja.Demo);


        [TestCase]
        public void BI004()
        {
            string Baza = "BITest";
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie
                .Zaloguj(BAZA_BI_TEST, "Administrator");
            LicencjaDemonstracyjna licencjaDemonstracyjna = stronaGlowna
                .PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaHandlowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczHandlowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            }
            else
            { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
            Drzewko drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.MaksymalizujOkno();
            drzewko.PrzejdzDoBI();
            ModeleDanych modeleDanych = drzewko.PrzejdzDoModeleDanych();
            modeleDanych.NowaDefinicjaWskaznika1();

            Assert.AreEqual("Definicja wskaźnika: ", modeleDanych.PobierzTytulOkna());

            modeleDanych.ZamknijOkno();
            modeleDanych.KliknijNie();
            modeleDanych.NowaDefinicjaWskaznika2();

            Assert.AreEqual("Definicja raportu: ", modeleDanych.PobierzTytulOkna());

            modeleDanych.ZamknijOkno();
            modeleDanych.KliknijNie();

            DefinicjeElementowDashboardow definicjeElementowDashboardow = drzewko.PrzejdzDoDefinicjeElementowDashboardow();
            definicjeElementowDashboardow.NowyWskaznik1();

            Assert.AreEqual("Wskaźnik: (Wskaźnik)", definicjeElementowDashboardow.PobierzTytulOkna());

            definicjeElementowDashboardow.ZamknijOkno();
            definicjeElementowDashboardow.KliknijNie();
            definicjeElementowDashboardow.NowyWskaznik2();

            Assert.AreEqual("Lista: (Tabela)", definicjeElementowDashboardow.PobierzTytulOkna());

            definicjeElementowDashboardow.ZamknijOkno();
            definicjeElementowDashboardow.Kliknij_Nie();
            DefinicjaPrzedzialowCzasowych definicjaPrzedzialowCzasowych = drzewko.PrzejdzDoDefinicjaPrzedzialowCzasowych();

            Assert.AreNotEqual("Nowy (Definicja dynamiczna)", definicjaPrzedzialowCzasowych.PobierzNazwePrzyciskuZToolbar());

            DefinicjeUtrwalania definicjeUtrwalania = drzewko.PrzejdzDoDefinicjeUtrwalania();

            Assert.AreNotEqual("Nowy (Definicja utrwalania)", definicjeUtrwalania.PobierzNazwePrzyciskuZToolbar());

            DefinicjaZastawowDanych definicjaZastawowDanych = drzewko.PrzejdzDoDefinicjeZestawowDanych();

            Assert.AreNotEqual("Nowy (Definicja zestawów danych)", definicjaZastawowDanych.PobierzNazwePrzyciskuZToolbar());

            DefinicjaZestawowPrzedzialowCzasowych definicjaZestawowPrzedzialowCzasowych = drzewko.PrzejdzDoDefinicjeZestawowPrzedzialowCzasowych();

            Assert.AreNotEqual("Nowy (Zestaw przedziałów czasowych)", definicjaZestawowPrzedzialowCzasowych.PobierzNazwePrzyciskuZToolbar());

            ZestawyBarw zestawyBarw = drzewko.PrzejdzDoZestawyBarw();
            zestawyBarw.NowaDefinicjaZestawu();

            Assert.AreEqual("Zestaw barw: ", zestawyBarw.PobierzTytulOkna());

            zestawyBarw.ZamknijOkno();
            zestawyBarw.KliknijNie();

            ZestawyPrzedzialowDanych zestawyPrzedzialowDanych = drzewko.PrzejdzDoZestawyPrzedzialowDanych();
            zestawyPrzedzialowDanych.NowaDefinicjaZestawu();

            Assert.AreEqual("Zestaw przedziałów liczb dziesiętnych:  (Decimal)", zestawyPrzedzialowDanych.PobierzTytulOkna());

            zestawyPrzedzialowDanych.ZamknijOkno();
            zestawyPrzedzialowDanych.KliknijNie();
            drzewko.ZamknijOkno();
            licencjaDemonstracyjna = stronaGlowna
                .PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaFirmowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczFirmowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            }
            else
            { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
            stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI();
            modeleDanych = drzewko.PrzejdzDoModeleDanych();
            modeleDanych.NowaDefinicjaWskaznika1();

            Assert.AreEqual("Definicja wskaźnika: ", modeleDanych.PobierzTytulOkna());

            modeleDanych.ZamknijOkno();
            modeleDanych.KliknijNie();
            modeleDanych.NowaDefinicjaWskaznika2();

            Assert.AreEqual("Definicja domeny: ", modeleDanych.PobierzTytulOkna());

            modeleDanych.ZamknijOkno();
            modeleDanych.KliknijNie();
            modeleDanych.NowaDefinicjaWskaznika3();

            Assert.AreEqual("Definicja tabeli: ", modeleDanych.PobierzTytulOkna());

            modeleDanych.ZamknijOkno();
            modeleDanych.KliknijNie();
            modeleDanych.NowaDefinicjaWskaznika4();

            Assert.AreEqual("Definicja raportu: ", modeleDanych.PobierzTytulOkna());

            modeleDanych.ZamknijOkno();
            modeleDanych.KliknijNie();
            definicjeElementowDashboardow = drzewko.PrzejdzDoDefinicjeElementowDashboardow();
            definicjeElementowDashboardow.NowyWskaznik1();

            Assert.AreEqual("Wskaźnik: (Wskaźnik)", definicjeElementowDashboardow.PobierzTytulOkna());

            definicjeElementowDashboardow.ZamknijOkno();
            definicjeElementowDashboardow.KliknijNie();
            definicjeElementowDashboardow.NowyWskaznik2();

            Assert.AreEqual("Lista: (Tabela)", definicjeElementowDashboardow.PobierzTytulOkna());

            definicjeElementowDashboardow.ZamknijOkno();
            definicjeElementowDashboardow.Kliknij_Nie();
            definicjaPrzedzialowCzasowych = drzewko.PrzejdzDoDefinicjaPrzedzialowCzasowych();
            definicjaPrzedzialowCzasowych.NowaDefinicja();

            Assert.AreEqual("Definicja dynamiczna: ", definicjaPrzedzialowCzasowych.PobierzTytulOkna());

            definicjaPrzedzialowCzasowych.ZamknijOkno();
            definicjaPrzedzialowCzasowych.KliknijNie();
            definicjeUtrwalania = drzewko.PrzejdzDoDefinicjeUtrwalania();
            definicjeUtrwalania.NowaDefinicja();

            Assert.AreEqual("Dodawanie zapisu", definicjeUtrwalania.PobierzTytulOkna());

            definicjeUtrwalania.ZamknijOkno();
            definicjaZestawowPrzedzialowCzasowych = drzewko.PrzejdzDoDefinicjeZestawowPrzedzialowCzasowych();
            definicjaZestawowPrzedzialowCzasowych.NowaDefinicjaZestawu();

            Assert.AreEqual("Zestaw przedziałów czasowych: ", definicjaZestawowPrzedzialowCzasowych.PobierzTytulOkna());

            definicjeUtrwalania.ZamknijOkno();
            definicjeUtrwalania.KliknijNie();
            zestawyBarw = drzewko.PrzejdzDoZestawyBarw();
            zestawyBarw.NowaDefinicjaZestawu();

            Assert.AreEqual("Zestaw barw: ", zestawyBarw.PobierzTytulOkna());

            zestawyBarw.ZamknijOkno();
            zestawyBarw.KliknijNie();
            drzewko.ZamknijOkno();
        }

        [TestCase]
        public void BI005()
        {
            string Baza = "BITest";
            Logowanie logowanie = new Logowanie(driver);
            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            LicencjaDemonstracyjna licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaFirmowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczFirmowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
            Drzewko drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.MaksymalizujOkno();

            drzewko.PrzejdzDoBI();

            ModeleDanych modeleDanych = drzewko.PrzejdzDoModeleDanych();
            DefinicjaWskaznikaOkno definicjaWskaznikaOkno = modeleDanych.NowaDefinicjaWskaznika1();
            definicjaWskaznikaOkno.WpiszWPoleNazwa("AA_WSK");
            definicjaWskaznikaOkno.WpiszWPoleDefinicja("BI_m_a_%");
            Assert.AreEqual("BI_m_a_% udział elementów wyngrodzenia w całości kosztów wynagrodzeń", definicjaWskaznikaOkno.PobierzTekstZPolaDefinicj());

            definicjaWskaznikaOkno.WpiszWPoleDefinicja("BI_m_a_ABC");
            Assert.AreEqual("BI_m_a_ABC_Klasyfikacja ABC", definicjaWskaznikaOkno.PobierzTekstZPolaDefinicj());

            definicjaWskaznikaOkno.WpiszWPoleDefinicja("BI_m_a_Analiza na");
            Assert.AreEqual("BI_m_a_Analiza należności i zobowiązań kontrahenta", definicjaWskaznikaOkno.PobierzTekstZPolaDefinicj());

            definicjaWskaznikaOkno.WpiszWPoleDefinicja("BI_m_a_Analiza kw");
            Assert.AreEqual("BI_m_a_Analiza kwot projektu", definicjaWskaznikaOkno.PobierzTekstZPolaDefinicj());

            definicjaWskaznikaOkno.ZamknijOkno();
            modeleDanych.Kliknij_Nie();

            modeleDanych.ZamknijOkno();
            licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaHandlowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczHandlowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }

            drzewko = stronaGlowna.PrzejdzDoOpcji();

            drzewko.PrzejdzDoBI();

            modeleDanych = drzewko.PrzejdzDoModeleDanych();
            definicjaWskaznikaOkno = modeleDanych.NowaDefinicjaWskaznika1();
            definicjaWskaznikaOkno.WpiszWPoleNazwa("AA_WSK");
            definicjaWskaznikaOkno.WpiszWPoleDefinicja("BI_m_a_%");
            Assert.AreNotEqual("BI_m_a_% udział elementów wyngrodzenia w całości kosztów wynagrodzeń", definicjaWskaznikaOkno.PobierzTekstZPolaDefinicj());

            definicjaWskaznikaOkno.WpiszWPoleDefinicja("BI_m_a_ABC");
            Assert.AreEqual("BI_m_a_ABC_Klasyfikacja ABC", definicjaWskaznikaOkno.PobierzTekstZPolaDefinicj());

            definicjaWskaznikaOkno.WpiszWPoleDefinicja("BI_m_a_Analiza na");
            Assert.AreNotEqual("BI_m_a_Analiza należności i zobowiązań kontrahenta", definicjaWskaznikaOkno.PobierzTekstZPolaDefinicj());

            definicjaWskaznikaOkno.WpiszWPoleDefinicja("BI_m_a_Analiza kw");
            Assert.AreNotEqual("BI_m_a_Analiza kwot projektu", definicjaWskaznikaOkno.PobierzTekstZPolaDefinicj());

            definicjaWskaznikaOkno.ZamknijOkno();
            modeleDanych.Kliknij_Nie();

            drzewko.PrzejdzDoSystemowe();
            Operatorzy operatorzy = drzewko.PrzejdzDoOperatorzy();

            OperatorOkno operatorOkno = operatorzy.OtworzOperatoraOKodzie("Adam Pitera");
            operatorOkno.PrzejdzDoZakladkiSystemowe();
            if (!operatorOkno.CzyZazrzadzaPozostalymiOperatorami())
            {
                operatorOkno.ZaznaczOdznaczZarzadzaPozostalymiOperatorami();
            }
            operatorOkno.KliknijOK();
            drzewko.ZapiszIZamknij();

            licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaFirmowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczFirmowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Adam Pitera");


            drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI();
            modeleDanych = drzewko.PrzejdzDoModeleDanych();
            definicjaWskaznikaOkno = modeleDanych.NowaDefinicjaWskaznika2();
            definicjaWskaznikaOkno.WpiszWPoleNazwa("test");
            definicjaWskaznikaOkno.PrzejdzDoZakladkiTabele();
            definicjaWskaznikaOkno.WpiszWPoleDostepneZrodla("Tryby");

            Assert.AreEqual("TrybyZajec",
               definicjaWskaznikaOkno.ElementNTabeliKolumny(0, "Nazwa").Text);

            definicjaWskaznikaOkno.DodajZDostepnychDoWybranych();
            definicjaWskaznikaOkno.FocusNaOkienko();
            definicjaWskaznikaOkno.ZamknijOkno();
            definicjaWskaznikaOkno.KliknijNie();
            modeleDanych.ZamknijOkno();
            modeleDanych.Kliknij_Tak();

            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");

            drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoSystemowe();
            operatorzy = drzewko.PrzejdzDoOperatorzy();
            operatorOkno = operatorzy.OtworzOperatoraOKodzie("Adam Pitera");
            operatorOkno.PrzejdzDoZakladkiSystemowe();
            if (operatorOkno.CzyZazrzadzaPozostalymiOperatorami())
            {
                operatorOkno.ZaznaczOdznaczZarzadzaPozostalymiOperatorami();
            }
            operatorOkno.KliknijOK();
            drzewko.ZapiszIZamknij();

            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Adam Pitera");
            drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI();
            modeleDanych = drzewko.PrzejdzDoModeleDanych();

            definicjaWskaznikaOkno = modeleDanych.NowaDefinicjaWskaznika2();
            definicjaWskaznikaOkno.WpiszWPoleNazwa("test");
            definicjaWskaznikaOkno.PrzejdzDoZakladkiTabele();
            definicjaWskaznikaOkno.WpiszWPoleDostepneZrodla("Tryb");

            Assert.AreNotEqual("TrybyZajec",
               definicjaWskaznikaOkno.ElementNTabeliKolumny(0, "Nazwa").Text);


            definicjaWskaznikaOkno.ZamknijOkno();
            definicjaWskaznikaOkno.KliknijNie();
            modeleDanych.ZamknijOkno();
        }

        [TestCase]
        public void BI006()
        {
            string Baza = "BITest";
            Logowanie logowanie = new Logowanie(driver);

            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            LicencjaDemonstracyjna licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaFirmowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczFirmowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
            Drzewko drzewko = stronaGlowna.PrzejdzDoOpcji();

            drzewko.PrzejdzDoSystemowe();
            Operatorzy operatorzy = drzewko.PrzejdzDoOperatorzy();
            OperatorOkno operatorOkno = operatorzy.OtworzOperatoraOKodzie("Adam Pitera");
            operatorOkno.PrzejdzDoZakladkiSystemowe();
            if (!operatorOkno.CzyZazrzadzaPozostalymiOperatorami())
            {
                operatorOkno.ZaznaczOdznaczZarzadzaPozostalymiOperatorami();
            }
            operatorOkno.KliknijOK();
            drzewko.ZapiszIZamknij();

            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Adam Pitera");
            drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI();
            BIOgolne bIOgolne = drzewko.PrzejdzDoBIOgolne();
            if (!bIOgolne.CzyPrawaModeliDanych())
                bIOgolne.ZaznaczOdznaczPrawaModeliDanychCheckBox();
            bIOgolne.ZapiszBezZamykania();
            if (bIOgolne.CzyPrawaModeliDanych())
                bIOgolne.ZaznaczOdznaczPrawaModeliDanychCheckBox();
            drzewko.ZapiszIZamknij();
            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");

            drzewko = stronaGlowna.PrzejdzDoOpcji();

            drzewko.PrzejdzDoSystemowe();
            operatorzy = drzewko.PrzejdzDoOperatorzy();
            operatorOkno = operatorzy.OtworzOperatoraOKodzie("Adam Pitera");
            operatorOkno.PrzejdzDoZakladkiSystemowe();
            if (operatorOkno.CzyZazrzadzaPozostalymiOperatorami())
            {
                operatorOkno.ZaznaczOdznaczZarzadzaPozostalymiOperatorami();
            }
            operatorOkno.KliknijOK();
            drzewko.ZapiszIZamknij();

            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Adam Pitera");

            drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI().PrzejdzDoBIOgolne();
            Assert.IsFalse(bIOgolne.CzyPrawaModeliDanych());

            bIOgolne.ZaznaczOdznaczPrawaModeliDanychCheckBox();
            Assert.IsFalse(bIOgolne.CzyPrawaModeliDanych());

            bIOgolne.ZaznaczOdznaczPrawaModeliDanychCheckBox();
            Assert.IsFalse(bIOgolne.CzyPrawaModeliDanych());

            drzewko.ZapiszIZamknij();
        }

        [TestCase]
        public void BI007()
        {
            string Baza = "BITest";
            Logowanie logowanie = new Logowanie(driver);

            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            Drzewko drzewko = stronaGlowna.PrzejdzDoOpcji();
            OperatorOkno operatorOkno = drzewko
                .PrzejdzDoSystemowe()
                .PrzejdzDoOperatorzy()
                .OtworzOperatoraOKodzie("Adam Pitera")
                .PrzejdzDoZakladkiSystemowe();
            if (!operatorOkno.CzyZazrzadzaPozostalymiOperatorami())
            {
                operatorOkno.ZaznaczOdznaczZarzadzaPozostalymiOperatorami();
            }
            operatorOkno.KliknijOK();
            drzewko.ZapiszIZamknij();

            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Adam Pitera");
            drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko = stronaGlowna.PrzejdzDoOpcji();
            ModeleDanych modeleDanych = drzewko.PrzejdzDoBI().PrzejdzDoModeleDanych();
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("Domena", "Typ");
            modeleDanych.ZaznaczWszystko()
            .KliknijUstawPrawoDoModeli()
            .KliknijPrawoDostepu()
            .KliknijPelnePrawo()
            .KliknijOK();
            modeleDanych.Kliknij_Tak();
            modeleDanych.ZapiszIZamknij();
            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            LicencjaDemonstracyjna licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaHandlowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczHandlowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }

            drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI().PrzejdzDoModeleDanych();
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_ABC_Klasyfikacja ABC", "Nazwa");
            modeleDanych.KliknijCzynnosciMenuCtx().KliknijKopjujModeleDanych();
        }

        [TestCase]
        public void BI009()
        {
            string Baza = "BITest";
            Logowanie logowanie = new Logowanie(driver);

            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            LicencjaDemonstracyjna licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaFirmowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczFirmowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
            Drzewko drzewko = stronaGlowna.PrzejdzDoOpcji();

            drzewko.PrzejdzDoBI();
            ModeleDanych modeleDanych = drzewko.PrzejdzDoModeleDanych();
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_ABC_Klasyfikacja ABC", "Nazwa");
            UstawModeleDanychOkno ustawModeleDanychOkno = modeleDanych.KliknijUstawPrawoDoModeli();
            ustawModeleDanychOkno
                .KliknijPrawoDostepu()
                .KliknijPelnePrawo()
                .KliknijUprawnienia()
                .KliknijWybierzWiele()
                .KliknijDodajWszystkie()
                .ZatwierdzKliknijOK()
                .KliknijOK();

            //   modeleDanych.ZapiszBezZamykania();
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_ABC_Klasyfikacja ABC", "Nazwa");
            DefinicjaWskaznikaOkno definicjaWskaznikaOkno = modeleDanych.OtworzRekord();
            definicjaWskaznikaOkno.PrzejdzDoZakladkiPrawaDanych();
            int limit = definicjaWskaznikaOkno.LiczbaWierszyOstatni();
            for (int i = 0; i <= limit; i = i + 5)
            {
                Assert.AreEqual("Zaznaczony", definicjaWskaznikaOkno.TekstKomorkiNWKolumnie(i, "Pełne prawo"));
            }

            definicjaWskaznikaOkno.KliknijOK();
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_ABC_Klasyfikacja ABC", "Nazwa");
            modeleDanych.KliknijKopjujModeleDanych();
            //modeleDanych.TekstKomorkiNWKolumnie(modeleDanych.WezNumerWierszaOWartosciWKolumnie("BI_m_a_ABC_Klasyfikacja ABC", "Nazwa"), "Nazwa").Substring(-7)

            Assert.AreEqual("BI_m_a_ABC_Klasyfikacja ABC_Kopia_",
                modeleDanych.TekstKomorkiNWKolumnie(modeleDanych.WezNumerWierszaOWartosciWKolumnie("BI_m_a_ABC_Klasyfikacja ABC", "Nazwa") + 1, "Nazwa").Substring(0, 34));

            modeleDanych.ZapiszIZamknij();
        }

        [TestCase]
        public void BI010()
        {
            string Baza = "BITest";
            Logowanie logowanie = new Logowanie(driver);

            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            LicencjaDemonstracyjna licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaFirmowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczFirmowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }
            Drzewko drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI();
            BIOgolne bIOgolne = drzewko.PrzejdzDoBIOgolne();
            if (!bIOgolne.CzyPrawaModeliDanych())
            {
                bIOgolne.ZaznaczOdznaczPrawaModeliDanychCheckBox();
            }
            ModeleDanych modeleDanych = drzewko.PrzejdzDoModeleDanych();
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("Domena", "Typ");

            UstawModeleDanychOkno ustawModeleDanychOkno = modeleDanych.ZaznaczWszystko().KliknijUstawPrawoDoModeli();
            ustawModeleDanychOkno.KliknijPrawoDostepu().KliknijZakazDostepu().KliknijOK();
            ustawModeleDanychOkno.ZatwierdzZmiany();
            modeleDanych.ZapiszBezZamykania();

            modeleDanych.KliknijListeObszar().WybierzZListy("Handel");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("Domena", "Typ");
            modeleDanych.ZaznaczWszystko().KliknijUstawPrawoDoModeli();
            ustawModeleDanychOkno.KliknijPrawoDostepu().KliknijPelnePrawo().KliknijOK();
            ustawModeleDanychOkno.ZatwierdzZmiany();

            modeleDanych.KliknijListeObszar().WybierzZListy("CRM");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("Domena", "Typ");
            modeleDanych.ZaznaczWszystko().KliknijUstawPrawoDoModeli();
            ustawModeleDanychOkno.KliknijPrawoDostepu().KliknijPelnePrawo().KliknijOK();
            ustawModeleDanychOkno.ZatwierdzZmiany();

            modeleDanych.KliknijListeObszar().WybierzZListy("Finansowy");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("Domena", "Typ");
            modeleDanych.ZaznaczWszystko().KliknijUstawPrawoDoModeli();
            ustawModeleDanychOkno.KliknijPrawoDostepu().KliknijTylkoOdczyt().KliknijOK();
            ustawModeleDanychOkno.ZatwierdzZmiany();
            ustawModeleDanychOkno.ZapiszBezZamykania();


            modeleDanych.KliknijListeObszar().WybierzZListy("Handel");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_ABC_Klasyfikacja ABC", "Nazwa");
            DefinicjaWskaznikaOkno definicjaWskaznikaOkno = modeleDanych.OtworzRekord();
            definicjaWskaznikaOkno.Rozszerz();

            Assert.IsTrue(definicjaWskaznikaOkno.IsDodatkowePolaVisible());
            Assert.IsTrue(definicjaWskaznikaOkno.IsDodatkoweZlaczeniaVisible());
            Assert.IsTrue(definicjaWskaznikaOkno.IsDodatkowyWarunekVisible());

            definicjaWskaznikaOkno.UsunRozszerzenie();

            Assert.IsFalse(definicjaWskaznikaOkno.IsDodatkowePolaVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsDodatkoweZlaczeniaVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsDodatkowyWarunekVisible());

            definicjaWskaznikaOkno.PodgladZapytania();

            Assert.IsTrue(definicjaWskaznikaOkno.IsPodgladZapytaniaVisible());
            definicjaWskaznikaOkno.ZamknijOkno();
            definicjaWskaznikaOkno.Oblicz();
            definicjaWskaznikaOkno.KliknijOK();
            definicjaWskaznikaOkno.WlaczKalkulatorModeluDanych();
            Assert.IsTrue(definicjaWskaznikaOkno.IsKalkulatorModeluDanychVisible());
            definicjaWskaznikaOkno.ZamknijOkno();
            definicjaWskaznikaOkno.GenerujWidok();

            Assert.IsTrue(definicjaWskaznikaOkno.KomunikatZakonczonoPomyslnieVisible());
            definicjaWskaznikaOkno.Kliknij_OK();
            definicjaWskaznikaOkno.KliknijOK();

            modeleDanych.KliknijListeObszar().WybierzZListy("CRM");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_Analiza kwot projektu", "Nazwa");
            definicjaWskaznikaOkno = modeleDanych.OtworzRekord();
            definicjaWskaznikaOkno.Rozszerz();

            Assert.IsTrue(definicjaWskaznikaOkno.IsDodatkowePolaVisible());
            Assert.IsTrue(definicjaWskaznikaOkno.IsDodatkoweZlaczeniaVisible());
            Assert.IsTrue(definicjaWskaznikaOkno.IsDodatkowyWarunekVisible());

            definicjaWskaznikaOkno.UsunRozszerzenie();

            Assert.IsFalse(definicjaWskaznikaOkno.IsDodatkowePolaVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsDodatkoweZlaczeniaVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsDodatkowyWarunekVisible());

            definicjaWskaznikaOkno.PodgladZapytania();

            Assert.IsTrue(definicjaWskaznikaOkno.IsPodgladZapytaniaVisible());
            definicjaWskaznikaOkno.ZamknijOkno();
            definicjaWskaznikaOkno.Oblicz();
            definicjaWskaznikaOkno.KliknijOK();
            definicjaWskaznikaOkno.WlaczKalkulatorModeluDanych();
            Assert.IsTrue(definicjaWskaznikaOkno.IsKalkulatorModeluDanychVisible());
            definicjaWskaznikaOkno.ZamknijOkno();
            definicjaWskaznikaOkno.GenerujWidok();

            Assert.IsTrue(definicjaWskaznikaOkno.KomunikatZakonczonoPomyslnieVisible());
            definicjaWskaznikaOkno.Kliknij_OK();
            definicjaWskaznikaOkno.KliknijOK();

            modeleDanych.KliknijListeObszar().WybierzZListy("Finansowy");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_Analiza należności i zobowiazań kontrahenta", "Nazwa");

            Assert.IsFalse(definicjaWskaznikaOkno.IsRozszerzVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsGenerujWidokVisible());

            definicjaWskaznikaOkno.PodgladZapytania();

            Assert.IsTrue(definicjaWskaznikaOkno.IsPodgladZapytaniaVisible());
            definicjaWskaznikaOkno.ZamknijOkno();
            definicjaWskaznikaOkno.Oblicz();
            definicjaWskaznikaOkno.KliknijOK();
            definicjaWskaznikaOkno.WlaczKalkulatorModeluDanych();
            Assert.IsTrue(definicjaWskaznikaOkno.IsKalkulatorModeluDanychVisible());
            definicjaWskaznikaOkno.ZamknijOkno();

            modeleDanych.KliknijListeObszar().WybierzZListy("Kadry i płace");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_% udział elementów wyngrodzenia w całości kosztów wynagrodzeń", "Nazwa");
            Assert.IsFalse(definicjaWskaznikaOkno.IsRozszerzVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsPodgladZapytaniaButtonVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsObliczVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsGenerujWidokVisible());

            definicjaWskaznikaOkno.KliknijOK();

            drzewko.ZapiszIZamknij();

            licencjaDemonstracyjna = stronaGlowna.PrzejdzDoLicencjeDemonstracyjne();
            if (!licencjaDemonstracyjna.CzyLicencjaHandlowaZaznaczona())
            {
                licencjaDemonstracyjna.ZaznaczOdznaczHandlowaLicencja();
                stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij();
                logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            }
            else { stronaGlowna = licencjaDemonstracyjna.ZapiszIZamknij(); }



            drzewko = stronaGlowna.PrzejdzDoOpcji();
            drzewko.PrzejdzDoBI();
            modeleDanych = drzewko.PrzejdzDoModeleDanych();

            modeleDanych.KliknijListeObszar().WybierzZListy("Handel");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_ABC_Klasyfikacja ABC", "Nazwa");
            definicjaWskaznikaOkno = modeleDanych.OtworzRekord();
            definicjaWskaznikaOkno.Rozszerz();

            Assert.IsTrue(definicjaWskaznikaOkno.IsDodatkowePolaVisible());
            Assert.IsTrue(definicjaWskaznikaOkno.IsDodatkoweZlaczeniaVisible());
            Assert.IsTrue(definicjaWskaznikaOkno.IsDodatkowyWarunekVisible());

            definicjaWskaznikaOkno.UsunRozszerzenie();

            Assert.IsFalse(definicjaWskaznikaOkno.IsDodatkowePolaVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsDodatkoweZlaczeniaVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsDodatkowyWarunekVisible());

            definicjaWskaznikaOkno.PodgladZapytania();

            Assert.IsTrue(definicjaWskaznikaOkno.IsPodgladZapytaniaVisible());
            definicjaWskaznikaOkno.ZamknijOkno();
            definicjaWskaznikaOkno.Oblicz();
            definicjaWskaznikaOkno.KliknijOK();
            definicjaWskaznikaOkno.WlaczKalkulatorModeluDanych();
            Assert.IsTrue(definicjaWskaznikaOkno.IsKalkulatorModeluDanychVisible());
            definicjaWskaznikaOkno.ZamknijOkno();
            definicjaWskaznikaOkno.GenerujWidok();

            Assert.IsTrue(definicjaWskaznikaOkno.KomunikatZakonczonoPomyslnieVisible());
            definicjaWskaznikaOkno.Kliknij_OK();
            definicjaWskaznikaOkno.KliknijOK();


            modeleDanych.KliknijListeObszar().WybierzZListy("CRM");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_Analiza kwot projektu", "Nazwa");
            definicjaWskaznikaOkno = modeleDanych.OtworzRekord();
            Assert.IsTrue(definicjaWskaznikaOkno.IsRozszerzVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsPodgladZapytaniaButtonVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsObliczVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsGenerujWidokVisible());
            definicjaWskaznikaOkno.KliknijOK();

            modeleDanych.KliknijListeObszar().WybierzZListy("Finansowy");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_Analiza należności i zobowiazań kontrahenta", "Nazwa");
            definicjaWskaznikaOkno = modeleDanych.OtworzRekord();
            Assert.IsFalse(definicjaWskaznikaOkno.IsRozszerzVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsPodgladZapytaniaButtonVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsObliczVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsGenerujWidokVisible());
            definicjaWskaznikaOkno.KliknijOK();


            modeleDanych.KliknijListeObszar().WybierzZListy("Kadry i płace");
            modeleDanych.KliknijKomorkeOPodanymTekscieIKolumnie("BI_m_a_% udział elementów wyngrodzenia w całości kosztów wynagrodzeń", "Nazwa");
            definicjaWskaznikaOkno = modeleDanych.OtworzRekord();
            Assert.IsFalse(definicjaWskaznikaOkno.IsRozszerzVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsPodgladZapytaniaButtonVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsObliczVisible());
            Assert.IsFalse(definicjaWskaznikaOkno.IsGenerujWidokVisible());
            definicjaWskaznikaOkno.KliknijOK();

            drzewko.ZapiszIZamknij();

        }

        [TestCase]
        public void BI011()
        {
            string Baza = "BITest";
            Logowanie logowanie = new Logowanie(driver);

            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            TowaryTabela towaryTabela = stronaGlowna.PrzejdzDoTowary();
            DashboardManagerOkno dashboardManagerOkno = towaryTabela.ZarzadzajPanelemBI();
            dashboardManagerOkno.ElementNTabeliKolumny(2, "Opis").Click();
            dashboardManagerOkno.KliknijDodaj().ZapiszIZamknij();
            Assert.IsTrue(towaryTabela.CzyPanelBI());
            Assert.IsTrue(towaryTabela.CzyWartoscFakturSprzedazyText());

            ZarzadzanieDashboardami zarzadzanieDashboardami =
            stronaGlowna.PrzejdzDoOpcji()
                .PrzejdzDoBI()
                .PrzejdzDoZarzadzanieDashboardami();

            zarzadzanieDashboardami.FiltrujHandel()
                .Znajdz("Wartość faktur sprzedaży")
                .KopiujLokalizacjeNaUprawnienia()
                .KliknijUprawnienia()
                .KliknijNaOsobe("Adam Pitera")
                .KliknijOK();
            zarzadzanieDashboardami.ZapiszIZamknij();
            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Adam Pitera");

            stronaGlowna.PrzejdzDoOpcji()
                .PrzejdzDoBI()
                .PrzejdzDoZarzadzanieDashboardami()
                .FiltrujHandel();

            Assert.AreEqual("Wartość faktur sprzedaży (kraj)", dashboardManagerOkno.TekstKomorkiNWKolumnie(0, "Nazwa"));

            zarzadzanieDashboardami.ZapiszIZamknij();
            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Administrator");
            OperatorOkno operatorOkno = stronaGlowna.PrzejdzDoOpcji()
                .PrzejdzDoSystemowe()
                .PrzejdzDoOperatorzy()
                .OtworzOperatoraOKodzie("Adam Pitera")
                .PrzejdzDoZakladkiSystemowe();
            if (!operatorOkno.CzyZazrzadzaPozostalymiOperatorami())
            {
                operatorOkno.ZaznaczOdznaczZarzadzaPozostalymiOperatorami();
            }
            operatorOkno.KliknijOK();
            operatorOkno.ZapiszIZamknij();
            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Adam Pitera");

            stronaGlowna.PrzejdzDoOpcji()
               .PrzejdzDoBI()
               .PrzejdzDoZarzadzanieDashboardami()
               .FiltrujHandel();
            zarzadzanieDashboardami.KliknijKomorkeOPodanymTekscieIKolumnie("Adam Pitera", "Uprawnienie");

            Assert.IsTrue(zarzadzanieDashboardami.IsKopujLokalizacjeButtonVisible());

            zarzadzanieDashboardami
                .KopiujLokalizacjeNaUprawnienia()
                .KliknijPelnePrawo()
                .KliknijUprawnienia()
                .KliknijNaOsobe("Irena Sochacka")
                .KliknijOK();
            zarzadzanieDashboardami.ZapiszIZamknij();
            logowanie.ZalogujPonownie(BAZA_BI_TEST, "Irena Sochacka");
            stronaGlowna.PrzejdzDoTowary();

            Assert.IsTrue(towaryTabela.CzyWartoscFakturSprzedazyText());
        }

        [TestCase]
        public void BI014()
        {
            string Baza = "BITest";
            Logowanie logowanie = new Logowanie(driver);

            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            DefinicjaPrzedzialowCzasowych definicjaPrzedzialowCzasowych = stronaGlowna
                .PrzejdzDoOpcji()
                .PrzejdzDoBI().
                PrzejdzDoDefinicjaPrzedzialowCzasowych();
            DefinicjaStatycznaOkno definicjaStatycznaOkno = definicjaPrzedzialowCzasowych.NowaDefinicjaStatyczna();
            definicjaStatycznaOkno
                .WpiszNazwe("I kwartał 2019")
                .WpiszPrzedzial("2019.01.01…2019.03.31")
                .KliknijOK();
            Assert.IsTrue(definicjaPrzedzialowCzasowych.WezNumerWierszaOWartosciWKolumnie("I kwartał 2019", "Name") != -1);
            DefinicjaDynamicznaOkno definicjaDynamicznaOkno = definicjaPrzedzialowCzasowych.NowaDefinicja();

            definicjaDynamicznaOkno.WpiszNazwe("II kwartał bieżącego roku")
                .OdPlus()
                .OdPlus()
                .DoPlus()
                .DoPlus()
                .DoPlus()
                .WpiszOd1Pole1("Pierwszy")
                .WpiszOd1Pole2("Rok")
                .WpiszOd2Pole2("Kwartał")
                .WpiszOd2Pole3("1")
                .WpiszDo1Pole1("Pierwszy")
                .WpiszDo1Pole2("Rok")
                .WpiszDo2Pole2("Kwartał")
                .WpiszDo2Pole3("2")
                .WpiszDo3Pole3("-1");

            String Dzis = DateTime.Now.ToString("dd.MM.yyyy");

            Assert.AreEqual("Podgląd dla " + Dzis + ":    01.04.2019...30.06.2019", definicjaDynamicznaOkno.PodgladText());

            definicjaDynamicznaOkno.KliknijOK();

            Assert.IsTrue(definicjaPrzedzialowCzasowych.WezNumerWierszaOWartosciWKolumnie("II kwartał bieżącego roku", "Name") != -1);

            //definicjaPrzedzialowCzasowych.KliknijKomorkeOPodanymTekscieIKolumnie("I kwartał 2019", "Name");
            //definicjaPrzedzialowCzasowych.UsunRekord();
            //definicjaPrzedzialowCzasowych.KliknijKomorkeOPodanymTekscieIKolumnie("II kwartał bieżącego roku", "Name");
            //definicjaPrzedzialowCzasowych.UsunRekord();
            definicjaPrzedzialowCzasowych.ZapiszIZamknij();

        }
        [TestCase]
        public void BI015()
        {
            string Baza = "BITest";
            Logowanie logowanie = new Logowanie(driver);

            StronaGlowna stronaGlowna = logowanie.Zaloguj(BAZA_NUNIT_UI, "Administrator");
            DefinicjaZestawowPrzedzialowCzasowych definicjaZestawowPrzedzialowCzasowych = stronaGlowna
                .PrzejdzDoOpcji()
                .PrzejdzDoBI()
                .PrzejdzDoModeleDanychFolder()
                .PrzejdzDoDefinicjeZestawowPrzedzialowCzasowych();
            ZestawPrzedzialowCzasowychOkno zestawPrzedzialowCzasowychOkno = definicjaZestawowPrzedzialowCzasowych.NowaDefinicjaZestawu();
            zestawPrzedzialowCzasowychOkno.WpiszName("Test")
                .KLiknijNowyElementZestawu()
                .WybierzDefinicjaPrzdzialu("I kwartał")
                .Zatwierdz();

            zestawPrzedzialowCzasowychOkno
                .KLiknijNowyElementZestawu()
                .WybierzDefinicjaPrzdzialu("II kwartał")
                .ZamknijOkno();
            zestawPrzedzialowCzasowychOkno.Kliknij_Tak();

            zestawPrzedzialowCzasowychOkno.KliknijOK();

            Assert.IsTrue(definicjaZestawowPrzedzialowCzasowych.WezNumerWierszaOWartosciWKolumnie("Test", "Name") != -1);

            definicjaZestawowPrzedzialowCzasowych.KliknijKomorkeOPodanymTekscieIKolumnie("Test", "Name");
            definicjaZestawowPrzedzialowCzasowych.OtworzRekord();

            Assert.AreEqual("I kwartał 2019", definicjaZestawowPrzedzialowCzasowych.TekstKomorkiNWKolumnie(0, "Definition"));
            Assert.AreEqual("II kwartał bieżącego roku", definicjaZestawowPrzedzialowCzasowych.TekstKomorkiNWKolumnie(1, "Definition"));
            definicjaZestawowPrzedzialowCzasowych.KliknijOK();
            definicjaZestawowPrzedzialowCzasowych.ZapiszIZamknij();
        }
    }
}
