using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class AktivacijaKolaterala
    {
        public long OpomenaID { get; set; }
        public long BrojRacuna { get; set; }
        public long StanjeID { get; set; }
        public DateTime DatumAktivacijeKolaterala { get; set; }
    }
}
