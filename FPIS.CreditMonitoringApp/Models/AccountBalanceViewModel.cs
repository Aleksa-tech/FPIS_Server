using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPIS.CreditMonitoringApp.Models
{
    public class AccountBalanceViewModel
    {
        public List<string> AccountTypes { get; set; } = new List<string>();
        public Racun Account { get; set; }
        public List<Stanje> AccountBalances { get; set; }
        public Stanje AccountBalance { get; set; }
    }
}
