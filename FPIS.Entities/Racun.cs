using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Racun : IEntity
    {
        public long Id { get; set; }
        public string TipRacuna { get; set; }
        List<Stanje> StanjaRacuna { get; set; }
    }
}
