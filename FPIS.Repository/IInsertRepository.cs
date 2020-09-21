using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Repository
{
    public interface IInsertRepository<T> where T : IEntity
    {
        Task<T> InsertAsync(T entity);
    }
}
