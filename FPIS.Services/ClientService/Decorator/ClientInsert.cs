using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.ClientService.Decorator
{
    public class ClientInsert : IInsertService<Klijent>
    {
        private readonly IClientRepository _clientRepository;

        public ClientInsert(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task<bool> InsertAsync(Klijent entity)
        {
            var client = await _clientRepository.InsertAsync(entity);

            return client != null;
        }
    }
}
