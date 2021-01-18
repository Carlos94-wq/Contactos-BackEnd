using System;
using System.Collections.Generic;

namespace Contactos.Core.Entities
{
    public partial class TipoCorreo
    {
        public TipoCorreo()
        {
            Correo = new HashSet<Correo>();
        }

        public int IdTipoCorreo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Correo> Correo { get; set; }
    }
}
