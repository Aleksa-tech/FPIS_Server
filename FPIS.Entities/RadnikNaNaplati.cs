using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class RadnikNaNaplati : IEntity
    {
        public long Id { get; set; }
        public long RadnikID { get; set; }
        public long PozicijaNaNaplati { get; set; }
        public long SifraUgovora { get; set; }

    }
}
