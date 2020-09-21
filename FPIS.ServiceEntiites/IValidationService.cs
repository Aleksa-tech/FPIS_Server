using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPIS.ServiceEntities
{
    public interface IValidationService<T> where T : IEntity
    {
        Task<bool> IsValidId(long id);
        bool IsValidEntity(T entity);
    }
}
