using System;
using System.Collections.Generic;

namespace Contactos.Core.Entities
{
    public partial class Contacto: BaseEntity
    {
        public Contacto()
        {
            Correo = new HashSet<Correo>();
            Telefono = new HashSet<Telefono>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int EstadoCivil { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string CodigoP { get; set; }
        public string NumExt { get; set; }
        public string Provicnia { get; set; }

        public virtual Estatus Estatus { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Correo> Correo { get; set; }
        public virtual ICollection<Telefono> Telefono { get; set; }
    }
}
