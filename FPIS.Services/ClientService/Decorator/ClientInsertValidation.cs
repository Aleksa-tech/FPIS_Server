using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.ClientService.Decorator
{
    public class ClientInsertValidation : IInsertService<Klijent>
    {
        private readonly IInsertService<Klijent> _clientService;
        private IValidationService<Klijent> _validation;

        public ClientInsertValidation(IInsertService<Klijent> clientService, IValidationService<Klijent> validation)
        {
            this._clientService = clientService;
            this._validation = validation;
        }

        public async Task<bool> InsertAsync(Klijent entity)
        {
            var isValidEntity = _validation.IsValidEntity(entity);

            //should be thrown error
            if (!isValidEntity)
                return false;

            return await _clientService.InsertAsync(entity);
        }
    }
}
