using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.DAL.DataAccessBroker
{
    public abstract class ReadDbBroker<T> where T : IEntity
    {
        protected abstract T ReadEntity(SqlDataReader reader);

        public virtual async Task<IEnumerable<T>> GetAllAsync(SqlConnection conn, string commandText, CommandType commandType)
        {
            var entityCollection = new List<T>();
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var entity = ReadEntity(reader);
                        entityCollection.Add(entity);
                    }
                }
            }

            return entityCollection;
        }

        public virtual async Task<T> GetByIdAsync(long id, SqlConnection conn, string commandText, CommandType commandType)
        {
            var entity = default(T);
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
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
