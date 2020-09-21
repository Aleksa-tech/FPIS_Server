using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.ServiceEntities
{
    public interface IReadService<T> where T : IEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(long id);
    }
}
