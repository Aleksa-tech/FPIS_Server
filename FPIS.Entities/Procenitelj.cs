using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Procenitelj : IEntity
    {
        public long Id { get; set; }
        public string ImeProcenitelja { get; set; }
        public string PrezimeProcenitelja { get; set; }
        public string FirmaProcenitelja { get; set; }
    }
}
