using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.ClientService.Decorator
{
    public class ClientUpdate : IUpdateService<Klijent>
    {
        private readonly IClientRepository _clientRepository;

        public ClientUpdate(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task<bool> UpdateAsync(Klijent entity)
        {
            return await _clientRepository.UpdateAsync(entity) != null;
        }
    }
}
