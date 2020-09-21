using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Zemljiste : IEntity
    {
        public long Id { get; set; }
        public string VrstaZemljista { get; set; }
    }
}
