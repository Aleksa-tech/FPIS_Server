using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.DAL.DataAccessBroker
{
    public class AccountBalanceDbBroker : ReadWriteDbBroker<Stanje>
    {
        protected override void AddInsertParameters(SqlCommand cmd, Stanje entity)
        {
            cmd.Parameters.Add("@brojRacuna", SqlDbType.BigInt).Value = entity.BrojRacuna;
            cmd.Parameters.Add("@iznosStanja", SqlDbType.Float).Value = entity.IznosStanja;
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;
        }

        protected override void AddUpdateParameters(SqlCommand cmd, Stanje entity)
        {
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = entity.Id;
            cmd.Parameters.Add("@brojRacuna", SqlDbType.BigInt).Value = entity.BrojRacuna;
            cmd.Parameters.Add("@iznosStanja", SqlDbType.Float).Value = entity.IznosStanja;
        }

        protected override Stanje ReadEntity(SqlDataReader reader)
        {
            var accountBalance = new Stanje();
            accountBalance.Id = reader.GetInt64("Id");
            accountBalance.BrojRacuna = reader.GetInt64("BrojRacuna");
            accountBalance.IznosStanja = reader.GetDouble("IznosStanja");

            return accountBalance;
        }

        public async Task<IEnumerable<Stanje>> ReadBalancesByAccountAsync(long accountId, SqlConnection conn, string commandText, CommandType commandType)
        {
            var result = new List<Stanje>();
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.Add("@brojRacuna", SqlDbType.BigInt).Value = accountId;

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var entity = ReadEntity(reader);
                        result.Add(entity);
                    }
                }
            }

            return result;
        }
    }
}
