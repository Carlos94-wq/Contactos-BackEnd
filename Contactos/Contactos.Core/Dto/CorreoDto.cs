using System;
using System.Collections.Generic;
using System.Text;

namespace Contactos.Core.Dto
{
    public class CorreoDto
    {
        public int Id { get; set; }
        public int IdContacto { get; set; }
        public string Email { get; set; }
        public int IdTipoCorreo { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FeechaBaja { get; set; }
    }
}
