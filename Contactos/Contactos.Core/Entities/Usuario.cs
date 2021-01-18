using System;
using System.Collections.Generic;

namespace Contactos.Core.Entities
{
    public partial class Usuario: BaseEntity
    {
        public Usuario()
        {
            Contacto = new HashSet<Contacto>();
        }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public int IdRol { get; set; }

        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual Rol IrolNavigation { get; set; }
        public virtual ICollection<Contacto> Contacto { get; set; }
    }
}
