using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class SredstvaObezbedjenja : IEntity
    {
        public long Id { get; set; }
        public long SredstvaID { get; set; }
        public long RadnikID { get; set; }
        public long PozicijaNaPrijemu { get; set; }
    }
}
