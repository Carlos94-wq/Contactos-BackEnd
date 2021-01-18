using Contactos.Core.CustonEntities;
using Contactos.Core.Entities;
using Contactos.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Core.Interfaces.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll( UsuarioQueryFilters filters);
        Task<Usuario> GetById(int id);
        Task<bool> Add(Usuario usuario);
        Task<bool> Update(Usuario usuario);
        Task<bool> Delete(int id);
    }
}
