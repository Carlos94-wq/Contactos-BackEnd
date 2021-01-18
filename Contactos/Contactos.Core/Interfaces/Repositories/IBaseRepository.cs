using Contactos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
