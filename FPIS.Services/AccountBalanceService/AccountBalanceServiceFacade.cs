using FPIS.Entities;
using FPIS.ServiceEntities;
using FPIS.ServiceEntities.AccountBalanceService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountBalanceService
{
    public class AccountBalanceServiceFacade : IAccountBalanceFacade
    {
        private readonly IReadService<Stanje> _accountBalanceReadService;
        private readonly IInsertService<Stanje> _accountBalanceInsertService;
        private readonly IUpdateService<Stanje> _accountBalanceUpdateService;
        private readonly IDeleteService<Stanje> _accountBalanceDeleteService;
        private readonly IGetBalancesByAccountService _balancesByAccountService;

        public AccountBalanceServiceFacade(IReadService<Stanje> accountBalanceReadService,
                                           IInsertService<Stanje> accountBalanceInsertService,
                                           IUpdateService<Stanje> accountBalanceUpdateService,
                                           IDeleteService<Stanje> accountBalanceDeleteService,
                                           IGetBalancesByAccountService balancesByAccountService)
        {
            this._accountBalanceReadService = accountBalanceReadService;
            this._accountBalanceInsertService = accountBalanceInsertService;
            this._accountBalanceUpdateService = accountBalanceUpdateService;
            this._accountBalanceDeleteService = accountBalanceDeleteService;
            this._balancesByAccountService = balancesByAccountService;
        }

        public async Task DeleteAsync(long id)
        {
            await _accountBalanceDeleteService.DeleteAsync(id);
        }

        public async Task<List<Stanje>> GetAll()
        {
            return await _accountBalanceReadService.GetAll();
        }

        public async Task<Stanje> GetById(long id)
        {
            return await _accountBalanceReadService.GetById(id);
        }

        public async Task<bool> InsertAsync(Stanje entity)
        {
            return await _accountBalanceInsertService.InsertAsync(entity);
        }

        public async Task<List<Stanje>> ReadBalancesByAccountAsync(long accountId)
        {
            return await _balancesByAccountService.ReadBalancesByAccountAsync(accountId);       
        }

        public async Task<bool> UpdateAsync(Stanje entity)
        {
            return await _accountBalanceUpdateService.UpdateAsync(entity);
        }
    }
}
