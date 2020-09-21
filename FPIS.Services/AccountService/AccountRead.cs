using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountService
{
    public class AccountRead : IReadService<Racun>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountRead(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public async Task<List<Racun>> GetAll()
        {
            IEnumerable<Racun> clients = await _accountRepository.GetAllAsync();

            return (List<Racun>)clients;
        }

        public async Task<Racun> GetById(long id)
        {
            Racun account = await _accountRepository.GetByIdAsync(id);

            return account;
        }
    }
}
