using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities.AccountBalanceService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountBalanceService
{
    public class GetBalancesByAccountService : IGetBalancesByAccountService
    {
        private readonly IAccountBalanceRepository _accountBalanceRepository;

        public GetBalancesByAccountService(IAccountBalanceRepository accountBalanceRepository)
        {
            this._accountBalanceRepository = accountBalanceRepository;
        }

        public async Task<List<Stanje>> ReadBalancesByAccountAsync(long accountId)
        {
            IEnumerable<Stanje> entities = await _accountBalanceRepository.ReadBalancesByAccountAsync(accountId);

            return (List<Stanje>)entities;
        }
    }
}
