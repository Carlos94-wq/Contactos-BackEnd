using System;
using System.Collections.Generic;

namespace Contactos.Core.Entities
{
    public partial class Telefono: BaseEntity
    {
        public int IdContacto { get; set; }
        public string Numero { get; set; }
        public int IdTipoTelefono { get; set; }

        public virtual Contacto IdContactoNavigation { get; set; }
        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual TipoTelefono IdTipoTelefonoNavigation { get; set; }
    }
}
