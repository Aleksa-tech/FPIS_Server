using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Repository
{
    public interface IReadAllRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
