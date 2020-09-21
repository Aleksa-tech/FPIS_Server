using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Trasant : IEntity
    {
        public long Id { get; set; }
        public long SerijaMenice { get; set; }
        public long KlijentID { get; set; }
    }
}
