using TestyInterfejsowe.OknaDesktop.Narzedzia.Systemowe;
using TestyInterfejsowe.OknaDesktop.Opcje.BI;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace TestyInterfejsowe.OknaDesktop.Opcje
{
    class Drzewko : AbstractWindow
    {
        private WindowsElement ZapiszIZamknijButton => driver.FindElement(By.Name("Zapisz i zamknij"));
        #region Glowne Foldery Drzewka Opcji
        private WindowsElement FirmaFolder => driver.FindElement(By.Name("Firma"));
        private WindowsElement OgolneFolder => driver.FindElement(By.Name("Ogólne"));
        private WindowsElement CRMFolder => driver.FindElement(By.Name("CRM"));
        private WindowsElement PulpityFolder => driver.FindElement(By.Name("Pulpity"));
        private WindowsElement ZaleceniaSerwisoweFolder => driver.FindElement(By.Name("Zlecenia serwisowe"));
        private WindowsElement DMSFolder => driver.FindElement(By.Name("DMS"));
        private WindowsElement WorkflowFolder => driver.FindElement(By.Name("Workflow"));
        private WindowsElement AnalizyFolder => driver.FindElement(By.Name("Analizy"));
        private WindowsElement BIFolder => driver.FindElement(By.Name("BI"));
        private WindowsElement DelegacjeFolder => driver.FindElement(By.Name("Delegacje"));
        private WindowsElement EwidencjaDokumnetowFolder => driver.FindElement(By.Name("Ewidencja dokumentów"));
        private WindowsElement EwidencjaPojazdowFolder => driver.FindElement(By.Name("Ewidencja pojazdów"));
        private WindowsElement EwidencjaVatFolder => driver.FindElement(By.Name("Ewidencja VAT"));
        private WindowsElement EwidencjaSP => driver.FindElement(By.Name("Ewidencje ŚP"));
        private WindowsElement Handel => driver.FindElement(By.Name("Handel"));
        private WindowsElement KadryIPlaceFolder => driver.FindElement(By.Name("Kadry i płace"));
        private WindowsElement KontrahneciIUrzedyFolder => driver.FindElement(By.Name("Kontrahenci i urzędy"));
        private WindowsElement KsiegaInwentarzowaFolder => driver.FindElement(By.Name("Księga inwentarzowa"));
        private WindowsElement KsiegowoscFolder => driver.FindElement(By.Name("Księgowość"));
        private WindowsElement PodizelinikiFolder => driver.FindElement(By.Name("Podzielniki"));
        private WindowsElement ProdukcjaFolder => driver.FindElement(By.Name("Produkcja"));
        private WindowsElement RaportowanieFolder => driver.FindElement(By.Name("Raportowanie"));
        private WindowsElement SystemoweFolder => driver.FindElement(By.Name("Systemowe"));
        #endregion
        #region BI elementy drzewka opcji
        private WindowsElement AktualizacjaModeliDanychElementDrzewka => driver.FindElement(By.Name("Aktualizacja modeli danych"));
        private WindowsElement DefinicjeElementowDashboardowElementDrzewka => driver.FindElement(By.Name("Definicje elementów dashboard'ów"));
        private WindowsElement DefinicjePrzedzialowCzasowychElementDrzewka => driver.FindElement(By.Name("Definicje przedziałów czasowych"));
        private WindowsElement PrezentacjaDanychElementDrzewka => driver.FindElement(By.Name("Prezentacja danych"));
        private WindowsElement UtrwalanieDanychElementDrzewka => driver.FindElement(By.Name("Utrwalanie danych"));
        private WindowsElement DefinicjeUtrwalaniaElementDrzewka => driver.FindElement(By.Name("Definicje utrwalania"));
        private WindowsElement DefinicjeZestawowDanychElementDrzewka => driver.FindElement(By.Name("Definicje zestawów danych"));
        private WindowsElement DefinicjeZestawowPrzedzialowCzasowychElementDrzewka => driver.FindElement(By.Name("Definicje zestawów przedziałów czasowych"));
        private WindowsElement ModeleDanychElementDrzewka => driver.FindElement(By.Name("Modele danych [Ctrl+Shift+B]"));
        private WindowsElement ModeleDanychElementDrzewka1 => driver.FindElement(By.Name("Modele danych"));
        private WindowsElement ZarzadzanieDashboardamiElementDrzewka => driver.FindElement(By.Name("Zarządzanie dashboardami"));
        private WindowsElement ZestawyBarwElementDrzewka => driver.FindElement(By.Name("Zestawy barw"));
        private WindowsElement ZestawyPrzedzialowDanychElementDrzewka => driver.FindElement(By.Name("Zestawy przedziałów danych"));
        private WindowsElement OpcjeOkno => driver.FindElement(By.Name("Opcje"));

        public Drzewko(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public Drzewko PrzejdzDoBI()
        {
            BIFolder.Click();
            return this;
        }

        public Drzewko PrzejdzDoPrezentacjaDanych()
        {
            PrezentacjaDanychElementDrzewka.Click();
            return this;
        }

        public Drzewko PrzejdzDoUtrwalanieDanych()
        {
            UtrwalanieDanychElementDrzewka.Click();
            return this;
        }

        public BIOgolne PrzejdzDoBIOgolne()
        {
            driver.Mouse.MouseMove(BIFolder.Coordinates, 20, 30);
            driver.Mouse.Click(null);
            return new BIOgolne(driver);
        }

        public AktualizacjaModeliDanych PrzejdzDoAktualizacjaModeliDanych()
        {
            AktualizacjaModeliDanychElementDrzewka.Click();
            return new AktualizacjaModeliDanych(driver);
        }

        public DefinicjeElementowDashboardow PrzejdzDoDefinicjeElementowDashboardow()
        {
            DefinicjeElementowDashboardowElementDrzewka.Click();
            return new DefinicjeElementowDashboardow(driver);
        }

        public DefinicjaPrzedzialowCzasowych PrzejdzDoDefinicjaPrzedzialowCzasowych()
        {
            DefinicjePrzedzialowCzasowychElementDrzewka.Click();
            return new DefinicjaPrzedzialowCzasowych(driver);
        }

        public DefinicjeUtrwalania PrzejdzDoDefinicjeUtrwalania()
        {
            DefinicjeUtrwalaniaElementDrzewka.Click();
            return new DefinicjeUtrwalania(driver);
        }

        public DefinicjaZastawowDanych PrzejdzDoDefinicjeZestawowDanych()
        {
            DefinicjeZestawowDanychElementDrzewka.Click();
            return new DefinicjaZastawowDanych(driver);
        }

        public DefinicjaZestawowPrzedzialowCzasowych PrzejdzDoDefinicjeZestawowPrzedzialowCzasowych()
        {
            DefinicjeZestawowPrzedzialowCzasowychElementDrzewka.Click();
            return new DefinicjaZestawowPrzedzialowCzasowych(driver);
        }

        public ModeleDanych PrzejdzDoModeleDanych()
        {
            ModeleDanychElementDrzewka1.Click();
            ModeleDanychElementDrzewka.Click();
            return new ModeleDanych(driver);
        }

        public Drzewko PrzejdzDoModeleDanychFolder()
        {
            ModeleDanychElementDrzewka1.Click();
            return this;
        }

        public ZarzadzanieDashboardami PrzejdzDoZarzadzanieDashboardami()
        {
            ZarzadzanieDashboardamiElementDrzewka.Click();
            return new ZarzadzanieDashboardami(driver);
        }

        public ZestawyBarw PrzejdzDoZestawyBarw()
        {
            ZestawyBarwElementDrzewka.Click();
            return new ZestawyBarw(driver);
        }

        public ZestawyPrzedzialowDanych PrzejdzDoZestawyPrzedzialowDanych()
        {
            ZestawyPrzedzialowDanychElementDrzewka.Click();
            return new ZestawyPrzedzialowDanych(driver);
        }

        #endregion

        #region Systemowe elementy drzewka opcji
        private WindowsElement AsystentElementDrzewka => driver.FindElement(By.Name("Asystent"));
        private WindowsElement OperatorzyElementDrzewka => driver.FindElement(By.Name("Operatorzy [Ctrl+O]"));

        public Drzewko PrzejdzDoSystemowe()
        {
            SystemoweFolder.Click();
            return this;
        }

        public Asystent PrzejdzDoAsystent()
        {
            AsystentElementDrzewka.Click();
            return new Asystent(driver);
        }

        public Operatorzy PrzejdzDoOperatorzy()
        {
            OperatorzyElementDrzewka.Click();
            return new Operatorzy(driver);
        }
        #endregion

        #region Kontrahenci i urzędy elementy drzewka Opcji
        private WindowsElement KontrahneciIUrzedyFormyPrawne => driver.FindElement(By.Name("Formy Prawne"));
        private WindowsElement KontrahneciIUrzedyKategorie => driver.FindElement(By.Name("Kategorie"));
        private WindowsElement KontrahneciIUrzedyPKDiSIC => driver.FindElement(By.Name("PKD i SIC"));
        private WindowsElement KontrahneciIUrzedyCechy => driver.FindElement(By.Name("Cechy"));

        public Drzewko PrzejdzDoKontrahenciIUrzedyFolder()
        {
            KontrahneciIUrzedyFolder.Click();
            return this;
        }

        public Drzewko PrzejdzDoKategorie()
        {
            KontrahneciIUrzedyKategorie.Click();
            return this;
        }

        public void PrzejdzDoKontrahenciIUrzedyOgolne()
        {
            driver.Mouse.MouseMove(KontrahneciIUrzedyFolder.Coordinates, 20, 30);
            driver.Mouse.Click(null);
        }
        #endregion

        public StronaGlowna ZapiszIZamknij()
        {
            ZapiszIZamknijButton.Click();
            return new StronaGlowna(driver);
        }

        public int LewaWspolrzednaOknaOpcje()
        {
            String WordLeft = "Left:";
            String Zwrot;
            String Left;

            Zwrot = OpcjeOkno.GetAttribute("BoundingRectangle");
            Left = Zwrot.Substring(Zwrot.IndexOf(WordLeft) + WordLeft.Length, Zwrot.IndexOf(" ", Zwrot.IndexOf(WordLeft) + 1) - Zwrot.IndexOf(WordLeft) - WordLeft.Length);
            return Int32.Parse(Left);
        }

        public int TopWspolrzednaOknaOpcje()
        {
            String WordTop = "Top:";
            String Zwrot;
            String Top;

            Zwrot = OpcjeOkno.GetAttribute("BoundingRectangle");
            Top = Zwrot.Substring(Zwrot.IndexOf(WordTop) + WordTop.Length, Zwrot.IndexOf(" ", Zwrot.IndexOf(WordTop) + 1) - Zwrot.IndexOf(WordTop) - WordTop.Length);
            return Int32.Parse(Top);
        }
    }
}
