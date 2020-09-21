using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Menica : IEntity
    {
        public long Id { get; set; }
        public string MestoMenice { get; set; }
        public double IznosMenice { get; set; }
        public int GodinaMenice { get; set; }
    }
}
