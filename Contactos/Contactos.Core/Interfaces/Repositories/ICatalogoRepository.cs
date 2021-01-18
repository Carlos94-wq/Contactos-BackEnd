using Contactos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contactos.Core.Interfaces.Repositories
{
    public interface ICatalogoRepository
    {
        IEnumerable<Estatus> GetEstatus();
        IEnumerable<Rol> GetRoles();
        IEnumerable<TipoCorreo> tipoCorreos();
        IEnumerable<TipoTelefono> tipoTelefonos();
    }
}
