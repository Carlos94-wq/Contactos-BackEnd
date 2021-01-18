using System;
using System.Collections.Generic;

namespace Contactos.Core.Entities
{
    public partial class Correo: BaseEntity
    {
        public int IdContacto { get; set; }
        public string Email { get; set; }
        public int IdTipoCorreo { get; set; }
        public virtual Contacto IdContactoNavigation { get; set; }
        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual TipoCorreo IdTipoCorreoNavigation { get; set; }
    }
}
