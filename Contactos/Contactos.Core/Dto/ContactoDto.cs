using System;
using System.Collections.Generic;
using System.Text;

namespace Contactos.Core.Dto
{
    public class ContactoDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int EstadoCivil { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string CodigoP { get; set; }
        public string NumExt { get; set; }
        public string Provicnia { get; set; }

        public int IdEstatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FeechaBaja { get; set; }
    }
}
