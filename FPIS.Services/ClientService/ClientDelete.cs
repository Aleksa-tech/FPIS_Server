using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.ClientService
{
    public class ClientDelete : IDeleteService<Klijent>
    {
        private readonly IClientRepository _clientRepository;

        public ClientDelete(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task DeleteAsync(long id)
        {
            await _clientRepository.DeleteAsync(id);
        }
    }
}
