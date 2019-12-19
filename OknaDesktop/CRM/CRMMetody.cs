using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Appium.Windows;

namespace TestyInterfejsowe.OknaDesktop
{
    class CRMMetody : AbstractWindow
    {
        public CRMMetody(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        public String WartoscPolaListyZKolumny(int pozycja, String Kolumna)
        {
            return driver.FindElementByName(Kolumna + " row " + pozycja).Text;
        }

        public int ZnajdzPozycjeNaLiscieZKolumny(String tekst, String Kolumna)
        {
            var liczba = LiczbaWierszyOstatni();
            for (int i = 0; i <= liczba + 2; i++)
            {
                if (driver.FindElementByName(Kolumna + " row " + i).Text == tekst)
                    return i;
            }
            return -1;
        }
        
        public int LiczbaWierszyOstatni()
        {
            int Liczba = 0;
            String nazwa;

            driver.FindElementByName("Panel danych").Click();
            nazwa = driver.FindElementByXPath("//Custom[@Name=\"Panel danych\"]/*[last()]").GetAttribute("Name");
            Liczba = Int32.Parse(Regex.Match(nazwa, @"\d+").Value);
            return Liczba;
        }
    }
}
