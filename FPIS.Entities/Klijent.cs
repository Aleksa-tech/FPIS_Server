using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Klijent : IEntity
    {
        public long Id { get; set; }
        public long PIB { get; set; }
        public string AdresaISediste { get; set; }
        public string ImeIPrezimeKlijenta { get; set; }
        public long BrojRacuna { get; set; }
        public Racun Racun { get; set; }
    }
}
