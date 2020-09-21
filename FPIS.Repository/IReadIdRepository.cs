using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Repository
{
    public interface IReadIdRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(long id);
    }
}
