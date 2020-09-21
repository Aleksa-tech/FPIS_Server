using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.ServiceEntities.ClientService
{
    public interface IClientFacade : IReadService<Klijent>, IInsertService<Klijent>, IUpdateService<Klijent>, IDeleteService<Klijent>
    {
    }
}
