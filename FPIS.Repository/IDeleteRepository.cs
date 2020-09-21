using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.Repository
{
    public interface IDeleteRepository<T> where T : IEntity
    {
        Task DeleteAsync(long id);
    }
}
