using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountBalanceService
{
    public class AccountBalanceDelete : IDeleteService<Stanje>
    {
        private readonly IAccountBalanceRepository _accountBalanceRepository;

        public AccountBalanceDelete(IAccountBalanceRepository accountBalanceRepository)
        {
            this._accountBalanceRepository = accountBalanceRepository;
        }

        public async Task DeleteAsync(long id)
        {
            await _accountBalanceRepository.DeleteAsync(id);
        }
    }
}
