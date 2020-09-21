using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class ListNepokretnosti : IEntity
    {
        public long Id { get; set; }
        public DateTime DatumListaNep { get; set; }
        public DateTime VremeListaNep { get; set; }
        public long NacelnikID { get; set; }
    }
}
