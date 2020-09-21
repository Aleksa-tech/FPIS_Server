using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class PodaciOTeretimaIOgranicenjima : IEntity
    {
        public long Id { get; set; }
        public long BrojListaNepokretnosti { get; set; }
        public long BrojParceleTereta { get; set; }
        public string NacinKoriscenjaTereta { get; set; }
        public int BrojPosebDelaTereta { get; set; }
        public int BrojUlazaTereta { get; set; }
        public int BrojZgradaTereta { get; set; }
    }
}
