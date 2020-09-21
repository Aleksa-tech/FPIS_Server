using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountService
{
    public class GetAccountByIdAndTypeService : IGetAccountByIdAndTypeService
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByIdAndTypeService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public async Task<Racun> GetByIdAndTypeAsync(long accId, string accType)
        {
            var account = await _accountRepository.GetByIdAndTypeAsync(accId, accType);

            return account;
        }
    }
}
