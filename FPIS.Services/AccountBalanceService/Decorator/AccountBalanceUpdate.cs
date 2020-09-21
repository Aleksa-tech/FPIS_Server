using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountBalanceService.Decorator
{
    public class AccountBalanceUpdate : IUpdateService<Stanje>
    {
        private readonly IAccountBalanceRepository _accountBalanceRepository;

        public AccountBalanceUpdate(IAccountBalanceRepository accountBalanceRepository)
        {
            this._accountBalanceRepository = accountBalanceRepository;
        }

        public async Task<bool> UpdateAsync(Stanje entity)
        {
            return await _accountBalanceRepository.UpdateAsync(entity) != null;
        }
    }
}
