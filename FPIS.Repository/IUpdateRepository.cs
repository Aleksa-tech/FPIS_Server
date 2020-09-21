using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Repository
{
    public interface IUpdateRepository<T> where T : IEntity
    {
        Task<T> UpdateAsync(T entity);
    }
}
