using System;
using System.Collections.Generic;
using System.Text;

namespace TestyInterfejsowe.Testy.KlasyPomocnicze
{
    class BazaDanych
    {
        public BazaDanych(string nazwaBazyDanych, Licencja licencja = Licencja.Demo, Jezyk jezyk = Jezyk.Polski)
        {
            NazwaBazyDanych = nazwaBazyDanych;
            LicencjaBazy = licencja;
            JezykBazy = jezyk;
        }

        public String NazwaBazyDanych { get; set; }
        public Licencja LicencjaBazy { get; set; }
        public Jezyk JezykBazy { get; set; }


        
        internal enum Licencja
        {
            Demo = 0,
            Zlota = 1,
            Srebrna = 2,
            Platynowa = 3

        }


        internal enum Jezyk
        {
            Polski = 0,
            Angielski = 1
        }

    }
}
