using Contactos.Core.Entities;
using Contactos.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Core.Interfaces.Services
{
    public interface IContactoService
    {
        IEnumerable<Contacto> GetAll(ContactoQueryFilters filters);
        Task<Contacto> GetById(int id);
        Task<bool> Add(Contacto usuario);
        Task<bool> Update(Contacto usuario);
        Task<bool> Delete(int id);
    }
}
