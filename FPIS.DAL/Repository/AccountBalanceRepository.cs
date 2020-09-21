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
using System.Transactions;

namespace FPIS.DAL.Repository
{
    public class AccountBalanceRepository : BaseSqlRepository, IAccountBalanceRepository
    {
        private readonly AccountBalanceDbBroker _accountBalanceDbBroker;

        public AccountBalanceRepository(IOptions<DbSettings> dbSettings) : base(dbSettings)
        {
            _accountBalanceDbBroker = new AccountBalanceDbBroker();
        }


        public async Task<IEnumerable<Stanje>> GetAllAsync()
        {
            var result = default(IEnumerable<Stanje>);

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                result = await _accountBalanceDbBroker.GetAllAsync(conn, "[dbo].[ProcitajSvaStanja]", CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<Stanje> GetByIdAsync(long id)
        {
            var result = default(Stanje);

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                result = await _accountBalanceDbBroker.GetByIdAsync(id, conn, "[dbo].[ProcitajStanje]", CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<Stanje> InsertAsync(Stanje entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();
                    entity = await _accountBalanceDbBroker.InsertAsync(entity, conn, "[dbo].[UbaciStanje]", CommandType.StoredProcedure);
                }

                ts.Complete();
            }

            return entity;
        }

        public async Task<Stanje> UpdateAsync(Stanje entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();
                    entity = await _accountBalanceDbBroker.UpdateAsync(entity, conn, "[dbo].[IzmijeniStanje]", CommandType.StoredProcedure);
                }

                ts.Complete();
            }

            return entity;
        }

        public async Task DeleteAsync(long id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                await _accountBalanceDbBroker.DeleteAsync(id, conn, "[dbo].[ObrisiStanje]", CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Stanje>> ReadBalancesByAccountAsync(long accountId)
        {
            var result = default(IEnumerable<Stanje>);

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                result = await _accountBalanceDbBroker.ReadBalancesByAccountAsync(accountId, conn, "[dbo].[VratiStanjaRacuna]", CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
