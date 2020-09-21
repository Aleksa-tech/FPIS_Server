using FluentValidation;
using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.ClientService
{
    public class ClientValidation : IValidationService<Klijent>
    {
        private readonly IClientRepository _clientRepository;
        private IValidator<Klijent> _validator;

        public ClientValidation(IClientRepository clientRepository, IValidator<Klijent> validator)
        {
            this._clientRepository = clientRepository;
            this._validator = validator;
        }

        public bool IsValidEntity(Klijent entity)
        {
            return _validator.Validate(entity).IsValid;
        }

        public async Task<bool> IsValidId(long id)
        {
            var entity = await _clientRepository.GetByIdAsync(id);

            return entity != null;
        }
    }
}
