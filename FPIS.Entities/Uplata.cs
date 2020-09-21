using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Uplata
    {
        public long RadnikID { get; set; }
        public long PozicijaNaNaplati { get; set; }
        public long KlijentID { get; set; }
        public long UplatnicaID { get; set; }
        public DateTime DatumUplate { get; set; }
    }
}
