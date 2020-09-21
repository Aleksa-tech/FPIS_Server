using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPIS.CreditMonitoringApp.Models.RequestModels
{
    public class ClientRequestModel
    {
        public string PIB { get; set; }
        public string AdresaISediste { get; set; }
        public string ImeIPrezimeKlijenta { get; set; }
        public string BrojRacuna { get; set; }
    }
}
