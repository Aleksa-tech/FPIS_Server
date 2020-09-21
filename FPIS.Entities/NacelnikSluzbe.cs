using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class NacelnikSluzbe : IEntity
    {
        public long Id { get; set; }
        public string ImeNacelnika { get; set; }
        public string PrezimeNacelnika { get; set; }
    }
}
