using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.DAL.DataAccessBroker
{
    public class AccountDbBroker : ReadDbBroker<Racun>
    {
        protected override Racun ReadEntity(SqlDataReader reader)
        {
            var account = new Racun();
            account.Id = reader.GetInt64("Id");
            account.TipRacuna = reader.GetString("TipRacuna");

            return account;
        }

        public async Task<Racun> GetByIdAndTypeAsync(long accId, string accType, SqlConnection conn, string commandText, CommandType commandType)
        {
            var entity = default(Racun);
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = accId;
                cmd.Parameters.Add("@accType", SqlDbType.VarChar, 10).Value = accType;

                await cmd.ExecuteNonQueryAsync();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        entity = ReadEntity(reader);
                    }
                }
            }

            return entity;
        }
    }
}
