using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class PodaciOZemljistu : IEntity
    {
        public long Id { get; set; }
        public long BrojListaNepokretnosti { get; set; }
        public long BrojParceleZemljista { get; set; }
        public double PrihodOdZemljista { get; set; }
        public int BrojZgradaZemljista { get; set; }
        public long PovrsinaID { get; set; }
        public long ZemljisteID { get; set; }
    }
}
