using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Repository
{
    public interface IClientRepository : IReadAllRepository<Klijent>, IReadIdRepository<Klijent>, IInsertRepository<Klijent>, IUpdateRepository<Klijent>, IDeleteRepository<Klijent>
    {

    }
}
