using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.ServiceEntities
{
    public interface IGetAccountByIdAndTypeService
    {
        Task<Racun> GetByIdAndTypeAsync(long accId, string accType);
    }
}
