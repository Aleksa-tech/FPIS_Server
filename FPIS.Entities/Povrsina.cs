using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Entities
{
    public class Povrsina : IEntity
    {
        public long Id { get; set; }
        public string NazivPovrsine { get; set; }
    }
}
