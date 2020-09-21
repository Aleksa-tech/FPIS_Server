using FPIS.Entities;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountBalanceService.Decorator
{
    public class AccountBalanceUpdateValidation : IUpdateService<Stanje>
    {
        private readonly IUpdateService<Stanje> _accountBalanceService;
        private readonly IValidationService<Stanje> _validation;

        public AccountBalanceUpdateValidation(IUpdateService<Stanje> accountBalanceService, IValidationService<Stanje> validation)
        {
            this._accountBalanceService = accountBalanceService;
            this._validation = validation;
        }

        public async Task<bool> UpdateAsync(Stanje entity)
        {
            var isValidEntity = _validation.IsValidEntity(entity);
            var isValidId = await _validation.IsValidId(entity.Id);

            //should be thrown error
            if (!isValidEntity || !isValidId)
                return false;

            return await _accountBalanceService.UpdateAsync(entity);
        }
    }
}
