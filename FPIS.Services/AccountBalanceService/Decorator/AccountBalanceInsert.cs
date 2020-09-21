using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountBalanceService.Decorator
{
    public class AccountBalanceInsert : IInsertService<Stanje>
    {
        private readonly IAccountBalanceRepository _accountBalanceRepository;

        public AccountBalanceInsert(IAccountBalanceRepository accountBalanceRepository)
        {
            this._accountBalanceRepository = accountBalanceRepository;
        }

        public async Task<bool> InsertAsync(Stanje entity)
        {
            var accountBalance = await _accountBalanceRepository.InsertAsync(entity);

            return accountBalance != null;
        }
    }
}
