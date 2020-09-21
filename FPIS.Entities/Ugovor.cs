using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Ugovor : IEntity
    {
        public long Id { get; set; }
        public string TipUgovora { get; set; }
    }
}
