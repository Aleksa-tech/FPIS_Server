using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.ServiceEntities
{
    public interface IAccountFacade : IReadService<Racun>, IGetAccountByIdAndTypeService
    {

    }
}
