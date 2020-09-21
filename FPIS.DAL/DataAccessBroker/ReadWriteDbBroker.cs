using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.DAL.DataAccessBroker
{
    public abstract class ReadWriteDbBroker<T> : ReadDbBroker<T> where T : IEntity
    {
        protected abstract void AddInsertParameters(SqlCommand cmd, T entity);
        protected abstract void AddUpdateParameters(SqlCommand cmd, T entity);

        public virtual async Task<T> InsertAsync(T entity, SqlConnection conn, string commandText, CommandType commandType)
        {
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                AddInsertParameters(cmd, entity);
                await cmd.ExecuteNonQueryAsync();
                entity.Id = GetIdFromParameter(cmd);
            }

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity, SqlConnection conn, string commandText, CommandType commandType)
        {
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                AddUpdateParameters(cmd, entity);
                await cmd.ExecuteNonQueryAsync();
            }

            return entity;
        }

        public virtual async Task DeleteAsync(long id, SqlConnection conn, string commandText, CommandType commandType)
        {
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                await cmd.ExecuteNonQueryAsync();
            }
        }

        protected virtual long GetIdFromParameter(SqlCommand cmd)
        {
            return (long)cmd.Parameters["@id"].Value;
        }
    }
}
