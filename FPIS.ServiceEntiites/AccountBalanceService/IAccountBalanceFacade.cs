using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.ServiceEntities.AccountBalanceService
{
    public interface IAccountBalanceFacade : IReadService<Stanje>, IInsertService<Stanje>, IUpdateService<Stanje>, IDeleteService<Stanje>, IGetBalancesByAccountService
    {
    }
}
