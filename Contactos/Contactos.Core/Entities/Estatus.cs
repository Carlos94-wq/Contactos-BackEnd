using System;
using System.Collections.Generic;

namespace Contactos.Core.Entities
{
    public partial class Estatus
    {
        public Estatus()
        {
            Contacto = new HashSet<Contacto>();
            Correo = new HashSet<Correo>();
            Telefono = new HashSet<Telefono>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdEstatus { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Contacto> Contacto { get; set; }
        public virtual ICollection<Correo> Correo { get; set; }
        public virtual ICollection<Telefono> Telefono { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
