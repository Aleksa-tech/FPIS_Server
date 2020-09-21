using FPIS.Entities;
using FPIS.ServiceEntities;
using FPIS.ServiceEntities.ClientService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.ClientService
{
    public class ClientServiceFacade : IClientFacade
    {
        private readonly IReadService<Klijent> _clientRead;
        private readonly IInsertService<Klijent> _clientInsert;
        private readonly IUpdateService<Klijent> _clientUpdate;
        private readonly IDeleteService<Klijent> _clientDelete;

        public ClientServiceFacade(IReadService<Klijent> clientRead, IInsertService<Klijent> clientInsert, IUpdateService<Klijent> clientUpdate, IDeleteService<Klijent> clientDelete)
        {
            this._clientRead = clientRead;
            this._clientInsert = clientInsert;
            this._clientUpdate = clientUpdate;
            this._clientDelete = clientDelete;
        }

        public async Task DeleteAsync(long id)
        {
            await _clientDelete.DeleteAsync(id);
        }

        public async Task<List<Klijent>> GetAll()
        {
            return await _clientRead.GetAll();
        }

        public async Task<Klijent> GetById(long id)
        {
            return await _clientRead.GetById(id);
        }

        public async Task<bool> InsertAsync(Klijent entity)
        {
            return await _clientInsert.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(Klijent entity)
        {
            return await _clientUpdate.UpdateAsync(entity);
        }
    }
}
