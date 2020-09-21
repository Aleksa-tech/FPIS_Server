using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class PodaciOZgradama : IEntity
    {
        public long Id { get; set; }
        public long BrojListaNepokretnosti { get; set; }
        public long BrojParceleZg { get; set; }
        public double ObimUdelaZgrade { get; set; }
        public int BrojZgrada { get; set; }
        public string OblikSvojineZgrada { get; set; }
        public string AdresaZgrada { get; set; }
    }
}
