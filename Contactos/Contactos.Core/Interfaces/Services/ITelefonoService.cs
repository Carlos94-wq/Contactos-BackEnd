using Contactos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Core.Interfaces.Services
{
    public interface ITelefonoService
    {
        IEnumerable<Telefono> GetAll(int IdContacto);
        Task<Telefono> GetById(int id);
        Task<bool> Add(List<Telefono> telefonos);
        Task<bool> Update(Telefono usuario);
        Task<bool> Delete(int id);
    }
}
