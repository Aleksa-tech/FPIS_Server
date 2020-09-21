using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.DAL.Repository
{
    public abstract class BaseSqlRepository
    {
        public string ConnectionString { get; }

        public BaseSqlRepository(IOptions<DbSettings> dbSettings)
        {
            ConnectionString = dbSettings.Value.ConnectionString;
        }
    }
}
