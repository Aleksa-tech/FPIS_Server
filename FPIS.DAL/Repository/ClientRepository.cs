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
    public class ClientRepository : BaseSqlRepository, IClientRepository
    {
        private readonly ClientDbBroker _clientDbBroker;

        public ClientRepository(IOptions<DbSettings> dbSettings) : base(dbSettings)
        {
            _clientDbBroker = new ClientDbBroker();
        }
        

        public async Task<IEnumerable<Klijent>> GetAllAsync()
        {
            var result = default(IEnumerable<Klijent>);

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                result = await _clientDbBroker.GetAllAsync(conn, "[dbo].[VratiKlijente]", CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<Klijent> GetByIdAsync(long id)
        {
            var result = default(Klijent);

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                result = await _clientDbBroker.GetByIdAsync(id, conn, "[dbo].[VratiKlijenta]", CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<Klijent> InsertAsync(Klijent entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();
                    entity = await _clientDbBroker.InsertAsync(entity, conn, "[dbo].[UbaciKlijenta]", CommandType.StoredProcedure);
                }

                ts.Complete();
            }

            return entity;
        }

        public async Task<Klijent> UpdateAsync(Klijent entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();
                    entity = await _clientDbBroker.UpdateAsync(entity, conn, "[dbo].[IzmijeniKlijenta]", CommandType.StoredProcedure);
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
                await _clientDbBroker.DeleteAsync(id, conn, "[dbo].[ObrisiKlijenta]", CommandType.StoredProcedure);
            }
        }
    }
}
