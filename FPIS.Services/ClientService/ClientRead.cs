using FPIS.Entities;
using FPIS.Repository;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.ClientService
{
    public class ClientRead : IReadService<Klijent>
    {
        private readonly IClientRepository _clientRepository;

        public ClientRead(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task<List<Klijent>> GetAll()
        {
            IEnumerable<Klijent> clients = await _clientRepository.GetAllAsync();

            return (List<Klijent>)clients;
        }

        public async Task<Klijent> GetById(long id)
        {
            Klijent client = await _clientRepository.GetByIdAsync(id);

            return client;
        }
    }
}
