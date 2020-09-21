using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class VrstaTereta : IEntity
    {
        public long Id { get; set; }
        public string TipTereta { get; set; }
        public string OpisTereta { get; set; }
    }
}
