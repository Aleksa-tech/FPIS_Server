using FPIS.Entities;
using FPIS.ServiceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Services.AccountService
{
    public class AccountServiceFacade : IAccountFacade
    {
        private readonly IReadService<Racun> _readService;
        private readonly IGetAccountByIdAndTypeService _getByIdAndTypeService;

        public AccountServiceFacade(IReadService<Racun> readService, IGetAccountByIdAndTypeService getByIdAndTypeService)
        {
            this._readService = readService;
            this._getByIdAndTypeService = getByIdAndTypeService;
        }

        public async Task<List<Racun>> GetAll()
        {
            return await _readService.GetAll();
        }

        public async Task<Racun> GetById(long id)
        {
            return await _readService.GetById(id);
        }

        public async Task<Racun> GetByIdAndTypeAsync(long accId, string accType)
        {
            return await _getByIdAndTypeService.GetByIdAndTypeAsync(accId, accType);
        }
    }
}
