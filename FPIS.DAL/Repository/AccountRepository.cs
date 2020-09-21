using FPIS.DAL.DataAccessBroker;
using FPIS.Entities;
using FPIS.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.DAL.Repository
{
    public class AccountRepository : BaseSqlRepository, IAccountRepository
    {
        private readonly AccountDbBroker _accountDbBroker;

        public AccountRepository(IOptions<DbSettings> dbSettings) : base(dbSettings)
        {
            _accountDbBroker = new AccountDbBroker();
        }

        public async Task<IEnumerable<Racun>> GetAllAsync()
        {
            var result = default(IEnumerable<Racun>);

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                result = await _accountDbBroker.GetAllAsync(conn, "[dbo].[ProcitajRacune]", CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<Racun> GetByIdAndTypeAsync(long accId, string accType)
        {
            var result = default(Racun);

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                result = await _accountDbBroker.GetByIdAndTypeAsync(accId, accType, conn, "[dbo].[NadjiRacunPoIdTip]", CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<Racun> GetByIdAsync(long id)
        {
            var result = default(Racun);

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                result = await _accountDbBroker.GetByIdAsync(id, conn, "[dbo].[ProcitajRacun]", CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
