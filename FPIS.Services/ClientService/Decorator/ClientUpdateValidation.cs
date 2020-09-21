using FPIS.Entities;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.ClientService.Decorator
{
    public class ClientUpdateValidation : IUpdateService<Klijent>
    {
        private readonly IUpdateService<Klijent> _clientService;
        private readonly IValidationService<Klijent> _validation;

        public ClientUpdateValidation(IUpdateService<Klijent> clientService, IValidationService<Klijent> validation)
        {
            this._clientService = clientService;
            this._validation = validation;
        }

        public async Task<bool> UpdateAsync(Klijent entity)
        {
            var isValidEntity = _validation.IsValidEntity(entity);
            var isValidId = await _validation.IsValidId(entity.Id);

            //should be thrown error
            if (!isValidEntity || !isValidId)
                return false;

            return await _clientService.UpdateAsync(entity);
        }
    }
}
