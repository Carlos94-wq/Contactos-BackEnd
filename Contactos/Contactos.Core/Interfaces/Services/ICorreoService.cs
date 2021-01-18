using Contactos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Core.Interfaces.Services
{
    public interface ICorreoService
    {
        IEnumerable<Correo> GetAll(int IdContacto);
        Task<Correo> GetById(int id);
        Task<bool> Add(List<Correo> telefonos);
        Task<bool> Update(Correo usuario);
        Task<bool> Delete(int id);
    }
}
