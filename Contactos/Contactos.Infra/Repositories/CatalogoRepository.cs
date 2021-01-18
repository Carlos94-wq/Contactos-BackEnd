using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Repositories;
using Contactos.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contactos.Infra.Repositories
{
    public class CatalogoRepository: ICatalogoRepository
    {
        private readonly DBCONTACTOSContext context;

        public CatalogoRepository( DBCONTACTOSContext context )
        {
            this.context = context;
        }

        public IEnumerable<Estatus> GetEstatus()
        {
            return this.context.Estatus.ToList();
        }

        public IEnumerable<Rol> GetRoles()
        {
            return this.context.Rol.ToList();
        }

        public IEnumerable<TipoCorreo> tipoCorreos()
        {
            return this.context.TipoCorreo.ToList();
        }

        public IEnumerable<TipoTelefono> tipoTelefonos()
        {
            return this.context.TipoTelefono.ToList();
        }
    }
}
