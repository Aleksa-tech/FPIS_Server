using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Radnik : IEntity
    {
        public long Id { get; set; }
        public string ImeIPrezime { get; set; }
    }
}
