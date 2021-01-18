using System;
using System.Collections.Generic;

namespace Contactos.Core.Entities
{
    public partial class TipoTelefono
    {
        public TipoTelefono()
        {
            Telefono = new HashSet<Telefono>();
        }

        public int IdTipoTelefono { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Telefono> Telefono { get; set; }
    }
}
