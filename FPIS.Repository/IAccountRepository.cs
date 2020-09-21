using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Repository
{
    public interface IAccountRepository : IReadAllRepository<Racun>, IReadIdRepository<Racun>
    {
        Task<Racun> GetByIdAndTypeAsync(long accId, string accType);
    }
}
