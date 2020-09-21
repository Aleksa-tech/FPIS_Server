using FluentValidation;
using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountBalanceService
{
    public class AccountBalanceValidation : IValidationService<Stanje>
    {
        private readonly IAccountBalanceRepository _accountBalanceRepository;
        private IValidator<Stanje> _validator;

        public AccountBalanceValidation(IAccountBalanceRepository accountBalanceRepository, IValidator<Stanje> validator)
        {
            this._accountBalanceRepository = accountBalanceRepository;
            this._validator = validator;
        }

        public bool IsValidEntity(Stanje entity)
        {
            return _validator.Validate(entity).IsValid;
        }

        public async Task<bool> IsValidId(long id)
        {
            var entity = await _accountBalanceRepository.GetByIdAsync(id);

            return entity != null;
        }
    }
}
