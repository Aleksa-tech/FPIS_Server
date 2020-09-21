using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Repository
{
    public interface IAccountBalanceRepository : IReadAllRepository<Stanje>, IReadIdRepository<Stanje>, IInsertRepository<Stanje>, IUpdateRepository<Stanje>, IDeleteRepository<Stanje>
    {
        Task<IEnumerable<Stanje>> ReadBalancesByAccountAsync(long accountId);
    }
}
