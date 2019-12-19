using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop.PodgladTabel
{
    class DefinicjaCechyOkno : AbstractWindow
    {
        private WindowsElement NowaCechaBttn => driver.FindElementByName("Nowy (Definicja cechy)");
        private WindowsElement TypCechyPole => driver.FindElementByXPath("//Text[@Name=\"Tabela:\"]/following-sibling::Pane/ComboBox/Text");
        private WindowsElement NazwaPole => driver.FindElementByXPath("//Text[@Name=\"Nazwa:\"]/following-sibling::Pane/Edit/Edit");
        private WindowsElement TypWartosciPole => driver.FindElementByXPath("//Text[@Name=\"Typ, wartości wprowadzanej cechy:\"]/following-sibling::Pane");
        private WindowsElement TabelaDanychRefPole => driver.FindElementByXPath("//Text[@Name=\"Tabela danych referencyjnych:\"]/following-sibling::Pane");
        private WindowsElement HistoriaDanychWCzasieCheckBox => driver.FindElementByXPath("//Pane[@Name=\"Dodatkowe\"]/following-sibling::Pane[1]");
        private WindowsElement WartoscCechyWymaganaCheckBox => driver.FindElementByXPath("//Pane[@Name=\"Dodatkowe\"]/following-sibling::Pane[2]");
        private WindowsElement InicjujCecheCheckBox => driver.FindElementByXPath("//Pane[@Name=\"Dodatkowe\"]/following-sibling::Pane[3]");
        private WindowsElement ZaawansowaneZakladka => driver.FindElementByName("Zaawansowane");
        private WindowsElement Cecha6RadioBox => driver.FindElementByXPath("//Pane[@AutomationId=\"FeatureAdvancedPage\"]/Pane[5]/CheckBox");
        private WindowsElement ZakladkaAlgorytm => driver.FindElementByXPath("//Tree[@AutomationId=\"PagesTree\"]/TreeItem[5]");

        public DefinicjaCechyOkno(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public DefinicjaCechyOkno UzupelnijTypDanychCechy(String typ)
        {
            FocusNaOkienko();
            TypCechyPole.Click();
            TypCechyPole.SendKeys(typ);
            return this;
        }

        public DefinicjaCechyOkno UzupelnijNazweCechy(String nazwa)
        {
            FocusNaOkienko();
            NazwaPole.Click();
            NazwaPole.SendKeys(nazwa);
            return this;
        }

        public void CzyZaznaczHistoriaDanychWCzasie(Boolean zaznaczyc)
        {
            if (zaznaczyc)
            {
                if (HistoriaDanychWCzasieCheckBox.Text == "Tak")
                    return;
                else
                {
                    HistoriaDanychWCzasieCheckBox.Click();
                    return;
                }
            }
            if (!zaznaczyc)
            {
                if (HistoriaDanychWCzasieCheckBox.Text == "Nie")
                    return;
                else
                {
                    HistoriaDanychWCzasieCheckBox.Click();
                    return;
                }
            }
        }
        public void PrzejdzDoZaawansowaneZakladka()
        {
            ZaawansowaneZakladka.Click();
        }
        public void Cecha6Wybierz()
        {
            Cecha6RadioBox.Click();
        }

        public String PiataZakladka()
        {
            return ZakladkaAlgorytm.Text;
        }
    }
}
