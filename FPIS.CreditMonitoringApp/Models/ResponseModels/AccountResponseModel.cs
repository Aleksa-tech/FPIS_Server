using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPIS.CreditMonitoringApp.Models.ResponseModels
{
    public class AccountResponseModel
    {
        public string Message { get; set; }
        public object Error { get; set; }
        public List<Racun> Accounts { get; set; }
    }
}
