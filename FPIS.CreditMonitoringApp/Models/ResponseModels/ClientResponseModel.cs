using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPIS.CreditMonitoringApp.Models.ResponseModels
{
    public class ClientResponseModel
    {
        public string Message { get; set; }
        public object Error { get; set; }
    }
}
