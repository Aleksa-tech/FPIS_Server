using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class ProcenaTrzisneVrednosti : IEntity
    {
        public long Id { get; set; }
        public string OpisProcene { get; set; }
    }
}
