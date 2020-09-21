using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Uplatnica : IEntity
    {
        public long Id { get; set; }
        public string SvrhaUplateUplatnice { get; set; }
        public double IznosUplatnice { get; set; }
        public string ValutaUplatnice { get; set; }
        public int ModelUplatnice { get; set; }
        public int PozivniBrojUplatnice { get; set; }
    }
}
