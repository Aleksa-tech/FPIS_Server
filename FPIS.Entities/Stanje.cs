using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Stanje : IEntity
    {
        public long Id { get; set; }
        public long BrojRacuna { get; set; }
        public double IznosStanja { get; set; }
    }
}
