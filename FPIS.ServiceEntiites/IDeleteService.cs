using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.ServiceEntities
{
    public interface IDeleteService<T> where T : IEntity 
    {
        Task DeleteAsync(long id);
    }
}
