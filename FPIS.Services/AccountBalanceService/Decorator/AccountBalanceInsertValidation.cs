using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountBalanceService.Decorator
{
    public class AccountBalanceInsertValidation : IInsertService<Stanje>
    {
        private readonly IInsertService<Stanje> _insertService;
        private IValidationService<Stanje> _validation;

        public AccountBalanceInsertValidation(IInsertService<Stanje> insertService, IValidationService<Stanje> validation)
        {
            this._insertService = insertService;
            this._validation = validation;
        }

        public async Task<bool> InsertAsync(Stanje entity)
        {
            var isValidEntity = _validation.IsValidEntity(entity);

            //should be thrown error
            if (!isValidEntity)
                return false;

            return await _insertService.InsertAsync(entity);
        }
    }
}
