using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Opomena : IEntity
    {
        public long Id { get; set; }
        public int BrojOpomene { get; set; }
        public long KlijentID { get; set; }
        public long RadnikID { get; set; }
        public long PozicijaNaNaplati { get; set; }
    }
}
