using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountBalanceService
{
    public class AccountBalanceRead : IReadService<Stanje>
    {
        private readonly IAccountBalanceRepository _accountBalanceRepository;

        public AccountBalanceRead(IAccountBalanceRepository accountBalanceRepository)
        {
            this._accountBalanceRepository = accountBalanceRepository;
        }

        public async Task<List<Stanje>> GetAll()
        {
            IEnumerable<Stanje> entities = await _accountBalanceRepository.GetAllAsync();

            return (List<Stanje>)entities;
        }

        public async Task<Stanje> GetById(long id)
        {
            Stanje accountBalance = await _accountBalanceRepository.GetByIdAsync(id);

            return accountBalance;
        }

        public async Task<IEnumerable<Stanje>> ReadBalancesByAccountAsync(long accountId)
        {
            IEnumerable<Stanje> entities = await _accountBalanceRepository.ReadBalancesByAccountAsync(accountId);

            return entities;
        }
    }
}
