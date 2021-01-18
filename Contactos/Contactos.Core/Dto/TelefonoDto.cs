using System;
using System.Collections.Generic;
using System.Text;

namespace Contactos.Core.Dto
{
    public class TelefonoDto
    {
        public int Id { get; set; }
        public int IdContacto { get; set; }
        public string Numero { get; set; }
        public int IdTipoTelefono { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FeechaBaja { get; set; }
    }
}
